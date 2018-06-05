using System.Collections.ObjectModel;

namespace FriendStorage.UI.ViewModel
{
    public interface INavigationViewModel
    {
        void Load();
    }

    internal class NavigationViewModel : INavigationViewModel
    {
        //TODO

        public NavigationViewModel() //TODO
        {
            //TODO
            NavigationItems
                = new ObservableCollection<NavigationItemViewModel>();
        }

        public void Load()
        {
            NavigationItems.Clear();
            //TODO
        }

        public ObservableCollection<NavigationItemViewModel> NavigationItems
        { get; private set; }

        //TODO
    }
}
