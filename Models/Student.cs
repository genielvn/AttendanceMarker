using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceMarker.Models
{
    class Student
    {
        public string StudentName { get; }
        private readonly List<Attendance> _attendanceRecord;
        public Student(string studentName)
        {
            StudentName = studentName;
            _attendanceRecord = new List<Attendance>();
        }

        public void AddRecord(Attendance attendance)
        {
            _attendanceRecord.Add(attendance);
        }

        public List<Attendance> GetRecord(DateTime date)
        {
            return _attendanceRecord.Where(record => record.Date == date).ToList();
        }

        public bool TogglePresent(DateTime date)
        {
            foreach (var attendance in _attendanceRecord)
            {
                if (attendance.Date == date)
                {
                    attendance.Present = !attendance.Present;
                    return true;
                }
            }
            return false;
        }
    }
}
