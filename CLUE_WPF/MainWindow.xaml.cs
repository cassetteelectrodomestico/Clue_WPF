using Clue_WPF.classes;
using Clue_WPF.visuals;
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
        //public static Canvas main;

        public static MainWindow thisWindow;

        //private Image context;

        private Scene background;

        //private Character character;
        
        //public bool canMove = true;

        public static List<Side> WayPoints;

        public MainWindow() {
            InitializeComponent();
            /*context = new Image() {
                Source = (ImageSource)TryFindResource("03_BackYard"),
                Stretch = Stretch.Fill,
                StretchDirection = StretchDirection.Both,
                Height = 557,
            };*/

            



            thisWindow = this;

            //character = new Character(new string[] {"01_FL", "01_FR", "01_BL", "01_BR"}, 480, 440);            
            //character = new Character(new string[] { "01_FL", "01_FR", "01_BL", "01_BR" }, 355, 490);
            //character = new Character(new string[] { "01_FL", "01_FR", "01_BL", "01_BR" }, 355, 440);

            //main = new Canvas();
            background = new Scene();

            //main.Children.Add(character);
            //mainPanel.Children.Add(context);
            //mainPanel.Children.Add(main);
            adjustPanel.Children.Add(background);
            //background.mainPanel.Children.Add(main);
        }

        private void Minime(object sender, RoutedEventArgs e) { WindowState = WindowState.Minimized; }
        private void Close(object sender, RoutedEventArgs e) { this.Close(); }
        private void Drag(object sender, MouseButtonEventArgs e) { if (e.ChangedButton == MouseButton.Left) DragMove(); }

        private void Click(object sender, MouseButtonEventArgs e) {
            Point p = e.GetPosition(this);
            if (p.Y == 0 && p.X == 0) return;
            if(e.ChangedButton == MouseButton.Left) {
                background.windowClick(p);
                //character.move(p.X, p.Y);
                //canMove = false;
                //Cursor = Cursors.Wait;
                //character.RenderTransform = new RotateTransform(angle += 15);
                MessageBox.Show(p.X.ToString() + "," + p.Y.ToString());
            }
        }

        
    }
}
 