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
        private NavigationStore _navigationStore;
        private CredentialHandler _credentials;

        public App()
        {
            _navigationStore = new NavigationStore();
            _credentials = new CredentialHandler();
            _credentials.SignUp("admin", "password", "Admin");
            _credentials.SignUp("smilie", "test_password", "Mr. Smilie");
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            _navigationStore.CurrentViewModel = CreateSignInViewModel();

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();
            base.OnStartup(e);
        }

        private SignInViewModel CreateSignInViewModel()
        {
            return new SignInViewModel(_navigationStore, _credentials, CreateSignUpViewModel);
        }

        private SignUpViewModel CreateSignUpViewModel()
        {
            return new SignUpViewModel(_navigationStore, _credentials, CreateSignInViewModel);
        }
    }

}
