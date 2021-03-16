using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Clue_WPF.modelos
{
    class Llenado
    {
        public List<Arma> armas { set; get; }
        public List<Dialogo> dialogos { set; get; }
        public List<Personaje> personajes { set; get; }
        public List<Partida> partidas { set; get; }
        public List<Cinematica> cinematicas { set; get; }
        public List<Objeto> objetos { set; get; }
        public Llenado()
        {
            this.setArmas();
            this.setPartida();
            this.setPersonajes();
            this.setCinematica();
        }

        public void setArmas()
        {
            armas = new List<Arma>();
            armas.Add(new Arma(0, "", ""));
            armas.Add(new Arma(1, "", ""));
            armas.Add(new Arma(2, "", ""));
            armas.Add(new Arma(3, "", ""));
            armas.Add(new Arma(4, "", ""));

        }
        public void setCinematica()
        {
            cinematicas = new List<Cinematica>();
            cinematicas.Add(new Cinematica(0, "", 0));
            cinematicas.Add(new Cinematica(1, "", 0));
            cinematicas.Add(new Cinematica(2, "", 0));
            cinematicas.Add(new Cinematica(3, "", 0));
            cinematicas.Add(new Cinematica(4, "", 0));
        }
        public void setPersonajes()
        {
            personajes = new List<Personaje>();
            personajes.Add(new Personaje(0, "El tipo", "Tú", "", "", "", ""));
            personajes.Add(new Personaje(1, "Ignacio", "El jardinero", "", "", "", ""));
            personajes.Add(new Personaje(2, "Refugio", "La abuelita", "", "", "", ""));
            personajes.Add(new Personaje(3, "Juanita", "La que limpia la casa", "", "", "", ""));
            personajes.Add(new Personaje(4, "David", "El mejor amigo", "", "", "", ""));
        }
        public void setPartida()
        {
            partidas = new List<Partida>();
            partidas.Add(new Partida(0,0,"",0,""));
            partidas.Add(new Partida(1,1,"",0,""));
            partidas.Add(new Partida(2,2,"",0,""));
            partidas.Add(new Partida(3,3,"",0,""));
            partidas.Add(new Partida(4,4,"",0,""));
        }
        public Arma getArma(int id)
        {
            return armas.Where(x => x.id == id).First();
        }
        public Personaje getPersonaje(int id)
        {
            return personajes.Where(x => x.id == id).First();
        }
        public Cinematica getCinematica(int id)
        {
            return cinematicas.Where(x => x.id == id).First();
        }
        public Partida getPartida(int id)
        {
            var rand = new Random().Next(0, 4);
            return partidas.Where(x => x.id == rand).First();
        }
        public string getDialogo(int partida, int personaje)
        {
            return dialogos.Where(x => (x.partida == partida && x.personaje == personaje)).First().ToString();
        }
    }
}
