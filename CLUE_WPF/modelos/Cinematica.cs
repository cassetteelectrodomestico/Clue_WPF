using System;
using System.Collections.Generic;
using System.Text;

namespace Clue_WPF.modelos
{
    class Cinematica
    {
        // Propiedades
        public int id { set; get; }
        public string texto { set; get; }
        public int partida { set; get; }

        public Cinematica(int id, string texto, int partida)
        {
            this.id = id;
            this.texto = texto;
            this.partida = partida;
        }
    }
}
