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
    /// Lógica de interacción para TextInferior.xaml
    /// </summary>
    public partial class TextInferior : UserControl {

        public delegate void buttonMethod();

        public buttonMethod clickMethod;
        public TextInferior() {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            clickMethod?.Invoke();
        }
    }
}
