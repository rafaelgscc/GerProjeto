using System;
using System.Collections;
using System.ComponentModel;
using System.Web;
using System.Web.SessionState;
using System.Reflection;
using System.Resources;
using System.Globalization;
using System.Collections.Specialized;
using System.IO;
using System.IO.Compression;
using System.Web.UI;
using COMPONENTS;
using System.Web.Routing;

namespace PROJETO
{

	public partial class Global : System.Web.HttpApplication
	{

        partial void ApplicationStartExtension();
        partial void RegisterRoutesExtension(RouteCollection routes);
        partial void SessionStartExtension();
        partial void ApplicationBeginRequestExtension();
        partial void ApplicationEndRequestExtension();
        partial void SessionEndExtension();
        partial void ApplicationEndExtension();

		protected void Application_Start(Object sender, EventArgs e)
		{
			LoadApplicationSettings();
			ApplicationStartExtension();
		}

		protected string GetFileHash(string fileName)
		{
			FileStream file = new FileStream(fileName, FileMode.Open);
			System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
			byte[] retVal = md5.ComputeHash(file);
			file.Close();

			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			for (int i = 0; i < retVal.Length; i++)
			{
				sb.Append(retVal[i].ToString("x2"));
			}
			return sb.ToString();
		}

		private void LoadApplicationSettings()
		{
			string ConfigFile = Server.MapPath("~/App_Data/App.Config");
			string CurrentHash = GetFileHash(ConfigFile);
			
			// não vamos recarregar as configurações...
			if (Application["ConfigFileHash"] != null && Application["ConfigFileHash"].Equals(CurrentHash)) return;

			Application["Databases"] = new Databases(ConfigFile);
			Application["_locales"] = System.Configuration.ConfigurationManager.GetSection("locales");
			HttpContext.Current.Cache.Insert("__InvalidateAllPages", DateTime.Now, null,
											System.DateTime.MaxValue, System.TimeSpan.Zero,
											System.Web.Caching.CacheItemPriority.NotRemovable,
											null);
			Application["culture"] = Utility.siteLanguage;
		}
		protected void Application_BeginRequest(Object sender, EventArgs e)
		{
			if (Application[Request.PhysicalPath] != null)
				Request.ContentEncoding = System.Text.Encoding.GetEncoding(Application[Request.PhysicalPath].ToString());
			ApplicationBeginRequestExtension();
		}

		protected void Application_EndRequest(Object sender, EventArgs e)
		{
			ApplicationEndRequestExtension();
		}

		protected void Session_End(Object sender, EventArgs e)
		{
			SessionEndExtension();
		}

		protected void Application_End(Object sender, EventArgs e)
		{
			ApplicationEndExtension();
		}

		void Application_Error(object sender, EventArgs e)
		{
			if (Context != null)
			{
			    HttpException CurrentException = Server.GetLastError() as HttpException;
			    if (CurrentException != null)
			    {
                    int ErrorCode = 0;
                    string ErrorMessage = "";
                    if ((CurrentException).InnerException != null)
                    {
                        ErrorMessage = (CurrentException).InnerException.Message.Replace("\n", "<br>");;
                    }
                    else 
                    {
                        ErrorCode = CurrentException.GetHttpCode();
                        ErrorMessage = CurrentException.Message.Replace("\n", "<br>");;
                    }
					Server.ClearError();
					if(!Response.IsRequestBeingRedirected)
						Response.Redirect("~/Pages/BlankPage.aspx?errorCode=" + ErrorCode + "&errorMessage=" + ErrorMessage);
			    }
			}
		}

	}

}
