using Clue_WPF.modelos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Clue_WPF.visuals {
    public class Weapon : StackPanel {
        public Arma arma;
        public Image image;
        public double [] position;

        public Weapon(Arma arma, String image, double [] position) {
            this.arma = arma;
            this.image = new Image() {
                Source = (ImageSource)TryFindResource(image),
                Height = 50,
            };
            this.position = position;
            Children.Add(this.image);
            ToolTip = new ToolTip { Content = arma.nombre };
            MouseEnter += ButtonMouseEnter;
            MouseLeave += ButtonMouseLeave;
            PreviewMouseUp += (object sender, MouseButtonEventArgs e) => {
                //MessageBox.Show(arma.nombre);
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
                    arma.nombre;
                Scene.textInferior.description.Text = (arma.esCulpable ? arma.culpable : arma.inocente);
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
