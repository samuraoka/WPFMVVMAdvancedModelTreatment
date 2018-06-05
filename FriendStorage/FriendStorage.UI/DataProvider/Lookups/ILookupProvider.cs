using System.Collections.Generic;

namespace FriendStorage.UI.DataProvider.Lookups
{
    internal interface ILookupProvider<T>
    {
        IEnumerable<LookupItem> GetLookup();
    }
}
