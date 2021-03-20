using Clue_WPF.classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clue_WPF.modelos
{
    class Personaje /*: Character*/
    {
        // Propiedades
        public int id { set; get; }
        public string nombre { set; get; }
        public string profesion { set; get; }
        public string[] culpable { set; get; }
        public string motivo { set; get; }
        public string[] inocente { set; get; }

        public Personaje(int id, string nombre, string profesion, string[] culpable, string motivo, string[] inocente)
        {
            this.id = id;
            this.nombre = nombre;
            this.culpable = culpable;
            this.inocente = inocente;
            this.motivo = motivo;
            this.profesion = profesion;
        }
    }
}
