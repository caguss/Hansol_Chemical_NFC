using Hansol_Chemical_NFC.Models;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Xamarin.Forms;

namespace Hansol_Chemical_NFC.ViewModels
{
    public class PatrolRegistViewModel : BaseViewModel
    {
        private string id;
        private string location;
        private string type;
        private string summary;
        private bool complete;
        public Command<Patrol> AddItemCommand { get; }


        public PatrolRegistViewModel()
        {
            Title = "상세정보";
            //순찰종류 리스트 DB에서 불러오기
            PickerChoices = new ObservableCollection<PatrolType>() {
                new PatrolType{  Type = "001", Code ="123123123"},
                new PatrolType{ Type = "002",Code="234234234"},
                new PatrolType{ Type = "003",Code="345345345"}
            };
            AddItemCommand = new Command<Patrol>(
                 execute: (Patrol newone) =>
                 {
                     RefreshCanExecutes();
                     RegistPatrol(newone);
                 }
                 );
        }
        void RefreshCanExecutes()
        {
            (AddItemCommand as Command).ChangeCanExecute();
        }

        private async void RegistPatrol(Patrol obj)
        {
            ///Provider를 통한 데이터 추가
            ///
            if (await PatrolDataStore.AddItemAsync(obj))
            {
                //로그인 정보 저장을 위한 Provider
                await Shell.Current.Navigation.PopAsync();

            }
        }


        // this is the record that has the "ID" column I am trying to bind to
        public PatrolType ShowThisRecord { get; set; }
        //*****************************************
        PatrolType selectedRecord; //selected item object
        public PatrolType SelectedRecord
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
        public ObservableCollection<PatrolType> PickerChoices { get; set; }
    }
}
