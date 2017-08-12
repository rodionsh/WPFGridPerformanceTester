using System.Windows;
using System.Windows.Controls;
using WPFGridPerformanceTester.ViewModels;

namespace WPFGridPerformanceTester.Views
{
    public partial class BasicTelerikView : UserControl
    {
        private bool generating;
        public BasicTelerikView()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (!generating)
            {
                ((BasicTelerikViewModel)this.DataContext).Start();
            }
            else
            {
                ((BasicTelerikViewModel)this.DataContext).Stop();
            }
            generating = !generating;
        }
    }
}
