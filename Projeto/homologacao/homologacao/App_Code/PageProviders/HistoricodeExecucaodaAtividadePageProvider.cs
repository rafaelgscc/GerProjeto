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
	public class HistoricodeExecucaodaAtividadePageProvider : GeneralProvider
	{
		public DBGERPROJETO_TB_PROCESSOSDataProvider AUX_TB_HIST_EXECUCAO_ATIVIDADE_TB_PROCESSOSProvider;
		public List<RadComboBoxDataItem> cmbLancamentoItems
		{
			get
			{
				return new List<RadComboBoxDataItem>()
				{
					new RadComboBoxDataItem(HttpContext.GetLocalResourceObject(((Page)MainProvider).AppRelativeVirtualPath, "GComboBoxItem16").ToString(), "1"),
					new RadComboBoxDataItem(HttpContext.GetLocalResourceObject(((Page)MainProvider).AppRelativeVirtualPath, "GComboBoxItem17").ToString(), "2"),
					new RadComboBoxDataItem(HttpContext.GetLocalResourceObject(((Page)MainProvider).AppRelativeVirtualPath, "GComboBoxItem18").ToString(), "3"),
				};
			}
		}

		public HistoricodeExecucaodaAtividadePageProvider(IGeneralDataProvider Provider)
		{
			MainProvider = Provider;
			MainProvider.DataProvider = new DBGERPROJETO_TB_HIST_EXECUCAO_ATIVIDADEDataProvider(MainProvider, MainProvider.TableName, MainProvider.DatabaseName, "PK_TB_HIST_EXECUCAO_ATIVIDADE", "HistoricodeExecucaodaAtividade");
			MainProvider.DataProvider.PageProvider = this;
			AUX_TB_HIST_EXECUCAO_ATIVIDADE_TB_PROCESSOSProvider = new DBGERPROJETO_TB_PROCESSOSDataProvider(MainProvider, "TB_PROCESSOS", "DBGERPROJETO", "PK_TB_PROCESSOS", "AUX_TB_HIST_EXECUCAO_ATIVIDADE_TB_PROCESSOS");
		}

		public override GeneralDataProviderItem GetDataProviderItem(GeneralDataProvider Provider)
		{
			if (Provider == MainProvider.DataProvider)
			{ 
				return new DBGERPROJETO_TB_HIST_EXECUCAO_ATIVIDADEItem(MainProvider.DatabaseName);
			}
			else if (Provider.Name == "AUX_TB_HIST_EXECUCAO_ATIVIDADE_TB_PROCESSOS")
			{
				return new DBGERPROJETO_TB_PROCESSOSItem("DBGERPROJETOSystem.Collections.ObjectModel.ObservableCollection`1[GAS.TableField]");
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
			MainProvider.SetParametersValues(AUX_TB_HIST_EXECUCAO_ATIVIDADE_TB_PROCESSOSProvider);
			AUX_TB_HIST_EXECUCAO_ATIVIDADE_TB_PROCESSOSProvider.Dao = MainProvider.DataProvider.Dao;
			AUX_TB_HIST_EXECUCAO_ATIVIDADE_TB_PROCESSOSProvider.SelectItem(1, FormPositioningEnum.First,true);
		}

		public override int GetMaxProcessLanc()
		{
			return 2;
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
			if (AUX_TB_HIST_EXECUCAO_ATIVIDADE_TB_PROCESSOSProvider.PageNumber > 0 && (ProcessName == "ExecucaoAtividade" || (AllProcess && Pos == 1)))
			{
				RawValue = Utility.FixValue<double>(MainProvider.DataProvider.Item["percentualExecutado"].GetValue());
				AUX_TB_HIST_EXECUCAO_ATIVIDADE_TB_PROCESSOSProvider.Item["percentualExecutado"].SetValue(RawValue);
				ValueField = AUX_TB_HIST_EXECUCAO_ATIVIDADE_TB_PROCESSOSProvider.Dao.ToSql(AUX_TB_HIST_EXECUCAO_ATIVIDADE_TB_PROCESSOSProvider.Item["percentualExecutado"].GetFormattedValue() ,FieldType.Decimal);
				RelationField = AUX_TB_HIST_EXECUCAO_ATIVIDADE_TB_PROCESSOSProvider.ProviderFilterExpression();
				Process ExecucaoAtividade= new Process(AUX_TB_HIST_EXECUCAO_ATIVIDADE_TB_PROCESSOSProvider.Dao.PoeColAspas("TB_PROCESSOS"),AUX_TB_HIST_EXECUCAO_ATIVIDADE_TB_PROCESSOSProvider.Dao.PoeColAspas("percentualExecutado"), ValueField, RelationField,1,false);
				Process.Add("ExecucaoAtividade546111", ExecucaoAtividade);
			}
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
		public override GeneralDataProviderItem GetComboItem(GeneralDataProvider Provider, string Value)
		{
			try
			{
				var Dao = Provider.Dao;
			}
			catch
			{
			}
			return null;
		}
		
		public bool FillCombo(GeneralDataProvider Provider, RadComboBox ComboBox, int NumberOfItems, string TextFilter, bool AllowFilter)
		{
			return FillCombo(Provider, ComboBox, NumberOfItems, TextFilter, AllowFilter, null);
		}
		
		public bool FillCombo(GeneralDataProvider Provider, RadComboBox ComboBox, int NumberOfItems, string TextFilter, bool AllowFilter, Dictionary<string, object> ClientFields)
		{
			try
			{
				var Dao = Provider.Dao;
			}
			catch
			{
			}
			return false;
		}
		
		public bool FillCombo(List<RadComboBoxDataItem> ComboBoxDataItem, RadComboBox ComboBox, int NumberOfItems, string TextFilter, bool AllowFilter)
		{
			if (AllowFilter && !String.IsNullOrEmpty(TextFilter))
			{
				return Utility.FillComboBoxItems(ComboBox, 15, ComboBoxDataItem.FindAll(c => c.Text.ToLower().Contains(TextFilter.ToLower())));
			}
			return Utility.FillComboBoxItems(ComboBox, 15, ComboBoxDataItem);
		}



		/// <summary>
		/// Valida se todos os campos foram preenchidos corretamente
		/// </summary>
		/// <param name="provider">Provider que vai ser usado para carregar os itens da p?gina</param>
		public override bool Validate(GeneralDataProviderItem ProviderItem)
		{
			bool Accepted = false;
			try
			{
				Accepted =(ServerValidation.CheckNotEmpty(AliasVariables["dataLancamentoField"]));
			}
			catch (Exception)
			{
				Accepted = false;
			}
			if (!Accepted) { ProviderItem.Errors.Add("ServerValidationError:dtExecutado", "Executado em não pode ser vazio!");}
			try
			{
				Accepted =(ServerValidation.CheckNotEmpty(AliasVariables["dataCadastroField"]));
			}
			catch (Exception)
			{
				Accepted = false;
			}
			if (!Accepted) { ProviderItem.Errors.Add("ServerValidationError:DatePicker2", "Data do Cadastro não pode ser vazio!");}
			return (ProviderItem.Errors.Count == 0);
		}
		


	}

}
