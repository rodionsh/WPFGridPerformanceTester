using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DevExpress.Xpf.Core;
using WPFExampleTester.ViewModels;

namespace WPFExampleTester
{
    /// <summary>
    /// Interaction logic for BasicDXWindow.xaml
    /// </summary>
    public partial class BasicDXWindow : DXWindow
    {
        public BasicDXWindow()
        {
            InitializeComponent();
        }

        protected override void OnClose()
        {
            (ABook.DataContext as BasicDXViewModel).Dispose();
            (BBook.DataContext as BasicDXViewModel).Dispose();
            (CBook.DataContext as BasicDXViewModel).Dispose();
            base.OnClose();
        }
    }
}
