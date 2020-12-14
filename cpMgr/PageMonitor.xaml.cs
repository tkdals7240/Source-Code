using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace cpMgr
{
    /// <summary>
    /// PageMonitor.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class PageMonitor : Page
    {
        // Page
        PageCountLog pageCountLog = null;
        PagePioInterface pagePioInterface = null;
        PageIoStatus pageIoStatus = null;
        PageStepStatus pageStepStatus = null;

        public PageMonitor()
        {
            InitializeComponent();

            pageCountLog = new PageCountLog();
            pagePioInterface = new PagePioInterface();
            pageIoStatus = new PageIoStatus();
            pageStepStatus = new PageStepStatus();
            rbCountLog.IsChecked = true;
        }

        private void rbCountLog_Checked(object sender, RoutedEventArgs e)
        {
            if (pageCountLog == null) return;
            frame1.Navigate(pageCountLog);
        }

        private void rbPioInterface_Checked(object sender, RoutedEventArgs e)
        {
            if (pagePioInterface == null) return;
            frame1.Navigate(pagePioInterface);
        }

        private void rbIoStatus_Checked(object sender, RoutedEventArgs e)
        {
            if (pageIoStatus == null) return;
            frame1.Navigate(pageIoStatus);
        }

        private void rbStepStatus_Checked(object sender, RoutedEventArgs e)
        {
            if (pageStepStatus == null) return;
            frame1.Navigate(pageStepStatus);
        }
    }
}
