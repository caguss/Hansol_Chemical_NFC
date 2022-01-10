using Hansol_Chemical_NFC.ViewModels;
using Xamarin.Forms;

namespace Hansol_Chemical_NFC.Views
{
    public partial class PatrolPage : ContentPage
    {
        PatrolsViewModel _viewModel;

        public PatrolPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new PatrolsViewModel();

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }


    }
}