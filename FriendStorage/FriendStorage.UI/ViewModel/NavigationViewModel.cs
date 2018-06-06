using FriendStorage.Model;
using FriendStorage.UI.Command;
using FriendStorage.UI.DataProvider.Lookups;
using FriendStorage.UI.Events;
using Prism.Events;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace FriendStorage.UI.ViewModel
{
    public interface INavigationViewModel
    {
        void Load();
    }

    internal class NavigationViewModel : INavigationViewModel
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly ILookupProvider<Friend> _friendLookupProvider;

        public NavigationViewModel(IEventAggregator eventAggregator,
            ILookupProvider<Friend> friendLookupProvider) //TODO
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<FriendSavedEvent>()
                .Subscribe(OnFriendSaved);
            _eventAggregator.GetEvent<FriendDeletedEvent>()
                .Subscribe(OnFriendDeleted);
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
                    item.Id, item.DisplayValue, _eventAggregator));
            }
        }

        public ObservableCollection<NavigationItemViewModel> NavigationItems
        { get; private set; }

        private void OnFriendDeleted(int friendId)
        {
            var item = NavigationItems
                .SingleOrDefault(i => i.FriendId == friendId);
            if (item != null)
            {
                NavigationItems.Remove(item);
            }
        }

        private void OnFriendSaved(Friend savedFriend)
        {
            var item = NavigationItems
                .SingleOrDefault(i => i.FriendId == savedFriend.Id);
            if (item != null)
            {
                item.DisplayValue = string.Format(
                    $"{savedFriend.FirstName} {savedFriend.LastName}");
            }
            else
            {
                Load();
            }
        }
    }

    internal class NavigationItemViewModel : Observable
    {
        // Prism.Core
        // https://www.nuget.org/packages/Prism.Core/7.1.0.135-pre
        // Install-Package -Id Prism.Core -ProjectName FriendStorage.UI
        private readonly IEventAggregator _eventAggregator;
        private string _displayValue;

        internal NavigationItemViewModel(int friendId,
            string displayValue, IEventAggregator eventAggregator)
        {
            FriendId = friendId;
            DisplayValue = displayValue;
            _eventAggregator = eventAggregator;
            OpenFriendEditViewCommand
                = new DelegateCommand(OpenFriendEditViewExecute);
        }

        public ICommand OpenFriendEditViewCommand { get; set; }

        public int FriendId { get; private set; }

        public string DisplayValue
        {
            get { return _displayValue; }
            set
            {
                _displayValue = value;
                OnPropertyChanged();
            }
        }

        private void OpenFriendEditViewExecute(object obj)
        {
            _eventAggregator.GetEvent<OpenFriendEditViewEvent>()
                .Publish(FriendId);
        }
    }
}
