using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WFGridPerformanceTester;
using WFGridPerformanceTester.Views;

namespace WFGridPerformanceTester
{
    public partial class MainView : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public MainView()
        {
            InitializeComponent();
            if (!mvvmContext1.IsDesignMode)
                InitializeBindings();
        }

        void InitializeBindings()
        {
            var fluent = mvvmContext1.OfType<MainViewModel>();
        }

        private void newItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void newDXItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BasicDXForm form = new BasicDXForm();
            form.Show();
        }
    }
}
