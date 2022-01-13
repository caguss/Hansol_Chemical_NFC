using Hansol_Chemical_NFC.Models;
using Hansol_Chemical_NFC.ViewModels;
using System;
using Xamarin.Forms;

namespace Hansol_Chemical_NFC.Views
{
    public partial class LocationPage : ContentPage
    {
        Location registItem;
        TagViewModel taglist = new TagViewModel();
        LocationViewModel viewModel = new LocationViewModel();

        public LocationPage()
        {
            InitializeComponent();

            try
            {
                BindingContext = viewModel;
                //태그 데이터 바인딩
                RefreshData();


            }
            catch (Exception)
            {

            }
        }

        private void RefreshData()
        {
            taglist = new TagViewModel();
            cbTag.BindingContext = taglist;
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    taglist.PickerChoices[i].IsDriving = dt.Rows[i]["주차장소"].ToString();

            //}

            cbTag.SelectedIndex = 0;

        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        private async void btnRegist_Pressed(object sender, EventArgs e)
        {
            if (txtCompany.Text == "" || txtCode.Text == "" || txtName.Text == "" || txtPlant.Text == "" | taglist.SelectedRecord.Code == "")
            {
                await DisplayAlert("오류", "빈 칸을 입력해 주세요.", "확인");
                return;
            }
            registItem = new Location();
            registItem.Company = txtCompany.Text;
            registItem.Name = txtName.Text;
            registItem.Code = txtCode.Text;
            registItem.Plant = txtPlant.Text;
            registItem.Tagcode = taglist.SelectedRecord.Code;

            btnRegist.Command = viewModel.RegistCommand;
            btnRegist.CommandParameter = registItem;
        }
    }
}