using FriendStorage.Model;
using FriendStorage.UI.Command;
using FriendStorage.UI.DataProvider;
using FriendStorage.UI.DataProvider.Lookups;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Input;

namespace FriendStorage.UI.ViewModel
{
    public interface IFriendEditViewModel
    {
        void Load(int? friendId = null);
        Friend Friend { get; }
    }

    internal class FriendEditViewModel : Observable, IFriendEditViewModel
    {
        //TODO
        private readonly IFriendDataProvider _friendDataProvider;
        //TODO
        private Friend _friend;
        private IEnumerable<LookupItem> _friendGroups;
        private FriendEmail _selectedEmail;

        public FriendEditViewModel(IFriendDataProvider friendDataProvider) //TODO
        {
            //TODO
            _friendDataProvider = friendDataProvider;
            //TODO
            AddEmailCommand = new DelegateCommand(OnAddEmailExecute);
            //TODO
        }

        public void Load(int? friendId = null)
        {
            //TODO

            Friend = friendId.HasValue
                ? _friendDataProvider.GetFriendById(friendId.Value)
                : new Friend
                {
                    Address = new Address(),
                    Emails = new List<FriendEmail>()
                };

            InvalidateCommands();
        }

        public Friend Friend
        {
            get { return _friend; }
            set
            {
                _friend = value;
                OnPropertyChanged();
            }
        }

        public IEnumerable<LookupItem> FriendGroupLookup
        {
            get { return _friendGroups; }
            set
            {
                _friendGroups = value;
                OnPropertyChanged();
            }
        }

        public FriendEmail SelectedEmail
        {
            get { return _selectedEmail; }
            set
            {
                _selectedEmail = value;
                OnPropertyChanged();
                //TODO
            }
        }

        public ICommand SaveCommand { get; private set; }

        public ICommand ResetCommand { get; private set; }

        public ICommand DeleteCommand { get; private set; }

        public ICommand AddEmailCommand { get; private set; }

        public ICommand RemoveEmailCommand { get; private set; }

        //TODO

        private void OnAddEmailExecute(object obj)
        {
            //TODO
            throw new NotImplementedException();
        }

        private void InvalidateCommands()
        {
            //TODO
            Debug.WriteLine("[{0}] InvalidateCommands: Implemente This method"
                , DateTime.Now);
        }
    }
}
