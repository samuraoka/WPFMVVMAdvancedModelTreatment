using FriendStorage.Model;
using System;
using System.Collections.Generic;

namespace FriendStorage.DataAccess
{
    //TODO use mssql local db as a datasource.
    public class MsSqlDataService : IDataService
    {
        public void DeleteFriend(int friendId)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FriendGroup> GetAllFriendGroups()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Friend> GetAllFriends()
        {
            throw new NotImplementedException();
        }

        public Friend GetFriendById(int friendId)
        {
            throw new NotImplementedException();
        }

        public void SaveFriend(Friend friend)
        {
            throw new NotImplementedException();
        }
    }
}
