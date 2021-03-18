using System;
using System.Collections.Generic;
using System.Text;

namespace Clue_WPF.classes {
    public class Move {

        public static CPoint getPoint(List<Side> Waypoints, CPoint o, CPoint d) {
            double mn, ml, xc, yc;
            bool vale;
            CPoint p = new CPoint(d.X, d.Y);

            double minDistance = Double.PositiveInfinity;

            foreach(Side s in Waypoints) {
                double x1 = o.X, y1 = o.Y, x2 = d.X, y2 = d.Y;
                double xa = s.A.X, ya = s.A.Y, xb = s.B.X, yb = s.B.Y;
                double newDistance;

                mn = (x1 != x2) ? (y2 - y1) / (x2 - x1) : Double.NaN;
                ml = (xa != xb) ? (yb - ya) / (xb - xa) : Double.NaN;

                xc = Double.NaN;

                if (mn == Double.NaN) {
                    xc = x1;
                }
                else if (ml == Double.NaN) {
                    xc = xa;
                }
                else if (mn != ml) {
                    xc = (mn * x1 - ml * xa + ya - y1) / (mn - ml);
                }
                if (xc != Double.NaN) {
                    yc = y1 + mn * (xc - x1);
                }
                else {
                    yc = Double.NaN;
                }
                vale = xc != Double.NaN && (
                  (Math.Min(x1, x2) <= xc) && (xc <= Math.Max(x1, x2)) &&
                  (Math.Min(xa, xb) <= xc) && (xc <= Math.Max(xa, xb)) &&
                  (Math.Min(y1, y2) <= yc) && (yc <= Math.Max(y1, y2)) &&
                  (Math.Min(ya, yb) <= yc) && (yc <= Math.Max(ya, yb)));
                newDistance = Math.Sqrt(Math.Pow(o.X - xc, 2) + Math.Pow(o.Y - yc, 2));
                if (vale && newDistance < minDistance) {
                    minDistance = newDistance;
                    p.X = xc + ((xc > o.X) ? -2 : 2);
                    p.Y = yc + ((yc > o.Y) ? -2 : 2);
                }
            }

            return p;
        }
    }
}
