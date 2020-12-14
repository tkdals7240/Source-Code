using FmsTec.Util;
using log4net;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace cpMgr
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        // Page
        PageOperator pageOperator = null;
        PageControl pageControl = null;
        PageMonitor pageMonitor = null;
        PageLog pageLog = null;
        PageSetting pageSetting = null;
        PageAlarm pageAlarm = null;

        // Timer
        DispatcherTimer dispatcherTimer;
        bool blinkFlg = false;

        private static readonly ILog _Log = LogManager.GetLogger("MAIN");
        RandomReadClass randomRead = new RandomReadClass();
        DlgBcrReadFail dlgBcrReadFail = null;

        // Temp Status
        int _UserLevel = -1;

        public MainWindow()
        {
            InitializeComponent();

            // Create BCR Read Fail Dialog
            dlgBcrReadFail = new DlgBcrReadFail();

            // Windows Style
            if (GBL.wndMax)
            {
                this.ResizeMode = ResizeMode.CanResizeWithGrip;
                this.WindowStyle = WindowStyle.None;
                this.ShowInTaskbar = true;
                this.WindowState = WindowState.Maximized;
            }

            // GLOBAL 초기화
            GBL.Init();

            // Create Page Screen
            Create_Page();
        }

        void Create_Page()
        {
            // Init Page
            pageOperator = new PageOperator();
            pageControl = new PageControl();
            pageMonitor = new PageMonitor();
            pageLog = new PageLog();
            pageSetting = new PageSetting();
            pageAlarm = new PageAlarm();

            // First Display Operation Screen
            rbOperator.IsChecked = true;
        }
        private void Window_ContentRendered(object sender, EventArgs e)
        {
            DlgLogin dlg = new DlgLogin();
            dlg.Owner = Application.Current.MainWindow;
            dlg.ShowDialog();

            //  DispatcherTimer setup
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 500);
            dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            // 깜빡임 Flag
            blinkFlg = !blinkFlg;

            // PLC 통신상태
            if (MELSEC.Connected == false)
                lbCommErr.Visibility = blinkFlg ? Visibility.Visible : Visibility.Hidden;
            else
                lbCommErr.Visibility = Visibility.Hidden;


            // PLC Data Read
            randomRead.DataRead();

            // Online Status
            if (GBL.userLevel != _UserLevel)
            {
                _UserLevel = GBL.userLevel;
                if (GBL.userLevel > 0)
                {
                    lblOperMode.Foreground = Brushes.LimeGreen;
                    lblOperMode.Content = "----ON-";
                    //lbTitile.ForeColor = Color.LimeGreen;
                    pnlBottom.IsEnabled = true;
                }
                else
                {
                    lblOperMode.Foreground = Brushes.DarkGray;
                    lblOperMode.Content = "-OFF---";
                    //lbTitile.ForeColor = Color.White;
                    pnlBottom.IsEnabled = false;
                }
            }
            lbDataTime.Content = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            btnMain.Status = randomRead.GetData("D1000");
            btnAdmin.Status = GBL.userLevel == 0 ? 0 : 1;
            btnBuzzer.Status = randomRead.GetData("L3106");
            btnAlarm.Status = randomRead.GetData("L3104");

            //Console.WriteLine("D1000={0}", randomRead.GetData("D0001000"));

            // Display Active Screen Name
            if ((string)lbTitile.Content != GBL.activeScreen)
                lbTitile.Content = GBL.activeScreen;

            chkAutoMode.IsEnabled = randomRead.GetData("M3002") == 0;
            chkAutoMode.Status = randomRead.GetData("L3108");
            chkManualMode.IsEnabled = randomRead.GetData("M3001") == 0;
            chkManualMode.Status = randomRead.GetData("L3109");
            //chkStart.IsEnabled = GBL.userLevel == 1;
            chkStart.Status = randomRead.GetData("M3002") + randomRead.GetData("L3100");
            chkCycleStop.Status = randomRead.GetData("L3101");
            chkReset.Status = randomRead.GetData("L3104");
            chkBuzzerStop.Status = randomRead.GetData("L3106");
            chkDoorClose.IsEnabled = randomRead.GetData("M001") == 0;

            if (randomRead.GetData("M4012") == 1 && dlgBcrReadFail.IsVisible == false)
            {
                dlgBcrReadFail.Owner = Application.Current.MainWindow;
                dlgBcrReadFail.Show();
            }

            if (GBL.userLevel > 0)
            {
                int n = MyUtil.GetIdleTime();
                //Console.WriteLine("{0}/{1}", n, GBL.logoutTime);
                if (n > GBL.logoutTime) GBL.userLevel = 0;
            }
        }
        private void Window_Closed(object sender, EventArgs e)
        {
            // Resouce 반납
            dispatcherTimer.Stop();
            dlgBcrReadFail.ExitOK = true;
            dlgBcrReadFail.Close();
            //for (int i = 0; i < pnlMid.Controls.Count; i++)
            //    pnlMid.Controls[i].Dispose();

            //pnlMid.Controls.Clear();
            GBL.Close();
        }
        private void btnMain_Click(object sender, RoutedEventArgs e)
        {
            MELSEC.SetPulse("L2000");
            if (pageOperator == null) return;
            rbOperator.IsChecked = true;
            frame1.Navigate(pageOperator);
        }
        private void btnAdmin_Click(object sender, RoutedEventArgs e)
        {
            DlgLogin dlg = new DlgLogin();
            dlg.Owner = Application.Current.MainWindow;
            dlg.ShowDialog();
        }
        private void btnBuzzer_Click(object sender, RoutedEventArgs e)
        {
            MELSEC.SetInvert("L3106");
        }
        private void btnAlarm_Click(object sender, RoutedEventArgs e)
        {
            if (pageAlarm == null) return;
            frame1.Navigate(pageAlarm);
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show(this, "Do you want Exit?", "Conform",  MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                this.Close();
        }

        private void btnOperator_Checked(object sender, RoutedEventArgs e)
        {
            MELSEC.SetPulse("L2000");
            if (pageOperator == null) return;
            frame1.Navigate(pageOperator);
        }

        private void btnControl_Checked(object sender, RoutedEventArgs e)
        {
            if (pageControl == null) return;
            frame1.Navigate(pageControl);
        }

        private void btnMonitor_Checked(object sender, RoutedEventArgs e)
        {
            if (pageMonitor == null) return;
            frame1.Navigate(pageMonitor);
        }

        private void btnLog_Checked(object sender, RoutedEventArgs e)
        {
            if (pageLog == null) return;
            frame1.Navigate(pageLog);
        }

        private void btnSetting_Checked(object sender, RoutedEventArgs e)
        {
            if (pageSetting == null) return;
            frame1.Navigate(pageSetting);
        }

        private void chkAutoMode_Click(object sender, RoutedEventArgs e)
        {
            MELSEC.SetPulse("M3108");
            GBL.operatorScreenActive = 1;
            frame1.Navigate(pageOperator);
        }

        private void chkManualMode_Click(object sender, RoutedEventArgs e)
        {
            MELSEC.SetPulse("M3109");
            GBL.operatorScreenActive = 2;
            frame1.Navigate(pageOperator);
        }

        private void chkStart_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MELSEC.SetDevice("M3100", 1);
        }

        private void chkStart_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MELSEC.SetDevice("M3100", 0);
        }

        private void chkCycleStop_Click(object sender, RoutedEventArgs e)
        {
            MELSEC.SetPulse("M3101");
        }

        private void chkReset_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show(this, "Do you want Reset?", "Conform", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                MELSEC.SetPulse("M3104");
        }

        private void chkBuzzerStop_Click(object sender, RoutedEventArgs e)
        {
            MELSEC.SetInvert("L3106");
        }

        private void chkDoorClose_Click(object sender, RoutedEventArgs e)
        {
            //ActivateForm(typeof(FormControl));
        }
    }
}