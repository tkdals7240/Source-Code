using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// PageIoStatus.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class PageIoStatus : Page
    {
        DispatcherTimer dispatcherTimer;
        BlockReadClass blockRead = new BlockReadClass("X00", 1);
        public ObservableCollection<ListVew1Class> listView1List = new ObservableCollection<ListVew1Class>();
        public PageIoStatus()
        {
            InitializeComponent();

            // first display
            rbMCP.IsChecked = true;
            rbInput1.IsChecked = true;

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
            for (int i = 0; i < listView1List.Count; i++)
            {
                ListVew1Class lvi = listView1List[i];
                string addr = lvi.address;
                int value = blockRead.GetData(addr);
                if (value == 0)
                    lvi.addrcolor = Brushes.LightGray;
                else
                    lvi.addrcolor = Brushes.LimeGreen;
            }
            listView1.Items.Refresh();
        }

        private void radioBtn_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = (RadioButton)sender;

            if (rbMCP.IsChecked == true)
            {
                if (rbInput1.IsChecked == true)
                    ListDisplay("1");
                else
                    ListDisplay("2");
            }
            else
            {
                if (rbInput1.IsChecked == true)
                    ListDisplay("3");
                else
                    ListDisplay("4");
            }
        }

        private void ListDisplay(string gubun)
        {
            // Select Table
            var rstQry = LocalDB.GetIoData(gubun);

            // Display
            listView1List.Clear();
            foreach (var item in rstQry)
            {
                ListVew1Class lvi = new ListVew1Class();
                lvi.address = item.device;
                lvi.comment = item.comment;
                listView1List.Add(lvi);
            }
            string devAddr = listView1List[0].address;
            blockRead.ChangeAddr(devAddr, 1);

            listView1.ItemsSource = listView1List;
            listView1.Items.Refresh();
        }

        public class ListVew1Class
        {
            public string address { get; set; }
            public string comment { get; set; }
            public Brush addrcolor { get; set; }
        }
    }
}
