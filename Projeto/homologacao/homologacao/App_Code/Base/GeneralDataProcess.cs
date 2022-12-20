using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Web;
using System.IO;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.Security;
using System.Text.RegularExpressions;
using System.Globalization;
using PROJETO;
using COMPONENTS;
using COMPONENTS.Data;
using COMPONENTS.Configuration;
using COMPONENTS.Security;
using System.Resources;
using PROJETO.DataProviders;
using System.IO.Compression;
using System.Text;
using System.Collections.Generic;
using System.Reflection;
using Telerik.Web.UI;

namespace PROJETO.DataPages
{
	public abstract class GeneralDataProcess : Page, IGeneralDataProvider
	{
		private RadLabel _ErrorLabel;
		public RadLabel ErrorLabel
		{
			get
			{
				return _ErrorLabel;
			}
			set
			{
				_ErrorLabel = value;
			}
		}

		/// <summary>
		/// Mostra os erros que aconteceram no acesso ao banco ou pelo menos em tentativas de acesso
		/// </summary>
		protected virtual void ShowErrors(NameValueCollection ValidationErrors)
		{
			string DefaultMessage = "";
			for (int i = 0; i < ValidationErrors.Count; i++)
			{
				switch (ValidationErrors.AllKeys[i])
				{
					default:
						if (DefaultMessage != "") DefaultMessage += "<br>";
						DefaultMessage += ValidationErrors[i];
						break;
				}
			}
			if (ErrorLabel != null)
			{
				ErrorLabel.Visible = true;
				ErrorLabel.Text = DefaultMessage;
			}
			else
			{
				RadAjaxPanel ajaxPanel = null; 
				foreach (Control c in Controls)
				{
					if(c is RadAjaxPanel)
					{
						ajaxPanel = (RadAjaxPanel)c;
					}
				}
				if (ajaxPanel != null)
				{
					if (!string.IsNullOrEmpty(DefaultMessage) && DefaultMessage != "\"\"")
					{
						ajaxPanel.ResponseScripts.Add("alert('{0}');");
					}
				}
				else
				{
					ClientScript.RegisterStartupScript(GetType(), "Alert", String.Format("<script>alert('{0}');</script>", DefaultMessage.Replace("'", "").Replace("\r\n", "\\n")));
				}
			}
		}

		private GeneralDataProvider _DataProvider;
		public GeneralDataProvider DataProvider
		{
			get { return _DataProvider; }
			set { _DataProvider = value; }
		}

		protected ResourceManager RM;
		protected FormSupportedOperations PageOperations;

		public abstract string FormID { get; }
		public abstract string PageName { get; }

		public abstract void CreateProvider();
        
		public virtual bool AuthenticationRequired { get { return true; } }

		public virtual HtmlGenericControl PageHolder { get { return null; } }

		private Hashtable _OldParameters;
		public Hashtable OldParameters
		{
			get
			{
				return _OldParameters;
			}
			set
			{
				_OldParameters = value;
			}
		}
		
		public virtual void FillComboBoxes()
		{
		}

		public virtual void DefineAttributes()
		{
		}

		public virtual void ExecuteServerCommandRequest(string CommandName, string TargetName, string[] Parameters)
		{
		}

		/// <summary>
		/// Coloca m??scara nos campos da p??gina
		/// </summary>
		public virtual void DefineMask()
		{
		}

		/// <summary>
		/// Mostra os erros que aconteceram no acesso ao banco ou pelo menos em tentativas de acesso
		/// </summary>
		
		/// <summary>
		/// Limpa todos os campos para inserir outro ou algo do genero
		/// </summary>
		public virtual void ClearFields()
		{
		}

		public virtual void InitializeAlias(GeneralDataProviderItem Item)
		{
		}

		/// <summary>
		/// Carrega em um item os campos que foram escrito na tela
		/// </summary>
		/// <param name="item">item a ser preenchido</param>
		/// <param name="EnableValidation">se aceita valida??ao ou nao</param>

		public void FillAuxiliarTables()
		{
			if (DataProvider != null && DataProvider.PageProvider != null)
			{
				DataProvider.PageProvider.FillAuxiliarTables();
			}
		}

		public GeneralDataProviderItem GetCurrentItem(FormPositioningEnum Positioning, bool UpdateFromUI)
		{
			return null;
		}
		
		public void OnSelectedItem(GeneralDataProvider Provider, GeneralDataProviderItem Item, bool UpdateFromUI)
		{
			if (Provider == DataProvider)
			{
				InitializeAlias(Item);
				FillAuxiliarTables();
				ShowFormulas();
			}
		}
		
		public virtual void SetParametersValues(GeneralDataProvider Provider)
		{
		}

		public virtual void ShowFormulas()
		{
		}

		public FormStateEnum PageState;

		public GeneralDataProcess()
		{
			_OldParameters = new Hashtable();
		}

		// cria lista de par??metros vazia
		public void CreateEmptyParameters(GeneralDataProvider Provider)
		{
			if (Provider == DataProvider)
			{
				Provider.Parameters.Clear();
				Provider.CreateParameters();
			}
		}

		protected override object LoadPageStateFromPersistenceMedium()
		{
			return ViewStateManager.DecompressViewState(this);
		}

		protected override void SavePageStateToPersistenceMedium(object viewState)
		{
			ViewStateManager.CompressViewState(this, viewState);
		}

		/// <summary>
		/// primeira fun??ao a executar, usada na declara??ao de variaveis e outras coisas
		/// </summary>
		/// <param name="e">argumentos da OnInit</param>
		override protected void OnInit(EventArgs e)
		{
			RM = (System.Resources.ResourceManager)Application["rm"];

			// tenta pegar defini????o espec??fica para estilo dessa p??gina

			// n??o tem estilo espec??fico, vamos pegar o geral

			//Vamos explicitar todos os eventos porque estamos usando a diretiva/propriedade AutoEventWireup=false
			this.Load += new System.EventHandler(this.PageLoad);

			base.OnInit(e);

			PageCheckAuthentication();
			
			CreateProvider();
		}

		protected override void InitializeCulture()
		{
			Utility.SetThreadCulture();
		}

		public abstract void GetScreenFieldsValues();

		/// <summary>
		/// Page load da pagina, aqui se faz tudo o que deve ser feito quando a pagina carrega ou quando ocorre um post
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void PageLoad(object sender, System.EventArgs e)
		{
			if (HttpContext.Current.Request.UrlReferrer == null)
			{
				HttpContext.Current.Response.Redirect("Default.aspx?redirect=" + PageName);
			}

			DefineMask();          // faz defini????o de m??scara 
			
			DefineAttributes();   // faz defini????o de atributos gerais para a p??gina 
			
			GetScreenFieldsValues();
			
			if (!this.IsPostBack)
			{
				FillComboBoxes();
			}
			ShowFormulas();
		}

		/// <summary>
		/// testa se esta logado e se nao estiver manda para a pagina de login
		/// </summary>
		private void PageCheckAuthentication()
		{
			if (this.AuthenticationRequired)
			{
				Utility.CheckAuthentication(this);
			}
		}

		public void ApplyMasks(WebControl Txt)
        {
            if (Txt.Attributes["Mask"] != null)
            {
                if (!IsPostBack)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Mask" + Txt.ClientID, "<script>ApplyElementMask(document.getElementById('" + Txt.ClientID + "'));</script>");
                }
            }
        }

		#region IGeneralDataProvider Members
		
		public string TableName
		{
			get { throw new NotImplementedException(); }
		}

		public string DatabaseName
		{
			get { throw new NotImplementedException(); }
		}

		public GeneralDataProviderItem LoadItemFromControl(bool EnableValidation)
		{
			throw new NotImplementedException();
		}

		public GeneralDataProviderItem LoadItemFromGridControl(bool EnableValidation, string Grid)
		{
			throw new NotImplementedException();
		}
		
		public GeneralDataProviderItem LoadItemFromSchedulerControl(bool EnableValidation, string Grid)
		{
			throw new NotImplementedException();
		}

		public GeneralDataProviderItem LoadItemFromImageGalleryControl(bool EnableValidation, string ImageGallery)
		{
			throw new NotImplementedException();
		}
		
		public GeneralDataProviderItem LoadItemFromGanttControl(bool EnableValidation, string Gantt)
		{
			throw new NotImplementedException();
		}

		public GeneralDataProviderItem LoadItemFromDependenciesGanttControl(bool EnableValidation, string Gantt)
		{
			throw new NotImplementedException();
		}

		public void DeleteChildItens()
		{
			throw new NotImplementedException();
		}

        public void OnCommiting()
		{
		}

        public void OnRollbacking()
        {
        }

		public abstract GeneralDataProviderItem GetDataProviderItem(GeneralDataProvider Provider);

		public virtual void OnProcessSucceeded()
		{
		}

		public virtual void OnProcessFailed()
		{
		}

		public void GetParameters(bool KeepCurrentRecord, GeneralDataProvider Provider)
		{
		}

		public void SetOldParameters(GeneralDataProviderItem Item)
		{
			_OldParameters.Clear();
			if (Item != null)
			{
				foreach (string ParamKey in DataProvider.Parameters.Keys)
				{
					_OldParameters.Add(ParamKey, Item.Fields[ParamKey].Value);
					DataProvider.Parameters[ParamKey].Parameter.SetValue(Item.Fields[ParamKey].Value);
				}
			}
			ViewState["OldParameters"] = _OldParameters;
		}
		#endregion
	}
}
