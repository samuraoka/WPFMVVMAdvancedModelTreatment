using FriendStorage.Model;

namespace FriendStorage.UI.DataProvider
{
    internal interface IFriendDataProvider
    {
        Friend GetFriendById(int id);
        void SaveFriend(Friend friend);
        void DeleteFriend(int id);
    }
}
