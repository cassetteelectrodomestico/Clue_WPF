using System;
using System.Collections.Generic;
using System.Text;

namespace Clue_WPF.modelos
{
    public class Lugar
    {
        // Propiedades
        public int id { set; get; }
        public string nombre { set; get; }
        public string culpable { set; get; }
        public string inocente { set; get; }
        public bool esCulpable { set; get; }

        public Lugar(int id, string nombre, string culpable, string inocente, bool esCulpable)
        {
            this.id = id;
            this.nombre = nombre;
            this.culpable = culpable;
            this.inocente = inocente;
            this.esCulpable = esCulpable;
        }
    }
}
