using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Threading;
using TimeLord_MVVM_Kazakov.Modell;

namespace TimeLord_MVVM_Kazakov.ViewModell
{
    public class VMStopwatch : INotifyPropertyChanged
    {
        public Stopwatch Stopwatch { get; set; }

        private DispatcherTimer Timer = new DispatcherTimer()
        {
            Interval = new TimeSpan(0, 0, 1)
        };

        public VMStopwatch()
        {
            Stopwatch = new Stopwatch();
            Timer.Tick += Timer_Tick;
            Timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (Stopwatch.Work)
                Stopwatch.Time++;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}