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
    /// PageLog.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class PageLog : Page
    {
        // Page
        PageCstHistory pageCstHistory = null;

        public PageLog()
        {
            InitializeComponent();

            pageCstHistory = new PageCstHistory();
            rbCstHistory.IsChecked = true;
        }

        private void rbCountLog_Checked(object sender, RoutedEventArgs e)
        {
            if (pageCstHistory == null) return;
            frame1.Navigate(pageCstHistory);
        }
    }
}
