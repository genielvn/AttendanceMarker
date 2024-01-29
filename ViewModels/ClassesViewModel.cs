using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AttendanceMarker.Commands;
using AttendanceMarker.Models;
using AttendanceMarker.Stores;
using AttendanceMarker.Views;

namespace AttendanceMarker.ViewModels
{
    public class ClassesViewModel: ViewModelBase
    {
        private readonly ObservableCollection<ClassTableViewModel> _classes;
        private readonly NavigationStore _dashboardNavigationStore;

        private int _selectIndex;

        public IEnumerable<Class> Classes;
        public int SelectIndex 
        {
            get => _selectIndex;
            set 
            {
                _selectIndex = value;
                OnPropertyChanged(nameof(_selectIndex));
                if (_selectIndex == -1) return;
                _dashboardNavigationStore.CurrentViewModel = new StudentViewModel(Classes.ElementAt(_selectIndex).GetStudents());
            } 
        }

        //private ClassTableViewModel _selectedClass;
        //public ClassTableViewModel SelectedClass
        //{
        //    get => _selectedClass;
        //    set
        //    {
        //        _selectedClass = value;
        //        OnPropertyChanged(nameof(_selectedClass));
        //    }
        //}

        public IEnumerable<ClassTableViewModel> ClassesTable => _classes;
        public ICommand AddClassCommand { get; }
        public ClassesViewModel(IEnumerable<Class> classes, NavigationStore dashboardNavigationStore)
        {
            _classes = new ObservableCollection<ClassTableViewModel>();
            _dashboardNavigationStore = dashboardNavigationStore;
            Classes = classes;

            IEnumerator<Class> enumerator = classes.GetEnumerator();

            while (enumerator.MoveNext())
            {
                _classes.Add(new ClassTableViewModel(enumerator.Current));
            }

            AddClassCommand = new AddClassCommand(dashboardNavigationStore);
        }
    }
}
