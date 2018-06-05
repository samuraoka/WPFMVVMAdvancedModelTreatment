using FriendStorage.Model;
using FriendStorage.UI.DataProvider.Lookups;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace FriendStorage.UI.ViewModel
{
    public interface INavigationViewModel
    {
        void Load();
    }

    internal class NavigationViewModel : INavigationViewModel
    {
        //TODO
        private readonly ILookupProvider<Friend> _friendLookupProvider;

        public NavigationViewModel(
            ILookupProvider<Friend> friendLookupProvider) //TODO
        {
            //TODO
            _friendLookupProvider = friendLookupProvider;
            NavigationItems
                = new ObservableCollection<NavigationItemViewModel>();
        }

        public void Load()
        {
            NavigationItems.Clear();
            foreach (var item in _friendLookupProvider.GetLookup())
            {
                NavigationItems.Add(new NavigationItemViewModel(
                    item.Id, item.DisplayValue)); //TODO
            }
        }

        public ObservableCollection<NavigationItemViewModel> NavigationItems
        { get; private set; }

        //TODO
    }

    internal class NavigationItemViewModel //TODO
    {
        //TODO
        private string _displayValue;

        internal NavigationItemViewModel(int friendId, string displayValue) //TODO
        {
            FriendId = friendId;
            DisplayValue = displayValue;
            //TODO
        }

        public ICommand OpenFriendEditViewCommand { get; set; }

        public int FriendId { get; private set; }

        public string DisplayValue
        {
            get { return _displayValue; }
            set
            {
                _displayValue = value;
                //TODO
            }
        }

        //TODO
    }
}
