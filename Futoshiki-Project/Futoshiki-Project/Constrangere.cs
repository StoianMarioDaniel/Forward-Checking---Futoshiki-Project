using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futoshiki_Project
{
    public class Constrangere
    {
        private int row1;
        private int col1;
        private int row2;
        private int col2;
        private char sign;
        public int Row1
        { get { return row1; }  }
        public int Col1
        { get { return col1; }  }
        public int Row2
        { get { return row2; }  }
        public int Col2
        { get { return col2; }  }
        public char Sign
        { get { return sign; }  }
        public Constrangere(FutoshikiCell c1, FutoshikiCell c2, char s)
        {
            row1 = c1.Row;
            col1 = c1.Col;
            row2 = c2.Row;
            col2 = c2.Col;
            sign = s;
        }

    }
}
