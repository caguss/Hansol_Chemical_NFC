using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace Hansol_Chemical_NFC.ViewModels
{
    [QueryProperty(nameof(ID), nameof(ID))]
    public class ItemDetailViewModel : BaseViewModel
    {
        private string id;
        private string approvalName;
        private string requester;
        private string type;
        private string summary;
        private string attach;

        public ItemDetailViewModel()
        {
            Title = "상세정보";
        }
        public string ApprovalName
        {
            get => approvalName;
            set => SetProperty(ref approvalName, value);
        }
        public string Attach
        {
            get => attach;
            set => SetProperty(ref attach, value);
        }
        public string Requester
        {
            get => requester;
            set => SetProperty(ref requester, value);
        }
        public string Type
        {
            get => type;
            set => SetProperty(ref type, value);
        }
        public string Summary
        {
            get => summary;
            set => SetProperty(ref summary, value);
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
                var item = await ApprovalDataStore.GetItemAsync(itemId);
                SetProperty(ref id, item.ID);
                ApprovalName = item.ApprovalName;
                Requester = item.Requester;
                Type = item.Type;
                Summary = item.Summary;
                Attach = item.Attach;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
