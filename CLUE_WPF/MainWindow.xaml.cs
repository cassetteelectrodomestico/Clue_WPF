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
                Source = (ImageSource)TryFindResource("FrontYard"),
                Stretch = Stretch.Fill,
                StretchDirection = StretchDirection.Both,
                Height = 557,
            };

            WayPoints = new List<Side>();

            WayPoints.Add(new Side(new CPoint(364, 240), new CPoint(560, 241)));
            WayPoints.Add(new Side(new CPoint(560, 240), new CPoint(576, 274)));
            WayPoints.Add(new Side(new CPoint(576, 274), new CPoint(722, 273)));
            WayPoints.Add(new Side(new CPoint(722, 273), new CPoint(745, 243)));
            WayPoints.Add(new Side(new CPoint(745, 243), new CPoint(776, 228)));
            WayPoints.Add(new Side(new CPoint(776, 228), new CPoint(801, 450)));
            WayPoints.Add(new Side(new CPoint(801, 450), new CPoint(356, 449)));
            WayPoints.Add(new Side(new CPoint(356, 449), new CPoint(364, 240)));

            thisWindow = this;

            character = new Character(new string[] {"01_FL", "01_FR", "01_BL", "01_BR"}, 400, 300);            

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
 