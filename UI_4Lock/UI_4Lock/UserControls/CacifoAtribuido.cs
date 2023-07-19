using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
