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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MYDWP.View
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : UserControl
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            DoubleAnimation scrollAnim = new DoubleAnimation
            {
                From = ActualWidth,
                To = -ScrollingLabel.ActualWidth,
                Duration = new Duration(TimeSpan.FromSeconds(15)),
                RepeatBehavior = RepeatBehavior.Forever
            };

            ScrollingLabel.BeginAnimation(Canvas.LeftProperty, scrollAnim);
        }

        private void ProfileImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                Image img = sender as Image;
                if (img?.ContextMenu != null)
                {
                    img.ContextMenu.PlacementTarget = img;
                    img.ContextMenu.IsOpen = true;
                }
            }
        }
    }
}
