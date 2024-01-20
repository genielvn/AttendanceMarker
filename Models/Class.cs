using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceMarker.Models
{
    class Class
    {
        public string ClassName { get; }
        private readonly List<Student> _students;
        public Class(string className)
        {
            ClassName = className;
            _students = new List<Student>();
        }

        public void AddStudent(Student newStudent)
        {
            _students.Add(newStudent);
        }
    }
}
