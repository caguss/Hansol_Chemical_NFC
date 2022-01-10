using Hansol_Chemical_NFC.Models;
using Hansol_Chemical_NFC.Services;
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
    public class PatrolsViewModel : BaseViewModel
    {
        private Patrol _selectedItem;

        public ObservableCollection<Patrol> Patrols { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<Patrol> ItemTapped { get; }
        private IPopupNavigation _popup { get; set; }
        private PatrolDetailPopupPage _modalPage;

        public PatrolsViewModel()
        {
            Title = "순찰";
            DependencyService.Register<PatrolDataStore>();
            Patrols = new ObservableCollection<Patrol>();
            PatrolDataStore.GetRefresh();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<Patrol>(OnItemSelected);
            AddItemCommand = new Command(OnAddItem);

            _popup = PopupNavigation.Instance;
            _modalPage = new PatrolDetailPopupPage();
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Patrols.Clear();
                var items = await PatrolDataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Patrols.Add(item);
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


        // this is the record that has the "ID" column I am trying to bind to
        public Patrol ShowThisRecord { get; set; }
        //*****************************************
        Patrol selectedRecord; //selected item object
        public Patrol SelectedRecord
        {
            get { return selectedRecord; }
            set
            {
                if (selectedRecord != value)
                {
                    selectedRecord = value;
                    OnPropertyChanged();
                }
            }
        }
        //*****************************************
        // The picker is bound to this list of possible choices
        public ObservableCollection<Patrol> PickerChoices { get; set; }

        public Patrol SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(PatrolRegistPage));
        }
        public void Disappearing()
        {
            _popup.Popped -= Popup_Popped;
        }
        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
            _popup.Popped += Popup_Popped;
            //새로고침
        }

        /// <summary> Triggered when the MyContentPageName popup is closed "PopAsync()" </summary>
        private async void Popup_Popped(object sender, Rg.Plugins.Popup.Events.PopupNavigationEventArgs e)
        {

        }

        async void OnItemSelected(Patrol item)
        {
            if (item == null)
                return;
            _modalPage = new PatrolDetailPopupPage(item);
            await _popup.PushAsync(_modalPage);
        }
    }
}