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
        public List<Class> Classes;
        private readonly ObservableCollection<ClassTableViewModel> _classes;
        private readonly NavigationStore _dashboardNavigationStore;
        private readonly Func<List<Student>, Class, StudentViewModel> _createStudentViewModel;

        private int _selectIndex = -1;

        public int SelectIndex 
        {
            get =>  _selectIndex;
            set 
            {
                _selectIndex = value;
                OnPropertyChanged(nameof(_selectIndex));
                if (_selectIndex == -1) return;
                _dashboardNavigationStore.CurrentViewModel = _createStudentViewModel(
                    Classes.ElementAt(_selectIndex).GetStudents(),
                    Classes.ElementAt(_selectIndex));
            } 
        }

        public IEnumerable<ClassTableViewModel> ClassesTable => _classes;
        public ICommand AddClassCommand { get; }

        public ClassesViewModel(List<Class> classes, NavigationStore dashboardNavigationStore, Func<List<Student>, Class, StudentViewModel> createStudentViewModel)
        {
            _classes = new ObservableCollection<ClassTableViewModel>();
            _dashboardNavigationStore = dashboardNavigationStore;
            Classes = classes;
            _selectIndex = -1;

            _createStudentViewModel = createStudentViewModel;

            IEnumerable<Class> IClassEnumerable = classes;
            IEnumerator<Class> class_enumerate = IClassEnumerable.GetEnumerator();

            while (class_enumerate.MoveNext())
            {
                _classes.Add(new ClassTableViewModel(class_enumerate.Current));
            }

            AddClassCommand = new AddClassCommand(dashboardNavigationStore);
        }
    }
}