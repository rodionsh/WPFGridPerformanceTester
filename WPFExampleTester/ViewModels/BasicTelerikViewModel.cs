using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Threading;
using Telerik.Windows.Data;
using WPFExampleTester.Models;

namespace WPFGridPerformanceTester.ViewModels
{
    public class BasicTelerikViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        Random random = new Random();
        private DispatcherTimer timer;
        private DateTime lastUpdate;
        private int updated;

        private RadObservableCollection<BookLine> source;
        public RadObservableCollection<BookLine> Source
        {
            get => source;
            set
            {
                source = value;
                OnPropertyChanged();
            }
        }

        private string frequency = string.Empty;
        public string Frequency
        {
            get { return frequency; }
            set
            {
                frequency = value;
                OnPropertyChanged(nameof(Frequency));
            }
        }

        public BasicTelerikViewModel()
        {
            source = new RadObservableCollection<BookLine>();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(40);
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Source.SuspendNotifications();
            for (var i = 0; i < 50; i++)
            {
                var bookLine = new BookLine
                {
                    BWork = random.Next(999),
                    Bids = random.Next(50, 1000),
                    Price = random.Next(40000, 90000),
                    Asks = random.Next(50, 1000),
                    AWork = random.Next(999)
                };
                if (Source.Count <= 50)
                {
                    Source.Add(bookLine);
                }
                else
                {
                    bookLine = new BookLine
                    {
                        BWork = random.Next(999),
                        Bids = random.Next(50, 1000),
                        Price = random.Next(40000, 90000),
                        Asks = random.Next(50, 1000),
                        AWork = random.Next(999)
                    };
                    Source[i] = bookLine;
                }
            }
            Source.ResumeNotifications();
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

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
