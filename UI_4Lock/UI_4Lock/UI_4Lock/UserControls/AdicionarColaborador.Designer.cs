namespace UI_4Lock.UserControls
{
    partial class AdicionarColaborador
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
            this.guna2Button100 = new Guna.UI2.WinForms.Guna2Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBox5 = new System.Windows.Forms.RichTextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(381, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(279, 31);
            this.label1.TabIndex = 6;
            this.label1.Text = "Inserir Novo Colaborador:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // guna2Button100
            // 
            this.guna2Button100.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.guna2Button100.CheckedState.CustomBorderColor = System.Drawing.Color.Gray;
            this.guna2Button100.CustomBorderColor = System.Drawing.Color.Silver;
            this.guna2Button100.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.guna2Button100.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button100.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button100.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button100.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button100.FillColor = System.Drawing.Color.MediumSeaGreen;
            this.guna2Button100.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.guna2Button100.ForeColor = System.Drawing.Color.White;
            this.guna2Button100.HoverState.CustomBorderColor = System.Drawing.Color.Gray;
            this.guna2Button100.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.guna2Button100.Location = new System.Drawing.Point(387, 393);
            this.guna2Button100.Name = "guna2Button100";
            this.guna2Button100.Size = new System.Drawing.Size(270, 70);
            this.guna2Button100.TabIndex = 8;
            this.guna2Button100.Text = "Adicionar Colaborador";
            this.guna2Button100.Click += new System.EventHandler(this.guna2Button100_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(177, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(217, 24);
            this.label3.TabIndex = 13;
            this.label3.Text = "Número de Trabalhador:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(177, 260);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 24);
            this.label5.TabIndex = 15;
            this.label5.Text = "Nome:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(177, 185);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(172, 24);
            this.label6.TabIndex = 16;
            this.label6.Text = "Número do Cartão:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(177, 335);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 24);
            this.label2.TabIndex = 18;
            this.label2.Text = "Cargo:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // richTextBox5
            // 
            this.richTextBox5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox5.Location = new System.Drawing.Point(508, 109);
            this.richTextBox5.Name = "richTextBox5";
            this.richTextBox5.Size = new System.Drawing.Size(340, 45);
            this.richTextBox5.TabIndex = 19;
            this.richTextBox5.Text = "";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(508, 182);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(340, 45);
            this.richTextBox1.TabIndex = 20;
            this.richTextBox1.Text = "";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox2.Location = new System.Drawing.Point(508, 257);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(340, 45);
            this.richTextBox2.TabIndex = 21;
            this.richTextBox2.Text = "";
            // 
            // listBox1
            // 
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Items.AddRange(new object[] {
            "COLAB",
            "CUET",
            "RH"});
            this.listBox1.Location = new System.Drawing.Point(508, 323);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(340, 34);
            this.listBox1.TabIndex = 23;
            // 
            // AdicionarColaborador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.richTextBox5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.guna2Button100);
            this.Controls.Add(this.label1);
            this.Name = "AdicionarColaborador";
            this.Size = new System.Drawing.Size(1055, 532);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button guna2Button100;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBox5;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.ListBox listBox1;
    }
}
