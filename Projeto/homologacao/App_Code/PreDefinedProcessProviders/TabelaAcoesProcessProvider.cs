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

namespace PROJETO.DataProviders
{
	/// <summary>
	/// Classe de provider usada para a tabela auxiliar
	/// </summary>
	public class TabelaAcoesProcessProvider: GeneralProvider
	{
		public DBGERPROJETO_TB_ITENS_PROJETODataProvider DataProvider;
		
		public TabelaAcoesProcessProvider(IGeneralDataProvider Provider, string TableName, string DataBaseName)
		{
			MainProvider = Provider;
			DataProvider = new DBGERPROJETO_TB_ITENS_PROJETODataProvider(MainProvider, TableName, DataBaseName, "PK_TB_ITENS_PROJETO", "AtualizaAcao");
			DataProvider.PageProvider = this;
		}

		public override GeneralDataProviderItem GetDataProviderItem(GeneralDataProvider Provider)
		{
			return null;
		}

		public void ExecutePreDefinedProcess(Dictionary<string, GeneralDataProvider> AllParentItemsFromParent,Dictionary<string, object> AliasVariables, Dictionary<string, DataAccessObject> AllDaos)
		{
			DataProvider.Dao = AllDaos[DataProvider.DataBaseName];
			this.AliasVariables = AliasVariables;
			Dictionary<string, GeneralDataProvider> AllParentItems = null;
			List<GeneralDataProviderItem> Items;
            if (AllParentItemsFromParent != null)
            {
                AllParentItems = new Dictionary<string, GeneralDataProvider>(AllParentItemsFromParent);
            }
			if(AllParentItems == null)
			{
				AllParentItems = new Dictionary<string, GeneralDataProvider>();
			}
			AllParentItems.Add(DataProvider.Name, DataProvider);
			try
			{
				DataProvider.FiltroAtual = "";
				DataProvider.SelectCommand.OrderBy = "";
			}
			catch
			{
				DataProvider.FiltroAtual = "1 = 2";
			}
			DataProvider.CreateParameters();
			Items = DataProvider.SelectAllItems(true);
			foreach(GeneralDataProviderItem item in Items)
			{
				if (item != null)
				{
					DataProvider.Item = item;
					((TableCommand)DataProvider.SelectCommand).Parameters.Clear();
					foreach(ParameterStruct ps in DataProvider.Parameters.Values)
					{
						string paramformat = "";
						if (ps.Parameter is DateParameter)
						{
							paramformat = DataProvider.SelectCommand.DateFormat;
						}
						((TableCommand)DataProvider.SelectCommand).AddParameter(ps.Name, ps.Parameter, paramformat, DataProvider.Dao.PoeColAspas(ps.Name), Condition.Equal, false);
					}
					FillAuxiliarTables(AllParentItems);

				}
			}
		}

		public void FillAuxiliarTables(Dictionary<string, GeneralDataProvider> AllParentItems)
		{
		}
		
		public void SetParametersValues(GeneralDataProvider Provider, Dictionary<string, GeneralDataProvider> AllParentItems)
        {
        }
		

	}
}
