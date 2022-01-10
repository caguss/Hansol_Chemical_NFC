using Hansol_Chemical_NFC.Models;
using Hansol_Chemical_NFC.ViewModels;
using Xamarin.Forms;

namespace Hansol_Chemical_NFC.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}