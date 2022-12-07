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
	public class CadastroCoordenacoesGeraisPageProvider : GeneralProvider
	{
		public DBGERPROJETO_TB_DIRETORIADataProvider ComboBox1Provider;
		public DBGERPROJETO_TB_RESPONSAVELDataProvider ComboBox2Provider;

		public CadastroCoordenacoesGeraisPageProvider(IGeneralDataProvider Provider)
		{
			MainProvider = Provider;
			MainProvider.DataProvider = new DBGERPROJETO_TB_COORDENACAODataProvider(MainProvider, MainProvider.TableName, MainProvider.DatabaseName, "PK_TB_COORDENACAO", "CadastroCoordenacoesGerais");
			MainProvider.DataProvider.PageProvider = this;
			ComboBox1Provider = new DBGERPROJETO_TB_DIRETORIADataProvider(MainProvider, "TB_DIRETORIA", "DBGERPROJETO", "", "CadastroCoordenacoesGerais_ComboBox1ProviderAlias");
			ComboBox1Provider.PageProvider = this;
			ComboBox1Provider.CreatingParameters += GeneralDataProvider.GeneralCreatingParameters;
			ComboBox2Provider = new DBGERPROJETO_TB_RESPONSAVELDataProvider(MainProvider, "TB_RESPONSAVEL", "DBGERPROJETO", "", "CadastroCoordenacoesGerais_ComboBox2ProviderAlias");
			ComboBox2Provider.PageProvider = this;
			ComboBox2Provider.CreatingParameters += GeneralDataProvider.GeneralCreatingParameters;
		}

		public override GeneralDataProviderItem GetDataProviderItem(GeneralDataProvider Provider)
		{
			if (Provider == MainProvider.DataProvider)
			{ 
				return new DBGERPROJETO_TB_COORDENACAOItem(MainProvider.DatabaseName);
			}
			if (Provider == ComboBox1Provider)
			{
				return new DBGERPROJETO_TB_DIRETORIAItem(Provider.DataBaseName, "siglaDiretoria");
			}
			else if (Provider == ComboBox2Provider)
			{
				return new DBGERPROJETO_TB_RESPONSAVELItem(Provider.DataBaseName, "nomeResponsavel", "nomeSobrenome");
			}
			return null;
		}

		public override string GetItemText(GeneralDataProvider Provider, GeneralDataProviderItem Item)
		{
			if (Provider == ComboBox1Provider)
			{
				return Item["siglaDiretoria"].GetValue().ToString();
			}
			else if (Provider == ComboBox2Provider)
			{
				return Item["nomeResponsavel"].GetValue().ToString();
			}
		return "";
		}
		
		public override object GetItemValue(GeneralDataProvider Provider, GeneralDataProviderItem Item)
		{
			if (Provider == ComboBox1Provider)
			{
				return Item["siglaDiretoria"].GetValue();
			}
			else if (Provider == ComboBox2Provider)
			{
				return Item["nomeSobrenome"].GetValue();
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
			MainProvider.DataProvider.FindRecord("PK_TB_COORDENACAO", false,new string[] { MainProvider.DataProvider.Dao.GetIdentity(MainProvider.TableName , "codigo") });
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
		public override GeneralDataProviderItem GetComboItem(GeneralDataProvider Provider, string Value)
		{
			try
			{
				var Dao = Provider.Dao;
				if (Provider == ComboBox1Provider && !string.IsNullOrEmpty(Value))
				{
					Provider.FindRecord(new Dictionary<string, object>() { { "siglaDiretoria", Value } });
					return Provider.Item;
				}
			
				else if (Provider == ComboBox2Provider && !string.IsNullOrEmpty(Value))
				{
					Provider.FindRecord(new Dictionary<string, object>() { { "nomeSobrenome", Value } });
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
						Provider.FilterFields = "siglaDiretoria";
					}
					int Total;
					var data = Provider.SelectItems(0, 100, out Total);
					var dt = Utility.FillComboBoxItems(ComboBox, 100, data, "siglaDiretoria", " siglaDiretoria", false);
					return Total > 0;
				}
				else if (Provider == ComboBox2Provider)
				{
					if (AllowFilter)
					{
						Provider.FiltroAtual = TextFilter;
						Provider.FilterFields = "nomeResponsavel";
					}
					int Total;
					var data = Provider.SelectItems(0, 100, out Total);
					var dt = Utility.FillComboBoxItems(ComboBox, 100, data, "nomeSobrenome", " nomeResponsavel", false);
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
				Accepted =(ServerValidation.CheckNotEmpty(AliasVariables["siglaDiretoriaField"]));
			}
			catch (Exception)
			{
				Accepted = false;
			}
			if (!Accepted) { ProviderItem.Errors.Add("ServerValidationError:ComboBox1", "Sigla da Diretoria não pode ser vazio!");}
			try
			{
				Accepted =(ServerValidation.CheckNotEmpty(AliasVariables["siglaCoordenacaoField"]));
			}
			catch (Exception)
			{
				Accepted = false;
			}
			if (!Accepted) { ProviderItem.Errors.Add("ServerValidationError:RadTextBox3", "Sigla da Coordenacao não pode ser vazio!");}
			try
			{
				Accepted =(ServerValidation.CheckNotEmpty(AliasVariables["nomeCoordenacaoField"]));
			}
			catch (Exception)
			{
				Accepted = false;
			}
			if (!Accepted) { ProviderItem.Errors.Add("ServerValidationError:RadTextBox4", "Nome da Coordenacao não pode ser vazio!");}
			try
			{
				Accepted =(ServerValidation.CheckNotEmpty(AliasVariables["usuarioCadastroField"]));
			}
			catch (Exception)
			{
				Accepted = false;
			}
			if (!Accepted) { ProviderItem.Errors.Add("ServerValidationError:RadTextBox6", "Cadastrado por não pode ser vazio!");}
			try
			{
				Accepted =(ServerValidation.CheckNotEmpty(AliasVariables["dataCadastroField"]));
			}
			catch (Exception)
			{
				Accepted = false;
			}
			if (!Accepted) { ProviderItem.Errors.Add("ServerValidationError:DatePicker1", "Data do Cadastro não pode ser vazio!");}
			return (ProviderItem.Errors.Count == 0);
		}
		


	}

}
