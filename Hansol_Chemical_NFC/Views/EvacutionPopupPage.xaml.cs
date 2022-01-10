using Hansol_Chemical_NFC.ViewModels;
using Rg.Plugins.Popup.Services;
using System;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace Hansol_Chemical_NFC.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EvacutionPopupPage : global::Rg.Plugins.Popup.Pages.PopupPage
    {
        public EvacutionPopupPage()
        {
        }

        public EvacutionPopupPage(string imglink)
        {
            BindingContext  = new EvacutionPopupViewModel(imglink);

            InitializeComponent();

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

            PopupNavigation.Instance.PopAsync(true);

            return true;
        }


        // Invoked when background is clicked
        protected override bool OnBackgroundClicked()
        {
            // Return false if you don't want to close this popup page when a background of the popup page is clicked
            return true;
        }

        double currentScale = 1; double startScale = 1; double xOffset = 0; double yOffset = 0;

        private void OnPinchUpdated(object sender, Xamarin.Forms.PinchGestureUpdatedEventArgs e)
        {

            if (e.Status == Xamarin.Forms.GestureStatus.Started)
            {
                startScale = imgcontent.Scale;
                imgcontent.AnchorX = 0;
                imgcontent.AnchorY = 0;    
            }
            if (e.Status == Xamarin.Forms.GestureStatus.Running)
            {
                currentScale += (e.Scale - 1) * startScale;
                currentScale = Math.Max(1, currentScale);
                double renderedX = imgcontent.X + xOffset;
                double deltaX = renderedX / Width;
                double deltaWidth = Width / (imgcontent.Width * startScale);
                double originX = (e.ScaleOrigin.X - deltaX) * deltaWidth;
                double renderedY = imgcontent.Y + yOffset;
                double deltaY = renderedX / Height;
                double deltaHeight = Height / (imgcontent.Height * startScale);
                double originY = (e.ScaleOrigin.Y - deltaY) * deltaHeight;
                double targetX = xOffset - (originY * imgcontent.Width) * (currentScale - startScale);
                double targetY = yOffset - (originY * imgcontent.Height) * (currentScale -startScale);
                imgcontent.TranslationX = targetX.Clamp(-imgcontent.Width * (currentScale - 1), 0);
                imgcontent.TranslationY = targetY.Clamp(-imgcontent.Height * (currentScale - 1), 0);
                imgcontent.Scale = currentScale;
            }
            if(e.Status == Xamarin.Forms.GestureStatus.Completed)
            {
                xOffset = imgcontent.TranslationX;
                yOffset = imgcontent.TranslationY;
            }
        }
    }
}
