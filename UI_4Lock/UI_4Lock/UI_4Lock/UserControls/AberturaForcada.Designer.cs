using System.Windows.Forms;
using System;

namespace UI_4Lock.UserControls
{
    partial class AberturaForcada
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.richTextBox5 = new System.Windows.Forms.RichTextBox();
            this.richTextBox6 = new System.Windows.Forms.RichTextBox();
            this.richTextBox7 = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button3 = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 20F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(266, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(567, 41);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código para validar a abertura forçada:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Window;
            this.richTextBox1.Location = new System.Drawing.Point(231, 148);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(200, 30);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // guna2Button1
            // 
            this.guna2Button1.BackColor = System.Drawing.SystemColors.Control;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.MediumSeaGreen;
            this.guna2Button1.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold);
            this.guna2Button1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.guna2Button1.Location = new System.Drawing.Point(105, 375);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(253, 80);
            this.guna2Button1.TabIndex = 2;
            this.guna2Button1.Text = "Validar";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(231, 214);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(200, 30);
            this.richTextBox2.TabIndex = 3;
            this.richTextBox2.Text = "";
            // 
            // richTextBox3
            // 
            this.richTextBox3.Location = new System.Drawing.Point(231, 284);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.Size = new System.Drawing.Size(200, 30);
            this.richTextBox3.TabIndex = 4;
            this.richTextBox3.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(162, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "CUET:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(183, 214);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 23);
            this.label3.TabIndex = 6;
            this.label3.Text = "RH:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(188, 284);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 23);
            this.label4.TabIndex = 7;
            this.label4.Text = "CT:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(682, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 24);
            this.label5.TabIndex = 8;
            this.label5.Text = "Observações:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // richTextBox5
            // 
            this.richTextBox5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.richTextBox5.Location = new System.Drawing.Point(572, 142);
            this.richTextBox5.Name = "richTextBox5";
            this.richTextBox5.Size = new System.Drawing.Size(340, 45);
            this.richTextBox5.TabIndex = 11;
            this.richTextBox5.Text = "";
            this.richTextBox5.TextChanged += new System.EventHandler(this.richTextBox5_TextChanged);
            // 
            // richTextBox6
            // 
            this.richTextBox6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.richTextBox6.Location = new System.Drawing.Point(572, 208);
            this.richTextBox6.Name = "richTextBox6";
            this.richTextBox6.Size = new System.Drawing.Size(340, 45);
            this.richTextBox6.TabIndex = 12;
            this.richTextBox6.Text = "";
            this.richTextBox6.TextChanged += new System.EventHandler(this.richTextBox6_TextChanged);
            // 
            // richTextBox7
            // 
            this.richTextBox7.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.richTextBox7.Location = new System.Drawing.Point(572, 278);
            this.richTextBox7.Name = "richTextBox7";
            this.richTextBox7.Size = new System.Drawing.Size(340, 45);
            this.richTextBox7.TabIndex = 13;
            this.richTextBox7.Text = "";
            this.richTextBox7.TextChanged += new System.EventHandler(this.richTextBox7_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(280, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 24);
            this.label6.TabIndex = 14;
            this.label6.Text = "Entidades";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(270, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 17);
            this.label7.TabIndex = 15;
            this.label7.Text = "*";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(669, 104);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 17);
            this.label8.TabIndex = 16;
            this.label8.Text = "*";
            // 
            // guna2Button2
            // 
            this.guna2Button2.BackColor = System.Drawing.SystemColors.Control;
            this.guna2Button2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button2.FillColor = System.Drawing.Color.MediumSeaGreen;
            this.guna2Button2.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold);
            this.guna2Button2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.guna2Button2.Location = new System.Drawing.Point(420, 375);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.Size = new System.Drawing.Size(253, 80);
            this.guna2Button2.TabIndex = 17;
            this.guna2Button2.Text = "Registar por E-mail";
            this.guna2Button2.Click += new System.EventHandler(this.guna2Button2_Click);
            // 
            // guna2Button3
            // 
            this.guna2Button3.BackColor = System.Drawing.SystemColors.Control;
            this.guna2Button3.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button3.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button3.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button3.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button3.FillColor = System.Drawing.Color.MediumSeaGreen;
            this.guna2Button3.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold);
            this.guna2Button3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.guna2Button3.Location = new System.Drawing.Point(712, 375);
            this.guna2Button3.Name = "guna2Button3";
            this.guna2Button3.Size = new System.Drawing.Size(253, 80);
            this.guna2Button3.TabIndex = 18;
            this.guna2Button3.Text = "Abrir Cacifo";
            // 
            // AberturaForcada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.guna2Button3);
            this.Controls.Add(this.guna2Button2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.richTextBox7);
            this.Controls.Add(this.richTextBox6);
            this.Controls.Add(this.richTextBox5);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.richTextBox3);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label1);
            this.Name = "AberturaForcada";
            this.Size = new System.Drawing.Size(1055, 532);
            this.Load += new System.EventHandler(this.AberturaForcada_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private RichTextBox richTextBox2;
        private RichTextBox richTextBox3;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private RichTextBox richTextBox5;
        private RichTextBox richTextBox6;
        private RichTextBox richTextBox7;
        private Label label6;
        private Label label7;
        private Label label8;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private Guna.UI2.WinForms.Guna2Button guna2Button3;
    }
}
