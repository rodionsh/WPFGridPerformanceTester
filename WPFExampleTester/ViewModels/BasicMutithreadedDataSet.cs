using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Xml.Serialization.Configuration;
using DevExpress.Mvvm.Native;
using WPFExampleTester.Models;

namespace WPFGridPerformanceTester.ViewModels
{
    public class BasicMutithreadedDataSet : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Thread thread;
        private DispatcherTimer timer;
        private Random random = new Random();
        private TimeSpan lastRenderingTime = TimeSpan.MinValue;
        private DateTime lastUpdate;
        private int updates;

        public BasicMutithreadedDataSet()
        {
            AutoResetEvent isRunning = new AutoResetEvent(false);
            thread = new Thread(new ParameterizedThreadStart(Run));
            thread.Name = "DataSet Thread";
            thread.IsBackground = true;
            thread.Start(isRunning);
            isRunning.WaitOne();
            isRunning.Dispose();

            var woker = Dispatcher.FromThread(thread);
            woker.Invoke(delegate
            {
                Items = new BookLineObservable[0];
                timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(1/30.0);
                timer.Tick += UpdateDataItems;
                timer.IsEnabled = UpdateItems;
            });
        }

        private string frequency;
        public string Frequency
        {
            get => frequency;
            set
            {
                if (frequency != value)
                {
                    frequency = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Count
        {
            get { return Items.Length; }
            set
            {
                var count = value >= 0 ? value : 0;
                var worker = Dispatcher.FromThread(thread);
                worker.Invoke(delegate
                {
                    var newItems = new BookLineObservable[count];
                    var oldCount = Math.Min(Items.Length, count);
                    var i = 0;
                    for (; i < oldCount; i++)
                    {
                        newItems[i] = Items[i];
                    }

                    for (; i < count; i++)
                    {
                        newItems[i] = BookLineObservable.Generate(random);
                    }

                    Items = newItems;
                    OnPropertyChanged();
                });
            }
        }

        private BookLineObservable[] items;
        public BookLineObservable[] Items
        {
            get { return items; }
            set
            {
                if (value != items)
                {
                    //var worker = Dispatcher.FromThread(thread);
                    //worker.Invoke(delegate
                    //{
                        items = value;
                        OnPropertyChanged();
                    //});
                }
            }
        }

        private bool updateItems;
        public bool UpdateItems
        {
            get { return updateItems; }
            set
            {
                var woker = Dispatcher.FromThread(thread);
                woker.Invoke(delegate
                {
                    updateItems = value;
                    timer.IsEnabled = value;
                    Count = 50;
                    OnPropertyChanged();
                });
            }
        }

        private void UpdateDataItems(object sender, EventArgs e)
        {
            foreach (var item in Items)
            {
                item.Update(random);
            }
            var timeDif = DateTime.Now - lastUpdate;
            if (timeDif.TotalSeconds > 1)
            {
                Frequency = $"{updates / timeDif.TotalSeconds:F2} updates/second";
                lastUpdate = DateTime.Now;
                updates = 0;
            }
            updates++;
        }

        private static void Run(object parameter)
        {
            var d = Dispatcher.CurrentDispatcher;
            ((AutoResetEvent) parameter).Set();
            Dispatcher.Run();
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
