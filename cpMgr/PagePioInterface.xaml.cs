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
using System.Windows.Threading;

namespace cpMgr
{
    /// <summary>
    /// PagePioInterface.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class PagePioInterface : Page
    {
        RandomReadClass randomRead = new RandomReadClass();
        BlockReadClass blockRead1 = new BlockReadClass("R00000", 32);
        BlockReadClass blockRead2 = new BlockReadClass("W02000", 32);
        DispatcherTimer dispatcherTimer;
        public PagePioInterface()
        {
            InitializeComponent();

            //  DispatcherTimer setup
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 500);
            //dispatcherTimer.Start();
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
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            randomRead.DataRead();
            blockRead1.DataRead();
            blockRead2.DataRead();
            lbCstID1.Content = blockRead1.GetText("R00000", 32);
            lbCstID1.Content = blockRead2.GetText("W002000", 32);
            spLdReq.Status = randomRead.GetData("B5000");
            spUldReq.Status = randomRead.GetData("B5001");
            spReady.Status = randomRead.GetData("B5002");
            spAbnormal1.Status = randomRead.GetData("B5003");
            spCstContain1.Status = randomRead.GetData("B5007");
            spTrRequest.Status = randomRead.GetData("B2000");
            spCstContain2.Status = randomRead.GetData("B2005");
            spBusy.Status = randomRead.GetData("B2003");
            spComplete.Status = randomRead.GetData("B2002");
            spAbnormal2.Status = randomRead.GetData("B5007");
            spForkDetect.Status = randomRead.GetData("M33");
            spStkHotLine.Status = randomRead.GetData("M30");
        }

        private void btnPioViewAll_Click(object sender, RoutedEventArgs e)
        {
            DlgPioMonitor dlg = new DlgPioMonitor();
            dlg.Owner = Application.Current.MainWindow;
            dlg.ShowDialog();
        }
    }
}
