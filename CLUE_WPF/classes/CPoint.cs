using System;
using System.Collections.Generic;
using System.Text;

namespace Clue_WPF.classes {
    public class CPoint {
        public double X { set; get; }
        public double Y { set; get; }

        public CPoint(double X, double Y) {
            this.X = X;
            this.Y = Y;
        }
        public CPoint() {

        }
    }
}
