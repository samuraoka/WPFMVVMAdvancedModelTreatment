using Autofac;
using FriendStorage.DataAccess;
using FriendStorage.Model;
using FriendStorage.UI.DataProvider.Lookups;
using FriendStorage.UI.ViewModel;

namespace FriendStorage.UI.Startup
{
    public class Bootstrapper
    {
        internal IContainer Bootstrap()
        {
            // Autofac
            // https://www.nuget.org/packages/Autofac/
            var builder = new ContainerBuilder();

            //TODO

            //TODO
            builder.RegisterType<FileDataService>().As<IDataService>();
            builder.RegisterType<FriendLookupProvider>()
                .As<ILookupProvider<Friend>>();
            //TODO
            builder.RegisterType<NavigationViewModel>()
                .As<INavigationViewModel>();
            builder.RegisterType<MainViewModel>().AsSelf();

            return builder.Build();
        }
    }
}
