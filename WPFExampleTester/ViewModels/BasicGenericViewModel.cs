using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Threading;
using WPFExampleTester.Models;

namespace WPFGridPerformanceTester.ViewModels
{
    public class BasicGenericViewModel : INotifyPropertyChanged
    {
        Random random = new Random();
        private DispatcherTimer timer;
        private DateTime lastUpdate;
        private int updated;

        private ObservableCollection<BookLineObservable> data;
        public ObservableCollection<BookLineObservable> Data
        {
            get => data;
            set
            {
                data = value;
                OnPropertyChanged();
            }
        }

        private string frequency = string.Empty;

        public string Frequency
        {
            get => frequency;
            set
            {
                frequency = value;
                OnPropertyChanged();
            }
        }

        public BasicGenericViewModel()
        {
            data = new ObservableCollection<BookLineObservable>();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(40);
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            for (var i = 0; i < 50; i++)
            {
                var bookLine = new BookLineObservable
                {
                    BWork = random.Next(999),
                    Bids = random.Next(50, 1000),
                    Price = random.Next(40000, 90000),
                    Asks = random.Next(50, 1000),
                    AWork = random.Next(999)
                };
                if (Data.Count <= 50)
                {
                    Data.Add(bookLine);
                }
                else
                {
                    //bookLine = new BookLine
                    //{
                    //    BWork = random.Next(999),
                    //    Bids = random.Next(50, 1000),
                    //    Price = random.Next(40000, 90000),
                    //    Asks = random.Next(50, 1000),
                    //    AWork = random.Next(999)
                    //};
                    Data[i].Update(random);// = bookLine;
                }
            }
            var timeDif = DateTime.Now - lastUpdate;
            if (timeDif.TotalSeconds > 1)
            {
                Frequency = $"{updated / timeDif.TotalSeconds:F2} updates/second";
                lastUpdate = DateTime.Now;
                updated = 0;
            }
            updated++;
        }

        public void Start()
        {
            timer.Start();
        }

        public void Stop()
        {
            timer.Stop();
        }

        public void Dispose()
        {
            if (timer != null)
            {
                timer.Tick -= Timer_Tick;
                timer.Stop();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
