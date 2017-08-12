using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using Telerik.Windows.Automation.Peers;

namespace WPFExampleTester
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void OnAppStartup_UpdateThemeName(object sender, StartupEventArgs e)
        {
            DevExpress.Xpf.Core.ApplicationThemeHelper.UpdateApplicationThemeName();
            AutomationManager.AutomationMode = AutomationMode.Disabled;
            RenderOptions.ProcessRenderMode = RenderMode.SoftwareOnly;
        }
    }
}
