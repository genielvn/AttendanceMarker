using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttendanceMarker.Stores;

namespace AttendanceMarker.Commands
{
    internal class NavigateCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        public override void Execute(object? parameter)
        {

        }
    }
}
