using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MyWpfControl
{
    public class ImageBorder : Control
    {
        #region Properties
        public ImageSource Image
        {
            get { return (ImageSource)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }

        public static readonly DependencyProperty ImageProperty =
            DependencyProperty.Register("Image", typeof(ImageSource), typeof(ImageBorder), new PropertyMetadata(null));
        public ObservableCollection<ImageSource> Images
        {
            get { return (ObservableCollection<ImageSource>)GetValue(ImagesProperty); }
            set { SetValue(ImagesProperty, value); }
        }

        public static readonly DependencyProperty ImagesProperty =
            DependencyProperty.Register("Images", typeof(ObservableCollection<ImageSource>), typeof(ImageBorder), new PropertyMetadata(null));
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
            DependencyProperty.Register("Status", typeof(int), typeof(ImageBorder), new PropertyMetadata(null));
        #endregion

        static ImageBorder()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ImageBorder), new FrameworkPropertyMetadata(typeof(ImageBorder)));
        }
        public ImageBorder()
        {
            Images = new ObservableCollection<ImageSource>();
        }
    }
}
