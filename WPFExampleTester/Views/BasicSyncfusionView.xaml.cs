using System.Windows;
using System.Windows.Controls;
using WPFGridPerformanceTester.ViewModels;

namespace WPFGridPerformanceTester.Views
{
    public partial class BasicSyncfusionView : UserControl
    {
        private bool generating;
        public BasicSyncfusionView()
        {
            InitializeComponent();
            var dataContext = new BasicSyncfusionModel(BookControl);
            DataContext = dataContext;
            BookControl.ItemsSource = dataContext.Data;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (!generating)
            {
                ((BasicSyncfusionModel)this.DataContext).Start();
            }
            else
            {
                ((BasicSyncfusionModel)this.DataContext).Stop();
            }
            generating = !generating;
        }
    }
}
