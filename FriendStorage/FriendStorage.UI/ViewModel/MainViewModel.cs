using FriendStorage.UI.Command;
using FriendStorage.UI.Events;
using Prism.Events;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace FriendStorage.UI.ViewModel
{
    internal class MainViewModel : Observable
    {
        private readonly IEventAggregator _eventAggregator;
        //TODO
        private IFriendEditViewModel _selectedFriendEditViewModel;
        private Func<IFriendEditViewModel> _friendEditViewModelCreator;

        public MainViewModel(IEventAggregator eventAggregator,
            INavigationViewModel navigationViewModel,
            Func<IFriendEditViewModel> friendEditViewCreator) //TODO
        {
            _eventAggregator = eventAggregator;
            //TODO
            _eventAggregator.GetEvent<OpenFriendEditViewEvent>()
                .Subscribe(OnOpenFriendTab);
            _eventAggregator.GetEvent<FriendDeletedEvent>()
                .Subscribe(OnFriendDeleted);

            NavigationViewModel = navigationViewModel;
            _friendEditViewModelCreator = friendEditViewCreator;
            FriendEditViewModels
                = new ObservableCollection<IFriendEditViewModel>();
            CloseFriendTabCommand
                = new DelegateCommand(OnCloseFriendTabExecute);
            AddFriendCommand
                = new DelegateCommand(OnAddFriendExecute);
        }

        internal void Load()
        {
            NavigationViewModel.Load();
        }

        public ICommand CloseFriendTabCommand { get; private set; }

        public ICommand AddFriendCommand { get; set; }

        public INavigationViewModel NavigationViewModel
        { get; private set; }

        // Those ViewModes represent the Tab-Pages in the UI
        public ObservableCollection<IFriendEditViewModel> FriendEditViewModels
        { get; private set; }

        public IFriendEditViewModel SelectedFriendEditViewModel
        {
            get { return _selectedFriendEditViewModel; }
            set
            {
                _selectedFriendEditViewModel = value;
                OnPropertyChanged();
            }
        }

        private void OnAddFriendExecute(object obj)
        {
            IFriendEditViewModel viewModel = _friendEditViewModelCreator();
            FriendEditViewModels.Add(viewModel);
            viewModel.Load();
            SelectedFriendEditViewModel = viewModel;
        }

        private void OnOpenFriendTab(int friendId)
        {
            var viewModel = FriendEditViewModels
                .SingleOrDefault(vm => vm.Friend.Id == friendId);
            if (viewModel == null)
            {
                viewModel = _friendEditViewModelCreator();
                FriendEditViewModels.Add(viewModel);
                viewModel.Load(friendId);
            }
            SelectedFriendEditViewModel = viewModel;
        }

        private void OnCloseFriendTabExecute(object parameter)
        {
            var viewModel = parameter as IFriendEditViewModel;
            if (viewModel != null)
            {
                //TODO: Check if the Friend has changes and ask user to cancel
                FriendEditViewModels.Remove(viewModel);
            }
        }

        private void OnFriendDeleted(int friendId)
        {
            var viewModel = FriendEditViewModels
                .SingleOrDefault(f => f.Friend.Id == friendId);
            if (viewModel != null)
            {
                FriendEditViewModels.Remove(viewModel);
            }
        }
    }
}
