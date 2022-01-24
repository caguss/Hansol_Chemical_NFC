using Hansol_Chemical_NFC.Models;
using Hansol_Chemical_NFC.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Hansol_Chemical_NFC.Views
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel _viewmodel = null;
        string type = "";


        public ItemsPage()
        { }
        public ItemsPage(string current)
        {
            InitializeComponent();
            //분기별 가져오는 데이터 바꾸기
            //var current = Shell.Current.CurrentItem.CurrentItem.Route;
            type = current;
            switch (current)
            {
                case "MSDS":
                    type = "MSDS";
                    BindingContext = _viewmodel = new ItemsViewModel(type);
                    ItemsListView.ItemsSource = _viewmodel.Items;
                    break;
                case "Chemical":
                    type = "Chemical";
                    BindingContext = _viewmodel = new ItemsViewModel(type);
                    ItemsListView.ItemsSource = _viewmodel.Items;
                    break;
                case "EmergencyResponse":
                    type = "Response";
                    BindingContext = _viewmodel = new ItemsViewModel(type);
                    ItemsListView.ItemsSource = _viewmodel.Items;
                    break;
                case "User":
                    type = "User";
                    BindingContext = _viewmodel = new ItemsViewModel(type);
                    ItemsListView.ItemsSource = _viewmodel.Users;
                    break;
                case "Approval":
                    type = "Approval";
                    BindingContext = _viewmodel = new ItemsViewModel(type);
                    ItemsListView.ItemsSource = _viewmodel.Approvals;
                    break;
                default:
                    return;
            }

            listRefreshView.Command.Execute(type);

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewmodel.OnAppearing();
        }

        /// <summary>
        /// 검색 액션.
        /// 1. 전체 조회 후 Filtering -> 양이 많을 경우 버벅일듯
        /// 2. 처음에 빈값 이후 검색 하면 like 검색 -> 유력
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            ////검색 action
            SearchBar searchBar = (SearchBar)sender;
            switch (type)
            {
                case "MSDS":
                    var result_msds = _viewmodel.ItemDataStore.GetSearchResults(searchBar.Text);
                    ItemsListView.ItemsSource = result_msds;
                    break;
                case "Chemical":
                    var result_chemical = _viewmodel.ChemicalDataStore.GetSearchResults(searchBar.Text);
                    ItemsListView.ItemsSource = result_chemical;
                    break;
                case "User":
                    var result_user = _viewmodel.UserDataStore.GetSearchResults(searchBar.Text);
                    ItemsListView.ItemsSource = result_user;
                    break;
                case "Approval":
                    var result_approval = _viewmodel.ApprovalDataStore.GetSearchResults(searchBar.Text);
                    ItemsListView.ItemsSource = result_approval;
                    break;
            }
        }

        protected override bool OnBackButtonPressed()
        {
            Shell.Current.GoToAsync(nameof(HomePage));
            return true;
        }


    }
}