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
	public partial class ProjetosAtividades : GeneralDataPage
	{
		protected Projetos_E_Atividades_GerenciaisPageProvider PageProvider;
	

		public long projetoField = 0;
		public int itemProjetoField = 0;
		public string nomeAcaoField = "";
		public DateTime ? inicioPrevistoField;
		public DateTime ? terminoPrevistoField;
		public string siglaCoordenacaoField = "";
		public string siglaSetorialField = "";
		public int DiasPrevistosField = 0;
		public string nomeSobrenomeField = "";
		public double percentualExecutadoField = 0;
		public string statusAcaoField = "";
		public DateTime ? terminoRealizadoField = null;
		public string responsavelSubstitutoField = "";
		public string observacaoField = "";
		public string usuarioCadastroField = "";
		public DateTime ? dataCadastroField = null;
		public DateTime ? inicioRealizadoField = null;
		public double custoAcaoField = 0;
		public int DiasRealizadosField = 0;
		public string situacaoField = "";
		
		public override string FormID { get { return "32778"; } }
		public override string TableName { get { return "TB_ITENS_PROJETO"; } }
		public override string DatabaseName { get { return "DBGERPROJETO"; } }
		public override string PageName { get { return "ProjetosAtividades.aspx"; } }
		public override string ProjectID { get { return "328917AC"; } }
		public override string TableParameters { get { return "false"; } }
		public override bool PageInsert { get { return true;}}
		public override bool CanEdit { get { return true && UpdateValidation(); }}
		public override bool CanInsert  { get { return true && InsertValidation(); } }
		public override bool CanDelete { get { return false && DeleteValidation(); } }
		public override bool CanView { get { return true; } }
		public override bool OpenInEditMode { get { return false; } }
		


		public string ParamProjeto = "";
		public string ParamItemProjeto = "";

		public override void SetStartFilter()
		{
			try
			{
				if (!String.IsNullOrEmpty(ParamProjeto) && !String.IsNullOrEmpty(ParamItemProjeto))
				{
					PageProvider.MainProvider.DataProvider.StartFilter = "(" + Dao.PoeColAspas("projeto") + " = " + Dao.ToSql(ParamProjeto.ToString(), FieldType.Integer) + " ) and " + Dao.PoeColAspas("itemProjeto") + " = " + Dao.ToSql(ParamItemProjeto.ToString(), FieldType.Integer);
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
			PageProvider = new Projetos_E_Atividades_GerenciaisPageProvider(this);
		}
		
		private void InitializePageContent()
		{
		}

		public override void GridRebind()
		{
			Grid2.CurrentPageIndex = 0;
			Grid2.DataSource = null;
			Grid2.Rebind();
		}


		/// <summary>
        /// onInit Vamos Carregar o Painel de Ajax e Label de erros da página
        /// </summary>
		protected override void OnInit(EventArgs e)
		{
			ParamProjeto = HttpContext.Current.Request.QueryString["ParamProjeto"];
			try { if (string.IsNullOrEmpty(ParamProjeto)) ParamProjeto = HttpContext.Current.Session["ParamProjeto"].ToString();} catch {} 
			if (string.IsNullOrEmpty(ParamProjeto)) ParamProjeto = "0";
			ParamItemProjeto = HttpContext.Current.Request.QueryString["ParamItemProjeto"];
			try { if (string.IsNullOrEmpty(ParamItemProjeto)) ParamItemProjeto = HttpContext.Current.Session["ParamItemProjeto"].ToString();} catch {} 
			if (string.IsNullOrEmpty(ParamItemProjeto)) ParamItemProjeto = "0";
			AjaxPanel = MainAjaxPanel;
			if (IsPostBack)
			{
				AjaxPanel.ResponseScripts.Add("setTimeout(\"InitializeClient();\",100);");
			}
			AjaxPanel.ResponseScripts.Add("setTimeout(\"RegisterClientValidateScript();\",100);");
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
				if (Provider == PageProvider.AUX_TB_ITENS_PROJETO3_TB_PROCESSOSProvider && Provider.IndexName == "PK_TB_PROCESSOS")
				{
					if (PageProvider.MainProvider.DataProvider.Item != null)
					{
						Provider.Parameters["projeto"].Parameter.SetValue(Utility.FixValue<double>(PageProvider.MainProvider.DataProvider.Item["projeto"].GetValue()));
					}
					if (PageProvider.MainProvider.DataProvider.Item != null)
					{
						Provider.Parameters["itemProjeto"].Parameter.SetValue(Utility.FixValue<double>(PageProvider.MainProvider.DataProvider.Item["itemProjeto"].GetValue()));
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
				Item.SetFieldValue(Item["projeto"], RadTextBox1.Text, false);
				Item.SetFieldValue(Item["itemProjeto"], RadTextBox2.Text, false);
				Item.SetFieldValue(Item["nomeAcao"], RadTextBox3.Text, false);
				if (DatePicker1.SelectedDate != null) Item.SetFieldValue(Item["inicioPrevisto"], DatePicker1.SelectedDate.Value.ToString("dd/MM/yyyy"));
				else Item.SetFieldValue(Item["inicioPrevisto"], DBNull.Value);
				if (DatePicker2.SelectedDate != null) Item.SetFieldValue(Item["terminoPrevisto"], DatePicker2.SelectedDate.Value.ToString("dd/MM/yyyy"));
				else Item.SetFieldValue(Item["terminoPrevisto"], DBNull.Value);
				Item.SetFieldValue(Item["siglaCoordenacao"], RadTextBox8.Text, false);
				Item.SetFieldValue(Item["siglaSetorial"], RadTextBox9.Text, false);
				Item.SetFieldValue(Item["DiasPrevistos"], RadTextBox13.Text, false);
				Item.SetFieldValue(Item["nomeSobrenome"], RadTextBox4.Text, false);
				Item.SetFieldValue(Item["percentualExecutado"], RadTextBox10.Text, false);
				Item.SetFieldValue(Item["statusAcao"], RadTextBox11.Text, false);
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
				Item.SetFieldValue(Item["projeto"], RadTextBox1.Text, false);
				Item.SetFieldValue(Item["itemProjeto"], RadTextBox2.Text, false);
				Item.SetFieldValue(Item["nomeAcao"], RadTextBox3.Text, false);
				if (DatePicker1.SelectedDate != null) Item.SetFieldValue(Item["inicioPrevisto"], DatePicker1.SelectedDate.Value.ToString("dd/MM/yyyy"));
				else Item.SetFieldValue(Item["inicioPrevisto"], DBNull.Value);
				if (DatePicker2.SelectedDate != null) Item.SetFieldValue(Item["terminoPrevisto"], DatePicker2.SelectedDate.Value.ToString("dd/MM/yyyy"));
				else Item.SetFieldValue(Item["terminoPrevisto"], DBNull.Value);
				Item.SetFieldValue(Item["siglaCoordenacao"], RadTextBox8.Text, false);
				Item.SetFieldValue(Item["siglaSetorial"], RadTextBox9.Text, false);
				Item.SetFieldValue(Item["DiasPrevistos"], RadTextBox13.Text, false);
				Item.SetFieldValue(Item["nomeSobrenome"], RadTextBox4.Text, false);
				Item.SetFieldValue(Item["percentualExecutado"], RadTextBox10.Text, false);
				Item.SetFieldValue(Item["statusAcao"], RadTextBox11.Text, false);
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
			Mask.SetMask(RadTextBox1, "9999999999", 10, true);
			Mask.SetMask(RadTextBox2, "99999", 5, true);
			Mask.SetMask(RadTextBox3, "@!", 255, false);
			Mask.SetMask(DatePicker1.DateInput, "99/99/9999", 10, false);
			Mask.SetMask(DatePicker2.DateInput, "99/99/9999", 10, false);
			Mask.SetMask(RadTextBox8, "@!", 10, false);
			Mask.SetMask(RadTextBox9, "@!", 10, false);
			Mask.SetMask(RadTextBox13, "999", 3, true);
			Mask.SetMask(RadTextBox4, "@!", 50, false);
			Mask.SetMask(RadTextBox10, "999,99", 6, true);
		}

		public override void DefineStartScripts()
		{
			Utility.SetControlTabOnEnter(RadTextBox11);
		}
		
		public override void DisableEnableContros(bool Action)
		{
			RadTextBox1.Enabled = Action;
			RadTextBox2.Enabled = Action;
			RadTextBox3.Enabled = Action;
			DatePicker1.Enabled = Action;
			DatePicker2.Enabled = Action;
			RadTextBox8.Enabled = Action;
			RadTextBox9.Enabled = Action;
			RadTextBox13.Enabled = Action;
			RadTextBox4.Enabled = Action;
			RadTextBox10.Enabled = Action;
			RadTextBox11.Enabled = Action;
		}

		/// <summary>
		/// Limpa Campos na tela
		/// </summary>
		public override void ClearFields(bool ShouldClearFields)
		{
				RadTextBox1.Text = "";
				RadTextBox2.Text = "";
				RadTextBox3.Text = "";
				RadTextBox8.Text = "";
				RadTextBox9.Text = "";
				RadTextBox13.Text = "";
				RadTextBox4.Text = "";
				RadTextBox10.Text = "";
				RadTextBox11.Text = "";
			if (ShouldClearFields)
			{
				DatePicker1.SelectedDate = null;
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
				RadTextBox1.Text = (int.Parse(ParamProjeto)).ToString();
			}
			catch (Exception e)
			{
			}
			try
			{
				RadTextBox2.Text = (int.Parse(ParamItemProjeto)).ToString();
			}
			catch (Exception e)
			{
			}
			DatePicker1.SelectedDate = null;
			DatePicker2.SelectedDate = null;
		}

		public override void PageEdit()
		{
			DisableEnableContros(true); 
			base.PageEdit(); 
		}

		public override void ShowFormulas()
		{
			Label19.Text = Label19.Text.Replace("<", "&lt;");
			Label19.Text = Label19.Text.Replace(">", "&gt;");
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
			Label12.Text = Label12.Text.Replace("<", "&lt;");
			Label12.Text = Label12.Text.Replace(">", "&gt;");
			Label13.Text = Label13.Text.Replace("<", "&lt;");
			Label13.Text = Label13.Text.Replace(">", "&gt;");
			Label18.Text = Label18.Text.Replace("<", "&lt;");
			Label18.Text = Label18.Text.Replace(">", "&gt;");
			Label7.Text = Label7.Text.Replace("<", "&lt;");
			Label7.Text = Label7.Text.Replace(">", "&gt;");
			Label14.Text = Label14.Text.Replace("<", "&lt;");
			Label14.Text = Label14.Text.Replace(">", "&gt;");
			Label15.Text = Label15.Text.Replace("<", "&lt;");
			Label15.Text = Label15.Text.Replace(">", "&gt;");
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
					RadTextBox1.Text = Item["projeto"].GetFormattedValue();
				}
				else
				{
					RadTextBox1.Text = "" ;
				}
			}
			catch
			{
				RadTextBox1.Text = "" ;
			}
			try
			{
				if (Item != null)
				{
					RadTextBox2.Text = Item["itemProjeto"].GetFormattedValue();
				}
				else
				{
					RadTextBox2.Text = "" ;
				}
			}
			catch
			{
				RadTextBox2.Text = "" ;
			}
			try
			{
				if (Item != null)
				{
					RadTextBox3.Text = Item["nomeAcao"].GetFormattedValue();
				}
				else
				{
					RadTextBox3.Text = "" ;
				}
			}
			catch
			{
				RadTextBox3.Text = "" ;
			}
			try { DatePicker1.SelectedDate = Convert.ToDateTime(Item["inicioPrevisto"].GetFormattedValue("dd/MM/yyyy")); }
			catch { DatePicker1.SelectedDate = null; }
			try { DatePicker2.SelectedDate = Convert.ToDateTime(Item["terminoPrevisto"].GetFormattedValue("dd/MM/yyyy")); }
			catch { DatePicker2.SelectedDate = null; }
			try
			{
				if (Item != null)
				{
					RadTextBox8.Text = Item["siglaCoordenacao"].GetFormattedValue();
				}
				else
				{
					RadTextBox8.Text = "" ;
				}
			}
			catch
			{
				RadTextBox8.Text = "" ;
			}
			try
			{
				if (Item != null)
				{
					RadTextBox9.Text = Item["siglaSetorial"].GetFormattedValue();
				}
				else
				{
					RadTextBox9.Text = "" ;
				}
			}
			catch
			{
				RadTextBox9.Text = "" ;
			}
			try
			{
				if (Item != null)
				{
					RadTextBox13.Text = Item["DiasPrevistos"].GetFormattedValue();
				}
				else
				{
					RadTextBox13.Text = "" ;
				}
			}
			catch
			{
				RadTextBox13.Text = "" ;
			}
			try
			{
				if (Item != null)
				{
					RadTextBox4.Text = Item["nomeSobrenome"].GetFormattedValue();
				}
				else
				{
					RadTextBox4.Text = "" ;
				}
			}
			catch
			{
				RadTextBox4.Text = "" ;
			}
			try
			{
				if (Item != null)
				{
					RadTextBox10.Text = Item["percentualExecutado"].GetFormattedValue().Replace(".",",");
				}
				else
				{
					RadTextBox10.Text = "" ;
				}
			}
			catch
			{
				RadTextBox10.Text = "" ;
			}
			try
			{
				if (Item != null)
				{
					RadTextBox11.Text = Item["statusAcao"].GetFormattedValue();
				}
				else
				{
					RadTextBox11.Text = "" ;
				}
			}
			catch
			{
				RadTextBox11.Text = "" ;
			}
			ApplyMasks(RadTextBox1);
			ApplyMasks(RadTextBox2);
			ApplyMasks(RadTextBox3);
			ApplyMasks(DatePicker1);
			ApplyMasks(DatePicker2);
			ApplyMasks(RadTextBox8);
			ApplyMasks(RadTextBox9);
			ApplyMasks(RadTextBox13);
			ApplyMasks(RadTextBox4);
			ApplyMasks(RadTextBox10);
			ApplyMasks(RadTextBox11);
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
					nomeAcaoField = Item["nomeAcao"].GetFormattedValue();
				}
				else
				{
					nomeAcaoField = "";
				}
			}
			catch
			{
				nomeAcaoField = "";
			}
			try
			{
				inicioPrevistoField = Convert.ToDateTime(Item["inicioPrevisto"].GetFormattedValue("dd/MM/yyyy"));
			}
			catch
			{
				inicioPrevistoField = null;
			}
			try
			{
				terminoPrevistoField = Convert.ToDateTime(Item["terminoPrevisto"].GetFormattedValue("dd/MM/yyyy"));
			}
			catch
			{
				terminoPrevistoField = null;
			}
			try
			{
				if (Item != null)
				{
					siglaCoordenacaoField = Item["siglaCoordenacao"].GetFormattedValue();
				}
				else
				{
					siglaCoordenacaoField = "";
				}
			}
			catch
			{
				siglaCoordenacaoField = "";
			}
			try
			{
				if (Item != null)
				{
					siglaSetorialField = Item["siglaSetorial"].GetFormattedValue();
				}
				else
				{
					siglaSetorialField = "";
				}
			}
			catch
			{
				siglaSetorialField = "";
			}
			try
			{
				if (Item != null)
				{
					DiasPrevistosField = int.Parse(Item["DiasPrevistos"].GetFormattedValue());
				}
				else
				{
					DiasPrevistosField = 0;
				}
			}
			catch
			{
				DiasPrevistosField = 0;
			}
			try
			{
				if (Item != null)
				{
					nomeSobrenomeField = Item["nomeSobrenome"].GetFormattedValue();
				}
				else
				{
					nomeSobrenomeField = "";
				}
			}
			catch
			{
				nomeSobrenomeField = "";
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
					statusAcaoField = Item["statusAcao"].GetFormattedValue();
				}
				else
				{
					statusAcaoField = "";
				}
			}
			catch
			{
				statusAcaoField = "";
			}
			try
			{
				if (Item != null)
				{
					terminoRealizadoField = DateTime.Parse(Item["terminoRealizado"].GetFormattedValue(), CultureInfo.CurrentCulture);
				}
				else
				{
				terminoRealizadoField = null;
				}
			}
			catch
			{
				terminoRealizadoField = null;
			}
			try
			{
				if (Item != null)
				{
					responsavelSubstitutoField = Item["responsavelSubstituto"].GetFormattedValue();
				}
				else
				{
				responsavelSubstitutoField = "";
				}
			}
			catch
			{
				responsavelSubstitutoField = "";
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
				if (Item != null)
				{
					dataCadastroField = DateTime.Parse(Item["dataCadastro"].GetFormattedValue(), CultureInfo.CurrentCulture);
				}
				else
				{
				dataCadastroField = null;
				}
			}
			catch
			{
				dataCadastroField = null;
			}
			try
			{
				if (Item != null)
				{
					inicioRealizadoField = DateTime.Parse(Item["inicioRealizado"].GetFormattedValue(), CultureInfo.CurrentCulture);
				}
				else
				{
				inicioRealizadoField = null;
				}
			}
			catch
			{
				inicioRealizadoField = null;
			}
			try
			{
				if (Item != null)
				{
					custoAcaoField = double.Parse(Item["custoAcao"].GetFormattedValue(), CultureInfo.CurrentCulture);
				}
				else
				{
				custoAcaoField = 0;
				}
			}
			catch
			{
				custoAcaoField = 0;
			}
			try
			{
				if (Item != null)
				{
					DiasRealizadosField = int.Parse(Item["DiasRealizados"].GetFormattedValue(), CultureInfo.CurrentCulture);
				}
				else
				{
				DiasRealizadosField = 0;
				}
			}
			catch
			{
				DiasRealizadosField = 0;
			}
			try
			{
				if (Item != null)
				{
					situacaoField = Item["situacao"].GetFormattedValue();
				}
				else
				{
				situacaoField = "";
				}
			}
			catch
			{
				situacaoField = "";
			}
			PageProvider.AliasVariables.Add("projetoField", projetoField);
			PageProvider.AliasVariables.Add("itemProjetoField", itemProjetoField);
			PageProvider.AliasVariables.Add("nomeAcaoField", nomeAcaoField);
			PageProvider.AliasVariables.Add("inicioPrevistoField", inicioPrevistoField);
			PageProvider.AliasVariables.Add("terminoPrevistoField", terminoPrevistoField);
			PageProvider.AliasVariables.Add("siglaCoordenacaoField", siglaCoordenacaoField);
			PageProvider.AliasVariables.Add("siglaSetorialField", siglaSetorialField);
			PageProvider.AliasVariables.Add("DiasPrevistosField", DiasPrevistosField);
			PageProvider.AliasVariables.Add("nomeSobrenomeField", nomeSobrenomeField);
			PageProvider.AliasVariables.Add("percentualExecutadoField", percentualExecutadoField);
			PageProvider.AliasVariables.Add("statusAcaoField", statusAcaoField);
			PageProvider.AliasVariables.Add("terminoRealizadoField", terminoRealizadoField);
			PageProvider.AliasVariables.Add("responsavelSubstitutoField", responsavelSubstitutoField);
			PageProvider.AliasVariables.Add("observacaoField", observacaoField);
			PageProvider.AliasVariables.Add("usuarioCadastroField", usuarioCadastroField);
			PageProvider.AliasVariables.Add("dataCadastroField", dataCadastroField);
			PageProvider.AliasVariables.Add("inicioRealizadoField", inicioRealizadoField);
			PageProvider.AliasVariables.Add("custoAcaoField", custoAcaoField);
			PageProvider.AliasVariables.Add("DiasRealizadosField", DiasRealizadosField);
			PageProvider.AliasVariables.Add("situacaoField", situacaoField);
			PageProvider.AliasVariables.Add("ParamProjeto", ParamProjeto);
			PageProvider.AliasVariables.Add("ParamItemProjeto", ParamItemProjeto);
			PageProvider.AliasVariables.Add("BasePage", this);
        }

		protected void ___Form1_LoadCompleted()
		{
			bool ActionSucceeded_1 = true;
			try
			{
				AtualizaSituacaoAtividadeProcessProvider PreDefProvider = new AtualizaSituacaoAtividadeProcessProvider(this);
				PreDefProvider.AliasVariables = new Dictionary<string, object>();
				PreDefProvider.AliasVariables.Clear();
				PreDefProvider.ExecutePreDefinedProcess();
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
				Form1_LoadCompleted();
			}
			catch (Exception ex)
			{
				ActionSucceeded_2 = false;
				PageErrors.Add("Error", ex.Message);
				ShowErrors();
			}
		}




		public override void ExecuteServerCommandRequest(string CommandName, string TargetName, string[] Parameters)
		{
			ExecuteLocalCommandRequest(CommandName, TargetName, Parameters);
		}		
		
		/// <summary>
		/// Carrega os objetos de tela para o Item Provider da grid
		/// </summary>
		public override GeneralDataProviderItem LoadItemFromGridControl(bool EnableValidation, string GridId)
		{
			GeneralDataProviderItem Item = null;
			switch (GridId)
			{
				case "Grid2":
					if (PageProvider.TB_ITENS_PROJETO2_Grid2Provider.DataProvider.Item == null)
						Item = PageProvider.TB_ITENS_PROJETO2_Grid2Provider.GetDataProviderItem();
					else
						Item = PageProvider.TB_ITENS_PROJETO2_Grid2Provider.DataProvider.Item;
					PageProvider.TB_ITENS_PROJETO2_Grid2Provider.RaiseSetRelationFields(PageProvider.TB_ITENS_PROJETO2_Grid2Provider, Item);
					Item.SetFieldValue(Item["itemProcesso"], PageProvider.TB_ITENS_PROJETO2_Grid2Provider.GridData["itemProcesso"]);
					Item.SetFieldValue(Item["nomeProcesso"], PageProvider.TB_ITENS_PROJETO2_Grid2Provider.GridData["nomeProcesso"]);
					Item.SetFieldValue(Item["inicioPrevisto"], PageProvider.TB_ITENS_PROJETO2_Grid2Provider.GridData["inicioPrevisto"]);
					Item.SetFieldValue(Item["terminoPrevisto"], PageProvider.TB_ITENS_PROJETO2_Grid2Provider.GridData["terminoPrevisto"]);
					Item.SetFieldValue(Item["siglaSetorial"], PageProvider.TB_ITENS_PROJETO2_Grid2Provider.GridData["siglaSetorial"]);
					Item.SetFieldValue(Item["nomeSobrenome"], PageProvider.TB_ITENS_PROJETO2_Grid2Provider.GridData["nomeSobrenome"]);
					Item.SetFieldValue(Item["percentualExecutado"], PageProvider.TB_ITENS_PROJETO2_Grid2Provider.GridData["percentualExecutado"]);
					Item.SetFieldValue(Item["situacao"], PageProvider.TB_ITENS_PROJETO2_Grid2Provider.GridData["situacao"]);
					Item.SetFieldValue(Item["situacaoProjeto"], PageProvider.TB_ITENS_PROJETO2_Grid2Provider.GridData["situacaoProjeto"]);
					PageProvider.TB_ITENS_PROJETO2_Grid2Provider.InitializeAlias(Item);
					if (EnableValidation)
					{
						PageProvider.TB_ITENS_PROJETO2_Grid2Provider.Validate(Item);
					}
					break;
			}

			return Item;
		}

		public override void setGridPerm()
		{
			if (!PageOperations.AllowInsert)
			{
				Grid2.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
			}
			if (Grid2.Columns[0] is GridEditCommandColumn && !PageOperations.AllowUpdate)
			{
				Grid2.Columns[0].Visible = false;
			}
			if (Grid2.Columns.Count != 0 && Grid2.Columns[Grid2.Columns.Count - 1] is GridButtonColumn && (Grid2.Columns[Grid2.Columns.Count - 1] as GridButtonColumn).CommandName == "Delete" && !PageOperations.AllowDelete)
			{
				Grid2.Columns[Grid2.Columns.Count - 1].Visible = false;
			}
		}

		protected void Grid2_ItemCreated(object sender, GridItemEventArgs e)
		{
			if (e.Item is GridEditableItem && (e.Item.IsInEditMode))
			{
				if (Grid2.Columns[0].ColumnType == "GridEditCommandColumn" && PageOperations.AllowUpdate)
				{
					if (Grid2.Columns[0].HeaderStyle.Width == 20 && Grid2.Columns[0].Visible == true)
					{
						Grid2.Columns[0].HeaderStyle.Width = 70; 
					}
					else
					{
						Grid2.Columns[0].HeaderStyle.Width = 20; 
					}
				}
				GridEditableItem editableItem = (GridEditableItem)e.Item;
				TextBox txt;
				txt = (editableItem.EditManager.GetColumnEditor("GridColumn7") as GridTextBoxColumnEditor).TextBoxControl;
				txt.Width = 48;
				Mask.SetMask(txt, "99999", 5, true);
				txt.Attributes.Add("onblur", "OnMaskBlur();");
				txt.Attributes.Add("isGrid", "true");
				ApplyMasks(txt);
				txt = (editableItem.EditManager.GetColumnEditor("GridColumn8") as GridTextBoxColumnEditor).TextBoxControl;
				txt.Width = 168;
				Mask.SetMask(txt, "@!", 255, false);
				txt.Attributes.Add("onblur", "OnMaskBlur();");
				txt.Attributes.Add("isGrid", "true");
				ApplyMasks(txt);
				RadDatePicker dtp;
				dtp = (editableItem.EditManager.GetColumnEditor("GridColumn9") as GridDateTimeColumnEditor).PickerControl;
				dtp.Width = 78;
				Mask.SetMask(dtp.DateInput, "dd/MM/yyyy", 10, false);
				dtp.DateInput.Attributes.Add("onblur", "OnMaskBlur();");
				dtp.DateInput.Attributes.Add("isGrid", "true");
				ApplyMasks(dtp.DateInput);
				dtp = (editableItem.EditManager.GetColumnEditor("GridColumn11") as GridDateTimeColumnEditor).PickerControl;
				dtp.Width = 88;
				dtp.DateInput.Attributes.Add("data-validation-engine", "validate[funcCall[GridColumn11_Validation]]");
				dtp.DateInput.Attributes.Add("data-validation-message", "Término Previsto não pode ser vazio!");
				Mask.SetMask(dtp.DateInput, "dd/MM/yyyy", 10, false);
				dtp.DateInput.Attributes.Add("onblur", "OnMaskBlur();");
				dtp.DateInput.Attributes.Add("isGrid", "true");
				ApplyMasks(dtp.DateInput);
				txt = (editableItem.EditManager.GetColumnEditor("GridColumn14") as GridTextBoxColumnEditor).TextBoxControl;
				txt.Width = 75;
				Mask.SetMask(txt, "@!", 10, false);
				txt.Attributes.Add("onblur", "OnMaskBlur();");
				txt.Attributes.Add("isGrid", "true");
				ApplyMasks(txt);
				txt = (editableItem.EditManager.GetColumnEditor("GridColumn17") as GridTextBoxColumnEditor).TextBoxControl;
				txt.Width = 128;
				Mask.SetMask(txt, "@!", 50, false);
				txt.Attributes.Add("onblur", "OnMaskBlur();");
				txt.Attributes.Add("isGrid", "true");
				ApplyMasks(txt);
				txt = (editableItem.EditManager.GetColumnEditor("GridColumn21") as GridTextBoxColumnEditor).TextBoxControl;
				txt.Width = 78;
				Mask.SetMask(txt, "999,99", 6, true);
				txt.Attributes.Add("onblur", "OnMaskBlur();");
				txt.Attributes.Add("isGrid", "true");
				ApplyMasks(txt);
				txt = (editableItem.EditManager.GetColumnEditor("GridColumn24") as GridTextBoxColumnEditor).TextBoxControl;
				txt.Width = 78;
				Mask.SetMask(txt, "@!", 20, false);
				txt.Attributes.Add("onblur", "OnMaskBlur();");
				txt.Attributes.Add("isGrid", "true");
				ApplyMasks(txt);
				txt = (editableItem.EditManager.GetColumnEditor("GrdStatusSituacao") as GridTextBoxColumnEditor).TextBoxControl;
				txt.Width = 78;
				AjaxPanel.ResponseScripts.Add("jQuery(\"#Grid2\").validationEngine();");
				GridItemCreatedFinished(sender, e);
			}
		}
		
		
		
		
		protected void Grid2_ItemDataBound(object sender, GridItemEventArgs e)
		{
			if (e.Item is GridPagerItem)
			{
				GridPagerItem pager = (GridPagerItem)e.Item;
				RadComboBox PageSizeComboBox = (RadComboBox)pager.FindControl("PageSizeComboBox");
				PageSizeComboBox.Visible = false;
				Label ChangePageSizeLabel = (Label)pager.FindControl("ChangePageSizeLabel");
				ChangePageSizeLabel.Visible = false;
			}
		}
		
		protected void Grid2_ItemCommand(object source, GridCommandEventArgs e)
		{
			RadGrid Grid = (RadGrid)source;
			if (e.CommandName == RadGrid.InitInsertCommandName)// If insert mode, disallow edit
			{
				Grid.MasterTableView.ClearEditItems();
			}
			if (e.CommandName == RadGrid.EditCommandName) // If edit mode, disallow insert
			{
				e.Item.OwnerTableView.IsItemInserted = false;
			}
			if (e.CommandName == RadGrid.ExpandCollapseCommandName) // Allow Expand/Collapse one row at a time
			{
				foreach (GridItem item in e.Item.OwnerTableView.Items)
				{
					if (item.Expanded && item != e.Item)
					{
						item.Expanded = false;
					}
				}
			}
			if (e.CommandName == Telerik.Web.UI.RadGrid.ExportToWordCommandName || e.CommandName == Telerik.Web.UI.RadGrid.ExportToPdfCommandName ||
				e.CommandName == Telerik.Web.UI.RadGrid.ExportToExcelCommandName || e.CommandName == Telerik.Web.UI.RadGrid.ExportToCsvCommandName)
			{
				Grid.AllowPaging = false;
				Grid.ExportSettings.IgnorePaging = true;
				Grid.ExportSettings.OpenInNewWindow = true;
			}
			if (e.Item is GridDataItem && !(e.Item is GridDataInsertItem) && e.CommandName != "Cancel" && e.CommandName != "Update" && e.CommandName != "Insert")
			{
				GeneralGridProvider Provider = GetGridProvider(Grid);
				Hashtable CurrentValues = new Hashtable();
				GridDataItem item = (GridDataItem)e.Item;
				if (e.CommandArgument != null && e.CommandArgument.ToString() != "")
				{
					int index = 0;
					if (int.TryParse(e.CommandArgument.ToString(), out index)) item = e.Item.OwnerTableView.Items[index];
				}
				item.ExtractValues(CurrentValues);
				foreach (string key in item.OwnerTableView.DataKeyNames)
				{
					if(Provider.DataProvider.Item.GetFieldAliasByFieldName(key) != "")
						CurrentValues[Provider.DataProvider.Item.GetFieldAliasByFieldName(key)] = item.GetDataKeyValue(key);
					else
						CurrentValues[key] = item.GetDataKeyValue(key);
				}
				Provider.SelectItem(this, Grid.ID, CurrentValues);
		
				switch (e.CommandName)
				{
					case "GridColumn23":
						bool ActionSucceeded_GridColumn23_1 = true;
						try
						{
							string UrlPage = ResolveUrl("~/Pages/HistoricodeExecucaodaAtividade.aspx?ParamDiretriz={ParamDiretriz}&ParamAcao={ParamAcao}&ParamAtividade={ParamAtividade}");
							UrlPage = UrlPage.Replace("{ParamDiretriz}", (Convert.ToInt32(Provider.DataProvider.Item["projeto"].GetValue())).ToString());
							UrlPage = UrlPage.Replace("{ParamAcao}", (Convert.ToInt32(Provider.DataProvider.Item["itemProjeto"].GetValue())).ToString());
							UrlPage = UrlPage.Replace("{ParamAtividade}", (Convert.ToInt32(Provider.DataProvider.Item["itemProcesso"].GetValue())).ToString());
							try
							{
								AjaxPanel.ResponseScripts.Add("Navigate('" + UrlPage + "', true, null, { Modal: true, Center: true });");
							}
							catch(Exception ex)
							{
							}
						}
						catch (Exception ex)
						{
							ActionSucceeded_GridColumn23_1 = false;
							PageErrors.Add("Error", ex.Message);
							ShowErrors();
						}
					break;
					case "GridColumn22":
						bool ActionSucceeded_GridColumn22_1 = true;
						try
						{
							string UrlPage = ResolveUrl("~/Pages/CadastroAtividades.aspx?ParamProjeto={ParamProjeto}&ParamAcao={ParamAcao}&ParamAtividade={ParamAtividade}&ParamCoordenacao={ParamCoordenacao}");
							UrlPage = UrlPage.Replace("{ParamProjeto}", (Convert.ToInt32(Provider.DataProvider.Item["projeto"].GetValue())).ToString());
							UrlPage = UrlPage.Replace("{ParamAcao}", (Convert.ToInt32(Provider.DataProvider.Item["itemProjeto"].GetValue())).ToString());
							UrlPage = UrlPage.Replace("{ParamAtividade}", (Convert.ToInt32(Provider.DataProvider.Item["itemProcesso"].GetValue())).ToString());
							UrlPage = UrlPage.Replace("{ParamCoordenacao}", "");
							try
							{
								AjaxPanel.ResponseScripts.Add("Navigate('" + UrlPage + "', true, null, { Modal: true, Center: true });");
							}
							catch(Exception ex)
							{
							}
						}
						catch (Exception ex)
						{
							ActionSucceeded_GridColumn22_1 = false;
							PageErrors.Add("Error", ex.Message);
							ShowErrors();
						}
					break;
				}
			}
		}

		public override void RefreshOnNavigation()
		{
			Grid2.MasterTableView.ClearEditItems();
			Grid2.MasterTableView.IsItemInserted = false;
		}

		protected void Grid_Init(object sender, EventArgs e)
		{
			RadGrid Grid = (RadGrid)sender;
			GridFilterMenu menu = Grid.FilterMenu;
			int i = 0;
			while (i < menu.Items.Count)
			{
				if (menu.Items[i].Value == "Between" || menu.Items[i].Value == "NotBetween")
				{
					menu.Items.RemoveAt(i);
				}
				else
				{
					i++;
				}
			}
		}

		protected void Grid_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
		{
			int TotalRecords = 0;
			string GridFilter = "";
			RadGrid Grid = (RadGrid)source;

			InitializeGridData(Grid);

			
			if (Grid.MasterTableView.SortExpressions.Count > 0)
			{
				string orderBy = "";
				foreach (GridSortExpression sort in Grid.MasterTableView.SortExpressions)
				{
					orderBy += GetGridProvider(Grid).DataProvider.Dao.PoeColAspas(sort.FieldName) + " " + sort.SortOrderAsString() + ", ";
				}
				GetGridProvider(Grid).DataProvider.OrderBy = orderBy.Remove(orderBy.Length - 2);
			}
			Grid.DataSource = GetGridProvider(Grid).DataProvider.SelectItems(Grid.CurrentPageIndex, Grid.PageSize, out TotalRecords);
			Grid.VirtualItemCount = TotalRecords;
		}
		 
		protected void Grid_UpdateCommand(object source, GridCommandEventArgs e)
		{
			var editableItem = (GridEditableItem)e.Item;
			RadGrid Grid = (RadGrid)source;
			Tuple<Hashtable, Hashtable> GridValues = FillGridValues(editableItem, Grid);
			GetGridProvider(Grid).UpdateItem(this, Grid.ID, DefineGridInsertValues(Grid.ID, GridValues.Item1), GridValues.Item2);
			 if (GetGridProvider(Grid).PageErrors != null)
            {
                e.Canceled = true;
                PageErrors.Add(GetGridProvider(Grid).PageErrors);
                return;
            }
			Grid.DataSource = null;
            Grid.Rebind();
			PageShow(FormPositioningEnum.Current, true, false, false);
		}

		protected void Grid_InsertCommand(object source, GridCommandEventArgs e)
		{
			var editableItem = (GridEditableItem)e.Item;
			RadGrid Grid = (RadGrid)source;
			Hashtable newValues = new Hashtable();
			e.Item.OwnerTableView.ExtractValuesFromItem(newValues, editableItem);
			GetGridProvider(Grid).InsertItem(this, Grid.ID, DefineGridInsertValues(Grid.ID, newValues));
			if (GetGridProvider(Grid).PageErrors != null)
            {
                e.Canceled = true;
                PageErrors.Add(GetGridProvider(Grid).PageErrors);
                return;
            }
			PageShow(FormPositioningEnum.Current, true, false, false);
		}

		protected void Grid_DeleteCommand(object source, GridCommandEventArgs e)
		{
			RadGrid Grid = (RadGrid)source;
            DeleteGrid(Grid, false, (GridEditableItem)e.Item);
			if (GetGridProvider(Grid).PageErrors != null)
			{
				e.Canceled = true;
				PageErrors.Add(GetGridProvider(Grid).PageErrors);
				return;
			}
			PageShow(FormPositioningEnum.Current, true, false, false);
		}

		public override void DeleteChildItens()
        {
			DeleteGrid(Grid2, true, null);
            base.DeleteChildItens();
        }

		public void DeleteGrid(RadGrid Grid, bool DeleteAllItems, GridEditableItem SingleItem)
        {
			int StartIndex = 0;
            if (!DeleteAllItems) StartIndex = SingleItem.ItemIndex;
            else
            {
                Grid.DataSource = null;
                Grid.CurrentPageIndex = 0;
                Grid.Rebind();
            }
            while (Grid.Items.Count != 0 && PageErrors.Count == 0)
            {
                for (int i = StartIndex; Grid.MasterTableView.Items.Count > i; i++)
                {
                    switch (Grid.ID)
                    {
					}
                    Tuple<Hashtable, Hashtable> GridValues = FillGridValues(Grid.MasterTableView.Items[i], Grid);
                    GetGridProvider(Grid).DeleteItem(this, Grid.ID, GridValues.Item1, GridValues.Item2);
					if(GetGridProvider(Grid).PageErrors != null) PageErrors.Add(GetGridProvider(Grid).PageErrors);
                    if (!DeleteAllItems) break;
                }
				Grid.DataSource = null;
				if (DeleteAllItems) Grid.CurrentPageIndex = 0;
                if (!DeleteAllItems && Grid.Items.Count == 1 && Grid.CurrentPageIndex > 0) Grid.CurrentPageIndex--;
                Grid.Rebind();
				if (!DeleteAllItems) break;
            }
		}

		private Tuple<Hashtable, Hashtable> FillGridValues(GridEditableItem editableItem, RadGrid Grid)
		{
			Hashtable newValues = new Hashtable();
			editableItem.OwnerTableView.ExtractValuesFromItem(newValues, editableItem);
			Hashtable oldValues = newValues.Clone() as Hashtable;
			foreach (string key in Grid.MasterTableView.DataKeyNames)
			{
				string FdAlias = (from f in GetGridProvider(Grid).DataProvider.Item.Fields where f.Value.Name == key select f.Key).FirstOrDefault();
				if (!newValues.ContainsKey(key)) newValues.Add(key, editableItem.GetDataKeyValue(key));
				if (!oldValues.ContainsKey(FdAlias))
				{
					oldValues.Add(FdAlias, editableItem.GetDataKeyValue(key));
				}
				else
				{
					oldValues[FdAlias] = editableItem.GetDataKeyValue(key);
				}
			}
			return new Tuple<Hashtable, Hashtable>(newValues, oldValues);
		}
		
		private void InitializeGridData(RadGrid Grid)
		{
			switch (Grid.ID)
			{
				case "Grid2":
					try
					{
						GetGridProvider(Grid).DataProvider.FiltroAtual = Dao.PoeColAspas("projeto") + " = " + Dao.ToSql(PageProvider.MainProvider.DataProvider.Item["projeto"].GetFormattedValue(), FieldType.Integer) + " AND " + Dao.PoeColAspas("itemProjeto") + " = " + Dao.ToSql(PageProvider.MainProvider.DataProvider.Item["itemProjeto"].GetFormattedValue(), FieldType.Integer);
					}
					catch
					{
						GetGridProvider(Grid).DataProvider.FiltroAtual = "1 = 2";
					}
					Grid.Enabled = true;
					if (PageProvider.MainProvider.DataProvider.Item == null || PageProvider.MainProvider.DataProvider.Item["projeto"].GetValue() == null || PageProvider.MainProvider.DataProvider.Item["itemProjeto"].GetValue() == null)
					{
						Grid.Enabled = false;
					}
					break;
			}
		}
		
		public override GeneralGridProvider GetGridProvider(RadGrid Grid)
		{
			switch (Grid.ID)
			{
				case "Grid2":
					return PageProvider.TB_ITENS_PROJETO2_Grid2Provider;
			}
			return null;
		}
		public override GeneralDataProviderItem GetDataProviderItem(GeneralDataProvider Provider)
		{
			if (Provider.Name == "AtualizaSituacaoAtividades")
			{
				return new DBGERPROJETO_TB_PROCESSOSItem("DBGERPROJETO");
			}
			return base.GetDataProviderItem(Provider);
		}
		
		protected override void OnLoadComplete(EventArgs e)
		{
			___Form1_LoadCompleted();
			base.OnLoadComplete(e);
		}
#region CÓDIGO DE USUARIO

		protected void Form1_LoadCompleted()
		{
			try
            {
				// Atualiza Situação na Tabela de Atividades
				string sql = "UPDATE TB_PROCESSOS SET TB_PROCESSOS.situacao = CASE 	WHEN (percentualExecutado = 100) THEN 'CONCLUÍDO' " +
							"WHEN(inicioRealizado is not null and terminoRealizado is not Null and percentualExecutado < 100) THEN 'VERIFICAR %' " +
							"WHEN(terminoPrevisto < GETDATE() AND inicioRealizado is null and terminoRealizado is Null and percentualExecutado = 0) THEN 'ATRASADO' " +
							"WHEN(inicioRealizado IS NULL  AND inicioPrevisto < GETDATE() AND percentualExecutado = 0) THEN 'ATRASADO' " +
							//"WHEN(inicioRealizado IS NULL AND terminoRealizado is null AND percentualExecutado > 0) THEN 'VERIFICAR INICIO' " +
							"WHEN(inicioRealizado IS NULL AND terminoRealizado is null) THEN 'A INICIAR' " +
							"WHEN(inicioRealizado is not null and terminoRealizado is null and percentualExecutado < 100 and GETDATE() > terminoPrevisto) THEN 'ATRASADO' " +
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
				// Atualiza Diretriz "EM DIA"
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
				// Atualiza Diretriz "EM DIA"
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
				string sql6 = "UPDATE TB_ITENS_PROJETO SET SITUACAO = 'ATRASADO' FROM TB_ITENS_PROJETO B JOIN TB_PROCESSOS C ON B.projeto = C.projeto and b.itemProjeto = c.itemProjeto AND C.situacao = 'ATRASADO'";

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
				string sql7 = "UPDATE TB_ITENS_PROJETO SET SITUACAO = 'CONCLUÍDO' FROM TB_ITENS_PROJETO A WHERE A.percentualExecutado = 100";

				DataAccessObject Dao = Settings.GetDataAccessObject(((Databases)HttpContext.Current.Application["Databases"])["DBGERPROJETO"]);
				Dao.OpenConnection();
				Dao.ExecuteNonQuery(String.Format(sql7));
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
				// Atualiza Ação "SUSPENSO"
				string sql8 = "UPDATE TB_ITENS_PROJETO SET SITUACAO = 'SUSPENSO' FROM TB_ITENS_PROJETO A WHERE A.STATUSACAO = 'SUSPENSO'";

				//DataAccessObject Dao = Settings.GetDataAccessObject(((Databases)HttpContext.Current.Application["Databases"])["DBGERPROJETO"]);
				Dao.OpenConnection();
				Dao.ExecuteNonQuery(String.Format(sql8));
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
