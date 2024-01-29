using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttendanceMarker.Models;

namespace AttendanceMarker.ViewModels
{
    public class ClassTableViewModel : ViewModelBase
    {
        public readonly Class _class;
        public string ClassID => _class.ClassID;
        public string SubjectName => _class.SubjectName;
        public string Schedule => _class.Schedule;
        public int NumberOfStudents => _class.GetStudents().Count();

        public ClassTableViewModel(Class @class)
        {
            _class = @class;
        }
    }
}
