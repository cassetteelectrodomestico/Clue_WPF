using System;
using System.Collections.Generic;
using System.Text;

namespace Clue_WPF.modelos
{
    class Dialogo
    {
        // Propiedades
        public int id { set; get; }
        public string texto { set; get; }
        public int personaje { set; get; }
        public int partida { set; get; }

        public Dialogo(int id, string texto, int personaje, int partida) {
            this.id = id;
            this.texto = texto;
            this.personaje = personaje;
            this.partida = partida;
        }
    }
}
