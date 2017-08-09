using DevExpress.Xpf.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WPFExampleTester.Views
{
    public class UpdatesLockHelper
    {
        public static bool GetIsUpdatesLocked(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsUpdatesLockedProperty);
        }
        public static void SetIsUpdatesLocked(DependencyObject obj, bool value)
        {
            obj.SetValue(IsUpdatesLockedProperty, value);
        }
        public static readonly DependencyProperty IsUpdatesLockedProperty =
            DependencyProperty.RegisterAttached("IsUpdatesLocked", typeof(bool), typeof(UpdatesLockHelper), new PropertyMetadata(false, new PropertyChangedCallback(
                (sender, e) =>
                {
                    if (sender is DataGrid)
                    {
                        // TODO
                    }
                })));

        public static bool GetIsUpdatesDXLocked(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsUpdatesDXLockedProperty);
        }
        public static void SetIsUpdatesDXLocked(DependencyObject obj, bool value)
        {
            obj.SetValue(IsUpdatesDXLockedProperty, value);
        }
        public static readonly DependencyProperty IsUpdatesDXLockedProperty =
            DependencyProperty.RegisterAttached("IsUpdatesDXLocked", typeof(bool), typeof(UpdatesLockHelper), new PropertyMetadata(false, new PropertyChangedCallback(
                (sender, e) =>
                {
                    if (sender is DataControlBase)
                    {
                        if ((bool)e.NewValue)
                        {
                            (sender as DataControlBase).BeginDataUpdate();
                        }
                        else
                        {
                            (sender as DataControlBase).EndDataUpdate();
                        }
                    }
                })));
    }
}
