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
	public partial class DBGERPROJETO_TB_RESPONSAVELItem : GeneralDataProviderItem
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

		public DBGERPROJETO_TB_RESPONSAVELItem(string DataBaseName) : this(DataBaseName, true)
		{
		}

		public DBGERPROJETO_TB_RESPONSAVELItem(string DataBaseName, params string[] FieldNames) : this(DataBaseName, false, FieldNames)
		{
		}
		
		/// <summary>
		/// Construtor da Página
		/// </summary>
		private DBGERPROJETO_TB_RESPONSAVELItem(string DataBaseName, bool AllFields, params string[] FieldNames)
		{
			this.DataBaseName = DataBaseName;	
			Fields = CreateItemFields(AllFields, FieldNames);
		}
		
		public static Dictionary<string, FieldBase> CreateItemFields(bool AllFields, params string[] FieldNames)
		{
			Dictionary<string, FieldBase> NewFields = new Dictionary<string, FieldBase>();
			 NewFields.Add("codigo", new LongField("codigo", "", null, false));
			if (AllFields || Contains(FieldNames, "nomeResponsavel")) NewFields.Add("nomeResponsavel", new TextField("nomeResponsavel", "", null, true));
			if (AllFields || Contains(FieldNames, "nomeSobrenome")) NewFields.Add("nomeSobrenome", new TextField("nomeSobrenome", "", null, true));
			if (AllFields || Contains(FieldNames, "ramalResponsavel")) NewFields.Add("ramalResponsavel", new TextField("ramalResponsavel", "", null, true));
			if (AllFields || Contains(FieldNames, "contatoResponsavel")) NewFields.Add("contatoResponsavel", new TextField("contatoResponsavel", "", null, true));
			if (AllFields || Contains(FieldNames, "salaResponsavel")) NewFields.Add("salaResponsavel", new TextField("salaResponsavel", "", null, true));
			if (AllFields || Contains(FieldNames, "usuarioCadastro")) NewFields.Add("usuarioCadastro", new TextField("usuarioCadastro", "", null, true));
			if (AllFields || Contains(FieldNames, "dataCadastro")) NewFields.Add("dataCadastro", new DateField("dataCadastro", "", null, true));
			if (AllFields || Contains(FieldNames, "siglaDiretoria")) NewFields.Add("siglaDiretoria", new TextField("siglaDiretoria", "", null, true));
			if (AllFields || Contains(FieldNames, "siglaCoordenacao")) NewFields.Add("siglaCoordenacao", new TextField("siglaCoordenacao", "", null, true));
			if (AllFields || Contains(FieldNames, "siglaSetorial")) NewFields.Add("siglaSetorial", new TextField("siglaSetorial", "", null, true));
			
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
	public class DBGERPROJETO_TB_RESPONSAVELDataProvider : GeneralDataProvider
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
			return DBGERPROJETO_TB_RESPONSAVELItem.CreateItemFields(true); 
		}
	
		public DBGERPROJETO_TB_RESPONSAVELDataProvider(IGeneralDataProvider BasePage, string TableName, string DataBaseName, string IndexName, string Name) : base(BasePage, TableName, DataBaseName, IndexName, Name, "", false)
		{
		}

		public override void CreateUniqueParameter()
		{
			Parameters.Clear();
			switch (IndexName)
			{
				case "NK_TB_RESPONSAVEL1":
					CreateParameter("nomeResponsavel");
					break;
				case "PK_TB_RESPONSAVEL":
					CreateParameter("codigo");
					break;
			}
		}
				
		public override void CreateParameters()
		{
			Parameters.Clear();
			switch (IndexName)
			{
				case "NK_TB_RESPONSAVEL1":
					CreateParameter("nomeResponsavel");
					break;
				case "PK_TB_RESPONSAVEL":
					CreateParameter("codigo");
					break;
			}
			base.CreateParameters();
		}

		public override string ProviderFilterExpression()
		{
			return this.GetFilterExpression( DBGERPROJETO_TB_RESPONSAVELItem.CreateItemFields(false, GetUniqueKeyFields()));
		}

		public override string[] GetUniqueKeyFields()
		{
			return new string[] { "codigo" };
		}			
	}
}
