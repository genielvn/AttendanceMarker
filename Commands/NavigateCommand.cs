using AttendanceMarker.Models;
using AttendanceMarker.Stores;
using AttendanceMarker.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceMarker.Commands
{
    class NavigateCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<ViewBaseModel> _createViewModel;

        public NavigateCommand(NavigationStore navigationStore, Func<ViewBaseModel> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }

        public override void Execute(object? parameter)
        {
            _navigationStore.CurrentViewModel = _createViewModel();
        }
    }
}
