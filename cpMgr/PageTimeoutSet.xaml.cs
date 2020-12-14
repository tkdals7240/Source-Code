using FmsTec.Util;
using System.Windows;
using System.Windows.Controls;

namespace cpMgr
{
    /// <summary>
    /// PageTimeoutSet.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class PageTimeoutSet : Page
    {
        public PageTimeoutSet()
        {
            InitializeComponent();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            GBL.activeScreen = this.Title;
            txtLogoutTime.Text = GBL.logoutTime.ToString();
            this.IsEnabled = GBL.userLevel > 0;
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            IniFile inifile = new IniFile();
            inifile.WriteStr("Common", "LogoutTime", txtLogoutTime.Text);
            GBL.logoutTime = int.Parse(txtLogoutTime.Text);
            MessageBox.Show("Saved Logout-time.");
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox txtbox = sender as TextBox;
            DlgKeyboard dlg = new DlgKeyboard(txtbox.Text);
            dlg.Owner = Application.Current.MainWindow;
            dlg.Title = "Logout Time";
            dlg.ShowDialog();
            txtbox.Text = dlg._inStr;
        }
    }
}
