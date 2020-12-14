using System.Windows;
using System.Windows.Controls;

namespace cpMgr
{
    /// <summary>
    /// PageSetting.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class PageSetting : Page
    {
        // Page
        PageMdmsSet pageMdmsSet = null;
        PageTimeoutSet pageTimeoutSet = null;
        PageUserMgr pageUserMgr = null;

        public PageSetting()
        {
            InitializeComponent();

            pageMdmsSet = new PageMdmsSet();
            pageTimeoutSet = new PageTimeoutSet();
            pageUserMgr = new PageUserMgr();
            rbMdms.IsChecked = true;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (GBL.userLevel >= 2)
                rbUserMgr.Visibility = Visibility.Visible;
            else
                rbUserMgr.Visibility = Visibility.Hidden;
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {

        }

        private void rbMdms_Checked(object sender, RoutedEventArgs e)
        {
            if (pageMdmsSet == null) return;
            frame1.Navigate(pageMdmsSet);
        }
        private void rbTimeout_Checked(object sender, RoutedEventArgs e)
        {
            if (pageTimeoutSet == null) return;
            frame1.Navigate(pageTimeoutSet);
        }

        private void btnAbout_Click(object sender, RoutedEventArgs e)
        {
            DlgAbout dlg = new DlgAbout();
            dlg.Owner = Application.Current.MainWindow;
            dlg.ShowDialog();
        }
        private void rbUserMgr_Checked(object sender, RoutedEventArgs e)
        {
            if (pageUserMgr == null) return;
            frame1.Navigate(pageUserMgr);
        }
    }
}
