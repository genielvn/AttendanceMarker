using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AttendanceMarker.Models;
using AttendanceMarker.Views;

namespace AttendanceMarker.ViewModels
{
    public class ClassesViewModel: ViewModelBase
    {
        private readonly ObservableCollection<ClassTableViewModel> _classes;

        public IEnumerable<ClassTableViewModel> ClassesTable => _classes;
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

        public ICommand AddClassCommand { get; }
        public ClassesViewModel(IEnumerable<Class> classes)
        {
            _classes = new ObservableCollection<ClassTableViewModel>();

            IEnumerator<Class> enumerator = classes.GetEnumerator();

            while (enumerator.MoveNext())
            {
                _classes.Add(new ClassTableViewModel(enumerator.Current));
            }
        }
    }
}
