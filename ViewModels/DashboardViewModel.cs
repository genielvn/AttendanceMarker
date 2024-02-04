using System;
using System.Collections.Generic;
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
    public class DashboardViewModel : ViewModelBase
    {
        private readonly Teacher _teacher;
        private readonly CredentialHandler _credentials;
        private readonly NavigationStore _navigationStore;
        private NavigationStore _dashboardNavigationStore;

        public ViewModelBase CurrentDashboardViewModel => _dashboardNavigationStore.CurrentViewModel;
        public string TeacherName => _teacher.TeacherName;
        public ICommand LogOutCommand { get; }
        public ICommand GoToClassDashboardCommand { get; }
        public string Today => DateTime.Now.ToString("MMMM dd, yyyy");

        public DashboardViewModel(Teacher teacher, CredentialHandler credentials, NavigationStore navigationStore, Func<ViewModelBase> createSignInViewModel)
        {
            _teacher = teacher;
            _credentials = credentials;
            _navigationStore = navigationStore;

            _dashboardNavigationStore = new NavigationStore();
            _dashboardNavigationStore.CurrentViewModel = CreateClassesViewModel();
            _dashboardNavigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;

            LogOutCommand = new LogOutCommand(credentials, _navigationStore, createSignInViewModel);
        }

        private ClassesViewModel CreateClassesViewModel()
        {
            return new ClassesViewModel(_teacher.GetClasses(), _dashboardNavigationStore, CreateStudentViewModel, CreateAddClassViewModel);
        }

        private StudentViewModel CreateStudentViewModel(List<Student> students, Class @class)
        {
            return new StudentViewModel(students, @class, _dashboardNavigationStore, CreateClassesViewModel);
        private AddClassViewModel CreateAddClassViewModel()
        {
            return new AddClassViewModel(_teacher.GetClasses(), _dashboardNavigationStore, CreateClassesViewModel);
        }
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentDashboardViewModel));
        }

    }
}