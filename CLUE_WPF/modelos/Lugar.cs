using System;
using System.Collections.Generic;
using System.Text;

namespace Clue_WPF.modelos
{
    class Lugar
    {
        // Propiedades
        public int id { set; get; }
        public string nombre { set; get; }
        public string culpable { set; get; }
        public string inocente { set; get; }

        public Lugar(int id, string nombre, string culpable, string inocente)
        {
            this.id = id;
            this.nombre = nombre;
            this.culpable = culpable;
            this.inocente = inocente;
        }
    }
}
