using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Futoshiki_Project;

namespace Futoshiki_Project
{
    public partial class Form1: Form
    {
        private FutoshikiCell[,] gridCells;
        private Label[,] hSigns;
        private Label[,] vSigns;
        public Form1()
        {
            InitializeComponent();
        }
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            int size = (int)numSize.Value;
            GenerateBoardUI(size);
        }
        private void GenerateBoardUI(int size)
        {
            pnlBoard.Controls.Clear();

            gridCells = new FutoshikiCell[size, size];
            hSigns = new Label[size, size - 1]; 
            vSigns = new Label[size - 1, size]; 

            int cellSize = 60;
            int gap = 45; 
            int startX = 20;
            int startY = 20;

            for (int r = 0; r < size; r++)
            {
                for (int c = 0; c < size; c++)
                {
                    FutoshikiCell cell = new FutoshikiCell();
                    cell.Row = r;
                    cell.Col = c;
                    int x = startX + c * (cellSize + gap);
                    int y = startY + r * (cellSize + gap);
                    cell.Location = new Point(x, y);
                    pnlBoard.Controls.Add(cell);
                    gridCells[r, c] = cell;

                    if (c < size - 1)
                    {
                        Label lblH = CreateSignLabel();
                        lblH.Location = new Point(x + cellSize + (gap / 2) - 15, y + (cellSize / 2) - 20);

                        pnlBoard.Controls.Add(lblH);
                        hSigns[r, c] = lblH;
                    }
                    if (r < size - 1)
                    {
                        Label lblV = CreateSignLabel();
                        lblV.Location = new Point(x + (cellSize / 2) - 12, y + cellSize + (gap / 2) - 20);

                        pnlBoard.Controls.Add(lblV);
                        vSigns[r, c] = lblV;
                    }
                }
            }
            TestFillUI();
        }
        private Label CreateSignLabel()
        {
            Label lbl = new Label();
            lbl.AutoSize = true;
            lbl.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            lbl.ForeColor = Color.Red;
            lbl.Text = "";
            return lbl;
        }
        private void TestFillUI()
        {
            if (hSigns.GetLength(1) > 0) hSigns[0, 0].Text = "<";
            if (vSigns.GetLength(0) > 0) vSigns[0, 0].Text = "v";
            gridCells[0, 0].SetDomain("1 2 4");
            gridCells[0, 1].SetValue(5);
            gridCells[0, 1].IsFixed = true; 
        }
    }
}
