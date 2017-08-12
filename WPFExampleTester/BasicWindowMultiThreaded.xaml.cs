using System.Windows;
using System.Windows.Controls;
using WPFGridPerformanceTester.ViewModels;

namespace WPFGridPerformanceTester
{
    /// <summary>
    /// Interaction logic for BasicWindowMultiThreaded.xaml
    /// </summary>
    public partial class BasicWindowMultiThreaded : Window
    {
        private BasicMutithreadedDataSet aDataSet = new BasicMutithreadedDataSet();
        private BasicMutithreadedDataSet bDataSet = new BasicMutithreadedDataSet();
        private BasicMutithreadedDataSet cDataSet = new BasicMutithreadedDataSet();

        public BasicWindowMultiThreaded()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick1(object sender, RoutedEventArgs e)
        {
            aDataSet.UpdateItems = ((CheckBox)sender).IsChecked ?? false;
            AGrid.ItemsSource = aDataSet.Items;
        }

        private void ButtonBase_OnClick2(object sender, RoutedEventArgs e)
        {
            bDataSet.UpdateItems = ((CheckBox)sender).IsChecked ?? false;
            BGrid.ItemsSource = bDataSet.Items;
        }

        private void ButtonBase_OnClick3(object sender, RoutedEventArgs e)
        {
            cDataSet.UpdateItems = ((CheckBox)sender).IsChecked ?? false;
            CGrid.ItemsSource = cDataSet.Items;
        }
    }
}
