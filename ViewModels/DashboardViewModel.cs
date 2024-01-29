using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AttendanceMarker.Models;
using AttendanceMarker.Stores;

namespace AttendanceMarker.ViewModels
{
    class DashboardViewModel : ViewModelBase
    {
        private readonly Teacher _teacher;
        private readonly NavigationStore _dashboardNavigationStore;
        public ViewModelBase CurrentDashboardViewModel => _dashboardNavigationStore.CurrentViewModel;
        public string TeacherName => _teacher.TeacherName;
        public ICommand LogOutCommand { get; }
        public ICommand GoToClassDashboardCommand{ get; }

        public DashboardViewModel(Teacher teacher, NavigationStore dashboardNavigationStore)
        {
            _teacher = teacher;
            _dashboardNavigationStore = dashboardNavigationStore;
            _dashboardNavigationStore.CurrentViewModel = new ClassesViewModel(teacher.GetClasses(), _dashboardNavigationStore);
            _dashboardNavigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentDashboardViewModel));
        }
    }
}
