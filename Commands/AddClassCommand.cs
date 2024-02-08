using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AttendanceMarker.Models;
using AttendanceMarker.Stores;
using AttendanceMarker.ViewModels;

namespace AttendanceMarker.Commands
{
    public class AddClassCommand : CommandBase
    {
        private readonly List<Class> _class;
        private readonly NavigationStore _dashboardNavigationStore;
        private readonly AddClassViewModel _addClassViewModel;
        private readonly Func<ClassesViewModel> _createClassViewModel;
        public override void Execute(object? parameter)
        {
            MessageBox.Show("Add Class Complete");
            _class.Add(new Class(_addClassViewModel.ClassID, _addClassViewModel.ClassSubject, _addClassViewModel.ClassSchedule));
            _dashboardNavigationStore.CurrentViewModel = _createClassViewModel();
        }
        public AddClassCommand(AddClassViewModel addClassViewModel, 
            List<Class> @class, 
            NavigationStore dashboardNavigationStore, 
            Func<ClassesViewModel> createClassViewModel
        ) {
            _addClassViewModel = addClassViewModel;
            _class = @class;
            _dashboardNavigationStore = dashboardNavigationStore;
            _createClassViewModel = createClassViewModel;
        }
    }
}
