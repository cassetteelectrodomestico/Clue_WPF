using System;
using System.Collections.Generic;
using System.Text;

namespace Clue_WPF.modelos
{
    class Partida
    {
        // Propiedades
        public int id { set; get; }
        public int arma { set; get; }
        public string locacion { set; get; }
        public int asesino { set; get; }
        public int avance { set; get; }
        public string pista { set; get; }

        public Partida(int id, int arma, string locacion, int asesino, string pista)
        {
            this.id = id;
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
