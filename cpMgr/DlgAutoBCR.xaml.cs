using System;
using System.Windows;
using System.Windows.Threading;

namespace cpMgr
{
    /// <summary>
    /// DlgAutoBCR.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class DlgAutoBCR : Window
    {
        RandomReadClass randomRead = new RandomReadClass();
        BlockReadClass blockRead = new BlockReadClass("D4000", 8);

        // Timer
        DispatcherTimer dispatcherTimer;

        public DlgAutoBCR()
        {
            InitializeComponent();

            //  DispatcherTimer setup
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 500);
            dispatcherTimer.Start();
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            randomRead.DataRead();
            if (!blockRead.DataRead()) return;
            txtCstID.Text = blockRead.GetText("D4000", 8);
            txtCountOK.Text = randomRead.GetData("R04038").ToString();
            txtCountNG.Text = randomRead.GetData("R04039").ToString();
            btnKeyIn.Status = randomRead.GetData("M004043");
            btnSkip.Status = randomRead.GetData("M004044");
        }

        private void btnRestOK_Click(object sender, RoutedEventArgs e)
        {
            MELSEC.SetPulse("M004041");
        }

        private void btnResetNG_Click(object sender, RoutedEventArgs e)
        {
            MELSEC.SetPulse("M004042");
        }

        private void btnTriger_Click(object sender, RoutedEventArgs e)
        {
            MELSEC.SetPulse("M004040");
        }

        private void btnKeyIn_Click(object sender, RoutedEventArgs e)
        {
            MELSEC.SetDevice("M004043", 1);
            MELSEC.SetDevice("M004043", 0);
            MELSEC.SetDevice("M004043", 0);
        }

        private void btnSkip_Click(object sender, RoutedEventArgs e)
        {
            MELSEC.SetDevice("M004043", 0);
            MELSEC.SetDevice("M004043", 1);
            MELSEC.SetDevice("M004043", 0);
        }
    }
}
