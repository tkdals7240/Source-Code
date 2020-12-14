using System.Windows;

namespace cpMgr
{
    /// <summary>
    /// DlgAbout.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class DlgAbout : Window
    {
        public DlgAbout()
        {
            InitializeComponent();
            lblVersion.Content = Properties.Resources.BuildDate;
        }
    }
}
