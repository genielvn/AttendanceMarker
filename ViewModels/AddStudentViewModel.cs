using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AttendanceMarker.Commands;
using AttendanceMarker.Models;
using AttendanceMarker.Stores;

namespace AttendanceMarker.ViewModels
{
    public class AddStudentViewModel : ViewModelBase
    {
        private readonly NavigationStore _dashboardNavigationStore;
        private readonly List<Student> _student;
        private readonly Class _class;
        private readonly Func<List<Student>, Class, StudentViewModel> _createStudentViewModel;

        private string _studentID;
        public string StudentID
        {
            get => _studentID;
            set
            {
                _studentID = value;
                OnPropertyChanged(nameof(_studentID));
            }
        }

        private string _studentName;
        public string StudentName
        {
            get => _studentName;
            set
            {
                _studentName = value;
                OnPropertyChanged(nameof(_studentName));
            }
        }

        public ICommand ReturnCommand { get; }
        public ICommand AddStudentCommand { get; }

        public AddStudentViewModel(List<Student> students, 
            Class @class, 
            NavigationStore dashboardNavigationStore, 
            Func<List<Student>, Class, StudentViewModel> createStudentViewModel)
        {
            _student = students;
            _class = @class;
            _dashboardNavigationStore = dashboardNavigationStore;
            _createStudentViewModel = createStudentViewModel;

            AddStudentCommand = new AddStudentCommand(this, _student, _class, _dashboardNavigationStore, _createStudentViewModel);
            ReturnCommand = new NavigateStudentCommand(_student, _class, _dashboardNavigationStore, _createStudentViewModel);
        }
    }
}
