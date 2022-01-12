using Hansol_Chemical_NFC.Models;
using Hansol_Chemical_NFC.Services;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Hansol_Chemical_NFC.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command<User>(
                 execute: (User user) =>
                 {
                     RefreshCanExecutes();
                     OnLoginClicked(user);
                 }
                 );
        }

        /// <summary>
        /// 2fact 일치 시 정보 저장 및 페이지 이동
        /// </summary>
        /// <param name="obj">obj로 뭐가 올지 판단해서 Provider 매개변수 확인할 것.</param>
        private async void OnLoginClicked(object obj)
        {
            //2fact 정보 확인을 위한 Provider
            Provider prov = new Provider();
            //((User)obj).ID;

            if (true) //2fact 일치 시
            {
                //로그인 정보 저장을 위한 Provider
                prov = new Provider();
                App.UserName = "tester";
                App.Current.MainPage = new AppShell();
                //await Shell.Current.GoToAsync(nameof(HomePage));
                //await Shell.Current.GoToAsync($"../{nameof(HomePage)}");
            }
        }

        void RefreshCanExecutes()
        {
            (LoginCommand as Command).ChangeCanExecute();
        }

        // this is the record that has the "ID" column I am trying to bind to
        public Location ShowThisRecord { get; set; }
        //*****************************************
        Location selectedRecord; //selected item object
        public Location SelectedRecord
        {
            get { return selectedRecord; }
            set
            {
                if (selectedRecord != value)
                {
                    selectedRecord = value;
                    OnPropertyChanged();
                }
            }
        }
        //*****************************************
        // The picker is bound to this list of possible choices
        public ObservableCollection<Location> PickerChoices { get; set; }
    }
}
