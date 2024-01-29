using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceMarker.Models
{
    public class CredentialHandler
    {
        private List<Credentials> _credentials;

        public CredentialHandler()
        {
            _credentials = new List<Credentials>();
        }

        public void SignUp(string username, string password, string teacherName)
        {
            _credentials.Add(
                new Credentials(username, password, teacherName)
            );
        }

        public Teacher? LogIn(string username, string password)
        {
            foreach (var profile in _credentials)
            {
                if (profile.Match(username, password))
                {
                    Trace.WriteLine("You're in!");
                    return profile.GetTeacher();
                }
            }
            return null;
        }

        public Teacher GetOneTeacherSample()
        {
            return _credentials.First().GetTeacher();
        }
    }
}