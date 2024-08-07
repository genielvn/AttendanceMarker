﻿using System;
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
        private readonly NavigationStore _navigationStore;
        private readonly Func<ViewModelBase> _createViewModel;
        public LogOutCommand(CredentialHandler credentials, NavigationStore navigationStore, Func<ViewModelBase> createViewModelBase)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModelBase;
        }

        public override void Execute(object? parameter)
        {
            MessageBoxResult SignOut = MessageBox.Show("Do you wish to log out?", "Log Out", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (SignOut == MessageBoxResult.Yes)
            {
                _navigationStore.CurrentViewModel = _createViewModel();
            }
        }
    }
}
