using Hansol_Chemical_NFC.Models;
using Hansol_Chemical_NFC.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Hansol_Chemical_NFC.Views
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel _viewmodel;
        public ObservableCollection<Item> Users { get; }

        public ItemsPage()
        {
            BindingContext = _viewmodel = new ItemsViewModel();

            //분기별 가져오는 데이터 바꾸기
            var current = Shell.Current.CurrentItem.CurrentItem.Route;
            switch (current)
            {
                case "IMPL_MSDS":

                    break;
                case "IMPL_Chemical":
                    break;
                case "IMPL_EmergencyResponse":
                    break;
                case "IMPL_Contact":

                    break;
                case "IMPL_EmergencyMap":

                    break;
                case "IMPL_Response":
                    BindingContext = _viewmodel = new ItemsViewModel();

                    break;
                case "IMPL_Todo":
                    break;
                default:
                    break;
            }

            InitializeComponent();

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
            //검색 action
            SearchBar searchBar = (SearchBar)sender;
            List<Item> result = _viewmodel.ItemDataStore.GetSearchResults(searchBar.Text);
            ItemsListView.ItemsSource = result;
        }

    }
}