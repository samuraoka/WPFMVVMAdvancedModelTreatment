using System;
using System.Diagnostics;

namespace FriendStorage.UI.ViewModel
{
    //TODO
    internal class Observable //TODO
    {
        //TODO

        protected virtual void OnPropertyChanged(string propertyName = null) //TODO
        {
            //TODO
            Debug.WriteLine("[{0}] OnPropertyChangedEvent: PropertyName: {1}: Implement this method"
                , DateTime.Now
                , propertyName);
        }
    }
}
