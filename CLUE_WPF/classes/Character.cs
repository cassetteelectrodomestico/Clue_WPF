using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.Threading;
using System.Windows.Media.Animation;
using System.Windows;

namespace Clue_WPF.classes {
    class Character : Image {
        private double X { set; get; }
        private double Y { set; get; }
        private int location { set; get; }
        private List<ImageSource> faces  { set; get; }

        public Character(string [] faces, int X, int Y) {
            this.faces = new List<ImageSource>();
            foreach(string face in faces) this.faces.Add((ImageSource)TryFindResource(face));
            Source = this.faces[0];
            Height = 120;
            Stretch = Stretch.Fill;
            CacheMode = CacheMode;
            this.X = X;
            this.Y = Y;
            //Canvas.SetTop(this, -(618 - Y + 100));
            //Canvas.SetLeft(this, X - 10);
            reframe();
            location = 0;
        }

        public void move(double X, double Y) {
            bool x_end = false, y_end = false;
            double antX = this.X, antY = this.Y;
            int selector = 0, animation_counter = 0;
            selector += (X > antX) ? 1 : 0;
            selector += (Y > antY) ? 0 : 2;
            Source = faces[selector];
            /*while (!x_end || !y_end) {
                switch (selector) {
                    case 0:
                        if (this.X > X) this.X -= 1.0;
                        else x_end = true;
                        if (this.Y < Y) this.Y += 1.0;
                        else y_end = true;
                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                }
                reframe();
                //Thread.Sleep(50);
            }*/
            Vector offset = VisualTreeHelper.GetOffset(this);
            var top = offset.Y;
            var left = offset.X;
            TranslateTransform trans = new TranslateTransform();
            RenderTransform = trans;
            DoubleAnimation anim1 = new DoubleAnimation(0, X - antX, TimeSpan.FromSeconds(1));
            DoubleAnimation anim2 = new DoubleAnimation(0, Y - antY, TimeSpan.FromSeconds(1));
            trans.BeginAnimation(TranslateTransform.XProperty, anim1);
            trans.BeginAnimation(TranslateTransform.YProperty, anim2);
            this.X = X;
            this.Y = Y;
            
        }


        public void reframe() {
            Canvas.SetTop(this, -(618 - Y + 100));
            Canvas.SetLeft(this, X - 10);
            
        }
    }
}