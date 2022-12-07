using System;
using System.Collections;
using System.ComponentModel;
using System.Web;
using System.IO;
using System.Text;
using System.Web.SessionState;
using System.Resources;
using System.Globalization;
using System.Web.UI.WebControls;
using System.Collections.Specialized;
using System.Text.RegularExpressions;
using COMPONENTS;
using COMPONENTS.Data;
using COMPONENTS.Configuration;
using System.Web.Security;
using System.Configuration;
using System.Web.UI;
using System.Data;
using PROJETO.DataProviders;
using System.Collections.Generic;

namespace PROJETO
{
	public static class EnvironmentVariable
    {

        public static string LoggedIdUser
        {
            get
            {
				try
				{
					return Crypt.Decripta(HttpContext.Current.Session[GMembershipProvider.Default.UserIdSessionVariable].ToString());
				}
				catch
				{
					return "";
				}
            }
        }

        public static string LoggedLoginUser
        {
            get
            {
                try
				{

					return Crypt.Decripta(HttpContext.Current.Session[GMembershipProvider.Default.UserLoginSessionVariable].ToString());
				}
				catch
				{
					return "";
				}
            }
        }

        public static string LoggedNameUser
        {
            get
            {
                try
				{
					return Crypt.Decripta(HttpContext.Current.Session[GMembershipProvider.Default.UserNameSessionVariable].ToString());
				}
				catch
				{
					return "";
				}
            }
        }

        public static string LoggedObsUser
        {
            get
            {
                try
				{
					return Crypt.Decripta(HttpContext.Current.Session[GMembershipProvider.Default.UserObsSessionVariable].ToString());
				}
				catch
				{
					return "";
				}
            }
        }

        public static string LoggedIdGroup
        {
            get
            {
                try
				{
					return Crypt.Decripta(HttpContext.Current.Session[GMembershipProvider.Default.GroupIdSessionVariable].ToString());
				}
				catch
				{
					return "";
				}
            }
        }

        public static string LoggedNameGroup
        {
            get
            {
                try
				{
					return Crypt.Decripta(HttpContext.Current.Session[GMembershipProvider.Default.GroupNameSessionVariable].ToString());
				}
				catch
				{
					return "";
				}
            }
        }
        
        public static string LoggedIsAdminGroup
        {
            get
            {
                try
				{
					return HttpContext.Current.Session[GMembershipProvider.Default.GroupIsAdminSessionVariable].ToString();
				}
				catch
				{
					return "";
				}
            }
        }
        public static string CompanyName
        {
            get
            {
                return ConfigurationManager.AppSettings["CompanyName"];
            }
        }

        public static string DeveloperName
        {
            get
            {
                return ConfigurationManager.AppSettings["DeveloperName"];
            }
        }

        public static string ProjectVersion
        {
            get
            {
                return ConfigurationManager.AppSettings["ProjectVersion"];
            }
        }

        public static string ProjectCopyright
        {
            get
            {
                return ConfigurationManager.AppSettings["ProjectCopyright"];
            }
        }

		public static DateTime ActualDate
        {
            get
            {
                return System.DateTime.Today;
            }
        }

		public static DateTime ActualDateTime
        {
            get
            {
                return System.DateTime.Now;
            }
        }

		public static int ActualDay
		{
			get
			{
				return System.DateTime.Now.Day;
			}
		}

		public static int ActualMonth
		{
			get
			{
				return System.DateTime.Now.Month;
			}
		}

		public static int ActualYear
		{
			get
			{
				return System.DateTime.Now.Year;
			}
		}

		public static string ActualTime
        {
            get
            {
                return System.DateTime.Now.ToLongTimeString();
            }
        }
		
		public static class DBGERPROJETO 
		{
			public static class TB_PARAMETRO 
			{
				public static string HDEmail
				{
					get
					{
						DataAccessObject Dao = null;
						if (HttpContext.Current.Session["AllDaos"] != null)
						{
							if ((((Dictionary<string, COMPONENTS.Data.DataAccessObject>)(HttpContext.Current.Session["AllDaos"]))).ContainsKey("DBGERPROJETO"))
							{
								Dao = (((Dictionary<string, COMPONENTS.Data.DataAccessObject>)(HttpContext.Current.Session["AllDaos"])))["DBGERPROJETO"];
							}
						}
						if (Dao == null)  Dao = Utility.GetDAO("DBGERPROJETO");
							return Dao.RunSql("SELECT TOP 1  " +  Dao.PoeColAspas("HDEmail") + "  FROM " +  Dao.PoeColAspas("TB_PARAMETRO")).Tables[0].Rows[0][0].ToString();
					}
				}
				public static string HDNome
				{
					get
					{
						DataAccessObject Dao = null;
						if (HttpContext.Current.Session["AllDaos"] != null)
						{
							if ((((Dictionary<string, COMPONENTS.Data.DataAccessObject>)(HttpContext.Current.Session["AllDaos"]))).ContainsKey("DBGERPROJETO"))
							{
								Dao = (((Dictionary<string, COMPONENTS.Data.DataAccessObject>)(HttpContext.Current.Session["AllDaos"])))["DBGERPROJETO"];
							}
						}
						if (Dao == null)  Dao = Utility.GetDAO("DBGERPROJETO");
							return Dao.RunSql("SELECT TOP 1  " +  Dao.PoeColAspas("HDNome") + "  FROM " +  Dao.PoeColAspas("TB_PARAMETRO")).Tables[0].Rows[0][0].ToString();
					}
				}
				public static long HDPorta
				{
					get
					{
						DataAccessObject Dao = null;
						if (HttpContext.Current.Session["AllDaos"] != null)
						{
							if ((((Dictionary<string, COMPONENTS.Data.DataAccessObject>)(HttpContext.Current.Session["AllDaos"]))).ContainsKey("DBGERPROJETO"))
							{
								Dao = (((Dictionary<string, COMPONENTS.Data.DataAccessObject>)(HttpContext.Current.Session["AllDaos"])))["DBGERPROJETO"];
							}
						}
						if (Dao == null)  Dao = Utility.GetDAO("DBGERPROJETO");
							return Convert.ToInt64(Dao.RunSql("SELECT TOP 1  " +  Dao.PoeColAspas("HDPorta") + "  FROM " +  Dao.PoeColAspas("TB_PARAMETRO")).Tables[0].Rows[0][0]);
					}
				}
				public static string HDSMTP
				{
					get
					{
						DataAccessObject Dao = null;
						if (HttpContext.Current.Session["AllDaos"] != null)
						{
							if ((((Dictionary<string, COMPONENTS.Data.DataAccessObject>)(HttpContext.Current.Session["AllDaos"]))).ContainsKey("DBGERPROJETO"))
							{
								Dao = (((Dictionary<string, COMPONENTS.Data.DataAccessObject>)(HttpContext.Current.Session["AllDaos"])))["DBGERPROJETO"];
							}
						}
						if (Dao == null)  Dao = Utility.GetDAO("DBGERPROJETO");
							return Dao.RunSql("SELECT TOP 1  " +  Dao.PoeColAspas("HDSMTP") + "  FROM " +  Dao.PoeColAspas("TB_PARAMETRO")).Tables[0].Rows[0][0].ToString();
					}
				}
				public static string HDSSL
				{
					get
					{
						DataAccessObject Dao = null;
						if (HttpContext.Current.Session["AllDaos"] != null)
						{
							if ((((Dictionary<string, COMPONENTS.Data.DataAccessObject>)(HttpContext.Current.Session["AllDaos"]))).ContainsKey("DBGERPROJETO"))
							{
								Dao = (((Dictionary<string, COMPONENTS.Data.DataAccessObject>)(HttpContext.Current.Session["AllDaos"])))["DBGERPROJETO"];
							}
						}
						if (Dao == null)  Dao = Utility.GetDAO("DBGERPROJETO");
							return Dao.RunSql("SELECT TOP 1  " +  Dao.PoeColAspas("HDSSL") + "  FROM " +  Dao.PoeColAspas("TB_PARAMETRO")).Tables[0].Rows[0][0].ToString();
					}
				}
				public static long HDExpiraSenha
				{
					get
					{
						DataAccessObject Dao = null;
						if (HttpContext.Current.Session["AllDaos"] != null)
						{
							if ((((Dictionary<string, COMPONENTS.Data.DataAccessObject>)(HttpContext.Current.Session["AllDaos"]))).ContainsKey("DBGERPROJETO"))
							{
								Dao = (((Dictionary<string, COMPONENTS.Data.DataAccessObject>)(HttpContext.Current.Session["AllDaos"])))["DBGERPROJETO"];
							}
						}
						if (Dao == null)  Dao = Utility.GetDAO("DBGERPROJETO");
							return Convert.ToInt64(Dao.RunSql("SELECT TOP 1  " +  Dao.PoeColAspas("HDExpiraSenha") + "  FROM " +  Dao.PoeColAspas("TB_PARAMETRO")).Tables[0].Rows[0][0]);
					}
				}
				public static DateTime HD_Atualizacao
				{
					get
					{
						DataAccessObject Dao = null;
						if (HttpContext.Current.Session["AllDaos"] != null)
						{
							if ((((Dictionary<string, COMPONENTS.Data.DataAccessObject>)(HttpContext.Current.Session["AllDaos"]))).ContainsKey("DBGERPROJETO"))
							{
								Dao = (((Dictionary<string, COMPONENTS.Data.DataAccessObject>)(HttpContext.Current.Session["AllDaos"])))["DBGERPROJETO"];
							}
						}
						if (Dao == null)  Dao = Utility.GetDAO("DBGERPROJETO");
							return Convert.ToDateTime(Dao.RunSql("SELECT TOP 1  " +  Dao.PoeColAspas("HD_Atualizacao") + "  FROM " +  Dao.PoeColAspas("TB_PARAMETRO")).Tables[0].Rows[0][0]);
					}
				}
			}
		}

    }
}
