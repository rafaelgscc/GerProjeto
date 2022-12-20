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
	public partial class TB_HIST_EXECUCAO_ATIVIDADE_Repeater : GeneralDataPage
	{
		protected TB_HIST_EXECUCAO_ATIVIDADE_RepeaterPageProvider PageProvider;
	

		public string btnFecharField = "btnFechar";
		public long projetoField = 0;
		public int itemProjetoField = 0;
		public int itemProcessoField = 0;
		public DateTime ? dataLancamentoField = null;
		public int JustificativaField = 0;
		public double percentualExecutadoField = 0;
		public string observacaoField = "";
		public string usuarioCadastroField = "";
		public DateTime ? dataCadastroField = null;
		
		public override string FormID { get { return "32812"; } }
		public override string TableName { get { return "TB_HIST_EXECUCAO_ATIVIDADE"; } }
		public override string DatabaseName { get { return "DBGERPROJETO"; } }
		public override string PageName { get { return "TB_HIST_EXECUCAO_ATIVIDADE_Repeater.aspx"; } }
		public override string ProjectID { get { return "328917AC"; } }
		public override string TableParameters { get { return "false"; } }
		public override bool PageInsert { get { return false;}}
		public override bool CanEdit { get { return true && UpdateValidation(); }}
		public override bool CanInsert  { get { return true && InsertValidation(); } }
		public override bool CanDelete { get { return true && DeleteValidation(); } }
		public override bool CanView { get { return true; } }
		public override bool OpenInEditMode { get { return false; } }
		


		public string ParamMeta = "";
		public string ParamAcao = "";
		public string ParamAtividade = "";

		public override void SetStartFilter()
		{
			try
			{
				if (!String.IsNullOrEmpty(ParamMeta) && !String.IsNullOrEmpty(ParamAcao) && !String.IsNullOrEmpty(ParamAtividade))
				{
					PageProvider.MainProvider.DataProvider.StartFilter = "((" + Dao.PoeColAspas("projeto") + " = " + Dao.ToSql(ParamMeta.ToString(), FieldType.Integer) + " ) and " + Dao.PoeColAspas("itemProjeto") + " = " + Dao.ToSql(ParamAcao.ToString(), FieldType.Integer) + " ) and " + Dao.PoeColAspas("itemProcesso") + " = " + Dao.ToSql(ParamAtividade.ToString(), FieldType.Integer);
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
			PageProvider = new TB_HIST_EXECUCAO_ATIVIDADE_RepeaterPageProvider(this);
		}
		
		private void InitializePageContent()
		{
		}


		/// <summary>
        /// onInit Vamos Carregar o Painel de Ajax e Label de erros da página
        /// </summary>
		protected override void OnInit(EventArgs e)
		{
			ParamMeta = HttpContext.Current.Request.QueryString["ParamMeta"];
			try { if (string.IsNullOrEmpty(ParamMeta)) ParamMeta = HttpContext.Current.Session["ParamMeta"].ToString();} catch {} 
			if (string.IsNullOrEmpty(ParamMeta)) ParamMeta = "0";
			ParamAcao = HttpContext.Current.Request.QueryString["ParamAcao"];
			try { if (string.IsNullOrEmpty(ParamAcao)) ParamAcao = HttpContext.Current.Session["ParamAcao"].ToString();} catch {} 
			if (string.IsNullOrEmpty(ParamAcao)) ParamAcao = "0";
			ParamAtividade = HttpContext.Current.Request.QueryString["ParamAtividade"];
			try { if (string.IsNullOrEmpty(ParamAtividade)) ParamAtividade = HttpContext.Current.Session["ParamAtividade"].ToString();} catch {} 
			if (string.IsNullOrEmpty(ParamAtividade)) ParamAtividade = "0";
			AjaxPanel = MainAjaxPanel;
			if (IsPostBack)
			{
				AjaxPanel.ResponseScripts.Add("setTimeout(\"InitializeClient();\",100);");
			}
			if (!PageInsert )
				DisableEnableContros(false);
			this.Load += new EventHandler(DataPage_Load);

			base.OnInit(e);
		}
		
		
		private void StartListControls()
		{
			Repeater1Index = new Hashtable();
			PageProvider.Repeater1RepeaterProvider.DataProvider.PrepareSelectCountCommands();
			PageProvider.Repeater1RepeaterProvider.DataProvider.OrderBy = "[dataLancamento] Desc";
			if (!Utility.CheckAllowView(this))
			{
				PageProvider.Repeater1RepeaterProvider.DataProvider.FiltroAtual = "1 = 2";
			}
			else
			{
				try
				{
					if (!String.IsNullOrEmpty(ParamMeta) && !String.IsNullOrEmpty(ParamAcao) && !String.IsNullOrEmpty(ParamAtividade))
					{
						PageProvider.Repeater1RepeaterProvider.DataProvider.FiltroAtual = "((" + Dao.PoeColAspas("projeto") + " = " + Dao.ToSql(ParamMeta.ToString(), FieldType.Integer) + " ) and " + Dao.PoeColAspas("itemProjeto") + " = " + Dao.ToSql(ParamAcao.ToString(), FieldType.Integer) + " ) and " + Dao.PoeColAspas("itemProcesso") + " = " + Dao.ToSql(ParamAtividade.ToString(), FieldType.Integer);
					}
				}
				catch
				{
					PageProvider.Repeater1RepeaterProvider.DataProvider.FiltroAtual = "1 = 2";
				}
			}
			int __Repeater1_PageNumber = Repeater1_PageNumber;
			Repeater1.DataSource = RepeaterPagerControler.ControlPagesButtons(Pager1, 5, 10, ref __Repeater1_PageNumber, true, true, PageProvider.Repeater1RepeaterProvider.DataProvider);
			Repeater1_PageNumber = __Repeater1_PageNumber;
			Repeater1.ItemDataBound += new RepeaterItemEventHandler(Repeater1_ItemDataBound);
			Repeater1.DataBind();
		}

		public int Repeater1_PageNumber
		{
			get
			{
				if (ViewState["Repeater1_PageNumber"] != null)
					return (int)ViewState["Repeater1_PageNumber"];
				return 0;
			}
			set
			{
				ViewState["Repeater1_PageNumber"] = value;
			}
		}

		public void __Pager1__Click(object sender, EventArgs e)
		{
			switch (((Button)sender).CommandArgument.ToUpper())
			{
				case "F":
					Repeater1_PageNumber = 0;
					break;
				case "P":
					if(Repeater1_PageNumber > 0)
						Repeater1_PageNumber--;
					break;
				case "N":
					Repeater1_PageNumber++;
					break;
				case "L":
					Repeater1_PageNumber = -1;
					break;
				default:
					int Num;
					if (int.TryParse(((Button)sender).CommandArgument, out Num))
					{
						Repeater1_PageNumber = Num;
					}
					break;
			}
		}

		public Hashtable Repeater1Index
		{
			get
			{
				if (ViewState["Repeater1Index"] != null)
				{
					return (Hashtable)ViewState["Repeater1Index"];
				}
				return null;
			}
			set
			{
				ViewState["Repeater1Index"] = value;
			}
		}

		void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			object RowObj = e.Item.DataItem;
			if (RowObj is DataRowView) RowObj = ((DataRowView)RowObj).Row;
			DataRow row = RowObj as DataRow;
			if(row != null)
			{
				DataListProviderSinc(row, null, PageProvider.Repeater1RepeaterProvider.DataProvider);
				Repeater1Index[e.Item.UniqueID] = "projeto=" + row["projeto"].ToString()+ "§" +"itemProjeto=" + row["itemProjeto"].ToString()+ "§" +"itemProcesso=" + row["itemProcesso"].ToString()+ "§" +"dataLancamento=" + row["dataLancamento"].ToString()+ "§" +"Justificativa=" + row["justificativa"].ToString();
			}
			switch (e.Item.ItemType)
			{
				case ListItemType.Header:
					break;
				case ListItemType.Item:
					if(row != null)
					{
						RadLabel RepCtrLabel3 = e.Item.FindControl("Label3") as RadLabel;
						RepCtrLabel3.Text = row["projeto"].ToString();
						RepCtrLabel3.Text = RepCtrLabel3.Text.Replace("<", "&lt;").Replace(">", "&gt;");
						RepCtrLabel3.Text = Mask.ApplyMask(RepCtrLabel3.Text, "9999999999", "NUMBER");
						RadLabel RepCtrLabel6 = e.Item.FindControl("Label6") as RadLabel;
						RepCtrLabel6.Text = row["itemProjeto"].ToString();
						RepCtrLabel6.Text = RepCtrLabel6.Text.Replace("<", "&lt;").Replace(">", "&gt;");
						RepCtrLabel6.Text = Mask.ApplyMask(RepCtrLabel6.Text, "99999", "NUMBER");
						RadLabel RepCtrLabel9 = e.Item.FindControl("Label9") as RadLabel;
						RepCtrLabel9.Text = row["itemProcesso"].ToString();
						RepCtrLabel9.Text = RepCtrLabel9.Text.Replace("<", "&lt;").Replace(">", "&gt;");
						RepCtrLabel9.Text = Mask.ApplyMask(RepCtrLabel9.Text, "99999", "NUMBER");
						RadLabel RepCtrLabel12 = e.Item.FindControl("Label12") as RadLabel;
						RepCtrLabel12.Text = new DateField("",row["dataLancamento"].ToString()).GetFormattedValue("dd/MM/yyyy");
						RepCtrLabel12.Text = RepCtrLabel12.Text.Replace("<", "&lt;").Replace(">", "&gt;");
						RadLabel RepCtrLabel15 = e.Item.FindControl("Label15") as RadLabel;
						RepCtrLabel15.Text = row["justificativa"].ToString();
						RepCtrLabel15.Text = RepCtrLabel15.Text.Replace("<", "&lt;").Replace(">", "&gt;");
						RepCtrLabel15.Text = Mask.ApplyMask(RepCtrLabel15.Text, "9", "NUMBER");
						RadLabel RepCtrLabel18 = e.Item.FindControl("Label18") as RadLabel;
						RepCtrLabel18.Text = row["percentualExecutado"].ToString();
						RepCtrLabel18.Text = RepCtrLabel18.Text.Replace("<", "&lt;").Replace(">", "&gt;");
						RepCtrLabel18.Text = Mask.ApplyMask(RepCtrLabel18.Text, "999,99", "NUMBER");
						RadLabel RepCtrLabel21 = e.Item.FindControl("Label21") as RadLabel;
						RepCtrLabel21.Text = row["observacao"].ToString();
						RepCtrLabel21.Text = RepCtrLabel21.Text.Replace("<", "&lt;").Replace(">", "&gt;");
						RadLabel RepCtrLabel24 = e.Item.FindControl("Label24") as RadLabel;
						RepCtrLabel24.Text = row["usuarioCadastro"].ToString();
						RepCtrLabel24.Text = RepCtrLabel24.Text.Replace("<", "&lt;").Replace(">", "&gt;");
						RepCtrLabel24.Text = Mask.ApplyMask(RepCtrLabel24.Text, "@!", "TEXT");
					}
					break;
				case ListItemType.AlternatingItem:
					if(row != null)
					{
						RadLabel RepCtrLabel4 = e.Item.FindControl("Label4") as RadLabel;
						RepCtrLabel4.Text = row["projeto"].ToString();
						RepCtrLabel4.Text = RepCtrLabel4.Text.Replace("<", "&lt;").Replace(">", "&gt;");
						RepCtrLabel4.Text = Mask.ApplyMask(RepCtrLabel4.Text, "9999999999", "NUMBER");
						RadLabel RepCtrLabel7 = e.Item.FindControl("Label7") as RadLabel;
						RepCtrLabel7.Text = row["itemProjeto"].ToString();
						RepCtrLabel7.Text = RepCtrLabel7.Text.Replace("<", "&lt;").Replace(">", "&gt;");
						RepCtrLabel7.Text = Mask.ApplyMask(RepCtrLabel7.Text, "99999", "NUMBER");
						RadLabel RepCtrLabel10 = e.Item.FindControl("Label10") as RadLabel;
						RepCtrLabel10.Text = row["itemProcesso"].ToString();
						RepCtrLabel10.Text = RepCtrLabel10.Text.Replace("<", "&lt;").Replace(">", "&gt;");
						RepCtrLabel10.Text = Mask.ApplyMask(RepCtrLabel10.Text, "99999", "NUMBER");
						RadLabel RepCtrLabel13 = e.Item.FindControl("Label13") as RadLabel;
						RepCtrLabel13.Text = new DateField("",row["dataLancamento"].ToString()).GetFormattedValue("dd/MM/yyyy");
						RepCtrLabel13.Text = RepCtrLabel13.Text.Replace("<", "&lt;").Replace(">", "&gt;");
						RadLabel RepCtrLabel16 = e.Item.FindControl("Label16") as RadLabel;
						RepCtrLabel16.Text = row["justificativa"].ToString();
						RepCtrLabel16.Text = RepCtrLabel16.Text.Replace("<", "&lt;").Replace(">", "&gt;");
						RepCtrLabel16.Text = Mask.ApplyMask(RepCtrLabel16.Text, "9", "NUMBER");
						RadLabel RepCtrLabel19 = e.Item.FindControl("Label19") as RadLabel;
						RepCtrLabel19.Text = row["percentualExecutado"].ToString();
						RepCtrLabel19.Text = RepCtrLabel19.Text.Replace("<", "&lt;").Replace(">", "&gt;");
						RepCtrLabel19.Text = Mask.ApplyMask(RepCtrLabel19.Text, "999,99", "NUMBER");
						RadLabel RepCtrLabel22 = e.Item.FindControl("Label22") as RadLabel;
						RepCtrLabel22.Text = row["observacao"].ToString();
						RepCtrLabel22.Text = RepCtrLabel22.Text.Replace("<", "&lt;").Replace(">", "&gt;");
						RadLabel RepCtrLabel25 = e.Item.FindControl("Label25") as RadLabel;
						RepCtrLabel25.Text = row["usuarioCadastro"].ToString();
						RepCtrLabel25.Text = RepCtrLabel25.Text.Replace("<", "&lt;").Replace(">", "&gt;");
						RepCtrLabel25.Text = Mask.ApplyMask(RepCtrLabel25.Text, "@!", "TEXT");
					}
					break;
			}
		}

		public override void ResetRepeaterList()
		{
			Repeater1_PageNumber = 0;
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
			Label26.Text = Label26.Text.Replace("<", "&lt;");
			Label26.Text = Label26.Text.Replace(">", "&gt;");
			Label27.Text = Label27.Text.Replace("<", "&lt;");
			Label27.Text = Label27.Text.Replace(">", "&gt;");
			Label28.Text = Label28.Text.Replace("<", "&lt;");
			Label28.Text = Label28.Text.Replace(">", "&gt;");
			Label29.Text = Label29.Text.Replace("<", "&lt;");
			Label29.Text = Label29.Text.Replace(">", "&gt;");
		}
		
		/// <summary>
		/// Define conteudo dos objetos de Tela
		/// </summary>
		public override void DefinePageContent(GeneralDataProviderItem Item)
		{
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
					projetoField = long.Parse(Item["projeto"].GetFormattedValue(), CultureInfo.CurrentCulture);
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
					itemProjetoField = int.Parse(Item["itemProjeto"].GetFormattedValue(), CultureInfo.CurrentCulture);
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
					itemProcessoField = int.Parse(Item["itemProcesso"].GetFormattedValue(), CultureInfo.CurrentCulture);
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
				if (Item != null)
				{
					dataLancamentoField = DateTime.Parse(Item["dataLancamento"].GetFormattedValue(), CultureInfo.CurrentCulture);
				}
				else
				{
				dataLancamentoField = null;
				}
			}
			catch
			{
				dataLancamentoField = null;
			}
			try
			{
				if (Item != null)
				{
					JustificativaField = int.Parse(Item["Justificativa"].GetFormattedValue(), CultureInfo.CurrentCulture);
				}
				else
				{
				JustificativaField = 0;
				}
			}
			catch
			{
				JustificativaField = 0;
			}
			try
			{
				if (Item != null)
				{
					percentualExecutadoField = double.Parse(Item["percentualExecutado"].GetFormattedValue(), CultureInfo.CurrentCulture);
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
			PageProvider.AliasVariables.Add("projetoField", projetoField);
			PageProvider.AliasVariables.Add("itemProjetoField", itemProjetoField);
			PageProvider.AliasVariables.Add("itemProcessoField", itemProcessoField);
			PageProvider.AliasVariables.Add("dataLancamentoField", dataLancamentoField);
			PageProvider.AliasVariables.Add("JustificativaField", JustificativaField);
			PageProvider.AliasVariables.Add("percentualExecutadoField", percentualExecutadoField);
			PageProvider.AliasVariables.Add("observacaoField", observacaoField);
			PageProvider.AliasVariables.Add("usuarioCadastroField", usuarioCadastroField);
			PageProvider.AliasVariables.Add("dataCadastroField", dataCadastroField);
			PageProvider.AliasVariables.Add("ParamMeta", ParamMeta);
			PageProvider.AliasVariables.Add("ParamAcao", ParamAcao);
			PageProvider.AliasVariables.Add("ParamAtividade", ParamAtividade);
			PageProvider.AliasVariables.Add("BasePage", this);
        }

		protected override void OnLoadComplete(EventArgs e)
		{
			StartListControls();
			base.OnLoadComplete(e);
		}

        public void DataListProviderSinc(object LineIndex, Hashtable Repeaterindex, GeneralDataProvider Provider)
		{
            if (LineIndex is DataRow)
            {
                Provider.LocateRecordByRow((DataRow)LineIndex);
            }
            else
            {
				if (Repeaterindex.Count > 0 && Repeaterindex.ContainsKey(LineIndex))
                {
					Dictionary<string, object> Values = new Dictionary<string, object>();
					string[] splittedVals = Repeaterindex[LineIndex].ToString().Split('§');
					foreach (string Val in splittedVals)
					{
						Values.Add(Val.Substring(0, Val.IndexOf("=")), Val.Substring(Val.IndexOf("=") + 1));
					}
					Provider.FindRecord(Values);
				}
            }
		}


		private void DataPage_Load(object sender, EventArgs e)
		{
			if (IsPostBack)
			{
				string EventTarget = Request["__EVENTTARGET"];
                int End = EventTarget.LastIndexOf("$");
                
                if (End == -1)
                {
                    EventTarget = Request["__EVENTARGUMENT"];
                    int Start  = EventTarget.LastIndexOf("|TargetControl:");
                    
                    if (Start > -1 )
                    {
                        End = (EventTarget.IndexOf("|", Start + 1) > -1 ? EventTarget.IndexOf("|"):(EventTarget.Length - 15) - Start);
                        EventTarget = EventTarget.Substring(Start + 15, End);
                    }
                }

				string[] TargetParts = EventTarget.Split(':');
				bool callPageShow = true;

				int Repeater1Pos = EventTarget.LastIndexOf("$");
				int Repeater1StartPos = ("$" + EventTarget).IndexOf("$Repeater1$");
				if (Repeater1StartPos != -1)
				{
					if (callPageShow) { PageShow(FormPositioningEnum.Current); callPageShow = false; };
					string Repeater1ClientID = EventTarget.Substring(0, Repeater1Pos);
					while (Repeater1ClientID.Substring(Repeater1StartPos).Count(c => c.Equals('$')) > 1)
                    {
                        Repeater1ClientID = Repeater1ClientID.Substring(0, Repeater1ClientID.LastIndexOf("$"));
                    }
					DataListProviderSinc(Repeater1ClientID, Repeater1Index, PageProvider.Repeater1RepeaterProvider.DataProvider);
				}
			}
		}


		public override void ExecuteServerCommandRequest(string CommandName, string TargetName, string[] Parameters)
		{
			ExecuteLocalCommandRequest(CommandName, TargetName, Parameters);
		}		
	}
}
