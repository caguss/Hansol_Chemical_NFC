using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Hansol_Chemical_NFC.Services
{
    public class ModelDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ResponseTemplate { get; set; }
        public DataTemplate UserTemplate { get; set; }
        public DataTemplate MSDSTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            try
            {
                switch (item.GetType().Name)
                {
                    case "Response":
                        return ResponseTemplate;
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
