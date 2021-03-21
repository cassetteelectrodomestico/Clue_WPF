using Clue_WPF.modelos;
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
    public partial class SeleccionarA : UserControl {

        public int asesino;
        public int lugar;
        public int arma;

        public SeleccionarA() {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e) {

            if(Sala.IsChecked==true) lugar = 0;
            if (Comedor.IsChecked == true) lugar = 1;
            if (Cocina.IsChecked == true) lugar = 2;
            if (Cuarto.IsChecked == true) lugar = 3;
            if (Jardin.IsChecked == true) lugar = 4;

            if (Abrecartas.IsChecked == true) arma = 0;
            if (Cuchillo.IsChecked == true) arma = 1;
            if (Cuerda.IsChecked == true) arma = 2;
            if (Martillo.IsChecked == true) arma = 3;
            if (Sarten.IsChecked == true) arma = 4;

            if (protagonista.IsChecked == true) asesino = 0;
            if (jardinero.IsChecked == true) asesino = 1;
            if (madre.IsChecked == true) asesino = 2;
            if (limpieza.IsChecked == true) asesino = 3;
            if (Vecino.IsChecked == true) asesino = 4;

            bool res = Juego.mainJuego.resultado(asesino, arma, lugar);

            if(Juego.mainJuego.laPartida.asesino == asesino) {
                if(asesino == 0)
                {
                    //cinematica molision
                }
                else
                {
                    //pena de muerte
                }
            }
            else
            {
                //molision
            }


        }
        private void checkThree(object sender, RoutedEventArgs e)
        {

            
        }
    }
}
