using AttendanceMarker.Models;
using AttendanceMarker.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceMarker.Commands
{
    public class SignInCommand : CommandBase
    {
        private readonly SignInViewModel _signInViewModel;
        private readonly CredentialHandler _credentials;

        public SignInCommand(SignInViewModel signInViewModel, CredentialHandler credentials)
        {
            _signInViewModel = signInViewModel;
            _credentials = credentials;
        }

        public override void Execute(object? parameter)
        {
            _credentials.LogIn(_signInViewModel.Username, _signInViewModel.Password);
        }
    }
}
