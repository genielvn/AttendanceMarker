using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceMarker.Models
{
    public class Teacher
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

        public List<Class> GetClasses()
        {
            return _classes;
        }

        public Class GetOneClassSample()
        {
            return _classes.First();
        }
    }
}
