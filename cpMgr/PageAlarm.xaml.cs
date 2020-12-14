using System.Windows;
using System.Windows.Controls;

namespace cpMgr
{
    /// <summary>
    /// PageAlarm.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class PageAlarm : Page
    {
        // Page
        PageUserAlarm pageUserAlarm = null;
        PageAlarmHistory pageAlarmHistory = null;

        public PageAlarm()
        {
            InitializeComponent();

            pageUserAlarm = new PageUserAlarm();
            pageAlarmHistory = new PageAlarmHistory();
            rbUserAlarm.IsChecked = true;
        }

        private void rbUserAlarm_Checked(object sender, RoutedEventArgs e)
        {
            if (pageUserAlarm == null) return;
            frame1.Navigate(pageUserAlarm);
        }

        private void rbAlarmHistory_Checked(object sender, RoutedEventArgs e)
        {
            if (pageAlarmHistory == null) return;
            frame1.Navigate(pageAlarmHistory);
        }
    }
}
