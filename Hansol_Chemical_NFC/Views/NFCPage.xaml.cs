using Hansol_Chemical_NFC.Models;
using Hansol_Chemical_NFC.Services;
using Hansol_Chemical_NFC.ViewModels;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Hansol_Chemical_NFC.Views
{
    public partial class NFCPage : ContentPage
    {
        App scanApp = new App(1);
        INFC_Interface scan = DependencyService.Get<INFC_Interface>();
        TagViewModel viewModel = new TagViewModel();

        Tag registItem;
        public NFCPage()
        {
            InitializeComponent();
        }
        protected override void OnDisappearing()
        {
            MessagingCenter.Unsubscribe<App, string>(scanApp, "ERROR");
            MessagingCenter.Unsubscribe<App, string>(scanApp, "DATA");
            //scan.UnregisterReceiver();
            //scan.RFIDEnable(false);
            base.OnDisappearing();
        }
        protected override void OnAppearing()
        {



            MessagingCenter.Subscribe<App, string>(this, "ERROR", (Action<App, string>)(async (sender, arg) =>
            {
                await ErrorReceive(arg);

            }));

            MessagingCenter.Subscribe<App, string>(this, "DATA", (Action<App, string>)(async (sender, arg) =>
            {
                await SearchingAction(arg); //test

            }));

            base.OnAppearing();
            scan.StartSearching();

        }

        private async Task SearchingAction(string arg)
        {
            //NFC 데이터 받았을 시
            await Task.Run(() =>
            txtTagCode.Text = arg);
        }

        private async Task ErrorReceive(string arg)
        {
            await DisplayAlert("오류", arg, "확인");
            btnRegist.IsEnabled = false;

        }

        private async void btnRegist_Pressed(object sender, EventArgs e)
        {
            if (txtTagCode.Text == "" || txtTagName.Text == "")
            {
                await DisplayAlert("오류", "빈 칸을 입력해 주세요.", "확인");
                return;
            }
            registItem = new Tag();
            registItem.Code = txtTagCode.Text;
            registItem.Name = txtTagName.Text;

            btnRegist.Command = viewModel.RegistCommand;
            btnRegist.CommandParameter = registItem;
        }
    }
}