using System;
using System.Collections.Generic;
using System.Text;

namespace Clue_WPF.modelos
{
    class Objeto
    {
        // Propiedades
        public int id { set; get; }
        public string nombre { set; get; }
        public string imagen { set; get; }

        public Objeto(int id, string nombre, string imagen)
        {
            this.id = id;
            this.nombre = nombre;
            this.imagen = imagen;
        }
    }
}
