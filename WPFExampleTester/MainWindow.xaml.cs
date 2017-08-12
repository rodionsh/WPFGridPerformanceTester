using System.Threading;
using System.Windows.Threading;
using DevExpress.Xpf.Bars;
using DevExpress.Xpf.Ribbon;
using WPFGridPerformanceTester;

namespace WPFExampleTester
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : DXRibbonWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void newItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            BasicWindow window = new BasicWindow();
            window.Show();
        }

        private void newDXItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            var window = new BasicDXWindow();
            window.Show();
        }

        private void NewSyncfusionItem_OnItemClick(object sender, ItemClickEventArgs e)
        {
            var newWindowThread = new Thread(() =>
            {
                SynchronizationContext.SetSynchronizationContext(
                    new DispatcherSynchronizationContext(Dispatcher.CurrentDispatcher));
                var window = new BasicSyncfusionWindow();
                window.Closed +=
                    (s, e2) => Dispatcher.CurrentDispatcher.BeginInvokeShutdown(DispatcherPriority.Background);
                window.Show();
                Dispatcher.Run();
            });
            newWindowThread.SetApartmentState(ApartmentState.STA);
            newWindowThread.IsBackground = true;
            newWindowThread.Start();
        }

        private void NewTelerikItem_OnItemClick(object sender, ItemClickEventArgs e)
        {
            var newWindowThread = new Thread(() =>
            {
                SynchronizationContext.SetSynchronizationContext(
                    new DispatcherSynchronizationContext(Dispatcher.CurrentDispatcher));
                var window = new BasicTelerikWindow();
                window.Closed +=
                    (s, e2) => Dispatcher.CurrentDispatcher.BeginInvokeShutdown(DispatcherPriority.Background);
                window.Show();
                Dispatcher.Run();
            });
            newWindowThread.SetApartmentState(ApartmentState.STA);
            newWindowThread.IsBackground = true;
            newWindowThread.Start();
        }

        private void NewBasicMutlithreaded_OnItemClick(object sender, ItemClickEventArgs e)
        {
            var newWindowThread = new Thread(() =>
            {
                SynchronizationContext.SetSynchronizationContext(
                    new DispatcherSynchronizationContext(Dispatcher.CurrentDispatcher));
                var window = new BasicWindowMultiThreaded();
                window.Closed +=
                    (s, e2) => Dispatcher.CurrentDispatcher.BeginInvokeShutdown(DispatcherPriority.Background);
                window.Show();
                Dispatcher.Run();
            });
            newWindowThread.SetApartmentState(ApartmentState.STA);
            newWindowThread.IsBackground = true;
            newWindowThread.Start();
        }

        private void NewC1Item_OnItemClick(object sender, ItemClickEventArgs e)
        {
            var newWindowThread = new Thread(() =>
            {
                SynchronizationContext.SetSynchronizationContext(
                    new DispatcherSynchronizationContext(Dispatcher.CurrentDispatcher));
                var window = new BasicC1Window();
                window.Closed +=
                    (s, e2) => Dispatcher.CurrentDispatcher.BeginInvokeShutdown(DispatcherPriority.Background);
                window.Show();
                Dispatcher.Run();
            });
            newWindowThread.SetApartmentState(ApartmentState.STA);
            newWindowThread.IsBackground = true;
            newWindowThread.Start();
        }

        private void NewItemMT_OnItemClick(object sender, ItemClickEventArgs e)
        {
            var newWindowThread = new Thread(() =>
            {
                SynchronizationContext.SetSynchronizationContext(
                    new DispatcherSynchronizationContext(Dispatcher.CurrentDispatcher));
                var window = new BasicWindow();
                window.Closed +=
                    (s, e2) => Dispatcher.CurrentDispatcher.BeginInvokeShutdown(DispatcherPriority.Background);
                window.Show();
                Dispatcher.Run();
            });
            newWindowThread.SetApartmentState(ApartmentState.STA);
            newWindowThread.IsBackground = true;
            newWindowThread.Start();
        }

        private void NewDXItemMT_OnItemClick(object sender, ItemClickEventArgs e)
        {
            var newWindowThread = new Thread(() =>
            {
                SynchronizationContext.SetSynchronizationContext(
                    new DispatcherSynchronizationContext(Dispatcher.CurrentDispatcher));
                var window = new BasicDXWindow();
                window.Closed +=
                    (s, e2) => Dispatcher.CurrentDispatcher.BeginInvokeShutdown(DispatcherPriority.Background);
                window.Show();
                Dispatcher.Run();
            });
            newWindowThread.SetApartmentState(ApartmentState.STA);
            newWindowThread.IsBackground = true;
            newWindowThread.Start();
        }
    }
}
