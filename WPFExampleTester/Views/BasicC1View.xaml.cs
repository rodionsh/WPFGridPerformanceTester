using System.Windows;
using System.Windows.Controls;
using WPFGridPerformanceTester.ViewModels;

namespace WPFGridPerformanceTester.Views
{
    /// <summary>
    /// Interaction logic for BasicC1View.xaml
    /// </summary>
    public partial class BasicC1View : UserControl
    {
        private bool generating;

        public BasicC1View()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (!generating)
            {
                ((BasicGenericViewModel)this.DataContext).Start();
            }
            else
            {
                ((BasicGenericViewModel)this.DataContext).Stop();
            }
            generating = !generating;
        }
    }
}
