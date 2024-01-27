using AttendanceMarker.Models;
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
        protected override void OnStartup(StartupEventArgs e)
        {
            CredentialHandler credentials = new CredentialHandler();
            credentials.SignUp("admin", "password", "Admin");
            credentials.SignUp("smilie", "test_password", "Mr. Smilie");

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(credentials)
            };
            MainWindow.Show();
            base.OnStartup(e);
        }
    }

}
