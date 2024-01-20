using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceMarker.Models
{
    class Credentials
    {
        public string Username { get; }
        public string Password { get; }

        private Teacher _teacher;

        public Credentials(string username, string password, string teacherName)
        {
            Username = username;
            Password = password;
            _teacher = new Teacher(
                teacherName
            );
        }

        public bool Match(string username, string password)
        {
            if (this.Username == username && this.Password == password) return true;
            return false;
        }

        public Teacher GetTeacher()
        {
            return _teacher;
        }

    }
}
