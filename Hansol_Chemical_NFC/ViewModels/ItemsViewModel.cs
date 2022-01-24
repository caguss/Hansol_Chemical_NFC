using Hansol_Chemical_NFC.Models;
using Hansol_Chemical_NFC.Services;
using Hansol_Chemical_NFC.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Hansol_Chemical_NFC.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private Approval _selectedApproval;
        private string pagetype;
        public ObservableCollection<Item> Items { get; }
        public ObservableCollection<User> Users { get; }
        public ObservableCollection<Approval> Approvals { get; }
        public ObservableCollection<Chemical> Chemicals { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<Approval> ItemTapped { get; }

    

        public ItemsViewModel()
        {
            DependencyService.Register<ItemDataStore>();
            DependencyService.Register<UserDataStore>();
            DependencyService.Register<ApprovalDataStore>();
            DependencyService.Register<ChemicalDataStore>();
            Items = new ObservableCollection<Item>();
            Users = new ObservableCollection<User>();
            Approvals = new ObservableCollection<Approval>();
            Chemicals = new ObservableCollection<Chemical>();

        }
        public ItemsViewModel(string Type)
        {
            //ItemTapped = new Command<Item>(OnItemSelected);
            pagetype = Type;
            //AddItemCommand = new Command(OnAddItem);

            switch (Type)
            {
                case "MSDS":
                    Title = "MSDS 검색";
                    DependencyService.Register<ItemDataStore>();

                    Items = new ObservableCollection<Item>();
                    ItemDataStore.GetRefresh();

                    LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand("MSDS"));
                    //AddItemCommand = new Command(OnAddItem);


                    break;
                case "Chemical":
                    Title = "화학물질 검색";
                    DependencyService.Register<ChemicalDataStore>();
                    Chemicals = new ObservableCollection<Chemical>();
                    ChemicalDataStore.GetRefresh();

                    LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand("Chemical"));
                    //ItemTapped = new Command<BModel>(OnItemSelected);

                    break;
                case "User":
                    Title = "사용자정보";
                    DependencyService.Register<UserDataStore>();
                    Users = new ObservableCollection<User>();
                    UserDataStore.GetRefresh();

                    LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand("User"));
                    //ItemTapped = new Command<BModel>(OnItemSelected);

                    break;
                case "Approval":
                    Title = "결재";
                    DependencyService.Register<ApprovalDataStore>();
                    Approvals = new ObservableCollection<Approval>();
                    ApprovalDataStore.GetRefresh();

                    LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand("Approval"));
                    ItemTapped = new Command<Approval>(OnItemSelected);

                    break;
            }
        }
        async Task ExecuteLoadItemsCommand(string type)
        {
            IsBusy = true;

            try
            {
                switch (type)
                {
                    case "MSDS":
                        Items.Clear();
                        var items = await ItemDataStore.GetItemsAsync(true);
                        foreach (var item in items)
                        {
                            Items.Add(item);
                        }
                        break;
                    case "User":
                        Users.Clear();
                        var users = await UserDataStore.GetItemsAsync(true);
                        foreach (var item in users)
                        {
                            Users.Add(item);
                        }
                        break;
                    case "Approval":
                        Approvals.Clear();
                        var approvals = await ApprovalDataStore.GetItemsAsync(true);
                        foreach (var item in approvals)
                        {
                            Approvals.Add(item);
                        }
                        break;
                    case "Chemical":
                        Chemicals.Clear();
                        var chemicals = await ChemicalDataStore.GetItemsAsync(true);
                        foreach (var item in chemicals)
                        {
                            Chemicals.Add(item);
                        }
                        break;
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

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public Approval SelectedItem
        {
            get => _selectedApproval;
            set
            {
                SetProperty(ref _selectedApproval, value);
                OnItemSelected(value);
            }
        }
 

     

        async void OnItemSelected(Approval item)
        {
            if (item == null)
                return;
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ID)}={item.ID}");
        }

        public ICommand PerformSearch => new Command<string>((string query) =>
        {
            switch (pagetype)
            {
                case "MSDS":
                    var result_msds = ItemDataStore.GetSearchResults(query);
                    Items.Clear();
                    foreach (var item in result_msds)
                    {
                        Items.Add(item);
                    }
                    break;
                case "Chemical":
                    var result_chemical = ChemicalDataStore.GetSearchResults(query);
                    Chemicals.Clear();
                    foreach (var item in result_chemical)
                    {
                        Chemicals.Add(item);
                    }
                    break;
                case "User":
                    var result_user = UserDataStore.GetSearchResults(query);
                    Users.Clear();
                    foreach (var item in result_user)
                    {
                        Users.Add(item);
                    }
                    break;
                case "Approval":
                    var result_approval = ApprovalDataStore.GetSearchResults(query);
                    Approvals.Clear();
                    foreach (var item in result_approval)
                    {
                        Approvals.Add(item);
                    }
                    break;
            }

         
        });
    }
}