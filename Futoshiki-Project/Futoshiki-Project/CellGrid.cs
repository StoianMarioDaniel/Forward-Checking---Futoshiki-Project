using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futoshiki_Project
{
    public class CellGrid
    {
        private FutoshikiCell[,] Cells { get; set; }
        private int Size { get; set; }
        private List<Constrangere> listaConstrangeri;

        public FutoshikiCell GetCell(int row, int col)
        {
            return Cells[row, col];
        }
        public void SetCell(FutoshikiCell cell)
        {
            Cells[cell.Row, cell.Col] = cell;
        }
        public int GetSize()
        {
            return Size;
        }
        public List<Constrangere> GetConstraints()
        {
            return listaConstrangeri;
        }
        public CellGrid(int size)
        {
            Size = size;
            Cells = new FutoshikiCell[size, size];
            listaConstrangeri = new List<Constrangere>();
        }
        public void AddConstraint(FutoshikiCell c1, FutoshikiCell c2, char s)
        {
            Constrangere constr = new Constrangere(c1, c2, s);
            listaConstrangeri.Add(constr);
        }
    }
}
