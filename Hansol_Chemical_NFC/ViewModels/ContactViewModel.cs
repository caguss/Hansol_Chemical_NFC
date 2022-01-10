using Hansol_Chemical_NFC.Models;
using Hansol_Chemical_NFC.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Hansol_Chemical_NFC.ViewModels
{
    public class ContactViewModel : BaseViewModel
    {
        private User _selectedItem;

        public ObservableCollection<User> Users { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<User> ItemTapped { get; }

        public ContactViewModel()
        {
            Title = "조회";
            Users = new ObservableCollection<User>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            //ItemTapped = new Command<User>(OnItemSelected);

            AddItemCommand = new Command(OnAddItem);
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Users.Clear();
                var users = await UserDataStore.GetItemsAsync(true);
                foreach (var user in users)
                {
                    Users.Add(user);
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

        public User SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                //OnItemSelected(value);
            }
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }

        //async void OnItemSelected(User user)
        //{
        //    //상세히 보기 필요없을듯?
        //    if (user == null)
        //        return;
        //    // user 데이터 조회 부분 추가예정
        //    // This will push the ItemDetailPage onto the navigation stack
        //    await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.CASNo)}={user.Name}");
        //}
    }
}