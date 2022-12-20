using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Collections.Generic;
using PROJETO;
using COMPONENTS.Security;
using COMPONENTS.Configuration;
using System.IO;
using System.Web.UI;
using COMPONENTS.Data;
using PROJETO.DataProviders;

namespace PROJETO
{

	/// <summary>
	/// Classe que executa Processs e lançamentos
	/// </summary>
	public static class DataProcessEntry
	{
		/// <summary>
		/// executa um unico Process
		/// </summary>
		/// <param name="vgTabelAlvo">Tabela alvo do Process</param>
		/// <param name="vgCampoAlvo">Campo alvo do Process</param>
		/// <param name="vgValor">Valor a ser colocado</param>
		/// <param name="vgCampoRelacao">Campo com relaçao ao campo que recebeu o Process</param>
		/// <param name="Dao">Classe de dados usada para fazer o Process</param>
		static public void ExecuteProcess(string vgTabelAlvo, string vgCampoAlvo, string vgValor, string vgCampoRelacao, DataAccessObject Dao)
		{
			List<Process> Proclist = new List<Process>();
			Proclist.Add(new Process(vgTabelAlvo, vgCampoAlvo, vgValor, vgCampoRelacao));
			ExecuteProcess(Proclist, Dao);
		}
		/// <summary>
		/// Executa varios Processs ao mesmo tempo
		/// </summary>
		/// <param name="vgProcesss">Um array com varios Processs</param>
		/// <param name="Dao">Classe de dados usada para fazer o Process</param>
		static public void ExecuteProcess(List<Process> vgProcesss, DataAccessObject Dao)
		{
			string vgSql = "Update " + vgProcesss[0].TabelaAlvo + " set ";
			string RelationFields = vgProcesss[0].CampoRelacao;
			string TabelaAlvo = vgProcesss[0].TabelaAlvo;
			Hashtable Images = new Hashtable();

			foreach (Process vgProcess in vgProcesss)
			{
				if (TabelaAlvo.ToUpper() != vgProcess.TabelaAlvo.ToUpper())
				{
					vgSql = vgSql.Trim(' ').Trim(',') + " WHERE " + RelationFields;//  vgProcesss[0].CampoRelacao;
					Dao.ExecuteNonQuery(vgSql);

					vgSql = "Update " + vgProcess.TabelaAlvo + " set ";
					TabelaAlvo = vgProcess.TabelaAlvo;
					RelationFields = vgProcess.CampoRelacao;
				}

				if (vgProcess.Valor.GetType() == typeof(byte[]))
				{
					vgSql += vgProcess.CampoAlvo + " = " + Dao.ParameterDelimiter + Utility.PoeUnderLines(vgProcess.CampoAlvo).ToUpper() + ", ";
					Images.Add(Utility.PoeUnderLines(vgProcess.CampoAlvo).ToUpper(), (byte[])vgProcess.Valor);
				}
				else if(vgProcess.Valor.GetType() == typeof(DBNull))
				{
					vgSql += vgProcess.CampoAlvo + " = NULL, ";
				}
				else if (vgProcess.Valor.GetType() == typeof(Double) || vgProcess.Valor.GetType() == typeof(Single) || vgProcess.Valor.GetType() == typeof(Decimal))
				{
					vgSql += vgProcess.CampoAlvo + " = " + vgProcess.Valor.ToString().Replace(",",".") + ", ";
				}
				else
				{
					vgSql += vgProcess.CampoAlvo + " = " + vgProcess.Valor + ", ";
				}
			}
			if (string.IsNullOrEmpty(RelationFields))
			{
				vgSql = vgSql.Trim(' ').Trim(',');
			}
			else
			{
				vgSql = vgSql.Trim(' ').Trim(',') + " WHERE " + RelationFields;//  vgProcesss[0].CampoRelacao;
			}

			try
			{
				if (Images.Count == 0)
				{
					Dao.ExecuteNonQuery(vgSql);
				}
				else
				{
					Dao.ExecuteNonQuery(vgSql, Images);
				}
			}
			catch (Exception e)
			{
				throw e;
			}
		}
		/// <summary>
		/// Lançamento que faz insert em outra tabela
		/// </summary>
		/// <param name="vgEntryItems">Array de EntryItems a serem feitos</param>
		/// <param name="Dao">Classe de dados usada para fazer o lançamento</param>
		static public void ExecuteInsertEntry(List<EntryItem> vgEntryItems, DataAccessObject Dao)
		{
			string vgSql = "Insert into " + Dao.PoeColAspas(vgEntryItems[0].TabelaAlvo) + " ";
			string vgCampos = "(";
			string vgValores = " VALUES (";
			Hashtable Images = new Hashtable();
			foreach (EntryItem vgEntryItem in vgEntryItems)
			{
				vgCampos += Dao.PoeColAspas(vgEntryItem.CampoAlvo) + ", ";
				if (vgEntryItem.Valor.GetType() == typeof(byte[]))
				{
					vgValores += Dao.ParameterDelimiter + Utility.PoeUnderLines(vgEntryItem.CampoAlvo).ToUpper() + ", ";
					Images.Add(Utility.PoeUnderLines(vgEntryItem.CampoAlvo).ToUpper(), (byte[])vgEntryItem.Valor);
				}
				else if(vgEntryItem.Valor.GetType() == typeof(DBNull))
				{
					vgValores += "NULL, ";
				}
				else
				{
					vgValores += vgEntryItem.Valor + ", ";
				}
			}
			vgCampos = vgCampos.TrimEnd(' ').TrimEnd(',') + ")";
			vgValores = vgValores.TrimEnd(' ').TrimEnd(',') + ")";
			vgSql += vgCampos + vgValores;
			try
			{
				if(Images.Count == 0)
				{
					Dao.ExecuteNonQuery(vgSql);
				}
				else
				{
					Dao.ExecuteNonQuery(vgSql, Images);
				}
			}
			catch (Exception e)
			{
				throw e;
			}
		}
		/// <summary>
		/// Lançamento que faz update em outra tabela que ja havia recebido um lançamento
		/// </summary>
		/// <param name="vgEntryItems">Array de EntryItems a serem feitos</param>
		/// <param name="vgCodLan">Codigo do lançamento feito anteriormente</param>
		/// <param name="Dao">Classe de dados usada para fazer o lançamento</param>
		static public void ExecuteUpdateEntry(List<EntryItem> vgEntryItems, string vgCodLan, DataAccessObject Dao, string CodLanField)
		{
			string vgSql = "Update " + vgEntryItems[0].TabelaAlvo + " set ";
			Hashtable Images = new Hashtable(); 
			foreach (EntryItem vgEntryItem in vgEntryItems)
			{
				if (vgEntryItem.Valor.GetType() == typeof(byte[]))
				{
					vgSql += vgEntryItem.CampoAlvo + " = " + Dao.ParameterDelimiter + Utility.PoeUnderLines(vgEntryItem.CampoAlvo).ToUpper() + ", ";
					Images.Add(Utility.PoeUnderLines(vgEntryItem.CampoAlvo).ToUpper(), (byte[])vgEntryItem.Valor);
				}
				else if(vgEntryItem.Valor.GetType() == typeof(DBNull))
				{
					vgSql += vgEntryItem.CampoAlvo + " = NULL, ";
				}
				else
				{
					vgSql += vgEntryItem.CampoAlvo + " = " + vgEntryItem.Valor + ", ";
				}
			}
			vgSql = vgSql.TrimEnd(' ').TrimEnd(',') + " where " + Dao.PoeColAspas(CodLanField) + " = " + vgCodLan;
			try
			{
				if (Images.Count == 0)
				{
					Dao.ExecuteNonQuery(vgSql);
				}
				else
				{
					Dao.ExecuteNonQuery(vgSql, Images);
				}
			}
			catch (Exception e)
			{
				throw e;
			}
		}
		/// <summary>
		/// Lançamento que faz Delete em outra tabela que ja havia recebido um lançamento
		/// </summary>
		/// <param name="vgEntryItems">Array de EntryItems a serem feitos</param>
		/// <param name="vgCodLan">Codigo do lançamento feito anteriormente</param>
		/// <param name="Dao">Classe de dados usada para fazer o lançamento</param>
		static public void ExecuteDeleteEntry(string vgTabelaAlvo, string vgCodLan, DataAccessObject Dao, string CodLanField)
		{
			string vgSql = "Delete from " + vgTabelaAlvo + " where " + Dao.PoeColAspas(CodLanField) + " = " + vgCodLan;

			try
			{
				Dao.ExecuteNonQuery(vgSql);
			}
			catch (Exception e)
			{
				throw e;
			}
		}
	}

	/// <summary>
	/// Classe que representa um Process
	/// </summary>
	public class Process
	{
		private string _TabelAlvo;
		private string _CampoAlvo;
		private object _Valor;
		private string _CampoRelacao;
		private List<Process> _Processs = new List<Process>();
		private int _Position;
		private bool _BeforeUpdate;

		/// <summary>
		/// Cria a string sql
		/// </summary>
		/// <returns>retorna a string sql para ser feito um update</returns>
		public string FormaSqlString()
		{
			return "Update " + TabelaAlvo + " set " + CampoAlvo + " = " + Valor + " where " + CampoRelacao;
		}
		/// <summary>
		/// recebe tudo que é necessario em um Process
		/// </summary>
		/// <param name="vgTabelAlvo">Tabela alvo</param>
		/// <param name="vgCampoAlvo">Campo alvo</param>
		/// <param name="vgValor">Valor a ser colocado</param>
		/// <param name="vgCampoRelacao">Campo com relação ao campo alvo</param>
		public Process(string vgTabelAlvo, string vgCampoAlvo, object vgValor, string vgCampoRelacao, int Position, bool BeforeUpdate)
		{
			_TabelAlvo = vgTabelAlvo;
			_CampoAlvo = vgCampoAlvo;
			_Valor = vgValor;
			_CampoRelacao = vgCampoRelacao;
			_Position = Position;
			_BeforeUpdate = BeforeUpdate;
			_Processs.Add(this);
		}

		public Process(string vgTabelAlvo, string vgCampoAlvo, object vgValor, string vgCampoRelacao)
			: this(vgTabelAlvo, vgCampoAlvo, vgValor, vgCampoRelacao, 0, false)
		{

		}

		public Process(string vgTabelAlvo, string vgCampoAlvo, object vgValor, string vgCampoRelacao, int Position)
			: this(vgTabelAlvo, vgCampoAlvo, vgValor, vgCampoRelacao, Position, false)
		{

		}

		public bool BeforeUpdate
		{
			get { return _BeforeUpdate; }
			set { _BeforeUpdate = value; }
		}

		public int Position
		{
			get { return _Position; }
			set { _Position = value; }
		}

		public List<Process> Processs
		{
			get { return _Processs; }
			set { _Processs = value; }
		}

		/// <summary>
		/// Propriedade da tabela alvo
		/// </summary>
		public string TabelaAlvo
		{
			get
			{
				return _TabelAlvo;
			}
			set
			{
				_TabelAlvo = value;
			}
		}
		/// <summary>
		/// Propriedade do campo alvo
		/// </summary>
		public string CampoAlvo
		{
			get
			{
				return _CampoAlvo;
			}
			set
			{
				_CampoAlvo = value;
			}
		}
		/// <summary>
		/// Propriedade com o valor a ser usado
		/// </summary>
		public object Valor
		{
			get
			{
				return _Valor;
			}
			set
			{
				_Valor = value;
			}
		}
		/// <summary>
		/// prorpiedade com o campo com relação ao campo alvo
		/// </summary>
		public string CampoRelacao
		{
			get
			{
				return _CampoRelacao;
			}
			set
			{
				_CampoRelacao = value;
			}
		}
	}
	public class Entry
	{
		private List<EntryItem> _EntryItems = new List<EntryItem>();

		public List<EntryItem> EntryItems
		{
			get { return _EntryItems; }
			set { _EntryItems = value; }
		}

		private string _Table;
		private int _NumberEntries;
		private int _EntryId;
		private string _Title;
		private string _CodLanField;
		private GeneralDataProvider _Provider;
		private int _Position;
		private bool _ExcludeEntry;

		public int Position
		{
			get { return _Position; }
			set { _Position = value; }
		}

		public GeneralDataProvider Provider
		{
			get { return _Provider; }
			set { _Provider = value; }
		}

		public string CodLanField
		{
			get { return _CodLanField; }
			set { _CodLanField = value; }
		}
		public string Table
		{
			get { return _Table; }
			private set { _Table = value; }
		}

		public int NumberEntries
		{
			get { return _NumberEntries; }
			private set { _NumberEntries = value; }
		}

		public int EntryId
		{
			get { return _EntryId; }
			private set { _EntryId = value; }
		}

		public string Title
		{
			get { return _Title; }
			private set { _Title = value; }
		}
		
		public bool ExcludeEntry
		{
			get { return _ExcludeEntry; }
			private set { _ExcludeEntry = value; }
		}

		public bool EntryControlCustomized { get; set; }

		public string EntryCustomKey { get; set; }

		public string EntryCustomId { get; set; }

		public string EntryControlId
		{
			get
			{
				if (EntryControlCustomized) return EntryCustomId;
				return EntryId.ToString().PadLeft(3, '0');
            }
		}

        public string EntryControlKey
        {
            get
            {
                if (EntryControlCustomized) return EntryCustomId;
                return Provider.vgFormID;
            }
        }

		public Entry(string Title, string Table, int NumberEntries, string CodLanField)
			: this(Title, Table, NumberEntries, CodLanField, null, 0, 1)
		{
		}

		public Entry(string Title, string Table, int NumberEntries, string CodLanField, GeneralDataProvider Provider)
			: this(Title, Table, NumberEntries, CodLanField, Provider, 0, 1)
		{

		}

		public Entry(string Title, string Table, int NumberEntries, string CodLanField, GeneralDataProvider Provider, int Position)
			: this(Title, Table, NumberEntries, CodLanField, Provider, 0, 1)
		{

		}

		public Entry(string Title, string Table, int NumberEntries, string CodLanField, GeneralDataProvider Provider, int Position, int EntryId)
			: this(Title, Table, NumberEntries, CodLanField, Provider, 0, 1, false)
		{

		}

		public Entry(string Title, string Table, int NumberEntries, string CodLanField, GeneralDataProvider Provider, int Position, int EntryId, bool ExcludeEntry)
			: this(Title, Table, NumberEntries, CodLanField, Provider, Position, EntryId, ExcludeEntry, false, "", "")
		{
		}

		public Entry(string Title, string Table, int NumberEntries, string CodLanField, GeneralDataProvider Provider, int Position, int EntryId, bool ExcludeEntry, bool IsCustomizeControl, string CustomEntryKey, string CustomEntryId)
		{
			_Title = Title;
			_Table = Table;
			_NumberEntries = NumberEntries;
			_CodLanField = CodLanField;
			_Provider = Provider;
			_Position = Position;
			_EntryId = EntryId;
			_ExcludeEntry = ExcludeEntry;
			EntryControlCustomized = IsCustomizeControl;
			EntryCustomKey = CustomEntryKey;
			EntryCustomId = CustomEntryId;
		}

	}

	/// <summary>
	/// Classe que representa um lançamento
	/// </summary>
	public class EntryItem
	{
		private string _TabelaAlvo;
		private string _CampoAlvo;
		private object _Valor;
		private int _NumberEntryItems;
		/// <summary>
		/// Recebe tudo que é necessario para fazer um lançamento
		/// </summary>
		/// <param name="vgTabelaAlvo">Tabela alvo</param>
		/// <param name="vgCampoAlvo">Campo alvo</param>
		/// <param name="vgValor">Valor a ser usado</param>
		public EntryItem(string vgTabelaAlvo, string vgCampoAlvo, object vgValor, int vgNumeroEntryItem)
		{
			_TabelaAlvo = vgTabelaAlvo;
			_CampoAlvo = vgCampoAlvo;
			_Valor = vgValor;
			_NumberEntryItems = vgNumeroEntryItem;
		}

		public EntryItem(string vgTabelaAlvo, string vgCampoAlvo, object vgValor)
			: this(vgTabelaAlvo, vgCampoAlvo, vgValor, 1)
		{
		}

		/// <summary>
		/// propriedade com a tabela alvo
		/// </summary>
		public string TabelaAlvo
		{
			get
			{
				return _TabelaAlvo;
			}
			set
			{
				_TabelaAlvo = value;
			}
		}
		/// <summary>
		/// Propriedade com o campo alvo
		/// </summary>
		public string CampoAlvo
		{
			get
			{
				return _CampoAlvo;
			}
			set
			{
				_CampoAlvo = value;
			}
		}
		/// <summary>
		/// Propriedade com o valor a ser usado
		/// </summary>
		public object Valor
		{
			get
			{
				return _Valor;
			}
			set
			{
				_Valor = value;
			}
		}

		public int NumberEntryItems
		{
			get
			{
				return _NumberEntryItems;
			}
			set
			{
				_NumberEntryItems = value;
			}
		}

		public string GetFormattedValue()
		{
			if (Valor == null) return null;
			return Valor.ToString();
		}
	}
}
