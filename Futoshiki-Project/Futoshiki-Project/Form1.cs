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
        private CellGrid grid;
        private Label[,] hSigns;
        private Label[,] vSigns;

        private Random rng = new Random();
        private FutoshikiCell selectedCell = null;
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            int size = (int)numSize.Value;
            GenerateBoardUI(size);
        }

        private void OnCellClicked(object sender, EventArgs e)
        {
            FutoshikiCell clickedCell = sender as FutoshikiCell;
            if (clickedCell.IsFixed) return;
            if (selectedCell != null) selectedCell.SetSelected(false);

            selectedCell = clickedCell;
            selectedCell.SetSelected(true);
            this.Focus();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (selectedCell == null) return base.ProcessCmdKey(ref msg, keyData);

            if (keyData == Keys.Back)
            {
                if (!selectedCell.IsFixed)
                {
                    selectedCell.SetValue(0);
                    RefreshAllDomains();
                }
                return true;
            }

            int val = 0;
            if (keyData >= Keys.D1 && keyData <= Keys.D9)
                val = (int)keyData - (int)Keys.D0;
            else if (keyData >= Keys.NumPad1 && keyData <= Keys.NumPad9)
                val = (int)keyData - (int)Keys.NumPad0;

            if (val > 0)
            {
                int size = (int)numSize.Value;
                if (val > size) return true;
                List<int> validOptions = selectedCell.GetPosibleValues(grid, size);

                if(validOptions.Count==0)
                {
                    MessageBox.Show("Mutare imposibila pentru numerele selectate momentan nu se potriveste nimic aici.\nIncearca alte combinatii (selectează alte casute si sterge cifrele cu Backspace).","Blocaj Logic",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                    );
                    return true;
                }


                if (validOptions.Contains(val))
                {
                    selectedCell.SetValue(val);
                    RefreshAllDomains();
                    CheckVictory(size);
                }
                else
                {
                    MessageBox.Show($"Mutare invalida! Conform regulilor, aici poti pune doar: {string.Join(", ", validOptions)}");
                }
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void RefreshAllDomains()
        {
            int size = (int)numSize.Value;
            for (int r = 0; r < size; r++)
            {
                for (int c = 0; c < size; c++)
                {
                    grid.GetCell(r, c).GetDomain(grid, size);
                }
            }
        }
        private void CheckVictory(int size)
        {
            bool full = true;
            for (int r = 0; r < size; r++)
            {
                for (int c = 0; c < size; c++)
                {
                    if (grid.GetCell(r, c).Value == 0)
                    {
                        full = false;
                        break;
                    }
                }
            }
            if (full)
            {
                MessageBox.Show("Felicitări! Ai terminat jocul!", "Victorie", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void GenerateBoardUI(int size)
        {
            pnlBoard.Controls.Clear();
            this.Width = 200 + size * 105;
            this.Height = 100 + size * 105;

            grid = new CellGrid(size);
            hSigns = new Label[size, size - 1]; 
            vSigns = new Label[size - 1, size]; 

            int cellSize = 60;
            int gap = 45; 
            int startX = 20;
            int startY = 20;

            int[,] solution = new int[size, size];
            for (int r = 0; r < size; r++)
            {
                for (int c = 0; c < size; c++)
                {
                    solution[r, c] = ((r + c) % size) + 1;
                }
            }

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
                    cell.CellClicked += OnCellClicked;
                    pnlBoard.Controls.Add(cell);
                    grid.SetCell(cell);

                    if (rng.Next(100) < 20)
                    {
                        cell.SetValue(solution[r, c]);
                        cell.IsFixed = true; 
                    }

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
            for (int r = 0; r < size; r++)
            {
                for (int c = 0; c < size; c++)
                {
                    int x = startX + c * (cellSize + gap);
                    int y = startY + r * (cellSize + gap);
                    if (c < size - 1)
                    {
                        if (rng.Next(100) < 40)
                        {
                            Label lblH = CreateSignLabel();
                            lblH.Location = new Point(x + cellSize + (gap / 2) - 15, y + (cellSize / 2) - 20);
                            pnlBoard.Controls.Add(lblH);
                            hSigns[r, c] = lblH;
                            char semn;
                            if (solution[r, c] < solution[r, c + 1]) semn = '<';
                            else semn = '>';

                            lblH.Text = semn.ToString();
                            grid.AddConstraint(grid.GetCell(r, c), grid.GetCell(r, c + 1), semn);
                        }
                    }
                    if (r < size - 1)
                    {
                        if (rng.Next(100) < 40)
                        {
                            Label lblV = CreateSignLabel();
                            lblV.Location = new Point(x + (cellSize / 2) - 12, y + cellSize + (gap / 2) - 20);
                            pnlBoard.Controls.Add(lblV);
                            vSigns[r, c] = lblV;
                            char semn;
                            if (solution[r, c] < solution[r + 1, c]) semn = 'v';
                            else semn = '∧';

                            lblV.Text = semn.ToString();
                            grid.AddConstraint(grid.GetCell(r, c), grid.GetCell(r + 1, c), semn);
                        }
                    }
                }
            }
            RefreshAllDomains();
           // TestFillUI(size);
        }

        private Label CreateSignLabel()
        {
            Label lbl = new Label();
            lbl.AutoSize = true;
            lbl.Font = new Font("Segoe UI", 20, FontStyle.Regular);
            lbl.ForeColor = Color.Red;
            lbl.Text = "";
            return lbl;
        }
        private void TestFillUI(int size)
        {
            if (grid.GetCell(0, 1) != null)
            {
                grid.GetCell(0, 1).SetValue(5);
                grid.GetCell(0, 1).IsFixed = true;
            }

            foreach (var constr in grid.GetConstraints())
            {
                grid.GetCell(constr.Row1, constr.Col1).GetDomain(grid, size);
                grid.GetCell(constr.Row2, constr.Col2).GetDomain(grid, size);
            }
        }
    }
}
