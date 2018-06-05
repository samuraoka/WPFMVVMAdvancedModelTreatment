using Autofac;
using FriendStorage.UI.Startup;
using FriendStorage.UI.View;
using FriendStorage.UI.ViewModel;
using System.Windows;

namespace FriendStorage.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var bootstrapper = new Bootstrapper();
            IContainer container = bootstrapper.Bootstrap(); ;

            var mainViewModel = container.Resolve<MainViewModel>();
            MainWindow = new MainWindow(mainViewModel);
            MainWindow.Show();
            mainViewModel.Load();
        }
    }
}
