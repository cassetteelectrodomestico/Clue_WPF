using Clue_WPF.modelos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Clue_WPF.visuals {
    class Room : StackPanel{
        public Lugar lugar;
        public Image image;
        public double[] position;

        public Room(Lugar lugar, double[] position) {
            this.lugar = lugar;
            this.image = new Image() {
                Source = (ImageSource)TryFindResource("ask"),
                Height = 40,
            };
            this.position = position;
            Children.Add(this.image);

            MouseEnter += ButtonMouseEnter;
            MouseLeave += ButtonMouseLeave;
            ToolTip = new ToolTip { Content = lugar.nombre };
            PreviewMouseUp += (object sender, MouseButtonEventArgs e) => {
                if (!Scene.canMove) return;
                if (Math.Sqrt(Math.Pow(Scene.mainCharacter.X - position[0], 2) + Math.Pow(Scene.mainCharacter.Y - position[1], 2)) > 80) return;
                //double lastTime = Scene.mainCharacter.move(p.X, p.Y);
                showInfo();

            };
        }

        public void showInfo() {
            this.Dispatcher.Invoke(() => {
                Scene.textInferior.Visibility = System.Windows.Visibility.Visible;
                Scene.textInferior.title.Text =
                    lugar.nombre;
                Scene.textInferior.description.Text = (lugar.esCulpable ? lugar.culpable : lugar.inocente);
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
