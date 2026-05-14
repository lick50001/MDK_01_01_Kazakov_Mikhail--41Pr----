using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.ComponentModel;
using TimeLord_MVVM_Kazakov.ViewModell;

namespace TimeLord_MVVM_Kazakov.Modell
{
    public class Stopwatch : INotifyPropertyChanged
    {
        private RelayCommand intervalTimer;
        private RelayCommand startTimer;

        public ObservableCollection<string> Interval { get; set; }
        public bool Work;

        private int time;
        private string textButton = "Начать";

        public RelayCommand IntervalTimer
        {
            get
            {
                return intervalTimer ??
                    (intervalTimer = new RelayCommand(obj =>
                    {
                        if (Work)
                            Interval.Insert(0, Timer);
                    },
                    obj => true));
            }
        }

        public RelayCommand StartTimer
        {
            get
            {
                return startTimer ??
                    (startTimer = new RelayCommand(obj =>
                    {
                        if (Work == false)
                        {
                            Interval.Clear();
                            Time = 0;
                            Work = true;
                            TextButton = "Стоп";
                        }
                        else
                        {
                            Work = false;
                            TextButton = "Начать";
                        }
                    },
                    obj => true));
            }
        }

        public Stopwatch()
        {
            Interval = new ObservableCollection<string>();
        }

        public string TextButton
        {
            get { return textButton; }
            set { textButton = value; OnPropertyChanged("TextButton"); }
        }

        public int Time
        {
            get { return time; }
            set { time = value; OnPropertyChanged("Time"); OnPropertyChanged("Timer"); }
        }

        public string Timer
        {
            get
            {
                float Hour = (Time / 60f / 60f);
                float Minute = (Time / 60f) - ((int)Hour * 60f);
                float Second = Time - (int)Hour * 60f * 60f - (int)Minute * 60f;

                string sHour = ((int)Hour).ToString().PadLeft(2, '0');
                string sMinute = ((int)Minute).ToString().PadLeft(2, '0');
                string sSecond = ((int)Second).ToString().PadLeft(2, '0');

                return $"{sHour}:{sMinute}:{sSecond}";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}