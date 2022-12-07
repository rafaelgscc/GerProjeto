using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
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
using Newtonsoft.Json;

namespace PROJETO.DataProviders
{
	public partial class DBGERPROJETO_TB_LOGIN_USERItem : GeneralDataProviderItem
	{
		private string DataBaseName;
				
		private DataAccessObject _Dao;
		public DataAccessObject Dao
		{
			get 
			{ 
				if (_Dao == null) _Dao = Utility.GetDAO(DataBaseName);
				return _Dao;
			}
		}

		public DBGERPROJETO_TB_LOGIN_USERItem(string DataBaseName) : this(DataBaseName, true)
		{
		}

		public DBGERPROJETO_TB_LOGIN_USERItem(string DataBaseName, params string[] FieldNames) : this(DataBaseName, false, FieldNames)
		{
		}
		
		/// <summary>
		/// Construtor da Página
		/// </summary>
		private DBGERPROJETO_TB_LOGIN_USERItem(string DataBaseName, bool AllFields, params string[] FieldNames)
		{
			this.DataBaseName = DataBaseName;	
			Fields = CreateItemFields(AllFields, FieldNames);
		}
		
		public static Dictionary<string, FieldBase> CreateItemFields(bool AllFields, params string[] FieldNames)
		{
			Dictionary<string, FieldBase> NewFields = new Dictionary<string, FieldBase>();
			if (AllFields || Contains(FieldNames, "LOGIN_GROUP_NAME")) NewFields.Add("LOGIN_GROUP_NAME", new TextField("LOGIN_GROUP_NAME", "", null, true));
			if (AllFields || Contains(FieldNames, "LOGIN_USER_LOGIN")) NewFields.Add("LOGIN_USER_LOGIN", new TextField("LOGIN_USER_LOGIN", "", null, true));
			if (AllFields || Contains(FieldNames, "LOGIN_USER_PASSWORD")) NewFields.Add("LOGIN_USER_PASSWORD", new TextField("LOGIN_USER_PASSWORD", "", null, true));
			if (AllFields || Contains(FieldNames, "LOGIN_USER_NAME")) NewFields.Add("LOGIN_USER_NAME", new TextField("LOGIN_USER_NAME", "", null, true));
			if (AllFields || Contains(FieldNames, "LOGIN_USER_OBS")) NewFields.Add("LOGIN_USER_OBS", new MemoField("LOGIN_USER_OBS", "", null, true));
			if (AllFields || Contains(FieldNames, "LOGIN_USER_EMAIL")) NewFields.Add("LOGIN_USER_EMAIL", new TextField("LOGIN_USER_EMAIL", "", null, true));
			if (AllFields || Contains(FieldNames, "LOGIN_USER_PHONE")) NewFields.Add("LOGIN_USER_PHONE", new TextField("LOGIN_USER_PHONE", "", null, true));
			if (AllFields || Contains(FieldNames, "LOGIN_USER_COORDENACAO")) NewFields.Add("LOGIN_USER_COORDENACAO", new TextField("LOGIN_USER_COORDENACAO", "", null, true));
			
			if (!AllFields)
			{
				Dictionary<string, FieldBase> NewFieldsOrder = new Dictionary<string, FieldBase>();
				foreach (string Field in FieldNames)
				{
					NewFieldsOrder.Add(Field, NewFields[Field]);
				}
				NewFields = NewFieldsOrder; 
			}
			
			return NewFields;
		}
		
		/// <summary>
		/// Valida se todos os campos foram preenchidos corretamente
		/// </summary>
		/// <param name="provider">Provider que vai ser usado para inserir o registro na tabela</param>
		public override void Validate(GeneralDataProvider provider)
		{
		}
	}
	
	/// <summary>
	/// Classe de provider usada para acessar a tabela de produtos
	/// </summary>
	public class DBGERPROJETO_TB_LOGIN_USERDataProvider : GeneralDataProvider
	{
		public FieldBase this[string ColumnName]
		{
			get
			{
				return Item[ColumnName];
			}
		}

		public override Dictionary<string, FieldBase> CreateItemFields()
		{
			return DBGERPROJETO_TB_LOGIN_USERItem.CreateItemFields(true); 
		}
	
		public DBGERPROJETO_TB_LOGIN_USERDataProvider(IGeneralDataProvider BasePage, string TableName, string DataBaseName, string IndexName, string Name) : base(BasePage, TableName, DataBaseName, IndexName, Name, "", false)
		{
		}

		public override void CreateUniqueParameter()
		{
			Parameters.Clear();
			switch (IndexName)
			{
				case "LOGIN_USER_PK":
					CreateParameter("LOGIN_USER_LOGIN");
					break;
			}
		}
				
		public override void CreateParameters()
		{
			Parameters.Clear();
			switch (IndexName)
			{
				case "LOGIN_USER_PK":
					CreateParameter("LOGIN_USER_LOGIN");
					break;
			}
			base.CreateParameters();
		}

		public override string ProviderFilterExpression()
		{
			return this.GetFilterExpression( DBGERPROJETO_TB_LOGIN_USERItem.CreateItemFields(false, GetUniqueKeyFields()));
		}

		public override string[] GetUniqueKeyFields()
		{
			return new string[] { "LOGIN_USER_LOGIN" };
		}			
	}
}
