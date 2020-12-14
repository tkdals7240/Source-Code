using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MyWpfControl
{
    public class StatusBorder : Control
    {
        #region Properties
        public ObservableCollection<Brush> Brushs
        {
            get { return (ObservableCollection<Brush>)GetValue(BrushsProperty); }
            set { SetValue(BrushsProperty, value); }
        }
        public static readonly DependencyProperty BrushsProperty =
            DependencyProperty.Register("Brushs", typeof(ObservableCollection<Brush>), typeof(StatusBorder), new PropertyMetadata(null));
        public ObservableCollection<string> Texts
        {
            get { return (ObservableCollection<string>)GetValue(TextsProperty); }
            set { SetValue(TextsProperty, value); }
        }
        public static readonly DependencyProperty TextsProperty =
            DependencyProperty.Register("Texts", typeof(ObservableCollection<string>), typeof(StatusBorder), new PropertyMetadata(null));
        public int Status
        {
            get { return (int)GetValue(StatusProperty); }
            set
            {
                if (value < Brushs.Count)
                {
                    Background = Brushs[value];
                }
                if (value < Texts.Count)
                {
                    Text = Texts[value];
                }
                SetValue(StatusProperty, value);
            }
        }
        public static readonly DependencyProperty StatusProperty =
            DependencyProperty.Register("Status", typeof(int), typeof(StatusBorder), new PropertyMetadata(null));
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(StatusBorder), new PropertyMetadata(null));
        #endregion

        static StatusBorder()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(StatusBorder), new FrameworkPropertyMetadata(typeof(StatusBorder)));
        }
        public StatusBorder()
        {
            Brushs = new ObservableCollection<Brush>();
            Texts = new ObservableCollection<string>();
            this.Background = Brushes.LightGray;
            this.Text = "StatusBorder";
        }
    }
}
