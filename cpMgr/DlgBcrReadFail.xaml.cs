using System;
using System.Windows;
using System.Windows.Threading;

namespace cpMgr
{
    /// <summary>
    /// DlgBcrReadFail.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class DlgBcrReadFail : Window
    {
        public bool ExitOK = false;
        RandomReadClass randomRead = new RandomReadClass();
        BlockReadClass blockRead1 = new BlockReadClass("D4000", 8);
        BlockReadClass blockRead2 = new BlockReadClass("D4020", 8);
        DispatcherTimer dispatcherTimer;

        public DlgBcrReadFail()
        {
            InitializeComponent();

            //  DispatcherTimer setup
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 500);
            //dispatcherTimer.Start();
        }

        private void btnKeyIn_Click(object sender, RoutedEventArgs e)
        {
            MELSEC.SetPulse("M004017", 0);
        }

        private void btnComplete_Click(object sender, RoutedEventArgs e)
        {
            MELSEC.SetPulse("M004017", 0);
            MELSEC.SetInvert("M004019");
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            randomRead.DataRead();
            if (!blockRead1.DataRead()) return;
            if (!blockRead2.DataRead()) return;
            txtBCR1.Text = blockRead1.GetText("D4000", 8);
            txtBCR2.Text = blockRead2.GetText("D4020", 8);
            btnKeyIn.Status = randomRead.GetData("M004017");
            btnComplete.Status = randomRead.GetData("M004044");
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!ExitOK)
            {
                this.Hide();
                e.Cancel = true;
            }
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (this.IsVisible)
                dispatcherTimer.Start();
            else
                dispatcherTimer.Stop();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            dispatcherTimer.Stop();
        }
    }
}
