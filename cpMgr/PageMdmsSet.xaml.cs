using FmsTec.Util;
using System.Windows;
using System.Windows.Controls;

namespace cpMgr
{
    /// <summary>
    /// PageMdmsSet.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class PageMdmsSet : Page
    {
        BlockReadClass blockRead = new BlockReadClass("D4000", 40);
        public PageMdmsSet()
        {
            InitializeComponent();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            GBL.activeScreen = this.Title;
            if (!blockRead.DataRead()) return;
            txtCstID1a.Text = blockRead.GetText("D4000", 8);
            txtCstID2a.Text = blockRead.GetText("D4008", 8);
            txtCstID3a.Text = blockRead.GetText("D4010", 8);
            txtCstID4a.Text = blockRead.GetText("D4018", 8);
            txtCstID5a.Text = blockRead.GetText("D4020", 8);

            IniFile inifile = new IniFile();
            GBL.cstID[0] = inifile.ReadStr("M-DMS", "CSTID1", "");
            GBL.cstID[1] = inifile.ReadStr("M-DMS", "CSTID2", "");
            GBL.cstID[2] = inifile.ReadStr("M-DMS", "CSTID3", "");
            GBL.cstID[3] = inifile.ReadStr("M-DMS", "CSTID4", "");
            GBL.cstID[4] = inifile.ReadStr("M-DMS", "CSTID5", "");

            txtCstID1.Text = GBL.cstID[0];
            txtCstID2.Text = GBL.cstID[1];
            txtCstID3.Text = GBL.cstID[2];
            txtCstID4.Text = GBL.cstID[3];
            txtCstID5.Text = GBL.cstID[4];
            this.IsEnabled = GBL.userLevel > 0;
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {

        }

        private void btnMdmsSave_Click(object sender, RoutedEventArgs e)
        {
            MELSEC.SetText("D4000", txtCstID1.Text, 8);
            MELSEC.SetText("D4008", txtCstID2.Text, 8);
            MELSEC.SetText("D4010", txtCstID3.Text, 8);
            MELSEC.SetText("D4018", txtCstID4.Text, 8);
            MELSEC.SetText("D4020", txtCstID5.Text, 8);
            GBL.cstID[0] = txtCstID1.Text;
            GBL.cstID[1] = txtCstID2.Text;
            GBL.cstID[2] = txtCstID3.Text;
            GBL.cstID[3] = txtCstID4.Text;
            GBL.cstID[4] = txtCstID5.Text;
            blockRead.DataRead();
            txtCstID1a.Text = blockRead.GetText("D4000", 8);
            txtCstID2a.Text = blockRead.GetText("D4008", 8);
            txtCstID3a.Text = blockRead.GetText("D4010", 8);
            txtCstID4a.Text = blockRead.GetText("D4018", 8);
            txtCstID5a.Text = blockRead.GetText("D4020", 8);
            IniFile inifile = new IniFile();
            inifile.WriteStr("M-DMS", "CSTID1", GBL.cstID[0]);
            inifile.WriteStr("M-DMS", "CSTID2", GBL.cstID[1]);
            inifile.WriteStr("M-DMS", "CSTID3", GBL.cstID[2]);
            inifile.WriteStr("M-DMS", "CSTID4", GBL.cstID[3]);
            inifile.WriteStr("M-DMS", "CSTID5", GBL.cstID[4]);
            MessageBox.Show("Saved CST-ID.");
        }

        private void txtCstID_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox txtbox = sender as TextBox;
            DlgKeyboard dlg = new DlgKeyboard(txtbox.Text);
            dlg.Owner = Application.Current.MainWindow;
            dlg.Title = "M-DMS CST-ID";
            dlg.ShowDialog();
            txtbox.Text = dlg._inStr;
        }
    }
}
