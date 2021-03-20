using System;
using System.Collections.Generic;
using System.Text;

namespace Clue_WPF.modelos
{
    class Cinematica
    {
        // Propiedades
        public string texto { set; get; }

        public Cinematica(int id, string texto)
        {
            this.texto = texto;
        }
    }
}
