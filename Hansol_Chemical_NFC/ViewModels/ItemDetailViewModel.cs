using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace Hansol_Chemical_NFC.ViewModels
{
    [QueryProperty(nameof(ID), nameof(ID))]
    public class ItemDetailViewModel : BaseViewModel
    {
        private string id;
        private string materialName;
        private string chemicalName;
        private string nfcTag;
        private string cASNO;

        public ItemDetailViewModel()
        {
            Title = "상세정보";
        }
        public string MaterialName
        {
            get => materialName;
            set => SetProperty(ref materialName, value);
        }

        public string ChemicalName
        {
            get => chemicalName;
            set => SetProperty(ref chemicalName, value);
        }
        public string NFCTag
        {
            get => nfcTag;
            set => SetProperty(ref nfcTag, value);
        }
        public string CASNo
        {
            get => cASNO;
            set => SetProperty(ref cASNO, value);
        }
        public string ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(string itemId)
        {
            try
            {
                var item = await ItemDataStore.GetItemAsync(itemId);
                SetProperty(ref id, item.ID);
                MaterialName = item.MaterialName;
                ChemicalName = item.ChemicalName;
                NFCTag = item.NFCTag;
                CASNo = item.CASNo;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
