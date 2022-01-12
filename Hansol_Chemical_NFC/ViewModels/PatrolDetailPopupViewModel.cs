using Rg.Plugins.Popup.Services;
using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace Hansol_Chemical_NFC.ViewModels
{
    [QueryProperty(nameof(ID), nameof(ID))]
    public class PatrolDetailPopupViewModel : BaseViewModel
    {
        private string id = "";
        private string location = "";
        private string type = "";
        private string summary = "";
        private bool isFinish = false;
        public string Location
        {
            get => location;
            set => SetProperty(ref location, value);
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
        public bool IsFinish
        {
            get => isFinish;
            set => SetProperty(ref isFinish, value);
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

        public Command CloseCommand { get; }
        public string IsFinishtxt
        {
            get
            {
                if (isFinish)
                    return "처리완료";
                else return "미완료";
            }
        }

        public PatrolDetailPopupViewModel()
        {
            CloseCommand = new Command(OnClosedClicked);
        }

        private async void OnClosedClicked(object obj)
        {
            await PopupNavigation.Instance.PopAsync(true);
        }


        public async void LoadItemId(string itemId)
        {
            try
            {
                var item = await PatrolDataStore.GetItemAsync(itemId);
                SetProperty(ref id, item.ID);
                Summary = item.Summary;
                Location = item.Location;
                Type = item.Type;
                IsFinish = item.Checked;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }


    }
}