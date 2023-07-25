using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;


namespace UI_4Lock.UserControls
{
    public partial class CacifoAtribuido : UserControl
    {
        public CacifoAtribuido()
        {
            InitializeComponent();

        }

        
        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        public string getBoxText()
        {
            return richTextBox1.Text;
        }

        public void setBoxText(string text) {
            richTextBox1.Text = text;
            
        }

        public void setBoxText2(string text)
        {
            richTextBox2.Text = text;

        }

        public void setBoxText3(string text)
        {
            richTextBox3.Text = text;

        }

        public void setBoxText4(string text)
        {
            richTextBox4.Text = text;

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void CacifoAtribuido_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
