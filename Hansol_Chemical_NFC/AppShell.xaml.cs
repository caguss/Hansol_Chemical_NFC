using Hansol_Chemical_NFC.Services;
using Hansol_Chemical_NFC.Views;
using System;
using Xamarin.Forms;

namespace Hansol_Chemical_NFC
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        /// <summary>
        /// 로그인 시 권한을 이용해 권한에 따른 페이지 설정
        /// </summary>
        /// 
        public string Param { get; set; }
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(PatrolPage), typeof(PatrolPage));
            Routing.RegisterRoute(nameof(PatrolRegistPage), typeof(PatrolRegistPage));
            //Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));

        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new AppShell();
            await Shell.Current.GoToAsync(nameof(LoginPage));
        }

    }
}
