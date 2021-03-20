using Clue_WPF.classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clue_WPF.modelos
{
    class Personaje {
        // Propiedades
        public string nombre { set; get; }
        public string profesion { set; get; }
        public bool culpable { set; get; }
        public string[] textos { set; get; }

        public string motivo { set; get; }

        public Personaje(string nombre, string profesion, bool culpable) {
            this.nombre = nombre;
            this.profesion = profesion;
        }
    }
}
