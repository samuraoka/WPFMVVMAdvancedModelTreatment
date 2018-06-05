using FriendStorage.Model;
using FriendStorage.UI.DataProvider;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace FriendStorage.UI.ViewModel
{
    public interface IFriendEditViewModel
    {
        void Load(int? friendId = null);
        Friend Friend { get; }
    }


    //TODO
    internal class FriendEditViewModel : Observable, IFriendEditViewModel
    {
        //TODO
        private readonly IFriendDataProvider _friendDataProvider;
        //TODO
        private Friend _friend;

        //TODO

        public FriendEditViewModel(IFriendDataProvider friendDataProvider) //TODO
        {
            //TODO
            _friendDataProvider = friendDataProvider;
            //TODO
        }

        //TODO
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

        private void InvalidateCommands()
        {
            //TODO
            Debug.WriteLine("[{0}] InvalidateCommands: Implemente This method"
                , DateTime.Now);
        }

    }

    //TODO
}
