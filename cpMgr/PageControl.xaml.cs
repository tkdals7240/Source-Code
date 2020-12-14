using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace cpMgr
{
    /// <summary>
    /// PageControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class PageControl : Page
    {
        RandomReadClass randomRead = new RandomReadClass();
        DispatcherTimer dispatcherTimer;
        public PageControl()
        {
            InitializeComponent();
            randomRead.AddDev("L3109");

            //  DispatcherTimer setup
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 500);
            //dispatcherTimer.Start();
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            // Data Read
            randomRead.DataRead();

            // Get Operator mode
            bool bit1 = randomRead.GetData("X0B") == 1;
            bool bit2 = randomRead.GetData("X0E") == 1;
            if (bit1)
            {
                lblMsg1.Visibility = Visibility.Visible;
                lblMsg1.Content = "MAIN OP The internal escape switch is pressed.";
            }
            else if (bit2)
            {
                lblMsg1.Visibility = Visibility.Visible;
                lblMsg1.Content = "OP PANNEL The internal escape switch is pressed.";
            }
            else
            {
                lblMsg1.Visibility = Visibility.Hidden;
                lblMsg1.Content = "";
            }
            btnClose.Status = randomRead.GetData("M002903");
            btnLockOff.Status = randomRead.GetData("M002903");
            this.IsEnabled = GBL.userLevel > 0;
        }

        private void btnLockOff_Click(object sender, RoutedEventArgs e)
        {
            if (randomRead.GetData("L3109") != 1)
            {
                MessageBox.Show("Not mantance mode, please change mode.");
                return;
            }

            DlgPassword dlg = new DlgPassword();
            dlg.Owner = Application.Current.MainWindow;
            if (dlg.ShowDialog() == true)
            {
                MELSEC.SetDevice("M003150", 1);     // Open
                MELSEC.SetDevice("M003151", 0);     // Close
                DlgMaintrance dlg2 = new DlgMaintrance();
                dlg2.Owner = Application.Current.MainWindow;
                dlg2.ShowDialog();
            }
        }

        private void btnLockOn_Click(object sender, RoutedEventArgs e)
        {
            DlgPassword dlg = new DlgPassword();
            dlg.Owner = Application.Current.MainWindow;
            if (dlg.ShowDialog() == true)
            {
                MELSEC.SetDevice("M003150", 0);     // Open
                MELSEC.SetDevice("M003151", 1);     // Close
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            GBL.activeScreen = this.Title;
            dispatcherTimer.Start();
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Stop();
        }
    }
}
