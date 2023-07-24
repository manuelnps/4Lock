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
using UI_4Lock.UserControls;

namespace UI_4Lock
{
    
    public partial class Form1 : Form
    {
        GlobalData con;
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
            //string connect = con.connect(); Falar ao tiago ?
            MySqlConnection connection = new MySqlConnection(connect);
            connection.Open();
            MySqlCommand login = new MySqlCommand("select CARGO from tag_cargo where TAG = '" + int.Parse(textBox1.Text) + "'", connection);
            MySqlDataReader reader = login.ExecuteReader();


            if (reader.Read()) // Check if the reader has rows
            {
                string cargo = reader["CARGO"].ToString(); // Get the cargo value from the reader
                if (string.Equals(cargo, "COLAB", StringComparison.OrdinalIgnoreCase))
                {
                    new mainmenu().Show();
                    this.Hide();
                }
                else
                {
                    textBox1.Clear();
                    textBox1.Focus();
                }
            }
            else
            {
                MessageBox.Show("Por favor fale com os Recursos Humanos","Cartão não encontrado",MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Clear();
                textBox1.Focus();
            }
            reader.Close();
            connection.Close();
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
