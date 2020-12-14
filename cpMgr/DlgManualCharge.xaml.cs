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
    /// DlgManualCharge.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class DlgManualCharge : Window
    {
        DispatcherTimer dispatcherTimer;
        RandomReadClass randomRead = new RandomReadClass();
        public DlgManualCharge()
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
            spCharge.Status = randomRead.GetData("M511");
        }

        private void btnON_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show(this, "Do you want Charge on?", "Conform",  MessageBoxButton.YesNo) ==  MessageBoxResult.Yes)
                MELSEC.SetPulse("M550");
        }

        private void btnOFF_Click(object sender, RoutedEventArgs e)
        {
            MELSEC.SetPulse("M551");
        }
    }
}
