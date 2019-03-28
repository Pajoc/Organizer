using Autofac;
using FriendOrganizer.UI.Data;
using FriendOrganizer.UI.Startup;
using System.Windows;

namespace FriendOrganizer.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var bootstrapper = new Bootstrapper();
            var container = bootstrapper.Bootstrap();

            //var mainWindow = new MainWindow(
            //    new ViewModel.MainViewModel(new FriendDataService()));

            //Evita ter de fazer o switch em vário sitios quando queremos usar uma implementação fake
            var mainWindow = container.Resolve<MainWindow>();
            mainWindow.Show();


        }
    }
}
