using System;
using System.Collections.Generic;
using System.Text;

namespace Clue_WPF.modelos
{
    class Arma
    {
        // Propiedades
        public string nombre { set; get; }

        public Arma(int id, string nombre)
        {
            this.nombre = nombre;
        }

    }
}
