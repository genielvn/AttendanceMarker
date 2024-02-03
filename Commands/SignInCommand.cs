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
    public class SignInCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly SignInViewModel _signInViewModel;
        private readonly CredentialHandler _credentials;

        public SignInCommand(SignInViewModel signInViewModel, CredentialHandler credentials)
        {
            _signInViewModel = signInViewModel;
            _credentials = credentials;
        }

        public override void Execute(object? parameter)
        {
            Teacher? teacher = _credentials.LogIn(_signInViewModel.Username, _signInViewModel.Password);

            if (teacher == null)
            {
                MessageBox.Show("The username or password may be incorrect.", "Incorrect credentials", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            MessageBox.Show($"Welcome, {teacher.TeacherName}!");
            //_navigationStore.CurrentViewModel = new DashboardViewModel(teacher, _credentials, _navigationStore, new NavigationStore());

        }

    }
}
