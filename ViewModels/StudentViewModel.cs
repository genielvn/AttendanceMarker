using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AttendanceMarker.Commands;
using AttendanceMarker.Models;
using AttendanceMarker.Stores;
using AttendanceMarker.Views;

namespace AttendanceMarker.ViewModels
{
    public class StudentViewModel : ViewModelBase
    {
        public List<Student> Students;
        private readonly ObservableCollection<StudentTableViewModel> _students;
        private readonly NavigationStore _dashboardNavigationStore;
        private readonly Class _currentClass;
        private readonly Func<ClassesViewModel> _createClassesViewModel;
        public IEnumerable<StudentTableViewModel> StudentTable => _students;


        private string _subjectName;
        public string SubjectName
        {
            get => _subjectName;
            set
            {
                _subjectName = value;
                OnPropertyChanged(nameof(SubjectName));
            }
        }

        private string _schedule;
        public string Schedule
        {
            get => _schedule;
            set
            {
                _schedule = value;
                OnPropertyChanged(nameof(Schedule));
            }
        }
        private string _class;
        public string Class
        {
            get => _class;
            set
            {
                _class = value;
                OnPropertyChanged(nameof(Schedule));
            }
        }
        public ICommand AddStudent { get; }
        public ICommand ReturnCommand { get; }
        public ICommand StartAttendance { get; }

        public StudentViewModel(List<Student> students, Class currentClass, NavigationStore dashboardNavigationStore, Func<ClassesViewModel> createClassViewModel) 
        {
            _students = new ObservableCollection<StudentTableViewModel>();
            _dashboardNavigationStore = dashboardNavigationStore;
            Students = students;
            _currentClass = currentClass;
            _createClassesViewModel = createClassViewModel;

            _subjectName = currentClass.SubjectName;
            _schedule = currentClass.Schedule;
            _class = currentClass.ClassID;

            IEnumerable<Student> IEnumerableStudents = students;
            IEnumerator<Student> student_enumerator = IEnumerableStudents.GetEnumerator();

            while (student_enumerator.MoveNext())
            {
                _students.Add(new StudentTableViewModel(student_enumerator.Current));
            }

            ReturnCommand = new NavigateCommand(_dashboardNavigationStore, createClassViewModel);

        }

    }
}
