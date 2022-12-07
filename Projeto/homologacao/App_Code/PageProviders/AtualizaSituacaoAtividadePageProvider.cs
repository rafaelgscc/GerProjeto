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
	public class AtualizaSituacaoAtividadeProcessProvider : GeneralProvider
	{
		public TabelaAtividadesProcessProvider TabelaAtividadesPreDefProvider;

		public AtualizaSituacaoAtividadeProcessProvider(IGeneralDataProvider Provider)
		{
			MainProvider = Provider;
			TabelaAtividadesPreDefProvider = new TabelaAtividadesProcessProvider(MainProvider, "TB_PROCESSOS", "DBGERPROJETO");
		}

		public override GeneralDataProviderItem GetDataProviderItem(GeneralDataProvider Provider)
		{
			return null;
		}

		private DataAccessObject _DaoDBGERPROJETO;
		public DataAccessObject DaoDBGERPROJETO
		{
			get
			{
				if (_DaoDBGERPROJETO == null) _DaoDBGERPROJETO = Utility.GetDAO("DBGERPROJETO");
				return _DaoDBGERPROJETO;
			}
			set
			{
				_DaoDBGERPROJETO = value;
			}
		}
		
		public void ExecutePreDefinedProcess()
		{
			bool HasTransaction = false;
			try
			{
				Dictionary<string, DataAccessObject> allDaos = new Dictionary<string, DataAccessObject>();
				DaoDBGERPROJETO.OpenConnection();
				DaoDBGERPROJETO.BeginTrans();
				HasTransaction = true;
				allDaos.Add("DBGERPROJETO", DaoDBGERPROJETO);
				HttpContext.Current.Session["AllDaos"] = allDaos;
				TabelaAtividadesPreDefProvider.ExecutePreDefinedProcess(null, AliasVariables, allDaos);
				DaoDBGERPROJETO.CommitTrans();
				HttpContext.Current.Session.Remove("AllDaos");
			}
			catch (Exception ex)
			{
				HttpContext.Current.Session.Remove("AllDaos");
				if (HasTransaction)
				{
				DaoDBGERPROJETO.RollBack();
				}
				throw ex;
			}
		}

		public override void FillAuxiliarTables()
		{
		}
	}
}
