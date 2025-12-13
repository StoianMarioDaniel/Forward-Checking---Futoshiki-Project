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
                lblValue.Text = val.ToString();
                lblDomain.Text = "";
            }
        }
        public void SetDomain(string domainText)
        {
            if (string.IsNullOrEmpty(lblValue.Text))
            {
                lblDomain.Text = domainText;
            }
            else
            {
                lblDomain.Text = "";
            }
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
