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
    /// DlgPioMonitor.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class DlgPioMonitor : Window
    {
        DispatcherTimer dispatcherTimer;
        BlockReadClass blockRead1 = new BlockReadClass("B5000", 4);
        BlockReadClass blockRead2 = new BlockReadClass("B2000", 4);
        public DlgPioMonitor()
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
            blockRead1.DataRead();
            spPort1.Status = blockRead1.GetData("B5000");
            spPort2.Status = blockRead1.GetData("B5001");
            spPort3.Status = blockRead1.GetData("B5002");
            spPort4.Status = blockRead1.GetData("B5003");
            spPort5.Status = blockRead1.GetData("B5004");
            spPort6.Status = blockRead1.GetData("B5005");
            spPort7.Status = blockRead1.GetData("B5006");
            spPort8.Status = blockRead1.GetData("B5007");
            spPort9.Status = blockRead1.GetData("B5008");
            spPort10.Status = blockRead1.GetData("B5009");
            spPort11.Status = blockRead1.GetData("B500A");
            spPort12.Status = blockRead1.GetData("B500B");
            spPort13.Status = blockRead1.GetData("B500C");
            spPort14.Status = blockRead1.GetData("B500D");
            spPort15.Status = blockRead1.GetData("B500E");
            spPort16.Status = blockRead1.GetData("B500F");
            spPort17.Status = blockRead1.GetData("B5010");
            spPort18.Status = blockRead1.GetData("B503E");
            blockRead2.DataRead();
            spStk1.Status = blockRead2.GetData("B2000");
            spStk2.Status = blockRead2.GetData("B2001");
            spStk3.Status = blockRead2.GetData("B2002");
            spStk4.Status = blockRead2.GetData("B2003");
            spStk5.Status = blockRead2.GetData("B2004");
            spStk6.Status = blockRead2.GetData("B2005");
            spStk7.Status = blockRead2.GetData("B2006");
            spStk8.Status = blockRead2.GetData("B2007");
            spStk9.Status = blockRead2.GetData("B2008");
            spStk10.Status = blockRead2.GetData("B2009");
            spStk11.Status = blockRead2.GetData("B200A");
            spStk12.Status = blockRead2.GetData("B200B");
            spStk13.Status = blockRead2.GetData("B200C");
            spStk14.Status = blockRead2.GetData("B200D");
            spStk15.Status = blockRead2.GetData("B200E");
            spStk16.Status = blockRead2.GetData("B200F");
            spStk17.Status = blockRead2.GetData("B203E");
        }
    }
}
