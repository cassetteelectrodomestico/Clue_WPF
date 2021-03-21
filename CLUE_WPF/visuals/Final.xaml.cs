using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Clue_WPF.visuals {
    /// <summary>
    /// Lógica de interacción para Final.xaml
    /// </summary>
    public partial class Final : UserControl {
        public Final() {
            InitializeComponent();
            Scene.music.Open(Scene.songs[5]);
            Scene.music.Play();
        }

        private void start_Click(object sender, RoutedEventArgs e) {
            MainWindow.thisWindow.adjustPanel.Children.Clear();
            MainWindow.thisWindow.adjustPanel.Children.Add(MainWindow.thisWindow.start);
            Scene.music.Stop();
        }
    }
}
