using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WpfApp.ViewModel.Login
{
    public class LoginViewModel : BaseViewModel
    {
        private DateTime _dateTime;
        private Timer _timer;

        public DateTime DateTime
        {
            get => _dateTime;
            set
            {
                if (_dateTime != value)
                {
                    _dateTime = value;
                    OnPropertyChanged(); // reports this property
                }
            }
        }

        public LoginViewModel()
        {
            DateTime = DateTime.Now;

            // Update the DateTime property every second.
            _timer = new Timer(new TimerCallback((s) => DateTime = DateTime.Now),
                               null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
        }

        ~LoginViewModel() =>
     _timer.Dispose();
    }
}
