using Clue_WPF.classes;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Clue_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Canvas main;

        public static MainWindow thisWindow;

        private Image context;
        private Character character;
        
        public bool canMove = true;

        public static List<Side> WayPoints;

        public MainWindow() {
            InitializeComponent();
            context = new Image() {
                Source = (ImageSource)TryFindResource("02_House"),
                Stretch = Stretch.Fill,
                StretchDirection = StretchDirection.Both,
                Height = 557,
            };

            WayPoints = new List<Side>();

            /*WayPoints.Add(new Side(new CPoint(213, 220), new CPoint(460, 222)));
            WayPoints.Add(new Side(new CPoint(460, 222), new CPoint(490, 257)));
            WayPoints.Add(new Side(new CPoint(490, 257), new CPoint(649, 256)));
            WayPoints.Add(new Side(new CPoint(649, 256), new CPoint(705, 202)));
            WayPoints.Add(new Side(new CPoint(705, 202), new CPoint(727, 194)));
            WayPoints.Add(new Side(new CPoint(727, 194), new CPoint(752, 448)));
            WayPoints.Add(new Side(new CPoint(752, 448), new CPoint(205, 447)));
            WayPoints.Add(new Side(new CPoint(205, 447), new CPoint(213, 220)));*/

            double[,] points = new double[,] {
                {313, 494},
                {304, 353},
                {256, 332},
                {258, 292},
                {308, 286},
                {307, 258},
                {259, 256},
                {260, 213},
                {310, 212},
                {319, 88},
                {338, 87},
                {339, 71},
                {383, 72},
                {391, 88},
                {457, 90},
                {456, 146},
                {695, 148},
                {695, 256},
                {625, 258},
                {625, 290},
                {696, 292},
                {697, 339},
                {621, 336},
                {618, 368},
                {572, 369},
                {575, 533},
                {510, 490},
                {512, 449},
                {460, 452},
                {456, 492},
                {313, 494},
                {379, 396},
                {511, 398},
                {508, 316},
                {583, 320},
                {578, 258},
                {505, 254},
                {504, 192},
                {458, 191},
                {454, 204},
                {389, 206},
                {392, 256},
                {345, 258},
                {347, 290},
                {380, 286},
                {379, 396}
            };

            int len = points.GetLength(0) - 1;

            for(int i = 0; i < len; i++) {
                int j = i + 1;
                WayPoints.Add(new Side(new CPoint(points[i,0], points[i,1]), new CPoint(points[j, 0], points[j, 1])));
            }


            thisWindow = this;

            //character = new Character(new string[] {"01_FL", "01_FR", "01_BL", "01_BR"}, 480, 440);            
            character = new Character(new string[] { "01_FL", "01_FR", "01_BL", "01_BR" }, 355, 490);
            main = new Canvas();

            main.Children.Add(character);
            mainPanel.Children.Add(context);
            mainPanel.Children.Add(main);
        }

        private void Minime(object sender, RoutedEventArgs e) { WindowState = WindowState.Minimized; }
        private void Close(object sender, RoutedEventArgs e) { this.Close(); }
        private void Drag(object sender, MouseButtonEventArgs e) { if (e.ChangedButton == MouseButton.Left) DragMove(); }

        private void Click(object sender, MouseButtonEventArgs e) {
            Point p = e.GetPosition(this);
            if (p.Y == 0 && p.X == 0) return;
            if(e.ChangedButton == MouseButton.Left && canMove) {
                character.move(p.X, p.Y);
                canMove = false;
                Cursor = Cursors.Wait;
                //character.RenderTransform = new RotateTransform(angle += 15);
                //MessageBox.Show(p.X.ToString() + "," + p.Y.ToString());
            }
        }

        public static void WakeUp() {
            thisWindow.Dispatcher.Invoke(() => {
                thisWindow.Cursor = Cursors.Arrow;
                thisWindow.canMove = true;
            });
        }
    }
}
 