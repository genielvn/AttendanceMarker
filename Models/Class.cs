using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttendanceMarker.Views;

namespace AttendanceMarker.Models
{
    public class Class
    {
        public string ClassID { get; }
        public string SubjectName { get; }
        public string Schedule { get; } 
        private readonly List<Student> _students;
        public Class(string classID, string subjectName, string schedule)
        {
            ClassID = classID;
            SubjectName = subjectName;
            Schedule = schedule;
            _students = new List<Student>();
        }

        public void AddStudent(Student newStudent)
        {
            _students.Add(newStudent);
        }
        public IEnumerable<Student> GetStudents()
        {
            return _students;
        }

        public override bool Equals(object? obj)
        {
            return obj is Class _class &&
                _class.ClassID == ClassID;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ClassID, _students);
        }

        public override string ToString()
        {
            return ClassID;
        }

        public Student GetOneStudenSample()
        {
            return _students.First();
        }
    }
}
