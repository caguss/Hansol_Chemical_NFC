using Hansol_Chemical_NFC.Models;
using Hansol_Chemical_NFC.ViewModels;
using Xamarin.Forms.Xaml;

namespace Hansol_Chemical_NFC.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PatrolDetailPopupPage : global::Rg.Plugins.Popup.Pages.PopupPage
    {
        PatrolDetailPopupViewModel _viewmodel;

        public PatrolDetailPopupPage()
        {
            InitializeComponent();
            BindingContext = _viewmodel = new PatrolDetailPopupViewModel();
        }

        public PatrolDetailPopupPage(Patrol patrol)
        {
            InitializeComponent();

            BindingContext = _viewmodel = new PatrolDetailPopupViewModel();
            _viewmodel.ID = patrol.ID;

        }

        public void OnAnimationStarted(bool isPopAnimation)
        {
            // optional code here   
        }


        public void OnAnimationFinished(bool isPopAnimation)
        {
            // optional code here   
        }

        protected override bool OnBackButtonPressed()
        {
            // Return true if you don't want to close this popup page when a back button is pressed
            return false;
        }


        // Invoked when background is clicked
        protected override bool OnBackgroundClicked()
        {
            // Return false if you don't want to close this popup page when a background of the popup page is clicked
            return true;
        }


    }
}
