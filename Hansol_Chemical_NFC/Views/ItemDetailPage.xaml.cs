using Hansol_Chemical_NFC.ViewModels;
using Xamarin.Forms;

namespace Hansol_Chemical_NFC.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
        protected override bool OnBackButtonPressed()
        {
            Shell.Current.Navigation.PopAsync();
            return false; //true 일시 취소버튼으로 꺼지지 않음
        }
    }
}