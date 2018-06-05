using FriendStorage.Model;
using System;
using System.Collections.Generic;

namespace FriendStorage.DataAccess
{
    public interface IDataService : IDisposable
    {
        //TODO
        IEnumerable<Friend> GetAllFriends();
        //TODO
        Friend GetFriendById(int id);
    }
}
