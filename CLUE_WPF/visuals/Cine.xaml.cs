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
    /// Lógica de interacción para Cine.xaml
    /// </summary>
    public partial class Cine : UserControl {
        public Cine(String source, String title, String description) {
            InitializeComponent();
            img.Source = (ImageSource)TryFindResource(source);
            txtInferior.title.Text = title;
            txtInferior.description.Text = description;
        }
    }
}
