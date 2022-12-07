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
	public partial class DBGERPROJETO_TB_COORDENACAOItem : GeneralDataProviderItem
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

		public DBGERPROJETO_TB_COORDENACAOItem(string DataBaseName) : this(DataBaseName, true)
		{
		}

		public DBGERPROJETO_TB_COORDENACAOItem(string DataBaseName, params string[] FieldNames) : this(DataBaseName, false, FieldNames)
		{
		}
		
		/// <summary>
		/// Construtor da Página
		/// </summary>
		private DBGERPROJETO_TB_COORDENACAOItem(string DataBaseName, bool AllFields, params string[] FieldNames)
		{
			this.DataBaseName = DataBaseName;	
			Fields = CreateItemFields(AllFields, FieldNames);
		}
		
		public static Dictionary<string, FieldBase> CreateItemFields(bool AllFields, params string[] FieldNames)
		{
			Dictionary<string, FieldBase> NewFields = new Dictionary<string, FieldBase>();
			 NewFields.Add("codigo", new LongField("codigo", "", null, false));
			if (AllFields || Contains(FieldNames, "siglaDiretoria")) NewFields.Add("siglaDiretoria", new TextField("siglaDiretoria", "", null, true));
			if (AllFields || Contains(FieldNames, "siglaCoordenacao")) NewFields.Add("siglaCoordenacao", new TextField("siglaCoordenacao", "", null, true));
			if (AllFields || Contains(FieldNames, "nomeCoordenacao")) NewFields.Add("nomeCoordenacao", new TextField("nomeCoordenacao", "", null, true));
			if (AllFields || Contains(FieldNames, "nomeCoordenador")) NewFields.Add("nomeCoordenador", new TextField("nomeCoordenador", "", null, true));
			if (AllFields || Contains(FieldNames, "usuarioCadastro")) NewFields.Add("usuarioCadastro", new TextField("usuarioCadastro", "", null, true));
			if (AllFields || Contains(FieldNames, "dataCadastro")) NewFields.Add("dataCadastro", new DateField("dataCadastro", "", null, true));
			
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
	public class DBGERPROJETO_TB_COORDENACAODataProvider : GeneralDataProvider
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
			return DBGERPROJETO_TB_COORDENACAOItem.CreateItemFields(true); 
		}
	
		public DBGERPROJETO_TB_COORDENACAODataProvider(IGeneralDataProvider BasePage, string TableName, string DataBaseName, string IndexName, string Name) : base(BasePage, TableName, DataBaseName, IndexName, Name, "", false)
		{
		}

		public override void CreateUniqueParameter()
		{
			Parameters.Clear();
			switch (IndexName)
			{
				case "NK_TB_COORDENACAO1":
					CreateParameter("siglaDiretoria");
					CreateParameter("siglaCoordenacao");
					break;
				case "PK_TB_COORDENACAO":
					CreateParameter("codigo");
					break;
			}
		}
				
		public override void CreateParameters()
		{
			Parameters.Clear();
			switch (IndexName)
			{
				case "NK_TB_COORDENACAO1":
					CreateParameter("siglaDiretoria");
					CreateParameter("siglaCoordenacao");
					break;
				case "PK_TB_COORDENACAO":
					CreateParameter("codigo");
					break;
			}
			base.CreateParameters();
		}

		public override string ProviderFilterExpression()
		{
			return this.GetFilterExpression( DBGERPROJETO_TB_COORDENACAOItem.CreateItemFields(false, GetUniqueKeyFields()));
		}

		public override string[] GetUniqueKeyFields()
		{
			return new string[] { "codigo" };
		}			
	}
}
