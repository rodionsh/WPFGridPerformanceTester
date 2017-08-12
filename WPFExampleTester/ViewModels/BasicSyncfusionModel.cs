using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Threading;
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.Windows.Shared;
using WPFExampleTester.Models;

namespace WPFGridPerformanceTester.ViewModels
{
    public class BasicSyncfusionModel : NotificationObject, IDisposable
    {
        private ObservableCollection<BookLineObservable> data;
        Random random = new Random();
        private DispatcherTimer timer;
        private DateTime lastUpdate;
        private int updated;
        private SfDataGrid grid;

        public ObservableCollection<BookLineObservable> Data
        {
            get { return data; }
            set
            {
                data = value;
                RaisePropertyChanged(nameof(Data));
            }
        }

        private string frequency = string.Empty;

        public string Frequency
        {
            get { return frequency; }
            set
            {
                frequency = value;
                RaisePropertyChanged(nameof(Frequency));
            }
        }

        public BasicSyncfusionModel(SfDataGrid grid)
        {
            data = new ObservableCollection<BookLineObservable>();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(40);
            timer.Tick += Timer_Tick;
            this.grid = grid;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            grid.View.BeginInit();
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
            grid.View.EndInit();
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
    }
}
