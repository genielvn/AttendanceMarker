using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttendanceMarker.Models;
using AttendanceMarker.Views;

namespace AttendanceMarker.ViewModels
{
    public class StudentViewModel : ViewModelBase
    {
        private IEnumerable<Student> _students;
        public StudentViewModel(IEnumerable<Student> students) 
        {

        }

        public StudentViewModel()
        {

        }
    }
}
