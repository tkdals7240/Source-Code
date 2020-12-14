using FmsTec.Util;
using LiteDB;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace cpMgr
{
    /// <summary>
    /// PageTimeoutSet.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class PageUserMgr : Page
    {
        LiteDatabase liteDB;
        public ObservableCollection<ListVew1Class> listView1List = new ObservableCollection<ListVew1Class>();
        public PageUserMgr()
        {
            InitializeComponent();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DataDisplay();
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {

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

        private void DataDisplay()
        {
            liteDB = LocalDB.liteDB;

            // Select Table
            var userTable = liteDB.GetCollection<UserTbl>("UserTbl");
            var rstQry = userTable.FindAll();

            // Display
            listView1List.Clear();
            foreach (var item in rstQry)
            {
                ListVew1Class listView1Item = new ListVew1Class
                {
                    no = item._id,
                    uid = item.userid,
                    pwd = item.password,
                    lvl = item.level
                };
                listView1List.Add(listView1Item);
            }
            listView1.ItemsSource = listView1List;
            listView1.Items.Refresh();
        }

        private void listView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListVew1Class selectedItem = (ListVew1Class)listView1.SelectedItem;
            if (selectedItem == null) return;
            txtUserID.Text = selectedItem.uid;
            txtPassword.Text = selectedItem.pwd;
            txtLevel.Text = selectedItem.lvl.ToString();
        }

        private void btnQuery_Click(object sender, RoutedEventArgs e)
        {
            DataDisplay();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            var userTable = liteDB.GetCollection<UserTbl>("UserTbl");
            var rstDat = userTable.FindOne(x => x.userid == txtUserID.Text);
            if (rstDat == null)
            {
                MessageBox.Show("Not Found user.");
                return;
            }
            rstDat.password = txtPassword.Text;
            userTable.Update(rstDat);
            DataDisplay();
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            var userTable = liteDB.GetCollection<UserTbl>("UserTbl");
            var rstQry = userTable.FindOne(x => x.userid == txtUserID.Text);
            var userData = new UserTbl
            {
                userid = txtUserID.Text,
                password = txtPassword.Text,
                level = int.Parse(txtLevel.Text)
            };
            userTable.Insert(userData);
            DataDisplay();
        }

        private void bttDelete_Click(object sender, RoutedEventArgs e)
        {
            var userTable = liteDB.GetCollection<UserTbl>("UserTbl");
            var rstDat = userTable.FindOne(x => x.userid == txtUserID.Text);
            if (rstDat == null)
            {
                MessageBox.Show("Not Found user.");
                return;
            }
            userTable.Delete(rstDat._id);
            DataDisplay();
        }
        public class ListVew1Class
        {
            public int no { get; set; }
            public string uid { get; set; }
            public string pwd { get; set; }
            public int lvl { get; set; }
        }
    }
}
