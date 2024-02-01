using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AttendanceMarker.Models;
using AttendanceMarker.Stores;
using AttendanceMarker.ViewModels;

namespace AttendanceMarker.Commands
{
    public class LogOutCommand : CommandBase
    {
        private readonly CredentialHandler _credentials;

        private readonly NavigationStore _navigationStore;
        public LogOutCommand(CredentialHandler credentials, NavigationStore navigationStore)
        {
            _credentials = credentials;
            _navigationStore = navigationStore;
        }

        public override void Execute(object? parameter)
        {
            MessageBoxResult SignOut = MessageBox.Show("Do you wish to log out?", "Log Out", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (SignOut == MessageBoxResult.Yes)
            {
                _navigationStore.CurrentViewModel = new SignInViewModel(_credentials, _navigationStore);
            }
        }
    }
}
