using Rg.Plugins.Popup.Services;
using System;
using Xamarin.Forms;

namespace Hansol_Chemical_NFC.ViewModels
{
    public class EvacutionPopupViewModel : BaseViewModel
    {
        private string imgLink;
        public Command CloseCommand { get; }
        public ImageSource Imglink
        {
            get
            {
                var source = new Uri(imgLink);
                return source;
            }
        }

        public EvacutionPopupViewModel()
        {
            CloseCommand = new Command(OnClosedClicked);

        }
        public EvacutionPopupViewModel(string imgLink)
        {
            CloseCommand = new Command(OnClosedClicked);
            this.imgLink = imgLink;
        }
        private async void OnClosedClicked(object obj)
        {
            await PopupNavigation.Instance.PopAsync(true);
        }
    }
}