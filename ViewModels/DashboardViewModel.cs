using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AttendanceMarker.Models;

namespace AttendanceMarker.ViewModels
{
    class DashboardViewModel : ViewBaseModel
    {
        private readonly Teacher _teacher;

        public string TeacherName => _teacher.TeacherName;
        public ICommand LogOutCommand { get; }
        public ICommand GoToClassDashboardCommand{ get; }
        public ViewBaseModel CurrentDashboardViewModel { get; }

        public DashboardViewModel(Teacher teacher)
        {
            _teacher = teacher;
            CurrentDashboardViewModel = new ClassesViewModel(teacher.GetClasses());
        }
    }
}
