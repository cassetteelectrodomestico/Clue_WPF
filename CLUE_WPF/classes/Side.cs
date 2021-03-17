using System;
using System.Collections.Generic;
using System.Text;

namespace Clue_WPF.classes {
    public class Side {
        public CPoint A { set; get; }
        public CPoint B { set; get; }

        public Side(CPoint A, CPoint B) {
            this.A = A;
            this.B = B;
        }
    }
}
