using System;
using System.Collections.Generic;
using System.Text;

namespace Clue_WPF.modelos
{
    class Cinematica
    {
        // Propiedades
        public string texto { set; get; }
        public int partida { set; get; }

        public Cinematica( string texto, int partida)
        {
            this.texto = texto;
            this.partida = partida;
        }
    }
}
