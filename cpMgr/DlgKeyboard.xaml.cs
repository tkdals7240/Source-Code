using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace cpMgr
{
    /// <summary>
    /// DlgKeyboard.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class DlgKeyboard : Window
    {
        public string _inStr;
        public DlgKeyboard(string instr, bool isPassword = false)
        {
            InitializeComponent();

            _inStr = instr;
            btnCaps.IsChecked = Keyboard.GetKeyStates(Key.CapsLock) == KeyStates.Toggled;
            Display_KeyChar();

            if (isPassword)
            {
                txtInput.Visibility = Visibility.Hidden;
                pwdInput.Visibility = Visibility.Visible;
                pwdInput.Password = instr;
                pwdInput.SelectAll();
                pwdInput.Focus();
            }
            else
            {
                txtInput.Visibility = Visibility.Visible;
                pwdInput.Visibility = Visibility.Hidden;
                txtInput.Text = instr;
                txtInput.SelectAll();
                txtInput.Focus();
            }
        }

        private void btnKeyin_Click(object sender, RoutedEventArgs e)
        {
            if (txtInput.Visibility == Visibility.Visible)
                txtInput.Focus();
            else
                pwdInput.Focus();

            string inStr = (sender as Button).Tag.ToString();
            char[] inChar = inStr.ToCharArray();
            if (inChar.Length > 0)
                MySendKey.SendKeyPress((MySendKey.KeyCode)inChar[0]);
        }

        private void btnCaps_CheckedChanged(object sender, RoutedEventArgs e)
        {
            bool capslock = Keyboard.GetKeyStates(Key.CapsLock) == KeyStates.Toggled;
            if (btnCaps.IsChecked != capslock)
                MySendKey.SendKeyPress(MySendKey.KeyCode.CAPS_LOCK);
            if (txtInput.Visibility == Visibility.Visible)
                txtInput.Focus();
            else
                pwdInput.Focus();
            Display_KeyChar();
        }
        private void Display_KeyChar()
        { 
            if (btnCaps.IsChecked == true)
            {
                btnA.Content = "A";
                btnB.Content = "B";
                btnC.Content = "C";
                btnD.Content = "D";
                btnE.Content = "E";
                btnF.Content = "F";
                btnG.Content = "G";
                btnH.Content = "H";
                btnI.Content = "I";
                btnJ.Content = "J";
                btnK.Content = "K";
                btnL.Content = "L";
                btnM.Content = "M";
                btnN.Content = "N";
                btnO.Content = "O";
                btnP.Content = "P";
                btnQ.Content = "Q";
                btnR.Content = "R";
                btnS.Content = "S";
                btnT.Content = "T";
                btnU.Content = "U";
                btnV.Content = "V";
                btnW.Content = "W";
                btnX.Content = "X";
                btnY.Content = "Y";
                btnZ.Content = "Z";
            }
            else
            {
                btnA.Content = "a";
                btnB.Content = "b";
                btnC.Content = "c";
                btnD.Content = "d";
                btnE.Content = "e";
                btnF.Content = "f";
                btnG.Content = "g";
                btnH.Content = "h";
                btnI.Content = "i";
                btnJ.Content = "j";
                btnK.Content = "k";
                btnL.Content = "l";
                btnM.Content = "m";
                btnN.Content = "n";
                btnO.Content = "o";
                btnP.Content = "p";
                btnQ.Content = "q";
                btnR.Content = "r";
                btnS.Content = "s";
                btnT.Content = "t";
                btnU.Content = "u";
                btnV.Content = "v";
                btnW.Content = "w";
                btnX.Content = "x";
                btnY.Content = "y";
                btnZ.Content = "z";
            }
        }

        private void btnBS_Click(object sender, RoutedEventArgs e)
        {
            if (txtInput.Visibility == Visibility.Visible)
                txtInput.Focus();
            else
                pwdInput.Focus();
            MySendKey.SendKeyPress(MySendKey.KeyCode.BACKSPACE);            
        }

        private void btnCSR_Click(object sender, RoutedEventArgs e)
        {
            if (txtInput.Visibility == Visibility.Visible)
                txtInput.Focus();
            else
                pwdInput.Focus();
            txtInput.Text = "";
            pwdInput.Password = "";
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            if (txtInput.Visibility == Visibility.Visible)
                _inStr = txtInput.Text;
            else
                _inStr = pwdInput.Password;
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Application curApp = Application.Current;
            Window mainWindow = curApp.MainWindow;
            this.Left = mainWindow.Left + (mainWindow.Width - this.ActualWidth) / 2;
            this.Top = mainWindow.Top + (mainWindow.Height - this.ActualHeight) / 2;
        }
    }
}
