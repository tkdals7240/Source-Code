using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MyWpfControl
{
    public class ImageButton : Button
    {
        #region Properties
        public ImageSource Image
        {
            get { return (ImageSource)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }

        public static readonly DependencyProperty ImageProperty =
            DependencyProperty.Register("Image", typeof(ImageSource), typeof(ImageButton), new PropertyMetadata(null));
        public ObservableCollection<ImageSource> Images
        {
            get { return (ObservableCollection<ImageSource>)GetValue(ImagesProperty); }
            set { SetValue(ImagesProperty, value); }
        }

        public static readonly DependencyProperty ImagesProperty =
            DependencyProperty.Register("Images", typeof(ObservableCollection<ImageSource>), typeof(ImageButton), new PropertyMetadata(null));
        public int Status
        {
            get { return (int)GetValue(StatusProperty); }
            set
            {
                if (value < Images.Count)
                {
                    Image = Images[value];
                }
                SetValue(StatusProperty, value);
            }
        }
        public static readonly DependencyProperty StatusProperty =
            DependencyProperty.Register("Status", typeof(int), typeof(ImageButton), new PropertyMetadata(null));
        #endregion

        static ImageButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ImageButton), new FrameworkPropertyMetadata(typeof(ImageButton)));
        }
        public ImageButton()
        {
            Images = new ObservableCollection<ImageSource>();
        }
    }
}
