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
    class NavigateStudentCommand : CommandBase
    {
        private readonly List<Student> _students;
        private readonly Class _class;
        private readonly NavigationStore _navigationStore;
        private readonly Func<List<Student>, Class, ViewModelBase> _createViewModel;

        public NavigateStudentCommand(List<Student> student, 
            Class @class, 
            NavigationStore navigationStore, 
            Func<List<Student>, Class, ViewModelBase> createViewModel
        ) {
            _students = student;
            _class = @class;
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }

        public override void Execute(object? parameter) 
        {
            _navigationStore.CurrentViewModel = _createViewModel(_students, _class);
        }
    }
}
