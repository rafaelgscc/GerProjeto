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
using PROJETO;
using COMPONENTS;
using COMPONENTS.Data;
using COMPONENTS.Configuration;
using COMPONENTS.Security;
using PROJETO.DataProviders;
using PROJETO.DataPages;
using Telerik.Web.UI;
using System.Linq;

namespace PROJETO.DataPages
{
	
	public partial class AtualizaSituacaoAcao : GeneralDataProcess
	{

		private AtualizaSituacaoAcaoProcessProvider PageProvider;

		public override string FormID { get { return "32792"; } }
		public override string PageName { get { return "AtualizaSituacaoAcao.aspx"; } }

		public override void CreateProvider()
		{
			PageProvider = new AtualizaSituacaoAcaoProcessProvider(this);
		}
		
		/// <summary>
		/// onInit Vamos Carregar o Painel de Ajax e Label de erros da página
		/// </summary>
		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);
			___Form1_OnLoad();
			
		}
		
		public override void ShowFormulas()
		{
		}

		public override void GetScreenFieldsValues()
		{
			PageProvider.AliasVariables = new Dictionary<string, object>();
			PageProvider.AliasVariables.Clear();
		}

		public void ExecutePreDefProcess()
		{
			try
			{
				GetScreenFieldsValues();
				GeneralDataProviderItem item = new GeneralDataProviderItem();
				PageProvider.Validate(item);
				if (item.Errors.Count == 0)
				{
					if (ErrorLabel != null) ErrorLabel.Text = "";
					PageProvider.ExecutePreDefinedProcess();
					OnProcessSucceeded();
				}
				else ShowErrors(item.Errors);
			}
			catch (Exception ex)
			{
				OnProcessFailed();
				NameValueCollection Errors = new NameValueCollection();
                Errors.Add("Error", ex.Message);
                ShowErrors(Errors);
			}
		}

		public override GeneralDataProviderItem GetDataProviderItem(GeneralDataProvider Provider)
		{
			if (Provider.Name == "AtualizaAcao")
			{
				return new DBGERPROJETO_TB_ITENS_PROJETOItem("DBGERPROJETO");
			}
			if (Provider.Name == "AtualizaAcao")
			{
				return new DBGERPROJETO_TB_ITENS_PROJETOItem("DBGERPROJETO");
			}
			return null;
		}

		protected void ___Form1_OnLoad()
		{
			bool ActionSucceeded_1 = true;
			try
			{
				Form1_OnLoad();
			}
			catch (Exception ex)
			{
				ActionSucceeded_1 = false;
				NameValueCollection Errors = new NameValueCollection();
				Errors.Add("Error", ex.Message);
				ShowErrors(Errors);
			}
		}

#region CÓDIGO DE USUARIO

		protected void Form1_OnLoad()
		{
			// Atualiza Situação na Tabela de Ações
 			DataAccessObject Dao = Settings.GetDataAccessObject(((Databases)HttpContext.Current.Application["Databases"])["DBGERPROJETO"]);
            DataTable DT = Dao.RunSql(String.Format("UPDATE TB_ITENS_PROJETO SET TB_ITENS_PROJETO.situacao = CASE WHEN (percentualExecutado = 100) THEN 'CONCLUÍDO'	WHEN (inicioRealizado IS NULL AND terminoRealizado is null) THEN 'A INICIAR' WHEN (inicioRealizado is not null and terminoRealizado is null and percentualExecutado < 100 and GETDATE() > terminoPrevisto) THEN 'ATRASADO' WHEN (inicioRealizado is not null and terminoRealizado is null and percentualExecutado < 100 and GETDATE()-15 < terminoPrevisto) THEN 'EM DIA' END")).Tables[0];

			Dao.CloseConnection();
			Dao.Dispose();
		}
#endregion
	}


}
