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
	public class TB_ITENS_PROJETOPageProvider : GeneralProvider
	{
		public DBGERPROJETO_TB_RESPONSAVELDataProvider ComboBox1Provider;
		public DBGERPROJETO_TB_RESPONSAVELDataProvider ComboBox2Provider;
		public DBGERPROJETO_TB_COORDENACAODataProvider cmbSiglaCoordenacaoProvider;
		public DBGERPROJETO_TB_SETORIALDataProvider ComboBox4Provider;
		public DBGERPROJETO_TBV_STATUS_ACAODataProvider ComboBox5Provider;

		public TB_ITENS_PROJETOPageProvider(IGeneralDataProvider Provider)
		{
			MainProvider = Provider;
			MainProvider.DataProvider = new DBGERPROJETO_TB_ITENS_PROJETODataProvider(MainProvider, MainProvider.TableName, MainProvider.DatabaseName, "PK_TB_ITENS_PROJETO", "TB_ITENS_PROJETO");
			MainProvider.DataProvider.PageProvider = this;
			ComboBox1Provider = new DBGERPROJETO_TB_RESPONSAVELDataProvider(MainProvider, "TB_RESPONSAVEL", "DBGERPROJETO", "", "TB_ITENS_PROJETO_ComboBox1ProviderAlias");
			ComboBox1Provider.PageProvider = this;
			ComboBox1Provider.CreatingParameters += GeneralDataProvider.GeneralCreatingParameters;
			ComboBox2Provider = new DBGERPROJETO_TB_RESPONSAVELDataProvider(MainProvider, "TB_RESPONSAVEL", "DBGERPROJETO", "", "TB_ITENS_PROJETO_ComboBox2ProviderAlias");
			ComboBox2Provider.PageProvider = this;
			ComboBox2Provider.CreatingParameters += GeneralDataProvider.GeneralCreatingParameters;
			cmbSiglaCoordenacaoProvider = new DBGERPROJETO_TB_COORDENACAODataProvider(MainProvider, "TB_COORDENACAO", "DBGERPROJETO", "", "TB_ITENS_PROJETO_cmbSiglaCoordenacaoProviderAlias");
			cmbSiglaCoordenacaoProvider.PageProvider = this;
			cmbSiglaCoordenacaoProvider.CreatingParameters += GeneralDataProvider.GeneralCreatingParameters;
			ComboBox4Provider = new DBGERPROJETO_TB_SETORIALDataProvider(MainProvider, "TB_SETORIAL", "DBGERPROJETO", "", "TB_ITENS_PROJETO_ComboBox4ProviderAlias");
			ComboBox4Provider.PageProvider = this;
			ComboBox4Provider.CreatingParameters += GeneralDataProvider.GeneralCreatingParameters;
			ComboBox5Provider = new DBGERPROJETO_TBV_STATUS_ACAODataProvider(MainProvider, "DBGERPROJETO_TBV_STATUS_ACAO.json", "DBGERPROJETO", "", "TB_ITENS_PROJETO_ComboBox5ProviderAlias");
		}

		public override GeneralDataProviderItem GetDataProviderItem(GeneralDataProvider Provider)
		{
			if (Provider == MainProvider.DataProvider)
			{ 
				return new DBGERPROJETO_TB_ITENS_PROJETOItem(MainProvider.DatabaseName);
			}
			if (Provider == ComboBox1Provider)
			{
				return new DBGERPROJETO_TB_RESPONSAVELItem(Provider.DataBaseName, "nomeSobrenome");
			}
			else if (Provider == ComboBox2Provider)
			{
				return new DBGERPROJETO_TB_RESPONSAVELItem(Provider.DataBaseName, "nomeSobrenome");
			}
			else if (Provider == cmbSiglaCoordenacaoProvider)
			{
				return new DBGERPROJETO_TB_COORDENACAOItem(Provider.DataBaseName, "siglaCoordenacao");
			}
			else if (Provider == ComboBox4Provider)
			{
				return new DBGERPROJETO_TB_SETORIALItem(Provider.DataBaseName, "siglaSetorial");
			}
			else if (Provider == ComboBox5Provider)
			{
				return new DBGERPROJETO_TBV_STATUS_ACAOItem(Provider.DataBaseName, "acao");
			}
			return null;
		}

		public override string GetItemText(GeneralDataProvider Provider, GeneralDataProviderItem Item)
		{
			if (Provider == ComboBox1Provider)
			{
				return Item["nomeSobrenome"].GetValue().ToString();
			}
			else if (Provider == ComboBox2Provider)
			{
				return Item["nomeSobrenome"].GetValue().ToString();
			}
			else if (Provider == cmbSiglaCoordenacaoProvider)
			{
				return Item["siglaCoordenacao"].GetValue().ToString();
			}
			else if (Provider == ComboBox4Provider)
			{
				return Item["siglaSetorial"].GetValue().ToString();
			}
			else if (Provider == ComboBox5Provider)
			{
				return Item["acao"].GetValue().ToString();
			}
		return "";
		}
		
		public override object GetItemValue(GeneralDataProvider Provider, GeneralDataProviderItem Item)
		{
			if (Provider == ComboBox1Provider)
			{
				return Item["nomeSobrenome"].GetValue();
			}
			else if (Provider == ComboBox2Provider)
			{
				return Item["nomeSobrenome"].GetValue();
			}
			else if (Provider == cmbSiglaCoordenacaoProvider)
			{
				return Item["siglaCoordenacao"].GetValue();
			}
			else if (Provider == ComboBox4Provider)
			{
				return Item["siglaSetorial"].GetValue();
			}
			else if (Provider == ComboBox5Provider)
			{
				return Item["acao"].GetValue();
			}
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
			MainProvider.DataProvider.FindRecord("PK_TB_ITENS_PROJETO", false,new string[] { MainProvider.DataProvider.Item["projeto"].GetFormattedValue(),MainProvider.DataProvider.Item["itemProjeto"].GetFormattedValue() });
		}

		public override string CreateProcessBeforeInsert(string FieldName)
		{
			if(FieldName == "DiasPrevistos")
			{
				if(((ServerValidation.CheckNotEmpty(AliasVariables["inicioPrevistoField"])) && ServerValidation.CheckNotEmpty(AliasVariables["terminoPrevistoField"])) && (DateTime)MainProvider.DataProvider.Item["terminoPrevisto"].GetValue() >= (DateTime)MainProvider.DataProvider.Item["inicioPrevisto"].GetValue())
				{
					return MainProvider.DataProvider.Dao.ToSql(new IntegerField("",DiferencaPrevista()).GetFormattedValue(""),FieldType.Integer);
				}
			}
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
		public override GeneralDataProviderItem GetComboItem(GeneralDataProvider Provider, string Value)
		{
			try
			{
				var Dao = Provider.Dao;
				if (Provider == ComboBox1Provider && !string.IsNullOrEmpty(Value))
				{
					try
					{
						Provider.StartFilter = Provider.Dao.PoeColAspas("siglaCoordenacao") + " = " + Provider.Dao.ToSql(AliasVariables["siglaCoordenacaoField"].ToString(), FieldType.Text);
					}
					catch { }
					Provider.FindRecord(new Dictionary<string, object>() { { "nomeSobrenome", Value } });
					return Provider.Item;
				}
			
				else if (Provider == ComboBox2Provider && !string.IsNullOrEmpty(Value))
				{
					try
					{
						Provider.StartFilter = Provider.Dao.PoeColAspas("siglaCoordenacao") + " = " + Provider.Dao.ToSql(AliasVariables["siglaCoordenacaoField"].ToString(), FieldType.Text);
					}
					catch { }
					Provider.FindRecord(new Dictionary<string, object>() { { "nomeSobrenome", Value } });
					return Provider.Item;
				}
			
				else if (Provider == cmbSiglaCoordenacaoProvider && !string.IsNullOrEmpty(Value))
				{
					Provider.FindRecord(new Dictionary<string, object>() { { "siglaCoordenacao", Value } });
					return Provider.Item;
				}
			
				else if (Provider == ComboBox4Provider && !string.IsNullOrEmpty(Value))
				{
					Provider.FindRecord(new Dictionary<string, object>() { { "siglaSetorial", Value } });
					return Provider.Item;
				}
			
				else if (Provider == ComboBox5Provider && !string.IsNullOrEmpty(Value))
				{
					Provider.FindRecord(new Dictionary<string, object>() { { "acao", Value } });
					return Provider.Item;
				}
			
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
				if (Provider == ComboBox1Provider)
				{
					if (AllowFilter)
					{
						Provider.FiltroAtual = TextFilter;
						Provider.FilterFields = "nomeSobrenome";
					}
					try
					{
						Provider.StartFilter = Provider.Dao.PoeColAspas("siglaCoordenacao") + " = " + Provider.Dao.ToSql(ClientFields["cmbSiglaCoordenacao"].ToString(), FieldType.Text);
					}
					catch { }
					int Total;
					var data = Provider.SelectItems(0, 100, out Total);
					var dt = Utility.FillComboBoxItems(ComboBox, 100, data, "nomeSobrenome", " nomeSobrenome", false);
					return Total > 0;
				}
				else if (Provider == ComboBox2Provider)
				{
					if (AllowFilter)
					{
						Provider.FiltroAtual = TextFilter;
						Provider.FilterFields = "nomeSobrenome";
					}
					try
					{
						Provider.StartFilter = Provider.Dao.PoeColAspas("siglaCoordenacao") + " = " + Provider.Dao.ToSql(ClientFields["cmbSiglaCoordenacao"].ToString(), FieldType.Text);
					}
					catch { }
					int Total;
					var data = Provider.SelectItems(0, 100, out Total);
					var dt = Utility.FillComboBoxItems(ComboBox, 100, data, "nomeSobrenome", " nomeSobrenome", false);
					return Total > 0;
				}
				else if (Provider == cmbSiglaCoordenacaoProvider)
				{
					if (AllowFilter)
					{
						Provider.FiltroAtual = TextFilter;
						Provider.FilterFields = "siglaCoordenacao";
					}
					int Total;
					var data = Provider.SelectItems(0, 100, out Total);
					var dt = Utility.FillComboBoxItems(ComboBox, 100, data, "siglaCoordenacao", " siglaCoordenacao", false);
					return Total > 0;
				}
				else if (Provider == ComboBox4Provider)
				{
					if (AllowFilter)
					{
						Provider.FiltroAtual = TextFilter;
						Provider.FilterFields = "siglaSetorial";
					}
					int Total;
					var data = Provider.SelectItems(0, 100, out Total);
					var dt = Utility.FillComboBoxItems(ComboBox, 100, data, "siglaSetorial", " siglaSetorial", false);
					return Total > 0;
				}
				else if (Provider == ComboBox5Provider)
				{
					if (AllowFilter)
					{
						Provider.FiltroAtual = TextFilter;
						Provider.FilterFields = "acao";
					}
					int Total;
					var data = Provider.SelectItems(0, 100, out Total);
					var dt = Utility.FillComboBoxItems(ComboBox, 100, data, "acao", " acao", false);
					return Total > 0;
				}
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
				Accepted =(ServerValidation.CheckNotEmpty(AliasVariables["nomeAcaoField"]));
			}
			catch (Exception)
			{
				Accepted = false;
			}
			if (!Accepted) { ProviderItem.Errors.Add("ServerValidationError:RadTextBox3", "Nome da Ação não pode ser vazio!");}
			try
			{
				Accepted =(ServerValidation.CheckNotEmpty(AliasVariables["nomeSobrenomeField"]));
			}
			catch (Exception)
			{
				Accepted = false;
			}
			if (!Accepted) { ProviderItem.Errors.Add("ServerValidationError:ComboBox1", "Nome Sobrenome não pode ser vazio!");}
			try
			{
				Accepted =(ServerValidation.CheckNotEmpty(AliasVariables["itemProjetoField"]));
			}
			catch (Exception)
			{
				Accepted = false;
			}
			if (!Accepted) { ProviderItem.Errors.Add("ServerValidationError:txtItemProjeto", "Item do Projeto não pode ser vazio!");}
			try
			{
				Accepted =(ServerValidation.CheckNotEmpty(AliasVariables["usuarioCadastroField"]));
			}
			catch (Exception)
			{
				Accepted = false;
			}
			if (!Accepted) { ProviderItem.Errors.Add("ServerValidationError:RadTextBox7", "Cadastrado por não pode ser vazio!");}
			try
			{
				Accepted =(ServerValidation.CheckNotEmpty(AliasVariables["dataCadastroField"]));
			}
			catch (Exception)
			{
				Accepted = false;
			}
			if (!Accepted) { ProviderItem.Errors.Add("ServerValidationError:DatePicker4", "Data do Cadastro não pode ser vazio!");}
			try
			{
				Accepted =(ServerValidation.CheckNotEmpty(AliasVariables["projetoField"]));
			}
			catch (Exception)
			{
				Accepted = false;
			}
			if (!Accepted) { ProviderItem.Errors.Add("ServerValidationError:RadTextBox1", "Código do Projeto não pode ser vazio!");}
			return (ProviderItem.Errors.Count == 0);
		}
		
		private int DiferencaPrevista()
			// Rotina para cálculo de dias do projeto, baseado na data de início previsto com a data de fim previsto
		{
			TimeSpan Diferenca = (Convert.ToDateTime(AliasVariables["terminoPrevistoField"].ToString()) - Convert.ToDateTime(AliasVariables["inicioPrevistoField"].ToString()));
			return Diferenca.Days;
		}

	}

}
