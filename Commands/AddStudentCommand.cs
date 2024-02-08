using System;
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
    public class AddStudentCommand : CommandBase
    {
        private readonly AddStudentViewModel _addStudentViewModel;
        private readonly List<Student> _students;
        private readonly Class _class;
        private readonly NavigationStore _dashboardNavigationStore;
        private readonly Func<List<Student>, Class, StudentViewModel> _createStudentViewModel;
        public AddStudentCommand(
            AddStudentViewModel addStudentViewModel, 
            List<Student> students, 
            Class @class, 
            NavigationStore dashboardNavigationStore, 
            Func<List<Student>, Class, StudentViewModel> createStudentViewModel
        ) {
            _addStudentViewModel = addStudentViewModel;
            _students = students;
            _class = @class;
            _dashboardNavigationStore = dashboardNavigationStore;
            _createStudentViewModel = createStudentViewModel;
        }
        public override void Execute(object? parameter)
        {
            MessageBox.Show("Add Student Complete");
            _students.Add(new Student(_addStudentViewModel.StudentName, _addStudentViewModel.StudentID));
            _dashboardNavigationStore.CurrentViewModel = _createStudentViewModel(_students, _class);
        }
    }
}
