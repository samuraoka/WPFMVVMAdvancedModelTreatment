namespace FriendStorage.UI.View.Services
{
    internal interface IMessageDialogService
    {
        MessageDialogResult ShowYesNoDialog(string title, string text,
            MessageDialogResult defaultResult = MessageDialogResult.Yes);
    }
}
