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
        private readonly SignInViewModel _signInViewModel;
        private readonly CredentialHandler _credentials;
        private readonly NavigationStore _navigationStore;

        public SignInCommand(SignInViewModel signInViewModel, CredentialHandler credentials, NavigationStore navigationStore)
        {
            _signInViewModel = signInViewModel;
            _credentials = credentials;
            _navigationStore = navigationStore;
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
            _navigationStore.CurrentViewModel = new DashboardViewModel(teacher, _credentials, _navigationStore, new NavigationStore());

        }

    }
}
