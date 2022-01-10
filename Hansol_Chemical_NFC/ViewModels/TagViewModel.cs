using Hansol_Chemical_NFC.Models;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Hansol_Chemical_NFC.ViewModels
{
    public class TagViewModel : BaseViewModel
    {
        public Command RegistCommand { get; }

        public TagViewModel()
        {
            Title = "NFC";
            RegistCommand = new Command<Tag>(execute: (Tag registItem) =>
            {
                RefreshCanExecutes();
                RegistClicked(registItem);
            });

            //Tag 리스트 DB에서 불러오기
            PickerChoices = new ObservableCollection<Tag>() {
                new Tag{  Name = "001", Code="123123123"},
                new Tag{ Name = "002",Code="234234234"},
                new Tag{ Name = "003",Code="345345345"}
            };
        }

        private void RegistClicked(object obj)
        {

        }
        void RefreshCanExecutes()
        {
            (RegistCommand as Command).ChangeCanExecute();
        }
        // this is the record that has the "ID" column I am trying to bind to
        public Tag ShowThisRecord { get; set; }
        //*****************************************
        Tag selectedRecord; //selected item object
        public Tag SelectedRecord
        {
            get { return selectedRecord; }
            set
            {
                if (selectedRecord != value)
                {
                    selectedRecord = value;
                    OnPropertyChanged();
                }
            }
        }
        //*****************************************
        // The picker is bound to this list of possible choices
        public ObservableCollection<Tag> PickerChoices { get; set; }
    }
}