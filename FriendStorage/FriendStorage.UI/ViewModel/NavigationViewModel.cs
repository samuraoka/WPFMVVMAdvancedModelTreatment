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

    internal class NavigationItemViewModel //TODO
    {
        //TODO
        private string _displayValue;

        //TODO

        public ICommand OpenFriendEditViewCommand { get; set; }

        //TODO


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
