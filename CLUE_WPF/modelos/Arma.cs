using System;
using System.Collections.Generic;
using System.Text;

namespace Clue_WPF.modelos
{
    class Arma
    {
        // Propiedades
        public int id { set; get; }
        public string nombre { set; get; }
        public string imagen { set; get; }

        public Arma(int id, string nombre, string imagen)
        {
            this.id = id;
            this.nombre = nombre;
            this.imagen = imagen;
        }

    }
}
