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
	public partial class HistoricodeExecucaodaAtividade : GeneralDataPage
	{
		protected HistoricodeExecucaodaAtividadePageProvider PageProvider;
	

		public string btnFecharField = "btnFechar";
		public long projetoField = 0;
		public int itemProjetoField = 0;
		public int itemProcessoField = 0;
		public DateTime ? dataLancamentoField;
		public int JustificativaField = 0;
		public double percentualExecutadoField = 0;
		public string observacaoField = "";
		public string usuarioCadastroField = "";
		public DateTime ? dataCadastroField;
		
		public override string FormID { get { return "32779"; } }
		public override string TableName { get { return "TB_HIST_EXECUCAO_ATIVIDADE"; } }
		public override string DatabaseName { get { return "DBGERPROJETO"; } }
		public override string PageName { get { return "HistoricodeExecucaodaAtividade.aspx"; } }
		public override string ProjectID { get { return "328917AC"; } }
		public override string TableParameters { get { return "false"; } }
		public override bool PageInsert { get { return true;}}
		public override bool CanEdit { get { return false && UpdateValidation(); }}
		public override bool CanInsert  { get { return true && InsertValidation(); } }
		public override bool CanDelete { get { return false && DeleteValidation(); } }
		public override bool CanView { get { return true; } }
		public override bool OpenInEditMode { get { return true; } }
		


		public string ParamDiretriz = "";
		public string ParamAcao = "";
		public string ParamAtividade = "";
		public string ParamData = "";
		public string ParamJustificativa = "";

		public override void SetStartFilter()
		{
			try
			{
				if (!String.IsNullOrEmpty(ParamDiretriz) && !String.IsNullOrEmpty(ParamAcao) && !String.IsNullOrEmpty(ParamAtividade) && !String.IsNullOrEmpty(ParamData) && !String.IsNullOrEmpty(ParamJustificativa))
				{
					PageProvider.MainProvider.DataProvider.StartFilter = "((((" + Dao.PoeColAspas("projeto") + " = " + Dao.ToSql(ParamDiretriz.ToString(), FieldType.Integer) + " ) and " + Dao.PoeColAspas("itemProjeto") + " = " + Dao.ToSql(ParamAcao.ToString(), FieldType.Integer) + " ) and " + Dao.PoeColAspas("itemProcesso") + " = " + Dao.ToSql(ParamAtividade.ToString(), FieldType.Integer) + " ) and " + Dao.PoeColAspas("dataLancamento") + " = " + Dao.ToSql(ParamData.ToString(), FieldType.Date) + " ) and " + Dao.PoeColAspas("justificativa") + " = " + Dao.ToSql(ParamJustificativa.ToString(), FieldType.Integer);
				}
				else
				{
					PageProvider.MainProvider.DataProvider.StartFilter = "1 = 2";
				}
			}
			catch
			{
				PageProvider.MainProvider.DataProvider.StartFilter = "1 = 2";
			}
		}
		
		public override void CreateProvider()
		{
			PageProvider = new HistoricodeExecucaodaAtividadePageProvider(this);
		}
		
		private void InitializePageContent()
		{
		}


		/// <summary>
        /// onInit Vamos Carregar o Painel de Ajax e Label de erros da página
        /// </summary>
		protected override void OnInit(EventArgs e)
		{
			ParamDiretriz = HttpContext.Current.Request.QueryString["ParamDiretriz"];
			try { if (string.IsNullOrEmpty(ParamDiretriz)) ParamDiretriz = HttpContext.Current.Session["ParamDiretriz"].ToString();} catch {} 
			if (string.IsNullOrEmpty(ParamDiretriz)) ParamDiretriz = "0";
			ParamAcao = HttpContext.Current.Request.QueryString["ParamAcao"];
			try { if (string.IsNullOrEmpty(ParamAcao)) ParamAcao = HttpContext.Current.Session["ParamAcao"].ToString();} catch {} 
			if (string.IsNullOrEmpty(ParamAcao)) ParamAcao = "0";
			ParamAtividade = HttpContext.Current.Request.QueryString["ParamAtividade"];
			try { if (string.IsNullOrEmpty(ParamAtividade)) ParamAtividade = HttpContext.Current.Session["ParamAtividade"].ToString();} catch {} 
			if (string.IsNullOrEmpty(ParamAtividade)) ParamAtividade = "0";
			ParamData = HttpContext.Current.Request.QueryString["ParamData"];
			try { if (string.IsNullOrEmpty(ParamData)) ParamData = HttpContext.Current.Session["ParamData"].ToString();} catch {} 
			ParamJustificativa = HttpContext.Current.Request.QueryString["ParamJustificativa"];
			try { if (string.IsNullOrEmpty(ParamJustificativa)) ParamJustificativa = HttpContext.Current.Session["ParamJustificativa"].ToString();} catch {} 
			if (string.IsNullOrEmpty(ParamJustificativa)) ParamJustificativa = "0";
			AjaxPanel = MainAjaxPanel;
			if (IsPostBack)
			{
				AjaxPanel.ResponseScripts.Add("setTimeout(\"InitializeClient();\",100);");
			}
			AjaxPanel.ResponseScripts.Add("setTimeout(\"RegisterClientValidateScript();\",100);");
			ErrorLabel = labError;
			if (!PageInsert )
				DisableEnableContros(false);

			base.OnInit(e);
		}
		

		/// <summary>
		/// Define os Parâmetros para acesso às tabelas auxiliares
		/// </summary>
		public override void SetParametersValues(GeneralDataProvider Provider)
		{
			try
			{
				if (Provider == PageProvider.AUX_TB_HIST_EXECUCAO_ATIVIDADE_TB_PROCESSOSProvider && Provider.IndexName == "PK_TB_PROCESSOS")
				{
					if (PageProvider.MainProvider.DataProvider.Item != null)
					{
						Provider.Parameters["projeto"].Parameter.SetValue(Utility.FixValue<double>(PageProvider.MainProvider.DataProvider.Item["projeto"].GetValue()));
					}
					if (PageProvider.MainProvider.DataProvider.Item != null)
					{
						Provider.Parameters["itemProjeto"].Parameter.SetValue(Utility.FixValue<double>(PageProvider.MainProvider.DataProvider.Item["itemProjeto"].GetValue()));
					}
					if (PageProvider.MainProvider.DataProvider.Item != null)
					{
						Provider.Parameters["itemProcesso"].Parameter.SetValue(Utility.FixValue<double>(PageProvider.MainProvider.DataProvider.Item["itemProcesso"].GetValue()));
					}
				}
			}
			catch
			{
			}
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
				Item.SetFieldValue(Item["projeto"], txtDiretriz.Text, false);
				Item.SetFieldValue(Item["itemProjeto"], txtAcao.Text, false);
				Item.SetFieldValue(Item["itemProcesso"], txtAtividade.Text, false);
				if (dtExecutado.SelectedDate != null) Item.SetFieldValue(Item["dataLancamento"], dtExecutado.SelectedDate.Value.ToString("dd/MM/yyyy"));
				else Item.SetFieldValue(Item["dataLancamento"], DBNull.Value);
				Item.SetFieldValue(Item["Justificativa"], cmbLancamento.SelectedValue);
				Item.SetFieldValue(Item["percentualExecutado"], txtPercExecutado.Text, false);
				Item.SetFieldValue(Item["observacao"], txtJustificativa.Text, false);
				Item.SetFieldValue(Item["usuarioCadastro"], RadTextBox6.Text, false);
				if (DatePicker2.SelectedDate != null) Item.SetFieldValue(Item["dataCadastro"], DatePicker2.SelectedDate.Value.ToString("dd/MM/yyyy"));
				else Item.SetFieldValue(Item["dataCadastro"], DBNull.Value);
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
				Item.SetFieldValue(Item["projeto"], txtDiretriz.Text, false);
				Item.SetFieldValue(Item["itemProjeto"], txtAcao.Text, false);
				Item.SetFieldValue(Item["itemProcesso"], txtAtividade.Text, false);
				if (dtExecutado.SelectedDate != null) Item.SetFieldValue(Item["dataLancamento"], dtExecutado.SelectedDate.Value.ToString("dd/MM/yyyy"));
				else Item.SetFieldValue(Item["dataLancamento"], DBNull.Value);
				Item.SetFieldValue(Item["Justificativa"], cmbLancamento.SelectedValue);
				Item.SetFieldValue(Item["percentualExecutado"], txtPercExecutado.Text, false);
				Item.SetFieldValue(Item["observacao"], txtJustificativa.Text, false);
				Item.SetFieldValue(Item["usuarioCadastro"], RadTextBox6.Text, false);
				if (DatePicker2.SelectedDate != null) Item.SetFieldValue(Item["dataCadastro"], DatePicker2.SelectedDate.Value.ToString("dd/MM/yyyy"));
				else Item.SetFieldValue(Item["dataCadastro"], DBNull.Value);
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
			Mask.SetMask(txtDiretriz, "9999999999", 10, true);
			Mask.SetMask(txtAcao, "99999", 5, true);
			Mask.SetMask(txtAtividade, "99999", 5, true);
			Mask.SetMask(dtExecutado.DateInput, "99/99/9999", 10, false);
			Mask.SetMask(txtPercExecutado, "999,99", 6, true);
			Mask.SetMask(RadTextBox6, "@!", 50, false);
			Mask.SetMask(DatePicker2.DateInput, "99/99/9999", 10, false);
		}

		public override void DefineStartScripts()
		{
			Utility.SetControlTabOnEnter(cmbLancamento);
			Utility.SetControlTabOnEnter(txtJustificativa);
		}
		
		public override void DisableEnableContros(bool Action)
		{
			dtExecutado.Enabled = Action;
			cmbLancamento.Enabled = Action;
			txtPercExecutado.Enabled = Action;
			txtJustificativa.Enabled = Action;
		}

		/// <summary>
		/// Limpa Campos na tela
		/// </summary>
		public override void ClearFields(bool ShouldClearFields)
		{
				txtDiretriz.Text = "";
				txtAcao.Text = "";
				txtAtividade.Text = "";
				cmbLancamento.SelectedIndex = -1;
				cmbLancamento.Text = "";
				txtPercExecutado.Text = "";
				RadTextBox6.Text = "";
			if (ShouldClearFields)
			{
				dtExecutado.SelectedDate = null;
				txtJustificativa.Text = "";
				DatePicker2.SelectedDate = null;
			}
			if (!PageInsert && PageState == FormStateEnum.Navigation)
				DisableEnableContros(false);				
			else
				DisableEnableContros(true);				
		}		

		public override void ShowInitialValues()
		{
			try
			{
				txtDiretriz.Text = (int.Parse(ParamDiretriz)).ToString();
			}
			catch (Exception e)
			{
			}
			try
			{
				txtAcao.Text = (int.Parse(ParamAcao)).ToString();
			}
			catch (Exception e)
			{
			}
			try
			{
				txtAtividade.Text = (int.Parse(ParamAtividade)).ToString();
			}
			catch (Exception e)
			{
			}
			dtExecutado.SelectedDate = DateTime.Parse(EnvironmentVariable.ActualDate.ToString("dd/MM/yyyy"));
			try
			{
				RadTextBox6.Text = (EnvironmentVariable.LoggedLoginUser.ToString()).ToString();
			}
			catch (Exception e)
			{
			}
			DatePicker2.SelectedDate = DateTime.Parse(EnvironmentVariable.ActualDate.ToString("dd/MM/yyyy"));
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
			Label3.Text = Label3.Text.Replace("<", "&lt;");
			Label3.Text = Label3.Text.Replace(">", "&gt;");
			Label4.Text = Label4.Text.Replace("<", "&lt;");
			Label4.Text = Label4.Text.Replace(">", "&gt;");
			Label5.Text = Label5.Text.Replace("<", "&lt;");
			Label5.Text = Label5.Text.Replace(">", "&gt;");
			Label6.Text = Label6.Text.Replace("<", "&lt;");
			Label6.Text = Label6.Text.Replace(">", "&gt;");
			Label7.Text = Label7.Text.Replace("<", "&lt;");
			Label7.Text = Label7.Text.Replace(">", "&gt;");
			Label8.Text = Label8.Text.Replace("<", "&lt;");
			Label8.Text = Label8.Text.Replace(">", "&gt;");
			Label9.Text = Label9.Text.Replace("<", "&lt;");
			Label9.Text = Label9.Text.Replace(">", "&gt;");
		}
		
		/// <summary>
		/// Define conteudo dos objetos de Tela
		/// </summary>
		public override void DefinePageContent(GeneralDataProviderItem Item)
		{
			try
			{
				if (Item != null)
				{
					txtDiretriz.Text = Item["projeto"].GetFormattedValue();
				}
				else
				{
					txtDiretriz.Text = "" ;
				}
			}
			catch
			{
				txtDiretriz.Text = "" ;
			}
			try
			{
				if (Item != null)
				{
					txtAcao.Text = Item["itemProjeto"].GetFormattedValue();
				}
				else
				{
					txtAcao.Text = "" ;
				}
			}
			catch
			{
				txtAcao.Text = "" ;
			}
			try
			{
				if (Item != null)
				{
					txtAtividade.Text = Item["itemProcesso"].GetFormattedValue();
				}
				else
				{
					txtAtividade.Text = "" ;
				}
			}
			catch
			{
				txtAtividade.Text = "" ;
			}
			try { dtExecutado.SelectedDate = Convert.ToDateTime(Item["dataLancamento"].GetFormattedValue("dd/MM/yyyy")); }
			catch { dtExecutado.SelectedDate = null; }
			try
			{
				string Val = Item["Justificativa"].GetFormattedValue();
				RadComboBoxDataItem cmbLancamentoitem = Utility.FindComboBoxItem(PageProvider.cmbLancamentoItems, Val);
				cmbLancamento.Text = cmbLancamentoitem.Text;
				cmbLancamento.SelectedValue = cmbLancamentoitem.Value;
				cmbLancamento.Attributes.Add("AllowFilter", "False");
			}
			catch
			{
				cmbLancamento.SelectedValue = "";
				cmbLancamento.Text = "";
			}
			try
			{
				if (Item != null)
				{
					txtPercExecutado.Text = Item["percentualExecutado"].GetFormattedValue().Replace(".",",");
				}
				else
				{
					txtPercExecutado.Text = "" ;
				}
			}
			catch
			{
				txtPercExecutado.Text = "" ;
			}
			try
			{
				if (Item != null)
				{
					txtJustificativa.Text = Item["observacao"].GetFormattedValue();
				}
				else
				{
					txtJustificativa.Text = "" ;
				}
			}
			catch
			{
				txtJustificativa.Text = "" ;
			}
			try
			{
				if (Item != null)
				{
					RadTextBox6.Text = Item["usuarioCadastro"].GetFormattedValue();
				}
				else
				{
					RadTextBox6.Text = "" ;
				}
			}
			catch
			{
				RadTextBox6.Text = "" ;
			}
			try { DatePicker2.SelectedDate = Convert.ToDateTime(Item["dataCadastro"].GetFormattedValue("dd/MM/yyyy")); }
			catch { DatePicker2.SelectedDate = null; }
			ApplyMasks(txtDiretriz);
			ApplyMasks(txtAcao);
			ApplyMasks(txtAtividade);
			ApplyMasks(dtExecutado);
			ApplyMasks(txtPercExecutado);
			ApplyMasks(txtJustificativa);
			ApplyMasks(RadTextBox6);
			ApplyMasks(DatePicker2);
			InitializePageContent();
			base.DefinePageContent(Item);
		}
		private void SelectComboItem(RadComboBox Combo, GeneralDataProvider Provider, string Value)
        {
			if (Combo.Items.Count == 0 && !string.IsNullOrEmpty(Value))
			{
				GeneralDataProviderItem item = PageProvider.GetComboItem(Provider, Value);
				Combo.Text = PageProvider.GetItemText(Provider, item);
				Combo.SelectedValue = PageProvider.GetItemValue(Provider, item).ToString();
				Combo.Attributes.Add("AllowFilter", "False");
			}
			else
            {
				Combo.Text = null;
				Combo.SelectedValue = null;
			}
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
				if (Item != null)
				{
					projetoField = long.Parse(Item["projeto"].GetFormattedValue());
				}
				else
				{
					projetoField = 0;
				}
			}
			catch
			{
				projetoField = 0;
			}
			try
			{
				if (Item != null)
				{
					itemProjetoField = int.Parse(Item["itemProjeto"].GetFormattedValue());
				}
				else
				{
					itemProjetoField = 0;
				}
			}
			catch
			{
				itemProjetoField = 0;
			}
			try
			{
				if (Item != null)
				{
					itemProcessoField = int.Parse(Item["itemProcesso"].GetFormattedValue());
				}
				else
				{
					itemProcessoField = 0;
				}
			}
			catch
			{
				itemProcessoField = 0;
			}
			try
			{
				dataLancamentoField = Convert.ToDateTime(Item["dataLancamento"].GetFormattedValue("dd/MM/yyyy"));
			}
			catch
			{
				dataLancamentoField = null;
			}
			try
			{
				JustificativaField = int.Parse(Item["Justificativa"].GetFormattedValue());
			}
			catch
			{
				JustificativaField = 0;
			}
			try
			{
				if (Item != null)
				{
					percentualExecutadoField = double.Parse(Item["percentualExecutado"].GetFormattedValue().Replace(".",","));
				}
				else
				{
					percentualExecutadoField = 0;
				}
			}
			catch
			{
				percentualExecutadoField = 0;
			}
			try
			{
				if (Item != null)
				{
					observacaoField = Item["observacao"].GetFormattedValue();
				}
				else
				{
					observacaoField = "";
				}
			}
			catch
			{
				observacaoField = "";
			}
			try
			{
				if (Item != null)
				{
					usuarioCadastroField = Item["usuarioCadastro"].GetFormattedValue();
				}
				else
				{
					usuarioCadastroField = "";
				}
			}
			catch
			{
				usuarioCadastroField = "";
			}
			try
			{
				dataCadastroField = Convert.ToDateTime(Item["dataCadastro"].GetFormattedValue("dd/MM/yyyy"));
			}
			catch
			{
				dataCadastroField = null;
			}
			PageProvider.AliasVariables.Add("projetoField", projetoField);
			PageProvider.AliasVariables.Add("itemProjetoField", itemProjetoField);
			PageProvider.AliasVariables.Add("itemProcessoField", itemProcessoField);
			PageProvider.AliasVariables.Add("dataLancamentoField", dataLancamentoField);
			PageProvider.AliasVariables.Add("JustificativaField", JustificativaField);
			PageProvider.AliasVariables.Add("percentualExecutadoField", percentualExecutadoField);
			PageProvider.AliasVariables.Add("observacaoField", observacaoField);
			PageProvider.AliasVariables.Add("usuarioCadastroField", usuarioCadastroField);
			PageProvider.AliasVariables.Add("dataCadastroField", dataCadastroField);
			PageProvider.AliasVariables.Add("ParamDiretriz", ParamDiretriz);
			PageProvider.AliasVariables.Add("ParamAcao", ParamAcao);
			PageProvider.AliasVariables.Add("ParamAtividade", ParamAtividade);
			PageProvider.AliasVariables.Add("ParamData", ParamData);
			PageProvider.AliasVariables.Add("ParamJustificativa", ParamJustificativa);
			PageProvider.AliasVariables.Add("BasePage", this);
        }

		protected void ___Form1_OnSaveSucceeded(GeneralDataProviderItem Item)
		{
			bool ActionSucceeded_1 = true;
			try
			{
				Form1_OnSaveSucceeded(Item);
			}
			catch (Exception ex)
			{
				ActionSucceeded_1 = false;
				PageErrors.Add("Error", ex.Message);
				ShowErrors();
			}
			bool ActionSucceeded_2 = true;
			try
			{
				Form1_OnSaveSucceeded_1(Item);
			}
			catch (Exception ex)
			{
				ActionSucceeded_2 = false;
				PageErrors.Add("Error", ex.Message);
				ShowErrors();
			}
			bool ActionSucceeded_3 = true;
			try
			{
				Form1_OnSaveSucceeded_2(Item);
			}
			catch (Exception ex)
			{
				ActionSucceeded_3 = false;
				PageErrors.Add("Error", ex.Message);
				ShowErrors();
			}
		}




		public override void ExecuteServerCommandRequest(string CommandName, string TargetName, string[] Parameters)
		{
			ExecuteLocalCommandRequest(CommandName, TargetName, Parameters);
		}		
		protected void ___cmbLancamento_OnItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
		{
			KeyValuePair<string, object> AllowFilterContext = e.Context.FirstOrDefault(c => c.Key == "AllowFilter");
			bool AllowFilter = false;
			if (AllowFilterContext.Value != null) AllowFilter = Convert.ToBoolean(AllowFilterContext.Value);
		
			int ItemsCount = Convert.ToInt32(e.Context["ItemsCount"]);
			e.EndOfItems = PageProvider.FillCombo(PageProvider.cmbLancamentoItems, sender as RadComboBox, e.NumberOfItems, e.Text, AllowFilter);
		}
		public override void SaveSucceeded(GeneralDataProviderItem Item)
		{
			___Form1_OnSaveSucceeded(Item);
		}
#region CÓDIGO DE USUARIO
		
		private double nTotalProjetosAT;
		private double nSomaTotalAT;
		private double nPercentualAT;
		
		private double nTotalProjetos;
		private double nSomaTotal;
		private double nPercentual;
		
		protected void Form1_OnSaveSucceeded(GeneralDataProviderItem Item)
		{
			//************ Atribuindo valores às atividades ************
			
			string sql = "SELECT COUNT(PROJETO) FROM TB_PROCESSOS WHERE PROJETO = " + projetoField.ToString() + " AND ITEMPROJETO = "  + itemProjetoField.ToString();
			//Atualização de percentual na tabela de ações
			DataAccessObject Dao = Settings.GetDataAccessObject(((Databases)HttpContext.Current.Application["Databases"])["DBGERPROJETO"]);
			Dao.OpenConnection();
			DataTable DT = Dao.RunSql(String.Format(sql)).Tables[0];

			if (DT.Rows.Count > 0) //Se tiver registros no banco 
			{
				nTotalProjetosAT = Convert.ToInt32(DT.Rows[0][0].ToString());
			}
			
			Dao.CloseConnection();
			Dao.Dispose();

			string sql2 = "SELECT SUM(PERCENTUALEXECUTADO) FROM TB_PROCESSOS WHERE PROJETO = "+ projetoField.ToString() + " AND ITEMPROJETO = " + itemProjetoField.ToString();
			//Verificar executa a sql no banco na TB_PROCESSOS

			Dao.OpenConnection();

			DataTable DT2 = Dao.RunSql(String.Format(sql2)).Tables[0];

			if (DT2.Rows.Count > 0) //Se tiver registros no banco 
			{
				nSomaTotalAT = Convert.ToDouble(DT2.Rows[0][0].ToString());
			}

			nPercentualAT = (nSomaTotalAT / nTotalProjetosAT);
			
            string sql3 = "UPDATE TB_ITENS_PROJETO SET TB_ITENS_PROJETO.percentualExecutado = "+ nPercentualAT.ToString("C",CultureInfo.CreateSpecificCulture("en-US")) + " WHERE TB_ITENS_PROJETO.projeto = "+ projetoField.ToString() + " AND ITEMPROJETO = " + itemProjetoField.ToString();

            Dao.ExecuteNonQuery(String.Format(sql3));

			Dao.CloseConnection();
			Dao.Dispose();
		}

		protected void Form1_OnSaveSucceeded_1(GeneralDataProviderItem Item)
		{
			// Percentual das Diretrizes
			string sql3 = "SELECT COUNT(PROJETO) FROM TB_ITENS_PROJETO A WHERE A.PROJETO =  " + projetoField.ToString() + " AND A.STATUSACAO != 'SUSPENSO'";
			DataAccessObject Dao = Settings.GetDataAccessObject(((Databases)HttpContext.Current.Application["Databases"])["DBGERPROJETO"]);	
			Dao.OpenConnection();
			
			DataTable DT3 = Dao.RunSql(String.Format(sql3)).Tables[0];

			if (DT3.Rows.Count > 0) //Se tiver registros no banco 
			{
				nTotalProjetos = Convert.ToInt32(DT3.Rows[0][0].ToString());
			}
			Dao.CloseConnection();
			Dao.Dispose();
		
			string sql4 = "SELECT SUM(PERCENTUALEXECUTADO) FROM TB_ITENS_PROJETO B WHERE B.PROJETO =  " + projetoField.ToString() + " AND B.STATUSACAO != 'SUSPENSO'";

			Dao.OpenConnection();

			DataTable DT4 = Dao.RunSql(String.Format(sql4)).Tables[0];

			if (DT4.Rows.Count > 0) //Se tiver registros no banco 
			{
				nSomaTotal = Convert.ToDouble(DT4.Rows[0][0].ToString());
			}

			nPercentual = (nSomaTotal / nTotalProjetos);
			
			string sql6 = "UPDATE TB_PROJETO SET TB_PROJETO.percentualExecutado = "+ nPercentual.ToString("C",CultureInfo.CreateSpecificCulture("en-US")) + " WHERE TB_PROJETO.codigo = "+ projetoField.ToString();			
            Dao.ExecuteNonQuery(String.Format(sql6));
			
			Dao.CloseConnection();
			Dao.Dispose();							
		}

		protected void Form1_OnSaveSucceeded_2(GeneralDataProviderItem Item)
		{
			try
            {
				// Atualiza Situação na Tabela de Atividades
				string sql = "UPDATE TB_PROCESSOS SET TB_PROCESSOS.situacao = CASE 	WHEN (percentualExecutado = 100) THEN 'CONCLUÍDO' " +
							"WHEN(inicioRealizado is not null and terminoRealizado is not Null and percentualExecutado < 100) THEN 'VERIFICAR %' " +
							"WHEN(inicioRealizado IS NULL  AND inicioPrevisto < GETDATE() AND percentualExecutado = 0) THEN 'ATRASADO' " +	
							"WHEN(inicioRealizado is not null and terminoRealizado is null and percentualExecutado < 100 and GETDATE() > terminoPrevisto) THEN 'ATRASADO' " +					
							"WHEN(terminoPrevisto < GETDATE() AND inicioRealizado is null and terminoRealizado is Null and percentualExecutado = 0) THEN 'ATRASADO' " +
							"WHEN(inicioRealizado IS NULL AND terminoRealizado is null) THEN 'A INICIAR' " +
							"WHEN(inicioRealizado is not null and terminoRealizado is null and percentualExecutado < 100 and GETDATE() - 15 < terminoPrevisto) THEN 'EM DIA' END";

				DataAccessObject Dao = Settings.GetDataAccessObject(((Databases)HttpContext.Current.Application["Databases"])["DBGERPROJETO"]);
				Dao.OpenConnection();
				Dao.ExecuteNonQuery(String.Format(sql));
			}
			catch(Exception ex)
            {
				throw ex;
            }
			finally
            {
				Dao.CloseConnection();
				Dao.Dispose();
			}
			
			// **************************************************************************** //
			// **************************************************************************** //			
			// BLOCO DE ATUALIZAÇÃO DA SITUAÇÃO DE EXECUÇÃO DAS DIRETRIZES E AÇÕES
		
			// BLOCO DAS DIRETRIZES //
			try
            {
				// Atualiza Diretriz "EM DIA"
				string sql2 = "UPDATE TB_PROJETO SET SITUACAO = 'EM DIA' FROM TB_PROJETO A JOIN TB_PROCESSOS C ON A.codigo = C.projeto AND A.percentualExecutado < 100";

				DataAccessObject Dao = Settings.GetDataAccessObject(((Databases)HttpContext.Current.Application["Databases"])["DBGERPROJETO"]);
				Dao.OpenConnection();
				Dao.ExecuteNonQuery(String.Format(sql2));
			}
			catch(Exception ex)
            {
				throw ex;
            }
			finally
            {
				Dao.CloseConnection();
				Dao.Dispose();
			}	
			// ATUALIZA DIRETRIZ "ATRASADO"
			try
            {
				// Atualiza Diretriz "ATRASADO"
				string sql3 = "UPDATE TB_PROJETO SET SITUACAO = 'ATRASADO' FROM TB_PROJETO A JOIN TB_PROCESSOS C ON A.codigo = C.projeto AND C.situacao = 'ATRASADO' AND A.percentualExecutado < 100";

				DataAccessObject Dao = Settings.GetDataAccessObject(((Databases)HttpContext.Current.Application["Databases"])["DBGERPROJETO"]);
				Dao.OpenConnection();
				Dao.ExecuteNonQuery(String.Format(sql3));
			}
			catch(Exception ex)
            {
				throw ex;
            }
			finally
            {
				Dao.CloseConnection();
				Dao.Dispose();
			}	
			// ATUALIZA DIRETRIZ "CONCLUÍDO"
			try
            {
				// Atualiza Diretriz "CONCLUÍDO"
				string sql4 = "UPDATE TB_PROJETO SET SITUACAO = 'CONCLUÍDO' FROM TB_PROJETO A WHERE A.percentualExecutado = 100	";

				DataAccessObject Dao = Settings.GetDataAccessObject(((Databases)HttpContext.Current.Application["Databases"])["DBGERPROJETO"]);
				Dao.OpenConnection();
				Dao.ExecuteNonQuery(String.Format(sql4));
			}
			catch(Exception ex)
            {
				throw ex;
            }
			finally
            {
				Dao.CloseConnection();
				Dao.Dispose();
			}	

			// BLOCO DAS AÇÕES //

			try
            {
				// Atualiza Diretriz "EM DIA"
				string sql5 = "UPDATE TB_ITENS_PROJETO SET SITUACAO = 'EM DIA' FROM TB_ITENS_PROJETO A JOIN TB_PROCESSOS C ON A.projeto = C.projeto and A.itemProjeto = c.itemProjeto AND A.percentualExecutado < 100";

				DataAccessObject Dao = Settings.GetDataAccessObject(((Databases)HttpContext.Current.Application["Databases"])["DBGERPROJETO"]);
				Dao.OpenConnection();
				Dao.ExecuteNonQuery(String.Format(sql5));
			}
			catch(Exception ex)
            {
				throw ex;
            }
			finally
            {
				Dao.CloseConnection();
				Dao.Dispose();
			}					
			// ************************************************************************ //
			try
            {
				// Atualiza Ação "ATRASADO"
				string sql6 = "UPDATE TB_ITENS_PROJETO SET SITUACAO = 'ATRASADO' FROM TB_ITENS_PROJETO B JOIN TB_PROCESSOS C ON B.projeto = C.projeto and b.itemProjeto = c.itemProjeto AND C.situacao = 'ATRASADO' AND B.STATUSACAO != 'SUSPENSO' ";

				DataAccessObject Dao = Settings.GetDataAccessObject(((Databases)HttpContext.Current.Application["Databases"])["DBGERPROJETO"]);
				Dao.OpenConnection();
				Dao.ExecuteNonQuery(String.Format(sql6));
			}
			catch(Exception ex)
            {
				throw ex;
            }
			finally
            {
				Dao.CloseConnection();
				Dao.Dispose();
			}
			// ************************************************************************ //
			try
            {
				// Atualiza Ação "CONCLUÍDO"
				string sql = "UPDATE TB_ITENS_PROJETO SET SITUACAO = 'CONCLUÍDO' FROM TB_ITENS_PROJETO A WHERE A.percentualExecutado = 100";

				DataAccessObject Dao = Settings.GetDataAccessObject(((Databases)HttpContext.Current.Application["Databases"])["DBGERPROJETO"]);
				Dao.OpenConnection();
				Dao.ExecuteNonQuery(String.Format(sql));
			}
			catch(Exception ex)
            {
				throw ex;
            }
			finally
            {
				Dao.CloseConnection();
				Dao.Dispose();
			}						
		}
#endregion
	}
}
