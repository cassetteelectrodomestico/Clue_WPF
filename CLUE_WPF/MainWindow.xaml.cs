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

        public static MainWindow thisWindow;

        private Scene background;

        public static List<Side> WayPoints;

        public MainWindow() {
            InitializeComponent();          
            thisWindow = this;
            background = new Scene();
            adjustPanel.Children.Add(background);
        }

        private void Minime(object sender, RoutedEventArgs e) { WindowState = WindowState.Minimized; }
        private void Close(object sender, RoutedEventArgs e) { this.Close(); }
        private void Drag(object sender, MouseButtonEventArgs e) { if (e.ChangedButton == MouseButton.Left) DragMove(); }

        private void Click(object sender, MouseButtonEventArgs e) {
            Point p = e.GetPosition(this);
            if (p.Y == 0 && p.X == 0) return;
            if(e.ChangedButton == MouseButton.Left) {
                background.windowClick(p);
                //MessageBox.Show(p.X.ToString() + "," + p.Y.ToString());
            }
        }

        
    }
}
 