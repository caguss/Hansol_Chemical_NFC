using Hansol_Chemical_NFC.Services;
using Hansol_Chemical_NFC.Views;
using Xamarin.Forms;

namespace Hansol_Chemical_NFC
{
    public partial class App : Application
    {
        public static string UserName { get; set; }

        public App()
        {
            InitializeComponent();

            DependencyService.Register<ItemDataStore>();
            var isLoogged = Xamarin.Essentials.SecureStorage.GetAsync("isLogged").Result;

            if (isLoogged == "1") //자동로그인 체크
            {
                //최신 버전 체크를 위한 Provider


                if (true) //최신 버전일 경우
                {
                    MainPage = new AppShell();
                }
                else
                {
                    MainPage = new AppShell();

                    Shell.Current.GoToAsync(nameof(LoginPage));

                }

            }
            else
            {
                MainPage = new AppShell();
                Shell.Current.GoToAsync(nameof(LoginPage));
            }
        }
        public App(int a)
        {
            InitializeComponent();

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
