using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Globalization;
using PROJETO;
using COMPONENTS;
using COMPONENTS.Data;
using COMPONENTS.Security;
using COMPONENTS.Configuration;
using System.IO;
using System.Web;
using System.Web.UI;
using PROJETO.DataProviders;
using PROJETO.DataPages;
using Telerik.Web.UI;


namespace PROJETO.DataProviders
{
	/// <summary>
	/// Classe de provider usada para a tabela auxiliar
	/// </summary>
	public class TB_HIST_EXECUCAO_ATIVIDADE_RepeaterPageProvider : GeneralProvider
	{
		public TB_HIST_EXECUCAO_ATIVIDADERepeaterDataProvider Repeater1RepeaterProvider;

		public TB_HIST_EXECUCAO_ATIVIDADE_RepeaterPageProvider(IGeneralDataProvider Provider)
		{
			MainProvider = Provider;
			MainProvider.DataProvider = new DBGERPROJETO_TB_HIST_EXECUCAO_ATIVIDADEDataProvider(MainProvider, MainProvider.TableName, MainProvider.DatabaseName, "PK_TB_HIST_EXECUCAO_ATIVIDADE", "TB_HIST_EXECUCAO_ATIVIDADE_Repeater");
			MainProvider.DataProvider.PageProvider = this;
			Repeater1RepeaterProvider = new TB_HIST_EXECUCAO_ATIVIDADERepeaterDataProvider(this);
		}

		public override GeneralDataProviderItem GetDataProviderItem(GeneralDataProvider Provider)
		{
			if (Provider == MainProvider.DataProvider)
			{ 
				return new DBGERPROJETO_TB_HIST_EXECUCAO_ATIVIDADEItem(MainProvider.DatabaseName);
			}
			return null;
		}

		public override string GetItemText(GeneralDataProvider Provider, GeneralDataProviderItem Item)
		{
		return "";
		}
		
		public override object GetItemValue(GeneralDataProvider Provider, GeneralDataProviderItem Item)
		{
		return null;
		}

		public override void FillAuxiliarTables()
		{
		}

		public override int GetMaxProcessLanc()
		{
			return 1;
		}
		
		public override void GetTableIdentity()
		{
			MainProvider.DataProvider.FindRecord("PK_TB_HIST_EXECUCAO_ATIVIDADE", false,new string[] { MainProvider.DataProvider.Item["projeto"].GetFormattedValue(),MainProvider.DataProvider.Item["itemProjeto"].GetFormattedValue(),MainProvider.DataProvider.Item["itemProcesso"].GetFormattedValue(),MainProvider.DataProvider.Item["dataLancamento"].GetFormattedValue(),MainProvider.DataProvider.Item["Justificativa"].GetFormattedValue() });
		}

		public override string CreateProcessBeforeInsert(string FieldName)
		{
			return "";
		}

		public override void CreateProcess(int Pos)
		{
			CreateProcess("",true, Pos);
		}

		public void ExecuteSingleProcess(string ProcessName)
        {
            CreateProcess(ProcessName, false);
            List<Process> ProcList = new List<Process>(Process.Values);
            if (ProcList.Count > 0)
                DataProcessEntry.ExecuteProcess(ProcList, MainProvider.DataProvider.Dao);
        }
		
		public void CreateProcess(string ProcessName, bool AllProcess)
		{
			CreateProcess(ProcessName, AllProcess, -1);
		}

		public void CreateProcess(string ProcessName, bool AllProcess, int Pos)
		{
			string RelationField = "";
			object ValueField = "";
			object RawValue = "";
			GeneralDataProviderItem Item;
			Process = new Dictionary<string, Process>();
			Process.Clear();
		}

		public override void CreateReverseProcess(int Pos , string SituationProcess)
		{
			string RelationField = "";
			object ValueField = "";
			object RawValue = "";
			ReverseProcess = new Dictionary<string, Process>();
			ReverseProcess.Clear();
			var situationP = new Dictionary<string, bool>();
		}


		/// <summary>
		/// Valida se todos os campos foram preenchidos corretamente
		/// </summary>
		/// <param name="provider">Provider que vai ser usado para carregar os itens da p?gina</param>
		public override bool Validate(GeneralDataProviderItem ProviderItem)
		{
			return (ProviderItem.Errors.Count == 0);
		}
		


	/// <summary>
	/// Classe de provider usada para acessar a tabela principal do Repeater
	/// </summary>
	public class TB_HIST_EXECUCAO_ATIVIDADERepeaterDataProvider : GeneralListControlProvider
	{
		public long projetoField;
		public int itemProjetoField;
		public int itemProcessoField;
		public DateTime dataLancamentoField;
		public int JustificativaField;
		public double percentualExecutadoField;
		public string observacaoField;
		public string usuarioCadastroField;
		public DateTime dataCadastroField;

		#region GeneralDataListProvider Members

		private DBGERPROJETO_TB_HIST_EXECUCAO_ATIVIDADEDataProvider _DataProvider;
		
		public override GeneralDataProvider DataProvider
		{
			get
			{
				return _DataProvider;
			}
			set
			{
				_DataProvider = value as DBGERPROJETO_TB_HIST_EXECUCAO_ATIVIDADEDataProvider;
			}
		}

		public TB_HIST_EXECUCAO_ATIVIDADE_RepeaterPageProvider ParentPageProvider;
		
		public override string TableName { get { return "TB_HIST_EXECUCAO_ATIVIDADE"; } }

		public override string DatabaseName { get { return "DBGERPROJETO"; } }

		public override string FormID { get { return "32812"; } }
		
		/// <summary>
		/// Valida se todos os campos do DataList foram preenchidos corretamente
		/// </summary>
		/// <param name="provider">Provider que vai ser usado para carregar os itens da página</param>
		public override bool Validate(GeneralDataProviderItem ProviderItem)
		{
			return (ProviderItem.Errors.Count == 0);
		}		
		
		#endregion

		public TB_HIST_EXECUCAO_ATIVIDADERepeaterDataProvider(TB_HIST_EXECUCAO_ATIVIDADE_RepeaterPageProvider ParentProvider)
		{
			ParentPageProvider = ParentProvider;
			DataProvider = new DBGERPROJETO_TB_HIST_EXECUCAO_ATIVIDADEDataProvider(this, TableName, DatabaseName, "PK_TB_HIST_EXECUCAO_ATIVIDADE", "TB_HIST_EXECUCAO_ATIVIDADE");
			MainProvider = this;
			MainProvider.DataProvider.PageProvider = this;
		}

		public DBGERPROJETO_TB_HIST_EXECUCAO_ATIVIDADEItem GetDataProviderItem()
		{
			return GetDataProviderItem(MainProvider.DataProvider) as DBGERPROJETO_TB_HIST_EXECUCAO_ATIVIDADEItem;
		}

		public override GeneralDataProviderItem GetDataProviderItem(GeneralDataProvider Provider)
		{
			if (Provider.Name == "TB_HIST_EXECUCAO_ATIVIDADE")
			{
				return new DBGERPROJETO_TB_HIST_EXECUCAO_ATIVIDADEItem(DatabaseName);
			}
			return null;
		}
		
		public override void SetParametersValues(GeneralDataProvider Provider)
        {
            try
            {
            }
            catch
            {
            }
        }

		public override void InitializeAlias(GeneralDataProviderItem Item)
        {
		    if (AliasVariables == null)
            {
                AliasVariables = new Dictionary<string, object>();
            }

			projetoField = Convert.ToInt64(Item["projeto"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("projetoField"))
			{
				AliasVariables["projetoField"] = projetoField;
			}
			else
			{
				AliasVariables.Add("projetoField" ,projetoField);
			}
			itemProjetoField = Convert.ToInt32(Item["itemProjeto"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("itemProjetoField"))
			{
				AliasVariables["itemProjetoField"] = itemProjetoField;
			}
			else
			{
				AliasVariables.Add("itemProjetoField" ,itemProjetoField);
			}
			itemProcessoField = Convert.ToInt32(Item["itemProcesso"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("itemProcessoField"))
			{
				AliasVariables["itemProcessoField"] = itemProcessoField;
			}
			else
			{
				AliasVariables.Add("itemProcessoField" ,itemProcessoField);
			}
			dataLancamentoField = Convert.ToDateTime(Item["dataLancamento"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("dataLancamentoField"))
			{
				AliasVariables["dataLancamentoField"] = dataLancamentoField;
			}
			else
			{
				AliasVariables.Add("dataLancamentoField" ,dataLancamentoField);
			}
			JustificativaField = Convert.ToInt32(Item["Justificativa"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("JustificativaField"))
			{
				AliasVariables["JustificativaField"] = JustificativaField;
			}
			else
			{
				AliasVariables.Add("JustificativaField" ,JustificativaField);
			}
			percentualExecutadoField = Convert.ToDouble(Item["percentualExecutado"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("percentualExecutadoField"))
			{
				AliasVariables["percentualExecutadoField"] = percentualExecutadoField;
			}
			else
			{
				AliasVariables.Add("percentualExecutadoField" ,percentualExecutadoField);
			}
			observacaoField = Convert.ToString(Item["observacao"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("observacaoField"))
			{
				AliasVariables["observacaoField"] = observacaoField;
			}
			else
			{
				AliasVariables.Add("observacaoField" ,observacaoField);
			}
			usuarioCadastroField = Convert.ToString(Item["usuarioCadastro"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("usuarioCadastroField"))
			{
				AliasVariables["usuarioCadastroField"] = usuarioCadastroField;
			}
			else
			{
				AliasVariables.Add("usuarioCadastroField" ,usuarioCadastroField);
			}
			dataCadastroField = Convert.ToDateTime(Item["dataCadastro"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("dataCadastroField"))
			{
				AliasVariables["dataCadastroField"] = dataCadastroField;
			}
			else
			{
				AliasVariables.Add("dataCadastroField" ,dataCadastroField);
			}
		}
		
		public override void GetTableIdentity()
		{
		}


}
	}

}
