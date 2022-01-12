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
        private Item _selectedItem;
        private Approval _selectedApproval;
        private User _selectedUser;

        public ObservableCollection<Item> Items { get; }
        public ObservableCollection<Approval> Approvals { get; }
        public ObservableCollection<User> Users { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<Item> ItemTapped { get; }

    

        public ItemsViewModel()
        {
            DependencyService.Register<ItemDataStore>();
            DependencyService.Register<ApprovalDataStore>();
            DependencyService.Register<UserDataStore>();
            Items = new ObservableCollection<Item>();
            Approvals = new ObservableCollection<Approval>();
            Users = new ObservableCollection<User>();
            ItemDataStore.GetRefresh();
            ApprovalDataStore.GetRefresh();
            UserDataStore.GetRefresh();
            ExecuteLoadItemsCommand("Item");
            ExecuteLoadItemsCommand("Approval");
            ExecuteLoadItemsCommand("User");
        }
        public ItemsViewModel(string Type)
        {
            //ItemTapped = new Command<Item>(OnItemSelected);

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
                case "Approval":
                    Title = "결재";
                    DependencyService.Register<ApprovalDataStore>();

                    Approvals = new ObservableCollection<Approval>();
                    ApprovalDataStore.GetRefresh();

                    LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand("Approval"));
                    //ItemTapped = new Command<BModel>(OnItemSelected);

                    break;
                case "Chemical":
                    Title = "화학물질 검색";
                    DependencyService.Register<ApprovalDataStore>();
                    Approvals = new ObservableCollection<Approval>();
                    //ApprovalDataStore.GetRefresh();

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
                    case "Approval":
                        Approvals.Clear();
                        var approvals = await ApprovalDataStore.GetItemsAsync(true);
                        foreach (var item in approvals)
                        {
                            Approvals.Add(item);
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
            //SelectedItem = null;
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

            // This will push the ItemDetailPage onto the navigation stack
            //await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ID)}={item.ID}");
        }

        public ICommand PerformSearch => new Command<string>((string query) =>
        { 
            //var result = ItemDataStore.GetSearchResults(query);
            //Items.Clear();
            //foreach (var item in result)
            //{
            //    Items.Add(item);
            //}
        });
    }
}