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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace cpMgr
{
    /// <summary>
    /// DlgManualNormal.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class DlgManualNormal : Window
    {
        DispatcherTimer dispatcherTimer;
        RandomReadClass randomRead = new RandomReadClass();
        public DlgManualNormal()
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
            cvsMain.IsEnabled = randomRead.GetData("L3109") == 1;
            btnFloatOn.Status = randomRead.GetData("M24");
            btnFloatOff.Status = randomRead.GetData("M25");
            btnCenterOn.Status = randomRead.GetData("M20");
            btnCenterOff.Status = randomRead.GetData("M21");
            spLamp1.Status = randomRead.GetData("M10");
            spLamp2.Status = randomRead.GetData("M11");
            spLamp3.Status = randomRead.GetData("M10");
            btnChargeBarUp.Status = randomRead.GetData("M33");
            btnChargeBarDown.Status = randomRead.GetData("M34");
        }

        private void btnFloatOn_Click(object sender, RoutedEventArgs e)
        {
            MELSEC.SetPulse("M1554");
        }

        private void btnFloatOff_Click(object sender, RoutedEventArgs e)
        {
            MELSEC.SetPulse("M1555");
        }

        private void btnCenterOn_Click(object sender, RoutedEventArgs e)
        {
            MELSEC.SetPulse("M1550");
        }

        private void btnCenterOff_Click(object sender, RoutedEventArgs e)
        {
            MELSEC.SetPulse("M1551");
        }

        private void btnChargeBarUp_Click(object sender, RoutedEventArgs e)
        {
            MELSEC.SetPulse("M1556");
        }

        private void btnChargeBarDown_Click(object sender, RoutedEventArgs e)
        {
            MELSEC.SetPulse("M1557");
        }
    }
}
