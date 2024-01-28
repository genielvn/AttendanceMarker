using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AttendanceMarker.ViewModels
{
    class DashboardViewModel : ViewBaseModel
    {
        public string _teacherName;
        public string TeacherName
        {
            get
            {
                return _teacherName;
            }
            set
            {
                _teacherName = value;
                OnPropertyChanged(nameof(TeacherName));
            }
        }
        public ICommand LogOutCommand { get; }
        public ICommand GoToClassDashboardCommand{ get; }
        public ViewBaseModel CurrentDashboardModel { get; }

        public DashboardViewModel()
        {

        }
    }
}
