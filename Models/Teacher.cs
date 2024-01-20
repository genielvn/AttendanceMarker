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
        
        public void AddClass(Class newClass) 
        {
            _classes.Add(newClass); 
        }

        public void AddStudent(Class _class, Student student)
        {
            foreach (var classvar in _classes)
            {
                if (_class.Equals(classvar))
                {
                    classvar.AddStudent(student);
                    return;
                }

                throw new Exception("Class does not exist");
            }
        }
    }
}
