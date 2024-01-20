using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceMarker.Models
{
    class Teacher
    {
        public string TeacherName { get; }
        private readonly List<Class> _classes;
        public Teacher(string teacherName)
        {
            TeacherName = teacherName;
            _classes = new List<Class>();
        }
        
    }
}
