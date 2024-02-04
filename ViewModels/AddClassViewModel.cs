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
    public class AddClassViewModel : ViewModelBase
    {
        private readonly Func<ClassesViewModel> _createClassViewModel;
        private readonly NavigationStore _dashboardNavigationStore;
        private readonly List<Class> _class;

        private string _classID;
        public string ClassID
        {
            get => _classID;
            set
            {
                _classID = value;
                OnPropertyChanged(nameof(_classID));
            }
        }

        private string _classSubject;
        public string ClassSubject
        {
            get => _classSubject;
            set
            {
                _classSubject = value;
                OnPropertyChanged(nameof(_classSubject));
            }
        }

        private string _classSchedule;
        public string ClassSchedule
        {
            get => _classSchedule;
            set
            {
                _classSchedule = value;
                OnPropertyChanged(nameof(_classSchedule));
            }
        }

        public ICommand ReturnCommand { get; }
        public ICommand AddClassCommand { get; }


        public AddClassViewModel(List<Class> @class, NavigationStore dashboardNavigationStore, Func<ClassesViewModel> createClassViewModel) {
            _class = @class;
            _createClassViewModel = createClassViewModel;
            _dashboardNavigationStore = dashboardNavigationStore;

            ReturnCommand = new NavigateCommand(_dashboardNavigationStore, _createClassViewModel);
            AddClassCommand = new AddClassCommand(this, _class, _dashboardNavigationStore, _createClassViewModel);
        }
    }
}
