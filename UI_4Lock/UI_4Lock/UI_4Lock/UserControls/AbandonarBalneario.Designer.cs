namespace UI_4Lock.UserControls
{
    partial class AbandonarBalneario
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2Button4 = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(360, 213);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(4);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(270, 50);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(333, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(341, 31);
            this.label1.TabIndex = 6;
            this.label1.Text = "Inserir Número de Colaborador:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // guna2Button4
            // 
            this.guna2Button4.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.guna2Button4.CheckedState.CustomBorderColor = System.Drawing.Color.Gray;
            this.guna2Button4.CustomBorderColor = System.Drawing.Color.Silver;
            this.guna2Button4.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.guna2Button4.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button4.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button4.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button4.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button4.FillColor = System.Drawing.Color.MediumSeaGreen;
            this.guna2Button4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.guna2Button4.ForeColor = System.Drawing.Color.White;
            this.guna2Button4.HoverState.CustomBorderColor = System.Drawing.Color.Gray;
            this.guna2Button4.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.guna2Button4.Location = new System.Drawing.Point(360, 326);
            this.guna2Button4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2Button4.Name = "guna2Button4";
            this.guna2Button4.Size = new System.Drawing.Size(270, 70);
            this.guna2Button4.TabIndex = 7;
            this.guna2Button4.Text = "Abandonar Cacifo de Balneário";
            this.guna2Button4.Click += new System.EventHandler(this.guna2Button4_Click);
            // 
            // AbandonarBalneario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.guna2Button4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AbandonarBalneario";
            this.Size = new System.Drawing.Size(1055, 532);
            this.Load += new System.EventHandler(this.AbandonarBalneario_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button guna2Button4;
    }
}
