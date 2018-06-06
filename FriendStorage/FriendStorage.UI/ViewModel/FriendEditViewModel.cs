using FriendStorage.Model;
using FriendStorage.UI.Command;
using FriendStorage.UI.DataProvider;
using FriendStorage.UI.DataProvider.Lookups;
using FriendStorage.UI.Events;
using Prism.Events;
using System;
using System.Collections.Generic;
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
        private readonly IEventAggregator _eventAggregator;
        //TODO
        private readonly IFriendDataProvider _friendDataProvider;

        //TODO
        private readonly ILookupProvider<FriendGroup>
            _friendGroupLookupProvider;
        private Friend _friend;
        private IEnumerable<LookupItem> _friendGroups;
        private FriendEmail _selectedEmail;

        public FriendEditViewModel(IEventAggregator eventAggregator,
            IFriendDataProvider friendDataProvider,
            ILookupProvider<FriendGroup> friendGroupLookupProvider) //TODO
        {
            _eventAggregator = eventAggregator;
            //TODO
            _friendDataProvider = friendDataProvider;
            _friendGroupLookupProvider = friendGroupLookupProvider;

            SaveCommand
                = new DelegateCommand(OnSaveExecute, OnSaveCanExecute);
            ResetCommand
                = new DelegateCommand(OnResetExecute, OnResetCanExecute);
            DeleteCommand
                = new DelegateCommand(OnDeleteExecute, OnDeleteCanExecute);

            AddEmailCommand = new DelegateCommand(OnAddEmailExecute);
            //TODO
        }

        public void Load(int? friendId = null)
        {
            FriendGroupLookup = _friendGroupLookupProvider.GetLookup();

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

        private void OnSaveExecute(object obj)
        {
            _friendDataProvider.SaveFriend(Friend);
            _eventAggregator.GetEvent<FriendSavedEvent>().Publish(Friend);
            InvalidateCommands();
        }

        private bool OnSaveCanExecute(object arg)
        {
            //TODO: Check for HasChanges
            return true;
        }

        private void OnResetExecute(object obj)
        {
            //TODO
            throw new NotImplementedException();
        }

        private bool OnResetCanExecute(object arg)
        {
            //TODO: Check for HasChanges
            return false;
        }

        private bool OnDeleteCanExecute(object arg)
        {
            return Friend != null && Friend.Id > 0;
        }

        private void OnDeleteExecute(object obj)
        {
            //TODO
            throw new NotImplementedException();
        }

        //TODO

        private void OnAddEmailExecute(object obj)
        {
            //TODO
            throw new NotImplementedException();
        }

        private void InvalidateCommands()
        {
            ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
            ((DelegateCommand)ResetCommand).RaiseCanExecuteChanged();
            ((DelegateCommand)DeleteCommand).RaiseCanExecuteChanged();
        }
    }
}
