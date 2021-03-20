using Clue_WPF.classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clue_WPF.modelos
{
    class Personaje {
        // Propiedades
        public int id { set; get; }
        public string nombre { set; get; }
        public string profesion { set; get; }
        public string[] culpable { set; get; }
        public string motivo { set; get; }
        public string[] inocente { set; get; }
        public bool esCulpable { set; get; }

        public Personaje(int id, string nombre, string profesion, string[] culpable, string motivo, string[] inocente, bool esCulpable)
        {
            this.id = id;
            this.nombre = nombre;
            this.culpable = culpable;
            this.inocente = inocente;
            this.motivo = motivo;
            this.profesion = profesion;
            this.esCulpable = esCulpable;
        }
    }
}
