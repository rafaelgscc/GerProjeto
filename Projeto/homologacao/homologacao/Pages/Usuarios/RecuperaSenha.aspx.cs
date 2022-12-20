using System;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;
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
using System.Configuration;
using System.Linq;
using PROJETO;
using COMPONENTS;
using COMPONENTS.Data;
using COMPONENTS.Configuration;
using COMPONENTS.Security;
using PROJETO.DataProviders;
using PROJETO.DataPages;
using Telerik.Web.UI;

namespace PROJETO.DataPages
{
	public partial class RecuperaSenha : GeneralDataPage
	{
		protected RecuperarSenhaPageProvider PageProvider;
	

		public string LOGINField = "";
		public string LOGIN_USER_LOGINField = "";
		public string LOGIN_USER_COORDENACAOField = "";
		
		public override string FormID { get { return "32769"; } }
		public override string TableName { get { return "TB_LOGIN_USER"; } }
		public override string DatabaseName { get { return "DBGERPROJETO"; } }
		public override string PageName { get { return "RecuperaSenha.aspx"; } }
		public override string ProjectID { get { return "328917AC"; } }
		public override string TableParameters { get { return "false"; } }
		public override bool PageInsert { get { return false;}}
		public override bool CanEdit { get { return false && UpdateValidation(); }}
		public override bool CanInsert  { get { return false && InsertValidation(); } }
		public override bool CanDelete { get { return false && DeleteValidation(); } }
		public override bool CanView { get { return true; } }
		public override bool OpenInEditMode { get { return false; } }
		



		public override bool AuthenticationRequired { get { return false; } }
		
		public override void CreateProvider()
		{
			PageProvider = new RecuperarSenhaPageProvider(this);
		}
		
		private void InitializePageContent()
		{
		}


		/// <summary>
        /// onInit Vamos Carregar o Painel de Ajax e Label de erros da página
        /// </summary>
		protected override void OnInit(EventArgs e)
		{
			AjaxPanel = MainAjaxPanel;
			if (IsPostBack)
			{
				AjaxPanel.ResponseScripts.Add("setTimeout(\"InitializeClient();\",100);");
			}
			if (HttpContext.Current.Request.UrlReferrer == null)
			{
				HttpContext.Current.Response.Redirect(Utility.StartPageName);  
				return;
			}
			ErrorLabel = labError;
			if (!PageInsert )
				DisableEnableContros(false);

			base.OnInit(e);
		}
		

		/// <summary>
		/// Carrega os objetos de Item de acordo com os controles
		/// </summary>
		public override void UpdateItemFromControl(GeneralDataProviderItem  Item)
		{
			// só vamos permitir a carga dos itens de acordo com os controles de tela caso esteja ocorrendo
			// um postback pois em caso contrário a página está sendo aberta em modo de inclusão/edição
			// e dessa forma não teve alteração de usuário nos dados do formulário
			if (PageState != FormStateEnum.Navigation && this.IsPostBack)
			{
			}
			InitializeAlias(Item);
		}

		/// <summary>
		/// Carrega os objetos de tela para o Item Provider da página
		/// </summary>

		public override GeneralDataProviderItem LoadItemFromControl(bool EnableValidation)
		{
			GeneralDataProviderItem Item = PageProvider.GetDataProviderItem(DataProvider);
			if (PageState != FormStateEnum.Navigation)
			{
			}
			else
			{
				Item = PageProvider.MainProvider.DataProvider.SelectItem(PageNumber, FormPositioningEnum.Current);
			}
			if (EnableValidation)
			{
				InitializeAlias(Item);
				if (PageState == FormStateEnum.Insert)
				{
					FillAuxiliarTables();
				}
				PageProvider.Validate(Item); 
			}
			if (Item!=null) PageErrors.Add(Item.Errors);
			return Item;
		}
		

		/// <summary>
		/// Define a Máscara para cada campo na tela
		/// </summary>
		public override void DefineMask()
		{
		}

		public override void DefineStartScripts()
		{
			Utility.SetControlTabOnEnter(txtLogin);
		}
		
		public override void DisableEnableContros(bool Action)
		{
		}

		/// <summary>
		/// Limpa Campos na tela
		/// </summary>
		public override void ClearFields(bool ShouldClearFields)
		{
			if (ShouldClearFields)
			{
			}
			if (!PageInsert && PageState == FormStateEnum.Navigation)
				DisableEnableContros(false);				
			else
				DisableEnableContros(true);				
		}		

		public override void ShowInitialValues()
		{
		}

		public override void PageEdit()
		{
			DisableEnableContros(true); 
			base.PageEdit(); 
		}

		public override void ShowFormulas()
		{
			Label1.Text = Label1.Text.Replace("<", "&lt;");
			Label1.Text = Label1.Text.Replace(">", "&gt;");
			Label2.Text = Label2.Text.Replace("<", "&lt;");
			Label2.Text = Label2.Text.Replace(">", "&gt;");
		}
		
		/// <summary>
		/// Define conteudo dos objetos de Tela
		/// </summary>
		public override void DefinePageContent(GeneralDataProviderItem Item)
		{
			ApplyMasks(txtLogin);
			InitializePageContent();
			base.DefinePageContent(Item);
		}
		/// <summary>
		/// Define apelidos da Página
		/// </summary>
		public override void InitializeAlias(GeneralDataProviderItem Item)
        {
			PageProvider.AliasVariables = new Dictionary<string, object>();
			PageProvider.AliasVariables.Clear();
			
			try
			{
				LOGINField = txtLogin.Text;
			}
			catch
			{
				LOGINField = "";
			}
			try
			{
				if (Item != null)
				{
					LOGIN_USER_LOGINField = Item["LOGIN_USER_LOGIN"].GetFormattedValue();
				}
				else
				{
				LOGIN_USER_LOGINField = "";
				}
			}
			catch
			{
				LOGIN_USER_LOGINField = "";
			}
			try
			{
				if (Item != null)
				{
					LOGIN_USER_COORDENACAOField = Item["LOGIN_USER_COORDENACAO"].GetFormattedValue();
				}
				else
				{
				LOGIN_USER_COORDENACAOField = "";
				}
			}
			catch
			{
				LOGIN_USER_COORDENACAOField = "";
			}
			PageProvider.AliasVariables.Add("LOGINField", LOGINField);
			PageProvider.AliasVariables.Add("LOGIN_USER_LOGINField", LOGIN_USER_LOGINField);
			PageProvider.AliasVariables.Add("LOGIN_USER_COORDENACAOField", LOGIN_USER_COORDENACAOField);
			PageProvider.AliasVariables.Add("BasePage", this);
        }

		protected void ___btnRecuperar_OnClick(object sender, EventArgs e)
		{
			bool ActionSucceeded_1 = true;
			try
			{
				btnRecuperar_OnClick(sender, e);
			}
			catch (Exception ex)
			{
				ActionSucceeded_1 = false;
				PageErrors.Add("Error", ex.Message);
				ShowErrors();
			}
		}




		public override void ExecuteServerCommandRequest(string CommandName, string TargetName, string[] Parameters)
		{
			ExecuteLocalCommandRequest(CommandName, TargetName, Parameters);
		}		
#region CÓDIGO DE USUARIO
		public bool vgOK = false;
		private string _Nome = "";
		private string _Email = "";
		
		/*	Função chamada no clique do botão Enviar
			Feita por: Erasmo de Cerqueira Junior
			Data: 04/08/2015
			Objetivo: 	Essa função tem como objetivo de Executar pré validação do processo de Recuperar Senha e no caso de sucesso
		            gerar uma nova senha
		*/
		
		protected void btnRecuperar_OnClick(object sender, EventArgs e)
		{
			string Mensagem = "";
			string sql = "SELECT L.LOGIN_USER_LOGIN, L.LOGIN_USER_NAME, L.LOGIN_USER_EMAIL FROM TB_LOGIN_USER L WHERE L.LOGIN_USER_LOGIN = '" + Crypt.Encripta(LOGINField) + "'";
			
			try
			{
				if (String.IsNullOrEmpty(LOGINField))
				{
					Mensagem = "Favor informar o Login!";
				}
				else
				{
					DataAccessObject Dao = Settings.GetDataAccessObject(((Databases)HttpContext.Current.Application["Databases"])["DBGERPROJETO"]);
					DataTable DT = Dao.RunSql(String.Format(sql)).Tables[0];
					if (DT.Rows.Count > 0) //Se tiver registros no banco vamos verificar se existe conteúdo
					{
						_Nome = Crypt.Decripta(DT.Rows[0][1].ToString());
						_Email = Crypt.Decripta(DT.Rows[0][2].ToString());
						if (!String.IsNullOrEmpty(_Email)) 
						{
							vgOK = true;
							try
							{
								//se tudo estiver ok até o momento vamos enviar o E-mail
								vgOK = EmailRecuperacaoSenhaSendEmail.Send((_Nome).ToString(), (LOGINField).ToString(), (_Email).ToString(), (GerarNovaSenha()).ToString());
								Mensagem = "E-mail enviado com sucesso!";
							}
                            catch
                            {
								Mensagem = "Falha no Envio do E-mail!";
							}
						}
						else
						{
							Mensagem = "Mensagem enviada para o e-mail cadastrado!";
						}
					}
					else
					{
						Mensagem = "Login inválido ou inexistente!";
					}
					Dao.CloseConnection();
					Dao.Dispose();
				}
			}
			catch (Exception)
			{
				
			}
			
			if (Mensagem.Length > 0) { PageErrors.Add("Error", Mensagem.ToString()); }
			ShowErrors(); 
		}
		
		/*	Função chamada no clique do botão Enviar
		Feita por: Erasmo de Cerqueira Junior
		Data: 06/08/2015
		Objetivo: 	Essa função tem como objetivo montar a nova senha que será enviada para o processo pré-definido*/
		private string GerarNovaSenha()
		{
            string vgSenha = "";
			if (vgOK)  //Validação estando ok, a partir da existência de um email vamos gerar uma nova senha
            {
                //vamos então gerar uma nova Senha para ser setada 
                vgSenha = ("NOVA" + (LOGINField.Length).ToString() + EnvironmentVariable.ActualDay.ToString() + EnvironmentVariable.ActualMonth.ToString() ); // A nova senha será montada a partir da palavra Nova+lenght(Login)+diames
				string sql = "UPDATE [dbo].[TB_LOGIN_USER] SET LOGIN_USER_PASSWORD = '" + Crypt.Encripta(vgSenha.ToString()) + "' " +
                             "WHERE LOGIN_USER_LOGIN = '" + Crypt.Encripta(LOGINField.ToString()) + "'";
				//Agora abrindo conexão para executar a SQL 
				DataAccessObject Dao = Settings.GetDataAccessObject(((Databases)HttpContext.Current.Application["Databases"])["DBGERPROJETO"]);
				Dao.OpenConnection();
				Dao.ExecuteNonQuery(String.Format(sql));
	            Dao.CloseConnection();
    	        Dao.Dispose();
            }
			return vgSenha;
		}
#endregion
	}
}
