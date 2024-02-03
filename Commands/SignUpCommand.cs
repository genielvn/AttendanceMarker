using AttendanceMarker.Models;
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

        public SignUpCommand(SignUpViewModel signUpViewModel, CredentialHandler credentials)
        {
            _signUpViewModel = signUpViewModel;
            _credentials = credentials;
        }

        public override void Execute(object? parameter)
        {
            if (_signUpViewModel.Password == _signUpViewModel.RetypePassword)
            {
                _credentials.SignUp(_signUpViewModel.Username, _signUpViewModel.Password, _signUpViewModel.Username);
                // TODO: Show the next view. Don't forget to change the parameter.
            }
            else
            {
                MessageBox.Show("Passwords did not match.", "Password Mismatch", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
