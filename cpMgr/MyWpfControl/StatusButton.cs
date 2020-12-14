using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MyWpfControl
{
    public class StatusButton : Button
    {
        #region Properties
        public ObservableCollection<Brush> Brushs
        {
            get { return (ObservableCollection<Brush>)GetValue(BrushsProperty); }
            set { SetValue(BrushsProperty, value); }
        }
        public static readonly DependencyProperty BrushsProperty =
            DependencyProperty.Register("Brushs", typeof(ObservableCollection<Brush>), typeof(StatusButton), new PropertyMetadata(null));

        public ObservableCollection<string> Texts
        {
            get { return (ObservableCollection<string>)GetValue(TextsProperty); }
            set { SetValue(TextsProperty, value); }
        }
        public static readonly DependencyProperty TextsProperty =
            DependencyProperty.Register("Texts", typeof(ObservableCollection<string>), typeof(StatusButton), new PropertyMetadata(null));

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
                    Content = Texts[value];
                }
                SetValue(StatusProperty, value);
            }
        }
        public static readonly DependencyProperty StatusProperty =
            DependencyProperty.Register("Status", typeof(int), typeof(StatusButton), new PropertyMetadata(null));
        #endregion

        static StatusButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(StatusButton), new FrameworkPropertyMetadata(typeof(StatusButton)));
        }
        public StatusButton()
        {
            Brushs = new ObservableCollection<Brush>();
            Texts = new ObservableCollection<string>();
            this.Background = Brushes.LightGray;
            this.Content = "StatusButton";
        }
    }
}
