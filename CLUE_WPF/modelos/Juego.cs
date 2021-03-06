using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Clue_WPF.modelos
{
    public class Juego
    {
        public static Juego mainJuego;
        public List<Arma> armas { set; get; }
        public List<Lugar> lugares { set; get; }
        public List<Personaje> personajes { set; get; }
        public List<Cinematica> cinematicas { set; get; }
        public List<Lugar> objetos { set; get; }
        public Partida laPartida { set; get; }
        public Juego() {
            laPartida = new Partida();
            setArmas();
            setLugares();
            setPersonajes();
            setCinematica();
            setPartida();
            mainJuego = this;
        }

        public void setArmas() {
            armas = new List<Arma>();
            armas.Add(new Arma(0, "Abrecartas", "Esto estaba guardado en mi cajón con llave.", "¿Acaso olvidé guardarlo en mi cajón?", false));
            armas.Add(new Arma(1, "Cuchillo", "Habrá que afilarlo.", "Habrá que ajustarle los remaches.", false));
            armas.Add(new Arma(2, "Cuerda", "Está muy deshilada.", "Está muy aspera.", false));
            armas.Add(new Arma(3, "Martillo", "Huele muy raro.", "Tiene oxido esa cosa.", false));
            armas.Add(new Arma(4, "Sarten", "Esta abolladura es nueva.", "Aún está caliente.", false));
        }
        public void setLugares() {
            lugares = new List<Lugar>();
            lugares.Add(new Lugar(0, "Sala", "¿Alguien movió el sofá?", "Necesita limpieza.", false));
            lugares.Add(new Lugar(1, "Comedor", "¿Que le pasó a esa silla?", "Huele a vainilla.", false));
            lugares.Add(new Lugar(2, "Cocina", "No hay nada preparado.", "Carla debió limpiar la grasa.", false));
            lugares.Add(new Lugar(3, "Cuarto de servicio", "Que raro, el limpiador de vainilla huele a limon.", "Huele a nuestro limpiador de vainilla.", false));
            lugares.Add(new Lugar(4, "Jardin", "Falta un pedazo de cesped.", "Horrendo trabajo que hizo Andrés.", false));
        }
        public void setCinematica() {
            cinematicas = new List<Cinematica>();
            cinematicas.Add(new Cinematica("El clima de hoy ha mostrado una exagerada pasión para ser los " +
                "primeros días del otoño. Ante la eterna agonía de una vida insatisfactoria, dónde la rútina se " +
                "vuelve cansina, y en este lugar las sorpresas no son, si no, negativas, estás perdido. Volverás. " +
                "Tu hogar te espera. Demasiado temprano para tu estándar. Te has vuelto libre sin querer ser libre. " +
                "Has dado el paso que todos tus conocidos quisieron dar y sin embargo, no pudieron. Te han obligado. " +
                "Ingratitud y falta de ética por parte de aquellos que viste y serviste durante años. Sollozas. " +
                "¿Qué otra cosa puedes hacer? O una mejor pregunta quizás sería ¿Qué se supone que harás ahora? De todo a la nada."));
            cinematicas.Add(new Cinematica("Estás por arribar a tu hogar, dónde tu amada esposa y tu hijo recién " +
                "nacido esperán. ¿Qué será de ellos? ¿Qué será de ti mismo? Habrá retribuciones. Saldrán adelante. " +
                "Tu parabrisas roto será el inicio de una nueva y mejor vida. ¿No? camino se atravesó una carroza " +
                "para heridos.Eres buen conductor, te has apartado y la has dejado pasar.Sin embargo, ¿Qué objetivo " +
                "ha tenido todo ? Si a tu arribo has notado algo inusual.Dos coches bloquean el acceso a tu hogar." +
                "Las autoridades locales han llegado.Ahora comprendes todo... "));
            cinematicas.Add(new Cinematica("Los policias son incompetentes. Te han dejado pasar. Hallaron y se " +
                "llevaron los cuerpos. Declararon el caso como homicidio-suicidio, limpiaron y solo esperan su orden para irse. " +
                "Tu sabes que no es cierto. Ninguna de las personas que se hallaban dentro del hogar durante el crimen están" +
                " habilitadas para salir de ahí hasta que la policia lo autorice. Reune las pistas para averiguar la verdad. " +
                "La justicia poética por cuenta propia no es la respuesta ¿Verdad?"));
            cinematicas.Add(new Cinematica("No pudiste vivir con la concienica de haber matado a tu propia familia, así que decididste acabar con tu sufrimiento"));
            cinematicas.Add(new Cinematica("Decidiste llevar a cabo justicia por cuenta propia y las autoridades han decidido condenarte a pena de muerte en la silla electrica"));
            cinematicas.Add(new Cinematica("Has cometido un error y acabaste con una vida inocente... Decidiste tomar tu propia vida antes que ellos la tomaran"));
        }
        public void setPersonajes(){
            personajes = new List<Personaje>();
            personajes.Add(new Personaje(0, "Braulio", "Protagonista", "", new string[] { "Nadie mas lo hizo" },
                "Sabías que te iban a despedir y embargar la casa. Tu esposa te engañaba, y aunque tu también, no pudiste soportarlo más.",
                new string[] { "Alguien lo hizo" }, false));
            personajes.Add(new Personaje(1, "Andres", "Jardinero", "Lo ibas a despedir terminando el mes.", new string[] {"Don Braulio, lamento su pérdida", "- Su esposa sabe lavar bien su uniforme." },
                " Sabía que lo ibas a despedir, no era tu culpa, ya no tenías trabajo pero esto te pasa por contratar a un exconvicto maniaco.",
                new string[] { "Patrón, lamento su pérdida", "Hoy no le correspondía venir hoy. Al parecer olvidó su cartera aquí ayer." }, false));
            personajes.Add(new Personaje(2, "Josefina", "Madre", "Jamás le agradó tu esposa.", new string[] { "Mis condolencias.Estoy afligida por mi nuera y mi nieto", " - Huele a dulce ¿Acaso horneó galletas?" },
                "Odiaba a su nuera. Siempre fue una mujer racista y por eso hizo lo que hizo.",
                new string[] { "Mis condolencias.Estoy afligida por mi nieto y lamento lo de tu esposa", "- Sus ojos están rojos por el llanto" }, false));
            personajes.Add(new Personaje(3, "Carla", "Limpieza", "Quería que dejaras a tu esposa por ella.", new string[] { "Jefe, no sé que decir...", "- Ese labial rojo le sienta bien. " },
                " Ese hijo debía ser suyo, la casa y el anillo también.",
                new string[] { "Braulio...", "- Que desaliñada se ve hoy." }, false));
            personajes.Add(new Personaje(4, "Pepe", "Vecino", "¿Seguirá molesto por que le robaste a la mujer de sus sueños?", new string[] { "Solo quería pasar a saludarte, vecino", "- La bolsa de su camisa está rota." },
                "Tu esposa no se quiso fugar con él, pagó el último precio.",
                new string[] { "Vine... porque... quería hablar...", "- Su cabello está despeinado." }, false));
        }
        public void setPartida(){
            Random rnd = new Random();
            laPartida.locacion = rnd.Next(0, 5);
            laPartida.asesino = rnd.Next(0, 5);
            laPartida.arma = rnd.Next(0, 5);
            lugares[laPartida.locacion].esCulpable = true;
            personajes[laPartida.asesino].esCulpable = true;
            armas[laPartida.arma].esCulpable = true;
            
        }
        public bool resultado(int asesino, int arma, int lugar){
            if(asesino == laPartida.asesino) {
                if (arma == laPartida.arma){
                    if (lugar == laPartida.locacion){
                        return true;
                    }
                    else{
                        return false;
                    }
                }
                else{
                    return false;
                }
            }
            else {
                return false;
            }
        }
        public string getArmaTexto(int id){
            Arma aux = armas.Where(x => x.id == id).First();
            if (aux.id == laPartida.arma){
                return aux.culpable;
            }
            else {
                return aux.inocente;
            }
        }
        public string getLugarTexto(int id){
            Lugar aux = lugares.Where(x => x.id == id).First();
            if (aux.id == laPartida.locacion) {
                return aux.culpable;
            }
            else {
                return aux.inocente;
            }
        }
        public string[] getPersonajeTexto(int id){
            Personaje aux = personajes.Where(x => x.id == id).First();
            if (aux.id == laPartida.asesino) {
                return aux.culpable;
            }
            else {
                return aux.inocente;
            }
        }
        public string getPersonajeMotivo(int id){
            Personaje aux = personajes.Where(x => x.id == id).First();
            return aux.motivo;
        }
        /*public string getCinematicaTexto(int id)
        {
            return cinematicas.Where(x => x.id == id).First().texto;
        }*/

    }
}
