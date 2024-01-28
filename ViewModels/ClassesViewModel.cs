using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AttendanceMarker.ViewModels
{
    public class ClassesViewModel: ViewBaseModel
    {
        private int _selectIndex;

        public int SelectIndex 
        {
            get
            {
                return _selectIndex;
            }
            set 
            {
                _selectIndex = value;
                OnPropertyChanged(nameof(_selectIndex));
            } 
        }

        public ICommand AddClass { get; }
        public ClassesViewModel()
        {

        }
    }
}
