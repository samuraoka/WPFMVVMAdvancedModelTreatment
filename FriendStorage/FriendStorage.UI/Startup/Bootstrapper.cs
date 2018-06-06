using Autofac;
using FriendStorage.DataAccess;
using FriendStorage.Model;
using FriendStorage.UI.DataProvider;
using FriendStorage.UI.DataProvider.Lookups;
using FriendStorage.UI.View.Services;
using FriendStorage.UI.ViewModel;
using Prism.Events;

namespace FriendStorage.UI.Startup
{
    public class Bootstrapper
    {
        internal IContainer Bootstrap()
        {
            // Autofac
            // https://www.nuget.org/packages/Autofac/
            var builder = new ContainerBuilder();

            builder.RegisterType<EventAggregator>()
                .As<IEventAggregator>().SingleInstance();
            builder.RegisterType<MessageDialogService>()
                .As<IMessageDialogService>();

            builder.RegisterType<FileDataService>().As<IDataService>();
            builder.RegisterType<FriendLookupProvider>()
                .As<ILookupProvider<Friend>>();
            builder.RegisterType<FriendGroupLookupProvider>()
                .As<ILookupProvider<FriendGroup>>();
            builder.RegisterType<FriendDataProvider>()
                .As<IFriendDataProvider>();

            builder.RegisterType<FriendEditViewModel>()
                .As<IFriendEditViewModel>();
            builder.RegisterType<NavigationViewModel>()
                .As<INavigationViewModel>();
            builder.RegisterType<MainViewModel>().AsSelf();

            return builder.Build();
        }
    }
}
