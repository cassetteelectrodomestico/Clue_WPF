using System;
using System.Collections.Generic;
using System.Text;

namespace Clue_WPF.modelos
{
    class Personaje
    {
        // Propiedades
        public int id { set; get; }
        public string nombre { set; get; }
        public string profecion { set; get; }
        public string imagen_frente { set; get; }
        public string imagen_atras { set; get; }
        public string imagen_derecha { set; get; }
        public string imagen_izquierda { set; get; }

        public Personaje(int id, string nombre, string profecion, string imagen_frente, string imagen_atras, string imagen_derecha, string imagen_izquierda)
        {
            this.id = id;
            this.nombre = nombre;
            this.profecion = profecion;
            this.imagen_frente = imagen_frente;
            this.imagen_atras = imagen_atras;
            this.imagen_derecha = imagen_derecha;
            this.imagen_izquierda = imagen_izquierda;
        }
    }
}
