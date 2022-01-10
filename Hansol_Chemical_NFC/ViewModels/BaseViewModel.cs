using Hansol_Chemical_NFC.Models;
using Hansol_Chemical_NFC.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace Hansol_Chemical_NFC.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public IDataStore<Item> ItemDataStore => DependencyService.Get<IDataStore<Item>>();
        public IDataStore<User> UserDataStore => DependencyService.Get<IDataStore<User>>();
        public IDataStore<Patrol> PatrolDataStore => DependencyService.Get<IDataStore<Patrol>>();
        public IDataStore<EmergencyEvacution> EvacutionDataStore => DependencyService.Get<IDataStore<EmergencyEvacution>>();

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        public string UserName
        {
            get { return App.UserName; }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        internal void OnAppearing()
        {
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
