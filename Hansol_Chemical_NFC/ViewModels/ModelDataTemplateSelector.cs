using System;
using Xamarin.Forms;

namespace Hansol_Chemical_NFC.ViewModels
{
    public class ModelDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ApprovalTemplate { get; set; }
        public DataTemplate UserTemplate { get; set; }
        public DataTemplate MSDSTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            try
            {
                switch (item.GetType().Name)
                {
                    case "Approval":
                        return ApprovalTemplate;
                    case "User":
                        return UserTemplate;
                    case "Item":
                        return MSDSTemplate;
                }

                return MSDSTemplate;

            }
            catch (Exception ex)
            {
                return MSDSTemplate;
            }
        }
    }
}
