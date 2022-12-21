using System;
using COMPONENTS;
using COMPONENTS.Data;
using COMPONENTS.Configuration;
using System.Collections.Specialized;
using System.Collections;
using PROJETO.DataPages;

namespace PROJETO.DataProviders
{
	public abstract class GeneralListControlProvider : GeneralProvider, IGeneralDataProvider
	{
		protected NameValueCollection PageErrors;
		public Hashtable DataListData { get; set; }
		public Hashtable DataListDataParameters { get; set; }

		public delegate void SetRelationParametersEventHandler(object sender);
		public event SetRelationParametersEventHandler SetRelationParameters;
		public void RaiseSetRelationParametersEvent(object sender)
		{
			if (SetRelationParameters != null)
			{
				SetRelationParameters(sender);
			}
		}

		public delegate void SetRelationFieldsEventHandler(object sender, GeneralDataProviderItem Item);
		public event SetRelationFieldsEventHandler SetRelationFields;
		public void RaiseSetRelationFields(object sender, GeneralDataProviderItem Item)
		{
			if (SetRelationFields != null)
			{
				SetRelationFields(sender, Item);
			}
		}

		public new virtual GeneralDataProviderItem GetDataProviderItem(GeneralDataProvider Provider)
		{
			return null;
		}

		public virtual void RefreshParentProvider(GeneralProvider ParentProvider)
		{
		}

		public virtual void SetParametersValues(GeneralDataProvider Provider)
		{
		}

		public virtual void InitializeAlias(GeneralDataProviderItem Item)
		{
		}

		public virtual bool Validate(GeneralDataProviderItem ProviderItem)
		{
			return true;
		}

		public virtual string GetMediaQuery(GeneralDataProviderItem Item, string Column)
		{
			return "";
		}

		public void InsertItem(IGeneralDataProvider BaseInterface, string DataListId, Hashtable DataListData)
		{
		}

		public void UpdateItem(IGeneralDataProvider BaseInterface, string DataListId, Hashtable DataListData, Hashtable DataListDataParameters)
		{
		}

		public void DeleteItem(IGeneralDataProvider BaseInterface, string DataListId, Hashtable DataListData, Hashtable DataListDataParameters)
		{
		}

		public void LocateRecord(IGeneralDataProvider BaseInterface, string DataListId, Hashtable DataListData)
		{
		}

		public void SelectItem(IGeneralDataProvider BaseInterface, string DataListId, Hashtable DataListData)
		{
			try
			{
				this.DataListData = DataListData;
				this.DataListDataParameters = DataListData;
				DataProvider.SelectItem(0, FormPositioningEnum.Current);
			}
			catch (Exception ex)
			{
			}
		}

		public void CreateEmptyParameters(GeneralDataProvider Provider)
		{
			if (DataProvider == Provider)
			{
				Provider.Parameters.Clear();
				Provider.CreateParameters();
			}
		}

		#region IGeneralDataProvider Members

		public abstract GeneralDataProvider DataProvider { get; set; }
		public abstract string TableName { get; }
		public abstract string DatabaseName { get; }
		public abstract string FormID { get; }

		public void GetParameters(bool KeepCurrentRecord, GeneralDataProvider Provider)
		{
			CreateEmptyParameters(Provider);
			if (KeepCurrentRecord)
			{
				if (DataListData != null)
				{
					foreach (string ParamKey in Provider.Parameters.Keys)
					{
						Provider.Parameters[ParamKey].Parameter.SetValue(DataListDataParameters[ParamKey]);
					}
				}
			}
			else
			{
				RaiseSetRelationParametersEvent(this);
			}
		}

		public GeneralDataProviderItem GetCurrentItem(FormPositioningEnum Positioning, bool UpdateFromUI)
		{
			return null;
		}

		public void OnSelectedItem(GeneralDataProvider Provider, GeneralDataProviderItem Item, bool UpdateFromUI)
		{
			if (Provider == DataProvider)
			{
				SetOldParameters(Item);
				InitializeAlias(Item);
				FillAuxiliarTables();
				ShowFormulas();
				SetLinks();
			}
		}

		public GeneralDataProviderItem LoadItemFromControl(bool EnableValidation)
		{
			return null;
		}

		public GeneralDataProviderItem LoadItemFromGridControl(bool EnableValidation, string Grid)
        {
            return null;
        }

		public GeneralDataProviderItem LoadItemFromSchedulerControl(bool EnableValidation, string Scheduler)
        {
            return null;
        }

		public GeneralDataProviderItem LoadItemFromImageGalleryControl(bool EnableValidation, string ImageGallery)
		{
			return null;
		}

		public GeneralDataProviderItem LoadItemFromGanttControl(bool EnableValidation, string Gantt)
		{
			return null;
		}

		public GeneralDataProviderItem LoadItemFromDependenciesGanttControl(bool EnableValidation, string Gantt)
		{
			return null;
		}

		public virtual void SetOldParameters(GeneralDataProviderItem Item)
		{
			DataListData = new Hashtable();
            DataListDataParameters = new Hashtable();
			if (Item != null)
			{
				foreach (string ParamKey in DataProvider.Parameters.Keys)
				{
                    DataListData.Add(ParamKey, Item.Fields[ParamKey].Value);
                    DataListDataParameters.Add(ParamKey, Item.Fields[ParamKey].Value);
					DataProvider.Parameters[ParamKey].Parameter.SetValue(Item.Fields[ParamKey].Value);
				}
			}
		}

		public virtual void ShowFormulas()
		{
		}

		public void DeleteChildItens()
		{
		}

		public void OnCommiting()
		{
			throw new NotImplementedException();
		}

		public void OnRollbacking()
		{
			throw new NotImplementedException();
		}

		public virtual void SetLinks()
		{
		}

		#endregion
	}
}
