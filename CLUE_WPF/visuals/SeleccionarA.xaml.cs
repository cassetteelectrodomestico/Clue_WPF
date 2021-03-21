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

        Cine cinematica1, cinematica2;

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
            String ase = Juego.mainJuego.personajes[asesino].nombre;
            String arm = Juego.mainJuego.armas[arma].nombre;
            String lug = Juego.mainJuego.lugares[lugar].nombre;

            bool ases = (asesino == Juego.mainJuego.laPartida.asesino);
            bool armat = (arma == Juego.mainJuego.laPartida.arma);
            bool luga = (lugar == Juego.mainJuego.laPartida.locacion);

            int asescore = (ases ? 40 : 0);
            int armascore = (armat ? 30 : 0);
            int lugascore = (luga ? 30 : 0);

            Final final = new Final();
            final.sospechosoinfo.Text = "Sospechoso: " + ase + "(" + (ases ? "Correcto" : "Incorrecto") + ")";
            final.sospechoso.Text = asescore.ToString();

            final.armainfo.Text = "Arma: " + arm + "(" + (armat ? "Correcto" : "Incorrecto") + ")";
            final.arma.Text = armascore.ToString();

            final.lugarinfo.Text = "Lugar: " + lug + "(" + (luga ? "Correcto" : "Incorrecto") + ")";
            final.lugar.Text = lugascore.ToString();

            final.total.Text = (armascore + asescore + lugascore).ToString();

            if (Juego.mainJuego.laPartida.asesino == asesino) {
                if(asesino == 0)
                {
                    cinematica1 = new Cine("03_Suicido", "Fuiste tu", Juego.mainJuego.personajes[0].motivo + "\n" + Juego.mainJuego.cinematicas[3].texto);
                    cinematica1.txtInferior.clickMethod = () => {
                        MainWindow.thisWindow.adjustPanel.Children.Clear();
                        MainWindow.thisWindow.adjustPanel.Children.Add(final);

                       

                    };

                    MainWindow.thisWindow.adjustPanel.Children.Clear();
                    MainWindow.thisWindow.adjustPanel.Children.Add(cinematica1);
                }
                else
                {
                    cinematica1 = new Cine("05_Oscuro", "Fue " + Juego.mainJuego.personajes[asesino].nombre, Juego.mainJuego.personajes[asesino].motivo);
                    cinematica2 = new Cine("04_Silla", "", Juego.mainJuego.cinematicas[4].texto);
                    
                    cinematica1.txtInferior.clickMethod = () => {
                        MainWindow.thisWindow.adjustPanel.Children.Clear();
                        MainWindow.thisWindow.adjustPanel.Children.Add(cinematica2);
                    };

                    cinematica2.txtInferior.clickMethod = () => {
                        MainWindow.thisWindow.adjustPanel.Children.Clear();
                        //Total
                        MainWindow.thisWindow.adjustPanel.Children.Add(final);
                    };

                    MainWindow.thisWindow.adjustPanel.Children.Clear();
                    MainWindow.thisWindow.adjustPanel.Children.Add(cinematica1);
                    //pena de muerte
                }
            }
            else
            {
                cinematica1 = new Cine("03_Suicido", "", Juego.mainJuego.cinematicas[5].texto);
                cinematica1.txtInferior.clickMethod = () => {
                    MainWindow.thisWindow.adjustPanel.Children.Clear();
                    //Total
                    MainWindow.thisWindow.adjustPanel.Children.Add(final);
                };

                MainWindow.thisWindow.adjustPanel.Children.Clear();
                MainWindow.thisWindow.adjustPanel.Children.Add(cinematica1);
                //molision
            }


        }
        private void checkThree(object sender, RoutedEventArgs e)
        {

            
        }
    }
}
