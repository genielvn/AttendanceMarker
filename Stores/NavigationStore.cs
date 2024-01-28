using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttendanceMarker.ViewModels;

namespace AttendanceMarker.Stores
{
    public class NavigationStore
    {
        private ViewBaseModel _currentViewModel;
        public ViewBaseModel CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnCurrentViewChanged();
            }
        }

        private void OnCurrentViewChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }

        public event Action CurrentViewModelChanged;

    }
}
