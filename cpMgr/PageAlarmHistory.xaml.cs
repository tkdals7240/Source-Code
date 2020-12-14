using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace cpMgr
{
    /// <summary>
    /// PageAlarmHistory.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class PageAlarmHistory : Page
    {
        DispatcherTimer dispatcherTimer;
        public ObservableCollection<ListVew1Class> listView1List = new ObservableCollection<ListVew1Class>();

        public PageAlarmHistory()
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
            Alarm_Display();
            //dispatcherTimer.Start();
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            //dispatcherTimer.Stop();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
        }
        void Alarm_Display()
        {
            listView1List.Clear();
            foreach (var item1 in GBL.AlarmHistory)
            {
                var item2 = GBL.AlarmList[item1.no];
                ListVew1Class lvi = new ListVew1Class()
                {
                    no = item2.no,
                    date = item1.dt.ToString("yyyy-MM-dd HH:mm:ss"),
                    trig = item2.trigger,
                    message = item2.message,
                    brush = Brushes.White
                };
                listView1List.Add(lvi);
            }
            listView1.ItemsSource = listView1List;
            listView1.Items.Refresh();
        }
        private void listView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListVew1Class selectedItem = (ListVew1Class)listView1.SelectedItem;
            if (selectedItem == null) return;

            int no = selectedItem.no;
        }

        public class ListVew1Class
        {
            public int no { get; set; }
            public string date { get; set; }
            public int trig { get; set; }
            public string message { get; set; }
            public Brush brush { get; set; }
        }
    }
}
