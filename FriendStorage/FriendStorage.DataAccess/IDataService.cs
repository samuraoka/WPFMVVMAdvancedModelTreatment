using FriendStorage.Model;
using System;
using System.Collections.Generic;

namespace FriendStorage.DataAccess
{
    public interface IDataService : IDisposable
    {
        Friend GetFriendById(int friendId);
        //TODO
        IEnumerable<Friend> GetAllFriends();
        IEnumerable<FriendGroup> GetAllFriendGroups();
    }
}
