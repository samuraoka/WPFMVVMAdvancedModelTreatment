using System.Windows.Input;

namespace FriendStorage.UI.ViewModel
{
    public class MainViewModel //TODO
    {
        //TODO

        public MainViewModel(INavigationViewModel navigationViewModel)
        {
            //TODO
            NavigationViewModel = navigationViewModel;
            //TODO
        }

        internal void Load()
        {
            NavigationViewModel.Load();
        }

        //TODO
        public ICommand AddFriendCommand { get; set; }

        internal INavigationViewModel NavigationViewModel { get; private set; }
        //TODO

    }
}
