using Hansol_Chemical_NFC.Views;
using System.Windows.Input;
using Xamarin.Forms;

namespace Hansol_Chemical_NFC.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private ICommand todoCommand;
        private ICommand patrolCommand;
        private string todoCount;
        private string responseCount;
        private string username;


        public ICommand TodoCommand => todoCommand ?? new Command(ToDoTapped);
        public ICommand PatrolCommand => patrolCommand ?? new Command(PatrolTapped);

        private async void PatrolTapped(object obj)
        {
            await Shell.Current.GoToAsync(nameof(PatrolPage));

        }

        public string TodoCount { get => todoCount; set => todoCount = value; }
        public string ResponseCount { get => responseCount; set => responseCount = value; }
        public string Username { get => username; set => username = value; }

        public HomeViewModel()
        {
            Title = "Home";
            TodoCount = "3";
            ResponseCount = "4";
            username = App.UserName;
        }

      

        private void ToDoTapped(object obj)
        {
            //해야할일 리스트 팝업?
        }

    }
}