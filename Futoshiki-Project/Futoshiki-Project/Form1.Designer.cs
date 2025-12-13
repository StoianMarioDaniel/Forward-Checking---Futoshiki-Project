namespace Futoshiki_Project
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkAnimation = new System.Windows.Forms.CheckBox();
            this.btnSolve = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.numSize = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlBoard = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSize)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.chkAnimation);
            this.panel1.Controls.Add(this.btnSolve);
            this.panel1.Controls.Add(this.btnGenerate);
            this.panel1.Controls.Add(this.numSize);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 605);
            this.panel1.TabIndex = 0;
            // 
            // chkAnimation
            // 
            this.chkAnimation.AutoSize = true;
            this.chkAnimation.Checked = true;
            this.chkAnimation.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAnimation.Location = new System.Drawing.Point(12, 175);
            this.chkAnimation.Name = "chkAnimation";
            this.chkAnimation.Size = new System.Drawing.Size(81, 20);
            this.chkAnimation.TabIndex = 4;
            this.chkAnimation.Text = "Animație";
            this.chkAnimation.UseVisualStyleBackColor = true;
            // 
            // btnSolve
            // 
            this.btnSolve.Location = new System.Drawing.Point(12, 130);
            this.btnSolve.Name = "btnSolve";
            this.btnSolve.Size = new System.Drawing.Size(143, 23);
            this.btnSolve.TabIndex = 3;
            this.btnSolve.Text = "Rezolvă (Start)";
            this.btnSolve.UseVisualStyleBackColor = true;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(12, 89);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(143, 23);
            this.btnGenerate.TabIndex = 2;
            this.btnGenerate.Text = "Generează Joc";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // numSize
            // 
            this.numSize.Location = new System.Drawing.Point(12, 43);
            this.numSize.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.numSize.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numSize.Name = "numSize";
            this.numSize.Size = new System.Drawing.Size(105, 22);
            this.numSize.TabIndex = 1;
            this.numSize.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dimensiune";
            // 
            // pnlBoard
            // 
            this.pnlBoard.AutoScroll = true;
            this.pnlBoard.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlBoard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBoard.Location = new System.Drawing.Point(200, 0);
            this.pnlBoard.Name = "pnlBoard";
            this.pnlBoard.Size = new System.Drawing.Size(759, 605);
            this.pnlBoard.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 605);
            this.Controls.Add(this.pnlBoard);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSolve;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.NumericUpDown numSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkAnimation;
        private System.Windows.Forms.Panel pnlBoard;
    }
}

