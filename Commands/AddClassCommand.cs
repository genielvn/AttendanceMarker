using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttendanceMarker.Stores;
using AttendanceMarker.ViewModels;

namespace AttendanceMarker.Commands
{
    public class AddClassCommand : CommandBase
    {
        private readonly NavigationStore _dashboardNavigationStore;

        public AddClassCommand(NavigationStore dashboardNavigationStore)
        {
            _dashboardNavigationStore = dashboardNavigationStore;
        }
        public override void Execute(object? parameter)
        {
            // Change screen to AddClass instead
        }
    }
}
