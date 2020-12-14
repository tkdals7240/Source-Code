using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace cpMgr
{
    /// <summary>
    /// PageCountLog.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class PageCountLog : Page
    {
        BlockReadClass blockRead = new BlockReadClass("R31000", 111);
        DispatcherTimer dispatcherTimer;
        public ObservableCollection<ListVew1Class> listView1List = new ObservableCollection<ListVew1Class>();
        public PageCountLog()
        {
            InitializeComponent();

            for (int i = 1; i <= 16; i++)
            {
                ListVew1Class listView1Item = new ListVew1Class
                {
                    no = i.ToString(),
                    date = "",
                    count = "",
                    brush = Brushes.White
                };
                listView1List.Add(listView1Item);
            }
            listView1.ItemsSource = listView1List;
            listView1.Items.Refresh();

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
            if (!blockRead.DataRead()) return;

            txtTodayCount.Text = blockRead.GetData("R31110").ToString();
            txtYesterDay.Text = blockRead.GetData("R31003").ToString();
            txtTotalCount.Text = blockRead.GetData("R31100").ToString();
            SetListView(0, "R31000", "R31001", "R31002", "R31003");
            SetListView(1, "R31005", "R31006", "R31007", "R31008");
            SetListView(2, "R31010", "R31011", "R31012", "R31013");
            SetListView(3, "R31015", "R31016", "R31017", "R31018");
            SetListView(4, "R31020", "R31021", "R31022", "R31023");
            SetListView(5, "R31025", "R31026", "R31027", "R31028");
            SetListView(6, "R31030", "R31031", "R31032", "R31033");
            SetListView(7, "R31035", "R31036", "R31037", "R31038");
            SetListView(8, "R31040", "R31041", "R31042", "R31043");
            SetListView(9, "R31045", "R31046", "R31047", "R31048");
            SetListView(10, "R31050", "R31051", "R31052", "R31053");
            SetListView(11, "R31055", "R31056", "R31057", "R31058");
            SetListView(12, "R31060", "R31061", "R31062", "R31063");
            SetListView(13, "R31065", "R31066", "R31067", "R31068");
            SetListView(14, "R31070", "R31071", "R31072", "R31073");
            SetListView(15, "R31075", "R31076", "R31077", "R31078");
            listView1.Items.Refresh();
        }
        private void SetListView(int no, string yyDev, string mmDev, string ddDev, string cntDev)
        {
            ListVew1Class lvi = listView1List[no];
            string yy = blockRead.GetData(yyDev).ToString();
            string mm = blockRead.GetData(mmDev).ToString();
            string dd = blockRead.GetData(ddDev).ToString();
            string cnt = blockRead.GetData(cntDev).ToString();
            lvi.date = string.Format("{0,2:00}/{1,2:00}/{2,2:00}", yy, mm, dd);
            lvi.count = cnt.ToString();
        }

        public class ListVew1Class
        {
            public string no { get; set; }
            public string date { get; set; }
            public string count { get; set; }
            public Brush brush { get; set; }
        }
    }
}
