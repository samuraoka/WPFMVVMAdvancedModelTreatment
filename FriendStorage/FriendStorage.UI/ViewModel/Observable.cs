using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FriendStorage.UI.ViewModel
{
    internal class Observable : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(
            [CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(
                this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
