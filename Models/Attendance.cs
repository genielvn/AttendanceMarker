using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceMarker.Models
{
    public class Attendance
    {
        public DateTime Date { get; }
        public bool Present { get; set; }
        public Attendance(DateTime date, bool present)
        {
            Date = date;
            Present = present;
        }
    }
}
