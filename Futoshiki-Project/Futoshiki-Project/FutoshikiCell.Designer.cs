namespace Futoshiki_Project
{
    partial class FutoshikiCell
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblValue = new System.Windows.Forms.Label();
            this.lblDomain = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblValue
            // 
            this.lblValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblValue.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValue.Location = new System.Drawing.Point(0, 0);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(86, 89);
            this.lblValue.TabIndex = 0;
            this.lblValue.Text = "5";
            this.lblValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDomain
            // 
            this.lblDomain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblDomain.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDomain.Location = new System.Drawing.Point(0, 73);
            this.lblDomain.Name = "lblDomain";
            this.lblDomain.Size = new System.Drawing.Size(86, 16);
            this.lblDomain.TabIndex = 1;
            this.lblDomain.Text = "lblDomain";
            this.lblDomain.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // FutoshikiCell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblDomain);
            this.Controls.Add(this.lblValue);
            this.Name = "FutoshikiCell";
            this.Size = new System.Drawing.Size(86, 89);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.Label lblDomain;
    }
}
