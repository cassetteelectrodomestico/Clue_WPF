using Clue_WPF.modelos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Clue_WPF.visuals {

    class NPC : StackPanel{
        public Personaje personaje;
        public Image image;
        public double[] position;

        public NPC(Personaje personaje, String image, double [] position) {
            this.personaje = personaje;
            this.image = new Image() {
                Source = (ImageSource)TryFindResource(image),
                Height = 100,
            };
            this.position = position;
            Children.Add(this.image);

            MouseEnter += ButtonMouseEnter;
            MouseLeave += ButtonMouseLeave;
            ToolTip = new ToolTip { Content = personaje.nombre };
            PreviewMouseUp += (object sender, MouseButtonEventArgs e) => {
                if (!Scene.canMove) return;
                if (Math.Sqrt(Math.Pow(Scene.mainCharacter.X - position[0], 2) + Math.Pow(Scene.mainCharacter.Y - position[1], 2)) > 80) return;
                //double lastTime = Scene.mainCharacter.move(p.X, p.Y);
                showInfo();
                
            };
        }

        public void showInfo() {
            this.Dispatcher.Invoke(() => {
                Scene.textInferior.Visibility = Visibility.Visible;
                Scene.textInferior.title.Text =
                    personaje.nombre + "(" + personaje.profesion + ")" + " - " + personaje.overview;
                Scene.textInferior.description.Text = "\"" + (personaje.esCulpable ? personaje.culpable[0] : personaje.inocente[0]) + "\"" + "\n";
                Scene.textInferior.description.Text += (personaje.esCulpable ? personaje.culpable[1] : personaje.inocente[1]);
                Scene.canMove = false;
            });
        }

        public void ButtonMouseEnter(object sender, MouseEventArgs e) {
            if (Scene.canMove) Cursor = Cursors.Hand;
        }

        public void ButtonMouseLeave(object sender, MouseEventArgs e) {
            if (Scene.canMove) Cursor = Cursors.Arrow;
        }

    }
}
