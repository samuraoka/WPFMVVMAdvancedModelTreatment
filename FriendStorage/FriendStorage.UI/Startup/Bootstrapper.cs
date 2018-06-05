using Autofac;
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
            builder.RegisterType<NavigationViewModel>()
                .As<INavigationViewModel>();
            builder.RegisterType<MainViewModel>().AsSelf();

            return builder.Build();
        }
    }
}
