using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Threading;

namespace TimeLord_MVVM_Kazakov.ViewModell
{
    public class VMStopwatch : INotifyPropertyChanged
    {
        public Stopwatch Stopwatch { get; set; }
        private DispatcherTimer Timer = new DispatcherTimer()
        {
            Interval = new System.TimeSpan(0, 0, 1)
        };
        public VMStopwatch()
        {
            Stopwatch = new Stopwatch()
            {
                Work = false,
                Timer = 0
            };
            Timer.Tick += Timer_Tick;
            Timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (Stopwatch.Work)
                Stopwatch.Time++;
        }
        public event ProgressChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}
