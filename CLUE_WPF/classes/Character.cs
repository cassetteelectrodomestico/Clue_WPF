using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.Threading;
using System.Windows.Media.Animation;
using System.Windows;
using System.Threading.Tasks;
using Clue_WPF.modelos;
using Clue_WPF.visuals;

namespace Clue_WPF.classes {
    public class Character : Image {
        public double X { set; get; }
        public double Y { set; get; }
        private int location { set; get; }
        private List<ImageSource> faces  { set; get; }

        public Character(string [] faces, double [] position) {
            this.faces = new List<ImageSource>();
            foreach(string face in faces) this.faces.Add((ImageSource)TryFindResource(face));
            Source = this.faces[0];
            Height = 100;
            Stretch = Stretch.Fill;
            CacheMode = CacheMode;
            
            this.X = position[0];
            this.Y = position[1];
            
            //Canvas.SetTop(this, -(618 - Y + 100));
            //Canvas.SetLeft(this, X - 10);
            reframe();
            location = 0;
        }

        public double move(double X, double Y) {
            reframe();
            double antX = this.X, antY = this.Y;
            int selector = 0;
            selector += (X > antX) ? 1 : 0;
            selector += (Y > antY) ? 0 : 2;
            Source = faces[selector];   
            CPoint destiny = Move.getPoint(MainWindow.WayPoints, new CPoint(antX, antY), new CPoint(X, Y));
            Vector offset = VisualTreeHelper.GetOffset(this);
            var top = offset.Y;
            var left = offset.X;
            double distance = Math.Sqrt(Math.Pow(destiny.X - antX, 2)+(destiny.Y - antY));
            double time = Math.Round((distance / 150) );
            if (time == 0 || double.IsNaN(time)) time = 1;
            TranslateTransform trans = new TranslateTransform();
            RenderTransform = trans;
            DoubleAnimation anim1 = new DoubleAnimation(0, destiny.X - antX, TimeSpan.FromSeconds(time));
            DoubleAnimation anim2 = new DoubleAnimation(0, destiny.Y - antY, TimeSpan.FromSeconds(time));
            trans.BeginAnimation(TranslateTransform.XProperty, anim1);
            trans.BeginAnimation(TranslateTransform.YProperty, anim2);

            this.X = destiny.X;
            this.Y = destiny.Y;
            
            Task.Delay(new TimeSpan(0,0,0,(int)(time),200)).ContinueWith(o => { afterAnimation(); });
            return time;
        }

        void afterAnimation() {
            Scene.WakeUp();
        }

        public void reframe(double [] position) {
            this.X = position[0];
            this.Y = position[1];
            reframe();
        }
        public void reframe() {
            //Cursor = System.Windows.Input.Cursors.Arrow;
            this.Dispatcher.Invoke(() => {
                Canvas.SetTop(this, -(618 - Y + 80));
                Canvas.SetLeft(this, X - 10);
            });

        }
    }
}