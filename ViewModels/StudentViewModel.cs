using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AttendanceMarker.Models;
using AttendanceMarker.Views;

namespace AttendanceMarker.ViewModels
{
    public class StudentViewModel : ViewModelBase
    {
        private IEnumerable<Student> _students;

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
        public ICommand StartAttendance { get; }

        public StudentViewModel(IEnumerable<Student> students) 
        {
            _students = students;
        }

    }
}
