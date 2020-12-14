using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// PageOperator.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class PageOperator : Page
    {
        RandomReadClass randomRead = new RandomReadClass();
        BlockReadClass blockRead = new BlockReadClass("D4000", 8);
        bool isAutoMode = false;
        bool isManualMode = false;
        bool oldAutoMode = false;
        bool oldManualMode = false;

        // Timer
        DispatcherTimer dispatcherTimer;

        public PageOperator()
        {
            InitializeComponent();

            //  DispatcherTimer setup
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 500);
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (isAutoMode)
                GBL.activeScreen = "AUTO MODE";
            else
                GBL.activeScreen = "MANUAL MODE";
            dispatcherTimer.Start();
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Stop();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            // Data Read
            randomRead.DataRead();
            blockRead.DataRead();

            // Get Operator mode
            isAutoMode = randomRead.GetData("L3108") == 1;
            isManualMode = randomRead.GetData("L3109") == 1;

            // background color
            if (isAutoMode != oldAutoMode)
            {
                oldAutoMode = isAutoMode;
                if (isAutoMode) GBL.activeScreen = "AUTO MODE";
                cvsMain.Background = isAutoMode ? Brushes.DeepSkyBlue : Brushes.Silver;
            }
            if (isManualMode != oldManualMode)
            {
                oldManualMode = isManualMode;
                if (isManualMode) GBL.activeScreen = "MANUAL MODE";
            }

            // Side Bar
            chkAbnormal.Status = randomRead.GetData("M002901");
            chkEmsStatus.Status = randomRead.GetData("M002900");
            chkAutoStatus.Status = randomRead.GetData("M003001");
            chkOperModeStatus.Status = randomRead.GetData("D001825");
            chkLightCurtain1.Status = randomRead.GetData("X1B29");
            btnModeChange.Status = randomRead.GetData("M003149");
            btnFWD.Status = randomRead.GetData("L003000");
            btnBWD.Status = randomRead.GetData("L003010");
            btnLightOn.Status = randomRead.GetData("Y091F");
            //btnLightOn.Text = (btnLightOn.Status == 1) ? "LIGHT ON" : "LIGHT OFF";

            // Main
            spRFID.Status = randomRead.GetData("D1020") == 0 ? 0 : 1;
            spCST.Status = randomRead.GetData("M0041");
            txtRFID.Content = blockRead.GetText("D4000", 8);
            spShuttle.Status = randomRead.GetData("L022500");
            int n1 = randomRead.GetData("M33");
            int n2 = randomRead.GetData("M34");
            if (n1 == 1 && n2 == 0) spChargeBar.Status = 2;
            else if (n1 == 0 && n2 == 1) spChargeBar.Status = 1;
            else spChargeBar.Status = 0;
            spCharger.Status = randomRead.GetData("M511");
            this.IsEnabled = GBL.userLevel > 0;
        }

        private void btnLightOn_Click(object sender, RoutedEventArgs e)
        {
            MELSEC.SetInvert("M3010");
        }

        private void btnFWD_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MELSEC.SetDevice("M003145", 1);
        }

        private void btnFWD_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MELSEC.SetDevice("M003145", 0);
        }

        private void btnBWD_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MELSEC.SetDevice("M003146", 1);
        }

        private void btnBWD_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MELSEC.SetDevice("M003146", 0);
        }

        private void btnModeChange_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MELSEC.SetDevice("M003149", 1);
        }

        private void btnModeChange_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MELSEC.SetDevice("M003149", 0);
        }

        private void spRFID_Click(object sender, MouseButtonEventArgs e)
        {
            if (isAutoMode)
            {
                DlgAutoBCR dlg = new DlgAutoBCR();
                dlg.Owner = Application.Current.MainWindow;
                dlg.ShowDialog();
            }
        }

        private void spCST_Click(object sender, MouseButtonEventArgs e)
        {
            if (isManualMode)
            {
                DlgManualNormal dlg = new DlgManualNormal();
                dlg.Owner = Application.Current.MainWindow;
                dlg.ShowDialog();
            }
        }

        private void spCharger_Click(object sender, MouseButtonEventArgs e)
        {
            if (isManualMode)
            {
                DlgManualCharge dlg = new DlgManualCharge();
                dlg.Owner = Application.Current.MainWindow;
                dlg.ShowDialog();
            }
        }
    }
}
