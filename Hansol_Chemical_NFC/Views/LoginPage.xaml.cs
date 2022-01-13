//using Newtonsoft.Json;
using Hansol_Chemical_NFC.Models;
using Hansol_Chemical_NFC.Services;
using Hansol_Chemical_NFC.ViewModels;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Hansol_Chemical_NFC.Views
{
    public partial class LoginPage : ContentPage
    {
        /// <summary>
        /// 자동로그인 기능, 로그인시 2Fact 인증, 최신버전 확인, 비밀번호 초기화
        private User person;

        public LoginPage()
        {
            InitializeComponent();
            Shell.SetTabBarIsVisible(this, false);
            Shell.SetNavBarIsVisible(this, false);
            BindingContext = new LoginViewModel();
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += async (s, e) =>
            {
                // Depreciated - Device.OpenUri( new Uri((Label)s).Text); 
                await Launcher.OpenAsync(new Uri("http://www.coever.co.kr"));
            };
            lblForgot.GestureRecognizers.Add(tapGestureRecognizer);

        }
        /// <summary>
        /// 최신 버전이 아닌 상태로 접속할 경우
        /// </summary>
        public LoginPage(bool notLatestVersion)
        {
            InitializeComponent();
            DownloadLatestVersion();
        }


        private async void DownloadLatestVersion()
        {
            if (await DisplayAlert("업데이트", "최신 버전이 존재합니다. 업데이트를 진행해주세요.", "확인", "취소"))
            {
                //플랫폼에 따른 최신 버전 다운로드
                switch (DeviceInfo.Platform.ToString())
                {
                    case "Android":
                        //안드로이드 버전 플랫폼 링크
                        break;
                    case "IOS":
                        //IOS 버전 플랫폼 링크
                        break;
                    default:
                        //지원하지 않는 플랫폼입니다.
                        break;
                }
            }
        }

        private async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            try
            {
                //if (usernameEntry.Text == null || passwordEntry.Text == null)
                //{
                //    await DisplayAlert("실패", "아이디와 패스워드를 입력해주세요", "확인");
                //    return;
                //}
                person = new User();
                person.ID = usernameEntry.Text;
                person.Password = passwordEntry.Text;
                ///정보 확인 후 2Fact인증 실행 해야함
                Provider prov = new Provider();
                //try
                //{
                //    if (await prov.Login_API(user))
                //    {
                //        string userdata = user.userAccount + "," + user.userPassword;
                //        Application.Current.Properties["LOGIN"] = userdata;
                //        await Application.Current.SavePropertiesAsync();
                //}
                if (true) //정보 일치의 경우
                {
                    //문자나 이메일을 통한 2Fact 인증 Action을 환경안전시스템에서 실시
                    LoginViewModel viewModel = new LoginViewModel();
                    usernameEntry.IsEnabled = false;
                    passwordEntry.IsEnabled = false;
                    SecondFactLayout.IsVisible = true;
                    btnLogin.Text = "인증하기";
                    btnLogin.Clicked -= OnLoginButtonClicked;
                    btnLogin.Command = viewModel.LoginCommand;
                    btnLogin.CommandParameter = person;
                    if (cbAutoLogin.IsChecked)
                    {
                        await Xamarin.Essentials.SecureStorage.SetAsync("isLogged", "1");
                    }

                    return;
                }
                else
                {
                    await DisplayAlert("실패", "아이디와 비밀번호가 일치하지 않습니다.", "확인");
                }
            }
            catch (Exception)
            {

                await DisplayAlert("실패", "통신에 이상이 발생했습니다.\n네트워크를 확인해 주세요.", "확인");
            }
        }
    }

}
