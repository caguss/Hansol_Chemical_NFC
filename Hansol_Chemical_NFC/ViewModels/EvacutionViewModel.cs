using Hansol_Chemical_NFC.Models;
using Hansol_Chemical_NFC.Views;
using Rg.Plugins.Popup.Contracts;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Hansol_Chemical_NFC.ViewModels
{
    public class EvacutionViewModel : BaseViewModel
    {
        private EmergencyEvacution _selectedItem;

        public ObservableCollection<EmergencyEvacution> Evacutions { get; }
        public Command LoadItemsCommand { get; }
        public Command<EmergencyEvacution> ItemTapped { get; }
        private IPopupNavigation _popup { get; set; }
        private EvacutionPopupPage _modalPage;

        public EvacutionViewModel()
        {
            Title = "비상대피도";
            Evacutions = new ObservableCollection<EmergencyEvacution>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<EmergencyEvacution>(OnItemSelected);

            _popup = PopupNavigation.Instance;
            //_modalPage = new EvacutionPopupPage();
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Evacutions.Clear();
                var items = await EvacutionDataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Evacutions.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
        public void Disappearing()
        {
            _popup.Popped -= Popup_Popped;
        }
        public new void OnAppearing()
        {
            _popup.Popped += Popup_Popped;
        }

        /// <summary> Triggered when the MyContentPageName popup is closed "PopAsync()" </summary>
        private async void Popup_Popped(object sender, Rg.Plugins.Popup.Events.PopupNavigationEventArgs e)
        {

        }

        public EmergencyEvacution SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        /// <summary> Triggered when the MyContentPageName popup is closed "PopAsync()" </summary>
        //private async void Popup_Popped(object sender, Rg.Plugins.Popup.Events.PopupNavigationEventArgs e)
        //{
        //    //팝업종료시 action
        //}


        async void OnItemSelected(EmergencyEvacution item)
        {
            if (item == null)
                return;
            _modalPage = new EvacutionPopupPage(item.Image);
            await _popup.PushAsync(_modalPage);
            //// This will push the ItemDetailPage onto the navigation stack
            //await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ID)}={item.ID}");
        }
    }
}