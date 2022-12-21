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
	public class CadastroDeDiretrizPageProvider : GeneralProvider
	{
		public DBGERPROJETO_TB_DIRETORIADataProvider ComboBox4Provider;
		public DBGERPROJETO_TB_SETORIALDataProvider ComboBox6Provider;
		public DBGERPROJETO_TB_COORDENACAODataProvider ComboBox7Provider;
		public DBGERPROJETO_TBV_ANODataProvider ComboBox8Provider;
		public List<RadComboBoxDataItem> ComboBox1Items
		{
			get
			{
				return new List<RadComboBoxDataItem>()
				{
					new RadComboBoxDataItem(HttpContext.GetLocalResourceObject(((Page)MainProvider).AppRelativeVirtualPath, "SIM").ToString(), "SIM"),
					new RadComboBoxDataItem(HttpContext.GetLocalResourceObject(((Page)MainProvider).AppRelativeVirtualPath, "NAO").ToString(), "NÃO"),
				};
			}
		}
		public List<RadComboBoxDataItem> ComboBox2Items
		{
			get
			{
				return new List<RadComboBoxDataItem>()
				{
					new RadComboBoxDataItem(HttpContext.GetLocalResourceObject(((Page)MainProvider).AppRelativeVirtualPath, "GComboBoxItem24").ToString(), "ATIVO"),
					new RadComboBoxDataItem(HttpContext.GetLocalResourceObject(((Page)MainProvider).AppRelativeVirtualPath, "GComboBoxItem25").ToString(), "SUSPENSO"),
				};
			}
		}
		
		public List<RadComboBoxDataItem> ComboBox3Items
		{
			get
			{
				return new List<RadComboBoxDataItem>()
				{
					new RadComboBoxDataItem(HttpContext.GetLocalResourceObject(((Page)MainProvider).AppRelativeVirtualPath, "GComboBoxItem1").ToString(), "E"),
					new RadComboBoxDataItem(HttpContext.GetLocalResourceObject(((Page)MainProvider).AppRelativeVirtualPath, "GComboBoxItem2").ToString(), "T"),
					new RadComboBoxDataItem(HttpContext.GetLocalResourceObject(((Page)MainProvider).AppRelativeVirtualPath, "GComboBoxItem3").ToString(), "I"),
				};
			}
		}
		

		public CadastroDeDiretrizPageProvider(IGeneralDataProvider Provider)
		{
			MainProvider = Provider;
			MainProvider.DataProvider = new DBGERPROJETO_TB_PROJETODataProvider(MainProvider, MainProvider.TableName, MainProvider.DatabaseName, "PK_TB_PROJETO", "CadastroDeDiretriz");
			MainProvider.DataProvider.PageProvider = this;
			ComboBox4Provider = new DBGERPROJETO_TB_DIRETORIADataProvider(MainProvider, "TB_DIRETORIA", "DBGERPROJETO", "", "CadastroDeDiretriz_ComboBox4ProviderAlias");
			ComboBox4Provider.PageProvider = this;
			ComboBox4Provider.CreatingParameters += GeneralDataProvider.GeneralCreatingParameters;
			ComboBox6Provider = new DBGERPROJETO_TB_SETORIALDataProvider(MainProvider, "TB_SETORIAL", "DBGERPROJETO", "", "CadastroDeDiretriz_ComboBox6ProviderAlias");
			ComboBox6Provider.PageProvider = this;
			ComboBox6Provider.CreatingParameters += GeneralDataProvider.GeneralCreatingParameters;
			ComboBox7Provider = new DBGERPROJETO_TB_COORDENACAODataProvider(MainProvider, "TB_COORDENACAO", "DBGERPROJETO", "", "CadastroDeDiretriz_ComboBox7ProviderAlias");
			ComboBox7Provider.PageProvider = this;
			ComboBox7Provider.CreatingParameters += GeneralDataProvider.GeneralCreatingParameters;
			ComboBox8Provider = new DBGERPROJETO_TBV_ANODataProvider(MainProvider, "DBGERPROJETO_TBV_ANO.json", "DBGERPROJETO", "", "CadastroDeDiretriz_ComboBox8ProviderAlias");
		}

		public override GeneralDataProviderItem GetDataProviderItem(GeneralDataProvider Provider)
		{
			if (Provider == MainProvider.DataProvider)
			{ 
				return new DBGERPROJETO_TB_PROJETOItem(MainProvider.DatabaseName);
			}
			if (Provider == ComboBox4Provider)
			{
				return new DBGERPROJETO_TB_DIRETORIAItem(Provider.DataBaseName, "siglaDiretoria");
			}
			else if (Provider == ComboBox6Provider)
			{
				return new DBGERPROJETO_TB_SETORIALItem(Provider.DataBaseName, "siglaSetorial");
			}
			else if (Provider == ComboBox7Provider)
			{
				return new DBGERPROJETO_TB_COORDENACAOItem(Provider.DataBaseName, "siglaCoordenacao");
			}
			else if (Provider == ComboBox8Provider)
			{
				return new DBGERPROJETO_TBV_ANOItem(Provider.DataBaseName, "ano");
			}
			return null;
		}

		public override string GetItemText(GeneralDataProvider Provider, GeneralDataProviderItem Item)
		{
			if (Provider == ComboBox4Provider)
			{
				return Item["siglaDiretoria"].GetValue().ToString();
			}
			else if (Provider == ComboBox6Provider)
			{
				return Item["siglaSetorial"].GetValue().ToString();
			}
			else if (Provider == ComboBox7Provider)
			{
				return Item["siglaCoordenacao"].GetValue().ToString();
			}
			else if (Provider == ComboBox8Provider)
			{
				return Item["ano"].GetValue().ToString();
			}
		return "";
		}
		
		public override object GetItemValue(GeneralDataProvider Provider, GeneralDataProviderItem Item)
		{
			if (Provider == ComboBox4Provider)
			{
				return Item["siglaDiretoria"].GetValue();
			}
			else if (Provider == ComboBox6Provider)
			{
				return Item["siglaSetorial"].GetValue();
			}
			else if (Provider == ComboBox7Provider)
			{
				return Item["siglaCoordenacao"].GetValue();
			}
			else if (Provider == ComboBox8Provider)
			{
				return Item["ano"].GetValue();
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
			MainProvider.DataProvider.FindRecord("PK_TB_PROJETO", false,new string[] { MainProvider.DataProvider.Dao.GetIdentity(MainProvider.TableName , "codigo") });
		}

		public override string CreateProcessBeforeInsert(string FieldName)
		{
			if(FieldName == "DiasDeProjeto")
			{
				if(((ServerValidation.CheckNotEmpty(AliasVariables["inicioPrevistoField"])) && ServerValidation.CheckNotEmpty(AliasVariables["terminoPrevistoField"])) && (DateTime)MainProvider.DataProvider.Item["terminoPrevisto"].GetValue() >= (DateTime)MainProvider.DataProvider.Item["inicioPrevisto"].GetValue())
				{
					return MainProvider.DataProvider.Dao.ToSql(new LongField("",DiferencaDeData()).GetFormattedValue(""),FieldType.Long);
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
				if (Provider == ComboBox4Provider && !string.IsNullOrEmpty(Value))
				{
					Provider.FindRecord(new Dictionary<string, object>() { { "siglaDiretoria", Value } });
					return Provider.Item;
				}
			
				else if (Provider == ComboBox6Provider && !string.IsNullOrEmpty(Value))
				{
					Provider.FindRecord(new Dictionary<string, object>() { { "siglaSetorial", Value } });
					return Provider.Item;
				}
			
				else if (Provider == ComboBox7Provider && !string.IsNullOrEmpty(Value))
				{
					Provider.FindRecord(new Dictionary<string, object>() { { "siglaCoordenacao", Value } });
					return Provider.Item;
				}
			
				else if (Provider == ComboBox8Provider && !string.IsNullOrEmpty(Value))
				{
					Provider.FindRecord(new Dictionary<string, object>() { { "ano", Value } });
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
				if (Provider == ComboBox4Provider)
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
				else if (Provider == ComboBox6Provider)
				{
					if (AllowFilter)
					{
						Provider.FiltroAtual = TextFilter;
						Provider.FilterFields = "siglaSetorial";
					}
					try
					{
						Provider.OrderBy = Provider.Dao.PoeColAspas("siglaSetorial");
					}
					catch { }
					int Total;
					var data = Provider.SelectItems(0, 100, out Total);
					var dt = Utility.FillComboBoxItems(ComboBox, 100, data, "siglaSetorial", " siglaSetorial", false);
					return Total > 0;
				}
				else if (Provider == ComboBox7Provider)
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
				else if (Provider == ComboBox8Provider)
				{
					if (AllowFilter)
					{
						Provider.FiltroAtual = TextFilter;
						Provider.FilterFields = "ano";
					}
					int Total;
					var data = Provider.SelectItems(0, 100, out Total);
					var dt = Utility.FillComboBoxItems(ComboBox, 100, data, "ano", " ano", false);
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
				Accepted =(ServerValidation.CheckNotEmpty(AliasVariables["nomeProjetoField"]));
			}
			catch (Exception)
			{
				Accepted = false;
			}
			if (!Accepted) { ProviderItem.Errors.Add("ServerValidationError:RadTextBox2", "Nome do Projeto não pode ser vazio!");}
			try
			{
				Accepted =(ServerValidation.CheckNotEmpty(AliasVariables["siglaDiretoriaField"]));
			}
			catch (Exception)
			{
				Accepted = false;
			}
			if (!Accepted) { ProviderItem.Errors.Add("ServerValidationError:ComboBox4", "Sigla da Diretoria não pode ser vazio!");}
			try
			{
				Accepted =(ServerValidation.CheckNotEmpty(AliasVariables["siglaCoordenacaoField"]));
			}
			catch (Exception)
			{
				Accepted = false;
			}
			if (!Accepted) { ProviderItem.Errors.Add("ServerValidationError:ComboBox7", "Coordenação não pode ser vazio!");}
			try
			{
				Accepted =(ServerValidation.CheckNotEmpty(AliasVariables["DiretrizField"]));
			}
			catch (Exception)
			{
				Accepted = false;
			}
			if (!Accepted) { ProviderItem.Errors.Add("ServerValidationError:ComboBox1", "Diretriz não pode ser vazio!");}
			try
			{
				Accepted =(ServerValidation.CheckNotEmpty(AliasVariables["nivelProjetoField"]));
			}
			catch (Exception)
			{
				Accepted = false;
			}
			if (!Accepted) { ProviderItem.Errors.Add("ServerValidationError:ComboBox3", "Nível não pode ser vazio!");}
			try
			{
				Accepted =(ServerValidation.CheckNotEmpty(AliasVariables["statusProjetoField"]));
			}
			catch (Exception)
			{
				Accepted = false;
			}
			if (!Accepted) { ProviderItem.Errors.Add("ServerValidationError:ComboBox2", "Status do Projeto não pode ser vazio!");}
			try
			{
				Accepted =(ServerValidation.CheckNotEmpty(AliasVariables["usuarioCadastroField"]));
			}
			catch (Exception)
			{
				Accepted = false;
			}
			if (!Accepted) { ProviderItem.Errors.Add("ServerValidationError:RadTextBox3", "Cadastrado por não pode ser vazio!");}
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
		
		private int DiferencaDeData()
			// Rotina para cálculo de dias do projeto, baseado na data de início previsto com a data de fim previsto
		{
			TimeSpan Diferenca = (Convert.ToDateTime(AliasVariables["terminoPrevistoField"].ToString()) - Convert.ToDateTime(AliasVariables["inicioPrevistoField"].ToString()));
			return Diferenca.Days;
		}

	}

}
