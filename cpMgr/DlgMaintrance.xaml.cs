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
    /// DlgMaintrance.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class DlgMaintrance : Window
    {
        int alarmUpdate = 0;
        RandomReadClass randomRead = new RandomReadClass();
        DispatcherTimer dispatcherTimer;
        public DlgMaintrance()
        {
            InitializeComponent();
            this.WindowState = WindowState.Normal;
            this.WindowStyle = WindowStyle.None;
            this.ShowInTaskbar = true;

            //  DispatcherTimer setup
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 500);
            dispatcherTimer.Start();
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            lbDataTime.Content = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

            // Data Read
            randomRead.DataRead();

            // Status Display
            btnLight.Status = randomRead.GetData("Y091F");
            btnBuzzer.Status = randomRead.GetData("L3106");
            btnReset.Status = randomRead.GetData("L3104");
            if (alarmUpdate != GBL.AlarmUpdate)
            {
                alarmUpdate = GBL.AlarmUpdate;
                Alarm_Display();
            }
        }

        void Alarm_Display()
        {
            listView1.Items.Clear();
            foreach (var item in GBL.AlarmList)
            {
                if (item.dt != DateTime.MinValue)
                {
                    if (item.dt == DateTime.MinValue) item.dt = DateTime.Now;
                    AlarmListClass almData1 = new AlarmListClass
                    {
                        date = item.dt.ToString("yyyy-MM-dd HH:mm:ss"),
                        trig = item.trigger.ToString(),
                        message = item.message,
                        brush = Brushes.White
                    };
                    listView1.Items.Add(almData1);
                }
            }
        }

        private void btnLight_Click(object sender, RoutedEventArgs e)
        {
            MELSEC.SetInvert("M3010");
        }

        private void btnBuzzer_Click(object sender, RoutedEventArgs e)
        {
            MELSEC.SetInvert("L3106");
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show(this, "Do you want Reset?", "Conform",  MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                MELSEC.SetPulse("M3104");
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            DlgPassword dlg = new DlgPassword();
            dlg.Owner = Application.Current.MainWindow;
            if (dlg.ShowDialog() == true)
            {
                this.Close();
            }
        }

        public class AlarmListClass
        {
            public string date { get; set; }
            public string trig { get; set; }
            public string message { get; set; }
            public Brush brush { get; set; }
        }
    }
}
