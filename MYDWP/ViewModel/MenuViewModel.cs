using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace MYDWP.ViewModel
{
    public class MenuViewModel : ViewModelBase
    {

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

        public MenuViewModel()
        {
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
