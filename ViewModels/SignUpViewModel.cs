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
    public class SignUpViewModel : ViewModelBase
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

        private string _teachername;
        public string TeacherName
        {
            get
            {
                return _teachername;
            }
            set
            {
                _teachername = value;
                OnPropertyChanged(nameof(TeacherName));
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
        public ICommand NavigateSignInCommand { get; }
        public ICommand CreateAccountCommand { get; }

        public SignUpViewModel(NavigationStore _navigationStore, CredentialHandler _credentials, Func<SignInViewModel> createSignInViewModel)
        {
            CreateAccountCommand = new SignUpCommand(this, _credentials, _navigationStore, createSignInViewModel);
            NavigateSignInCommand = new NavigateCommand(_navigationStore, createSignInViewModel);

        }
    }
}
