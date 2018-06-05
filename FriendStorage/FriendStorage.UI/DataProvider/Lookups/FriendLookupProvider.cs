using FriendStorage.DataAccess;
using FriendStorage.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FriendStorage.UI.DataProvider.Lookups
{
    internal class FriendLookupProvider : ILookupProvider<Friend>
    {
        // Delegate Factories
        // http://docs.autofac.org/en/latest/advanced/delegate-factories.html
        private readonly Func<IDataService> _dataServiceCreator;

        public FriendLookupProvider(Func<IDataService> dataServiceCreator)
        {
            _dataServiceCreator = dataServiceCreator;
        }

        public IEnumerable<LookupItem> GetLookup()
        {
            using (var service = _dataServiceCreator())
            {
                return service.GetAllFriends()
                    .Select(f => new LookupItem
                    {
                        Id = f.Id,
                        DisplayValue = string.Format(
                            $"{f.FirstName} {f.LastName}")
                    })
                    .OrderBy(l => l.DisplayValue)
                    .ToList();
            }
        }
    }
}
