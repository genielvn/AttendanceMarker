using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceMarker.ViewModels
{
    class MainViewModel : ViewBaseModel
    {
        public ViewBaseModel CurrentViewModel { get; }

        public MainViewModel()
        {
            CurrentViewModel = new SignInViewModel();
        }
    }
}
