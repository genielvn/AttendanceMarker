using AttendanceMarker.Models;
using AttendanceMarker.Stores;
using AttendanceMarker.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AttendanceMarker.Commands
{
    public class SignUpCommand : CommandBase
    {
        private readonly SignUpViewModel _signUpViewModel;
        private readonly CredentialHandler _credentials;
        private readonly NavigationStore _navigationStore;
        private readonly Func<ViewModelBase> _createViewModel;

        public SignUpCommand(SignUpViewModel signUpViewModel, CredentialHandler credentials, NavigationStore navigationStore, Func<ViewModelBase> createViewModel)
        {
            _signUpViewModel = signUpViewModel;
            _credentials = credentials;
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }

        public override void Execute(object? parameter)
        {
            if (_signUpViewModel.Password == _signUpViewModel.RetypePassword)
            {
                _credentials.SignUp(_signUpViewModel.Username, _signUpViewModel.Password, _signUpViewModel.Username);
                MessageBox.Show("You have successfully signed up! Sign in to continue to your account.", "Sign Up Complete", MessageBoxButton.OK, MessageBoxImage.Information);
                _navigationStore.CurrentViewModel = _createViewModel();
            }
            else
            {
                MessageBox.Show("Passwords did not match.", "Password Mismatch", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
