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

namespace cpMgr
{
    /// <summary>
    /// DlgLogin.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class DlgLogin : Window
    {
        public DlgLogin()
        {
            InitializeComponent();
            txtUserID.Text = GBL.userID;
            txtPassword.Password = GBL.passWord;
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            int rst = LocalDB.CheckUser(txtUserID.Text, txtPassword.Password);
            if (rst != -1)
            {
                GBL.userLevel = rst;
                this.DialogResult = true;
                this.Close();
                return;
            }
            MessageBox.Show(this, "Invalid User-ID or Password.");
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void txtUserID_Click(object sender, MouseButtonEventArgs e)
        {
            //DlgKeyboard dlg = new DlgKeyboard(txtUserID.Text);
            //dlg.Owner = GBL.MainWindow;
            //dlg.Title = "User ID";
            //dlg.ShowDialog();
            //txtUserID.Text = dlg._inStr;
        }

         private void txtUserID_Click(object sender, RoutedEventArgs e)
        {
            DlgKeyboard dlg = new DlgKeyboard(txtUserID.Text);
            dlg.Owner = Application.Current.MainWindow;
            dlg.Title = "User ID";
            dlg.ShowDialog();
            txtUserID.Text = dlg._inStr;
        }

        private void txtPassword_Click(object sender, RoutedEventArgs e)
        {
            DlgKeyboard dlg = new DlgKeyboard(txtPassword.Password, true);
            dlg.Owner = Application.Current.MainWindow;
            dlg.Title = "Password";
            dlg.ShowDialog();
            txtPassword.Password = dlg._inStr;
        }
    }
}
