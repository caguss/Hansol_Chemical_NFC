using Hansol_Chemical_NFC.Models;
using Hansol_Chemical_NFC.ViewModels;
using Xamarin.Forms;

namespace Hansol_Chemical_NFC.Views
{
    public partial class PatrolRegistPage : ContentPage
    {
        PatrolRegistViewModel _viewmodel;
        Patrol patrol;

        public PatrolRegistPage()
        {
            InitializeComponent();
            BindingContext = _viewmodel = new PatrolRegistViewModel();
        }
        protected override bool OnBackButtonPressed()
        {
            Shell.Current.Navigation.PopAsync();
            return false; //true 일시 취소버튼으로 꺼지지 않음
        }

        private void btnRegist_Clicked(object sender, System.EventArgs e)
        {
            patrol = new Patrol();
            patrol.Checked = false;
            patrol.Location = txtLocation.Text;
            patrol.Summary = txtComment.Text;
            patrol.Type = _viewmodel.SelectedRecord.Type;

            btnRegist.Clicked -= btnRegist_Clicked;
            btnRegist.Command = _viewmodel.AddItemCommand;
            btnRegist.CommandParameter = patrol;

        }
    }
}