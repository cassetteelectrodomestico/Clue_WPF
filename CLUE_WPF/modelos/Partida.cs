using System;
using System.Collections.Generic;
using System.Text;

namespace Clue_WPF.modelos
{
    public class Partida
    {
        // Propiedades
        public int arma { set; get; }
        public int locacion { set; get; }
        public int asesino { set; get; }
        public int avance { set; get; }
        public string pista { set; get; }

        public Partida() {

        }

        public Partida(int arma, int locacion, int asesino, string pista = "")
        {
            this.arma = arma;
            this.locacion = locacion;
            this.asesino = asesino;
            this.pista = pista;
            this.avance = 0;
        }
        public bool agregarAvance()
        {
            if (avance < 5) {
                avance++;
                return true;
            }
            else
                return false;
        }
    }
}
