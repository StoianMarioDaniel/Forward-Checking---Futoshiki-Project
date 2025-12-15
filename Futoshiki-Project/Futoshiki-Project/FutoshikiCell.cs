using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Futoshiki_Project
{
    public partial class FutoshikiCell: UserControl
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public int Value { get; set; }
        private bool _isFixed;
        public bool IsFixed
        {
            get { return _isFixed; }
            set
            {
                _isFixed = value;
                if (_isFixed)
                {
                    lblValue.ForeColor = Color.DarkBlue;
                    lblValue.Font = new Font("Segoe UI", 20, FontStyle.Bold);
                    this.BackColor = Color.FromArgb(240, 240, 240);
                }
                else
                {
                    lblValue.ForeColor = Color.Black;
                    lblValue.Font = new Font("Segoe UI", 20, FontStyle.Regular);
                    this.BackColor = Color.White;
                }
            }
        }

        public FutoshikiCell()
        {
            InitializeComponent();
            lblValue.Text = "";
            lblDomain.Text = "";
        }
        public void SetValue(int val)
        {
            if (val == 0)
            {
                lblValue.Text = "";
            }
            else
            {
                this.Value = val;
                lblValue.Text = val.ToString();
                lblDomain.Text = "";
            }
        }
        // Functie ce implementeaza Forward Checking pentru a returna o lista de valori posibile
        public List<int> GetPosibleValues(CellGrid grid,int size)
        {
            List<int> domeniu = Enumerable.Range(1,size).ToList();

            //Verificam linia pe care se afla celula si eliminam valorile existente din domeniu
            for(int c = 0;c<size;c++)
            {
                if(c != this.Col && grid.GetCell(this.Row,c).Value != 0)
                {
                    domeniu.Remove(grid.GetCell(this.Row, c).Value);
                }
            }
            //Verificam si coloana pe care se afla celula
            for (int r = 0; r < size; r++)
            {
                if (r != this.Row && grid.GetCell(r, this.Col).Value != 0)
                {
                    domeniu.Remove(grid.GetCell(r, this.Col).Value);
                }
            }
            //Verificam lista de constrangeri
            foreach(var constr in grid.GetConstraints())
            {
                // Verificam daca celula are vreo constrangere
                bool isCel1 = (constr.Row1 ==  this.Row && constr.Col1 == this.Col);
                bool isCel2 = (constr.Row2 ==  this.Row && constr.Col2 == this.Col);
                if(!isCel1 && !isCel2)
                {
                    continue;
                }
                // Daca are, determinam vecinul si relatia celulei fata de el
                FutoshikiCell vecin;
                char sign = ' ';
                if(isCel1)
                {
                    vecin = grid.GetCell(constr.Row2, constr.Col2);
                    switch(constr.Sign)
                    {
                        case 'v':
                            sign = '>';
                            break;
                        case '∧':
                            sign = '<';
                            break;
                        default:
                            sign = constr.Sign;
                            break;
                    }
                }
                else if(isCel2)
                {
                    vecin = grid.GetCell(constr.Row1, constr.Col1);
                    switch (constr.Sign)
                    {
                        case 'v':
                            sign = '<';
                            break;
                        case '∧':
                            sign = '>';
                            break;
                        case '>':
                            sign = '<';
                            break;
                        case '<':
                            sign = '>';
                            break;
                    }
                }
                // Daca vecinul are valoare, eliminam din domeniu valorile care nu respecta constrangerea
                if (this.Value != 0)
                {
                    if(sign == '>')
                    {
                        domeniu.RemoveAll(x => x <= this.Value);
                    }
                    else if(sign == '<')
                    {
                        domeniu.RemoveAll(x => x >= this.Value);
                    }
                }
                // Daca vecinul nu are valoare, facem o euristica si eliminam extremitatile
                else
                {
                    if (sign == '>')
                    {
                        domeniu.Remove(1);
                    }
                    else if (sign == '<')
                    {
                        domeniu.Remove(size);
                    }
                }
            }
            // Returnam lista de posibilitati
            return domeniu;
        }
        public void GetDomain(CellGrid grid,int size)
        {
            List<int> domeniu = GetPosibleValues(grid, size);
            // TO BE DONE: Afisarea posibilitatilor
        }
        public void SetError(bool isError)
        {
            if (isError)
                this.BackColor = Color.MistyRose;
            else
                this.BackColor = IsFixed ? Color.FromArgb(240, 240, 240) : Color.White;
        }
        private void lblValue_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }
    }
}
