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
            credentials.SignUp("s", "s", "Mr. Smilie");
            credentials.GetOneSample().AddClass(new Class(
                "BSCS 3-2", "COSC 30013: Subject Name", "M/F - 8:00 - 10:00"));

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
