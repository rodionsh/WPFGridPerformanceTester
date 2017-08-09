using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WFGridPerformanceTester.Models;

namespace WFGridPerformanceTester.Threads
{
    public class UpdaterThread
    {
        #region Constants
        private const int LEVELS = 50;
        private const int UPDATES = 50;
        #endregion

        readonly static Random random = new Random();

        readonly BindingList<BookLine> collection = new BindingList<BookLine>();
        public IList List { get { return this.collection; } }
        private int interEventDelay = 1024000;
        public int InterEventDelay
        {
            set { Interlocked.Exchange(ref interEventDelay, value); }
        }
        int needStop;
        readonly Stopwatch sw;
        readonly Stopwatch backgroundSw = new Stopwatch();
        private bool useRealtimeSource = true;
        readonly SynchronizationContext context;
        int changesFromPriopChangePerSecond = 0;
        int priorChanges;
        object lockObj = new object();
        public bool UseRealtimeSource
        {
            set { lock (lockObj) useRealtimeSource = value; }
        }
        public int ChangePerSecond
        {
            get
            {
                if (Interlocked.CompareExchange(ref changesFromPriopChangePerSecond, 0, 0) == 0)
                {
                    return priorChanges;
                }
                else
                {
                    int changes = Interlocked.Exchange(ref changesFromPriopChangePerSecond, 0);
                    TimeSpan changeReportInterval = sw.Elapsed;
                    priorChanges = Convert.ToInt32(changes / changeReportInterval.TotalSeconds);
                    sw.Reset();
                    sw.Start();
                    return priorChanges;
                }
            }
        }
        public UpdaterThread(SynchronizationContext context)
        {
            this.sw = new Stopwatch();
            this.context = context;
            sw.Start();

            for (int index = 0; index < LEVELS; index++)
            {
                int sequence = random.Next(999);
                collection.Add(new BookLine { BWork = random.Next(999), Bids = random.Next(50, 1000), Price = random.Next(40000, 90000), Asks = random.Next(50, 1000), AWork = random.Next(999) });
            }
        }
        public void Do()
        {
            int postedOperation = 0;
            do
            {
                Stopwatch watch = Stopwatch.StartNew();
                int row = random.Next(0, collection.Count);

                lock (lockObj)
                {
                    if (!useRealtimeSource)
                    {
                        Interlocked.Increment(ref postedOperation);
                        context.Post((x) =>
                        {
                            //collection[row] = new BookLine { BWork = random.Next(999), Bids = random.Next(50, 1000), Price = random.Next(40000, 90000), Asks = random.Next(50, 1000), AWork = random.Next(999) };
                            collection[row].BWork = random.Next(999);
                            collection[row].Bids = random.Next(50, 1000);
                            collection[row].Price = random.Next(40000, 90000);
                            collection[row].Asks = random.Next(50, 1000);
                            collection[row].AWork = random.Next(999);

                            collection.ResetItem(row);
                            Interlocked.Decrement(ref postedOperation);
                        }, null);
                    }
                    else
                    {
                        //collection[row] = new BookLine { BWork = random.Next(999), Bids = random.Next(50, 1000), Price = random.Next(40000, 90000), Asks = random.Next(50, 1000), AWork = random.Next(999) };
                        collection[row].BWork = random.Next(999);
                        collection[row].Bids = random.Next(50, 1000);
                        collection[row].Price = random.Next(40000, 90000);
                        collection[row].Asks = random.Next(50, 1000);
                        collection[row].AWork = random.Next(999);

                        collection.ResetItem(row);
                    }
                }
                this.changesFromPriopChangePerSecond++;
                for (;;)
                {
                    var elapsed = watch.ElapsedTicks;
                    var left = interEventDelay - elapsed;
                    if (left <= 0)
                    {
                        if (!useRealtimeSource)
                        {
                            Thread.Sleep(0);
                            while (backgroundSw.ElapsedMilliseconds > 12)
                            {
                                if (Interlocked.CompareExchange(ref needStop, 0, 0) != 0)
                                    break;
                                Thread.Sleep(1);
                            }
                            if (Interlocked.CompareExchange(ref postedOperation, 0, 0) > 100)
                            {
                                while (Interlocked.CompareExchange(ref postedOperation, 0, 0) > 10)
                                {
                                    if (Interlocked.CompareExchange(ref needStop, 0, 0) != 0)
                                        break;
                                    Thread.Sleep(0);
                                }
                            }
                        }
                        break;
                    }
                    if (left > 20000)
                        Thread.Sleep(1);
                }
                watch.Stop();
            } while (Interlocked.CompareExchange(ref needStop, 0, 0) == 0);
        }
        public void Stop()
        {
            Interlocked.Exchange(ref needStop, 1);
        }
        public void OnIdle(object state)
        {
            context.Post((x) => { backgroundSw.Reset(); backgroundSw.Start(); }, null);
        }
    }

}
