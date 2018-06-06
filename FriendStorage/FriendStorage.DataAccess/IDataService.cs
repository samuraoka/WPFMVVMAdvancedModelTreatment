using FriendStorage.Model;
using System;
using System.Collections.Generic;

namespace FriendStorage.DataAccess
{
    public interface IDataService : IDisposable
    {
        Friend GetFriendById(int friendId);
        void SaveFriend(Friend friend);
        void DeleteFriend(int friendId);
        IEnumerable<Friend> GetAllFriends();
        IEnumerable<FriendGroup> GetAllFriendGroups();
    }
}
