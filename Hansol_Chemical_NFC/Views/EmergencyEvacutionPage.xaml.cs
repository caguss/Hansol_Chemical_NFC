using Hansol_Chemical_NFC.ViewModels;
using Xamarin.Forms;

namespace Hansol_Chemical_NFC.Views
{
    public partial class EmergencyEvacutionPage : ContentPage
    {
        EvacutionViewModel _viewModel;

        public EmergencyEvacutionPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new EvacutionViewModel();
            _viewModel.Evacutions.Add(new Models.EmergencyEvacution() { Name = "test", Image = "http://coever.co.kr/Image/hansol_logo_clean.png" });
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            _viewModel.Disappearing();
        }

        /// <summary>
        /// 검색 액션.
        /// 1. 전체 조회 후 Filtering -> 양이 많을 경우 버벅일듯
        /// 2. 처음에 빈값 이후 검색 하면 like 검색 -> 유력
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            //검색 action

        }
    }
}