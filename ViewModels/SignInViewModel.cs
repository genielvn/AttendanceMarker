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
    public class SignInViewModel : ViewModelBase
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

		public ICommand SignInCommand { get; }
		public ICommand NavigateSignUpCommand { get; }
		public ICommand ForgotPasswordCommand { get; }

        public SignInViewModel(NavigationStore navigationStore, CredentialHandler _credentials, Func<SignUpViewModel> createSignUpViewModel)
        {
			SignInCommand = new SignInCommand(this, _credentials);
			NavigateSignUpCommand = new NavigateCommand(navigationStore, createSignUpViewModel);

        }
    }
}
