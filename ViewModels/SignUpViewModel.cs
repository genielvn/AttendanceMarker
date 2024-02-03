using AttendanceMarker.Commands;
using AttendanceMarker.Models;
using AttendanceMarker.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AttendanceMarker.ViewModels
{
    public class SignUpViewModel : ViewBaseModel
    {
        private string _username;
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        private string _retypePassword;
        public string RetypePassword
        {
            get
            {
                return _retypePassword;
            }
            set
            {
                _retypePassword = value;
                OnPropertyChanged(nameof(RetypePassword));
            }
        }

        public ICommand NavigateSignInCommand { get; }
        public ICommand CreateAccountCommand { get; }

        public SignUpViewModel(NavigationStore _navigationStore, CredentialHandler _credentials, Func<SignInViewModel> createSignInViewModel)
        {
            CreateAccountCommand = new SignUpCommand(this, _credentials);
            NavigateSignInCommand = new NavigateCommand(_navigationStore, createSignInViewModel);

        }
    }
}
