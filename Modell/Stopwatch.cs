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
        public ObservableCollection<string> Interval {  get; set; }
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
                    }));
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
                    }));
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
            set { time = value; OnPropertyChanged("Timer"); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null) 
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public string Timer
        {
            get
            {
                float Hour = (Time / 60f / 60f);
                float Minute = (Time / 60f) - ((int)Hour * 60f);
                float Second = Time - (int)Hour * 60f * 60f - (int)Minute * 60f;
                string sHour = ((int)Hour).ToString();
                string sMinute = ((int)Minute).ToString();
                string sSecond = ((int)Second).ToString();
                if (Hour < 10) sHour = "0" + ((int)Hour).ToString();
                if (Minute < 10) sMinute = "0" + ((int)Minute).ToString();
                if (Second < 10) sSecond = "0" + ((int)Second).ToString();
                return $" {sHour}: {sMinute}: {sSecond}";

            }
        }
    }
}
