using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace cpMgr
{
    /// <summary>
    /// PageCstHistory.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class PageCstHistory : Page
    {
        BlockReadClass blockRead1 = new BlockReadClass("R06124", 4);
        BlockReadClass blockRead2 = new BlockReadClass("R28000", 90);
        BlockReadClass blockRead3 = new BlockReadClass("R28700", 90);
        BlockReadClass blockRead4 = new BlockReadClass("R28200", 240);
        string[,] devTbl = new string[15, 13] {
            {"R28000", "R28001", "R28002", "R28003", "R28004", "R28005", "R28700", "R28701", "R28702", "R28703", "R28704", "R28705", "R28200"},
            {"R28006", "R28007", "R28008", "R28009", "R28010", "R28011", "R28706", "R28707", "R28708", "R28709", "R28710", "R28711", "R28216"},
            {"R28012", "R28013", "R28014", "R28015", "R28016", "R28017", "R28712", "R28713", "R28714", "R28715", "R28716", "R28717", "R28232"},
            {"R28018", "R28019", "R28020", "R28021", "R28022", "R28023", "R28718", "R28719", "R28720", "R28721", "R28722", "R28723", "R28248"},
            {"R28024", "R28025", "R28026", "R28027", "R28028", "R28029", "R28724", "R28725", "R28726", "R28727", "R28728", "R28729", "R28264"},
            {"R28030", "R28031", "R28032", "R28033", "R28034", "R28035", "R28730", "R28731", "R28732", "R28733", "R28734", "R28735", "R28280"},
            {"R28036", "R28037", "R28038", "R28039", "R28040", "R28041", "R28736", "R28737", "R28738", "R28739", "R28740", "R28741", "R28296"},
            {"R28042", "R28043", "R28044", "R28045", "R28046", "R28047", "R28742", "R28743", "R28744", "R28745", "R28746", "R28747", "R28312"},
            {"R28048", "R28049", "R28050", "R28051", "R28052", "R28053", "R28748", "R28749", "R28750", "R28751", "R28752", "R28753", "R28328"},
            {"R28054", "R28055", "R28056", "R28057", "R28058", "R28059", "R28754", "R28755", "R28756", "R28757", "R28758", "R28759", "R28344"},
            {"R28060", "R28061", "R28062", "R28063", "R28064", "R28065", "R28760", "R28761", "R28762", "R28763", "R28764", "R28765", "R28360"},
            {"R28066", "R28067", "R28068", "R28069", "R28070", "R28071", "R28766", "R28767", "R28768", "R28769", "R28770", "R28771", "R28376"},
            {"R28072", "R28073", "R28074", "R28075", "R28076", "R28077", "R28772", "R28773", "R28774", "R28775", "R28776", "R28777", "R28392"},
            {"R28078", "R28079", "R28080", "R28081", "R28082", "R28083", "R28778", "R28779", "R28780", "R28781", "R28782", "R28783", "R28408"},
            {"R28084", "R28085", "R28086", "R28087", "R28088", "R28089", "R28784", "R28785", "R28786", "R28787", "R28788", "R28789", "R28424"},
            };
        public ObservableCollection<ListVew1Class> listView1List = new ObservableCollection<ListVew1Class>();

        public PageCstHistory()
        {
            InitializeComponent();

            for (int i = 1; i <= 15; i++)
            {
                ListVew1Class listView1Item = new ListVew1Class
                {
                    indata = "",
                    outdata = "",
                    iddata = "",
                    brush = Brushes.White
                };
                listView1List.Add(listView1Item);
            }
            listView1.ItemsSource = listView1List;
            listView1.Items.Refresh();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            GBL.activeScreen = this.Title;
            DataDisplay();
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void DataDisplay()
        {
            if (!blockRead1.DataRead()) return;
            txtTodayCount.Text = blockRead1.GetData("R06126").ToString();
            txtYesterDay.Text = blockRead1.GetData("R06127").ToString();
            txtTotalCount.Text = blockRead1.GetData("R06124").ToString();
            if (!blockRead2.DataRead()) return;
            if (!blockRead3.DataRead()) return;
            if (!blockRead4.DataRead()) return;
            string yy, mm, dd, hh, MM, ss, rr;
            for (int i = 0; i < 15; i++)
            {
                ListVew1Class lvi = listView1List[i];
                yy = blockRead2.GetData(devTbl[i, 0]).ToString();
                mm = blockRead2.GetData(devTbl[i, 1]).ToString();
                dd = blockRead2.GetData(devTbl[i, 2]).ToString();
                hh = blockRead2.GetData(devTbl[i, 3]).ToString();
                MM = blockRead2.GetData(devTbl[i, 4]).ToString();
                ss = blockRead2.GetData(devTbl[i, 5]).ToString();
                lvi.indata = string.Format("{0,2:D2}/{1,2:D2}/{2,2:D2} {3,2:D2}:{4,2:D2}:{5,2:D2}", yy, mm, dd, hh, MM, ss);
                yy = blockRead3.GetData(devTbl[i, 6]).ToString();
                mm = blockRead3.GetData(devTbl[i, 7]).ToString();
                dd = blockRead3.GetData(devTbl[i, 8]).ToString();
                hh = blockRead3.GetData(devTbl[i, 9]).ToString();
                MM = blockRead3.GetData(devTbl[i, 10]).ToString();
                ss = blockRead3.GetData(devTbl[i, 11]).ToString();
                lvi.outdata = string.Format("{0,2:D2}/{1,2:D2}/{2,2:D2} {3,2:D2}:{4,2:D2}:{5,2:D2}", yy, mm, dd, hh, MM, ss);
                rr = blockRead4.GetText(devTbl[i, 12], 16);
                lvi.iddata = rr;
            }
            listView1.Items.Refresh();
        }

        public class ListVew1Class
        {
            public string indata { get; set; }
            public string outdata { get; set; }
            public string iddata { get; set; }
            public Brush brush { get; set; }
        }
    }
}
