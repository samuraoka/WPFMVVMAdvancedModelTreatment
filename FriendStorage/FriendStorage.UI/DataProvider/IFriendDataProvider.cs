using FriendStorage.Model;

namespace FriendStorage.UI.DataProvider
{
    internal interface IFriendDataProvider
    {
        Friend GetFriendById(int id);

        //TODO
        void SaveFriend(Friend friend);
    }
}
