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
    /// DlgPassword.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class DlgPassword : Window
    {
        public DlgPassword()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            if (txtPassword.Password == "8888")
            {
                this.DialogResult = true;
                this.Close();
                return;
            }
            MessageBox.Show(this, "Invalid Password.");
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
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
