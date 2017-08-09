using DevExpress.Data;
using DevExpress.XtraEditors;
using System;
using System.Threading;
using WFGridPerformanceTester.Threads;

namespace WFGridPerformanceTester.Views
{
    public partial class BigBasicDXView : XtraUserControl
    {
        #region Properties

        #endregion

        #region Privates
        Timer backgroundTimer;

        Thread starterThread;

        UpdaterThread updaterThread;

        RealTimeSource realTimeSource;

        SynchronizationContext syncContext;
        #endregion

        #region Initialization
        /// <summary>
        /// Default Constructor
        /// </summary>
        public BigBasicDXView()
        {
            InitializeComponent();
            InitializeCustomComponents();
        }

        protected void InitializeCustomComponents()
        {
            this.Disposed += BasicDXView_Disposed;

            syncContext = SynchronizationContext.Current;
            updaterThread = new UpdaterThread(syncContext);

            double pow = (34 - 10 + 3) / 2.0;
            updaterThread.InterEventDelay = (int)Math.Pow(2.0, pow);

            //updaterThread.InterEventDelay = 500;

            realTimeSource = CreateRealTimeSource();
            bookGridControl.DataSource = realTimeSource;

            backgroundTimer = new Timer(updaterThread.OnIdle, null, TimeSpan.Zero, TimeSpan.FromMilliseconds(10));

            starterThread = new Thread(updaterThread.Do);
            starterThread.IsBackground = true;
            starterThread.Start();

            realTimeSource.DataSource = updaterThread.List;
        }

        private void BasicDXView_Disposed(object sender, EventArgs e)
        {
            updaterThread.Stop();
            if (starterThread != null)
                starterThread.Join();
            backgroundTimer.Dispose();

            if (realTimeSource != null)
            {
                realTimeSource.DataSource = null;
                realTimeSource.Dispose();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        static RealTimeSource CreateRealTimeSource()
        {
            RealTimeSource realTimeSource = new RealTimeSource();
            return realTimeSource;
        }
        #endregion
    }
}
