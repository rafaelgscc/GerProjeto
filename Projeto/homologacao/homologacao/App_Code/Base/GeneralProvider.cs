using System;
using System.Collections.Generic;
using System.Web;
using System.Resources;
using System.Data;
using COMPONENTS;
using COMPONENTS.Data;
using COMPONENTS.Configuration;

namespace PROJETO.DataProviders
{
	public class GeneralProvider
	{
		private IGeneralDataProvider _MainProvider;
		public IGeneralDataProvider MainProvider
		{
			get
			{
				return _MainProvider;
			}
			set
			{
				_MainProvider = value;
			}
		}

		private Dictionary<string, object> _AliasVariables;
		public Dictionary<string, object> AliasVariables
		{
			get
			{
				return _AliasVariables;
			}
			set
			{
				_AliasVariables = value;
			}
		}

		private Dictionary<string, Process> _Process;
		public Dictionary<string, Process> Process
		{
			get
			{
				return _Process;
			}
			set
			{
				_Process = value;
			}
		}

		private Dictionary<string, Process> _ReverseProcess;
		public Dictionary<string, Process> ReverseProcess
		{
			get
			{
				return _ReverseProcess;
			}
			set
			{
				_ReverseProcess = value;
			}
		}

		public virtual GeneralDataProviderItem GetDataProviderItem(GeneralDataProvider Provider)
		{
			return null;
		}

		public virtual string GetItemText(GeneralDataProvider Provider, GeneralDataProviderItem Item)
		{
			return "";
		}

		public virtual object GetItemValue(GeneralDataProvider Provider, GeneralDataProviderItem Item)
		{
			return null;
		}

		public virtual GeneralDataProviderItem GetComboItem(GeneralDataProvider Provider, string Value)
        {
			return null;
		}

		public RadComboBoxDataItem GetComboItem(List<RadComboBoxDataItem> ComboBoxDataItem, string Value)
		{
			try
			{
				return ComboBoxDataItem.Find(i => i.Value == Value);
			}
			catch
			{
				return null;
			}
		}

		public virtual string GetGridComboText(string GridColumnId, string FieldId)
        {
            return "";
        }
        public virtual void Fill()
        {
        }
		public virtual void FillAuxiliarTables()
		{
		}

		public virtual void GetTableIdentity()
		{
		}
		
		public virtual void PositionParentsProvider()
        {

        }
		
		public virtual void CreateProcess(int Pos)
        {
            if (Process != null)
                Process.Clear();
        }

		public virtual string CreateProcessBeforeInsert(string FieldName)
		{
			return "";
		}

		//public virtual void CreateReverseProcess(int Pos)
        public virtual void CreateReverseProcess(int Pos, string SituationProcess)
		{
            if (ReverseProcess != null)
                ReverseProcess.Clear();
        }

        public virtual int GetMaxProcessLanc()
        {
            return 1;
        }

		public virtual bool Validate(GeneralDataProviderItem ProviderItem)
		{
			return true;
		}
	}
}
