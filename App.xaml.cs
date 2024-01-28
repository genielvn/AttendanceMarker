using AttendanceMarker.Models;
using AttendanceMarker.Stores;
using AttendanceMarker.ViewModels;
using System.Configuration;
using System.Data;
using System.Windows;

namespace AttendanceMarker
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly CredentialHandler credentials;
        private readonly NavigationStore _navigationStore;

        public App()
        {
            credentials = new CredentialHandler();
            credentials.SignUp("admin", "password", "Admin");
            credentials.SignUp("smilie", "test_password", "Mr. Smilie");

            _navigationStore = new NavigationStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _navigationStore.CurrentViewModel = new SignInViewModel(credentials, _navigationStore);

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();
            base.OnStartup(e);
        }
    }

}
