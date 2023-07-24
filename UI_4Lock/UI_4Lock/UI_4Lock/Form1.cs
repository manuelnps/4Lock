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

namespace UI_4Lock
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connect = "server=localhost;uid=root;pwd=Horsegrupo4;database=4lock";
            var connection = new MySqlConnection(connect);
            var command = connection.CreateCommand();
            MySqlCommand login = new MySqlCommand("select CARGO from tag_cargo where TAG = '" + int.Parse(textBox1.Text)+"'", connection);
            connection.Open();
            DataTable datatable = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(login);
            da.Fill(datatable);
            
            foreach(DataRow list in datatable.Rows)
            {
                /*
                if (Convert.ToInt32(list.ItemArray[0]) > 0)
                {
                    if
                    new mainmenu().Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Tag não encontrada.");
                    textBox1.Clear();
                    textBox1.Focus();
                }
                */
                string cargo = datatable.Rows[0].ToString();
                if (string.Equals(cargo, "COLAB", StringComparison.OrdinalIgnoreCase))
                {

                }

            }
            /* 
            if(textBox1.Text == "1234")
            {
                new mainmenu().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Tag não encontrada.");
                textBox1.Clear();
                textBox1.Focus();
            }
            */
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
