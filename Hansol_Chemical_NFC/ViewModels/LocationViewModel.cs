using Hansol_Chemical_NFC.Models;
using Xamarin.Forms;

namespace Hansol_Chemical_NFC.ViewModels
{
    public class LocationViewModel : BaseViewModel
    {
        public Command RegistCommand { get; }

        public LocationViewModel()
        {
            Title = "위치 등록";
            RegistCommand = new Command<Location>(
                 execute: (Location registItem) =>
                 {
                     RefreshCanExecutes();
                     RegistClicked(registItem);
                 }
                 );
        }

        private void RegistClicked(object obj)
        {

        }

        void RefreshCanExecutes()
        {
            (RegistCommand as Command).ChangeCanExecute();
        }
    }
}