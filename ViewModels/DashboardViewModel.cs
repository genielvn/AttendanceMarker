using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AttendanceMarker.Commands;
using AttendanceMarker.Models;
using AttendanceMarker.Stores;

namespace AttendanceMarker.ViewModels
{
    class DashboardViewModel : ViewModelBase
    public class DashboardViewModel : ViewModelBase
    {
        private readonly Teacher _teacher;
        private readonly CredentialHandler _credentials;
        private readonly NavigationStore _currentNavigationStore;
        private readonly NavigationStore _dashboardNavigationStore;
        public ViewModelBase CurrentDashboardViewModel => _dashboardNavigationStore.CurrentViewModel;
        public string TeacherName => _teacher.TeacherName;
        public ICommand LogOutCommand { get; }
        public ICommand GoToClassDashboardCommand { get; }
        public string Today => DateTime.Now.ToString("MMMM dd, yyyy");

        public DashboardViewModel(Teacher teacher, CredentialHandler credentials, NavigationStore currentNavigationStore, NavigationStore dashboardNavigationStore)
        {
            // Oh god, I am so fucking lazy that I passed the credentials to the view model instead of having a function that holds the view models.
            _teacher = teacher;
            _credentials = credentials;
            _dashboardNavigationStore = dashboardNavigationStore;
            _currentNavigationStore = currentNavigationStore;
            _dashboardNavigationStore.CurrentViewModel = new ClassesViewModel(teacher.GetClasses(), _dashboardNavigationStore);
            _dashboardNavigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            LogOutCommand = new LogOutCommand(credentials, _currentNavigationStore);

        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentDashboardViewModel));
        }
    }
}
