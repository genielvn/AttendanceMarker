using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttendanceMarker.Models;

namespace AttendanceMarker.ViewModels
{
    public class StudentTableViewModel : ViewModelBase
    {
        private readonly Student _student;
        public string StudentName => _student.StudentName;
        public string StudentID => _student.StudentID;

        public StudentTableViewModel(Student student)
        {
            _student = student;
        }

    }
}
