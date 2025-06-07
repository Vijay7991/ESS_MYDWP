using MYDWP.Command;
using MYDWP.ViewModel.ComponentsViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace MYDWP.ViewModel
{
    public class MenuViewModel : ViewModelBase
    {


        public UserProfileViewModel UserProfileViewModel { get;set; }

        private Visibility _showPRofile = Visibility.Collapsed;
        private string _currentDateFormatted;
        public string CurrentDateFormatted
        {
            get { return _currentDateFormatted; }
            set
            {
                if (_currentDateFormatted != value)
                {
                    _currentDateFormatted = value;
                    OnPropertyChanged(nameof(CurrentDateFormatted));
                }
            }
        }
        public Visibility ShowProfile
        {
            get { return _showPRofile; }
            set
            {
                if (_showPRofile != value)
                {
                    _showPRofile = value;
                    OnPropertyChanged(nameof(ShowProfile));
                }
            }
        }
        public ICommand ShowProfileCommand => new RelayCommand(() =>
        {
            if (ShowProfile == Visibility.Collapsed) ShowProfile = Visibility.Visible;
            else ShowProfile = Visibility.Collapsed;
        });
        public MenuViewModel()
        {
            UserProfileViewModel = new UserProfileViewModel(this);
            var timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            timer.Tick += (s, e) => UpdateDate();
            timer.Start();
        }

        private void UpdateDate()
        {
            CurrentDateFormatted = FormatDate(DateTime.Now);
        }

        private string FormatDate(DateTime date)
        {
            int day = date.Day;
            string suffix = GetDaySuffix(day);
            return $"{day}{suffix} {date:MMMM, yyyy}";
        }

        private string GetDaySuffix(int day)
        {
            if (day >= 11 && day <= 13) return "th";

            switch(day % 10)
            {
                case 1: return "st";
                case 2: return "nd";
                case 3: return "rd";
                default: return "th";
            }
        }

    }
}
