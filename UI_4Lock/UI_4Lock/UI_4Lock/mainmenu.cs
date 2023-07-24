//using CacifoAtribuida;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI_4Lock.UserControls;


namespace UI_4Lock
{
    public partial class mainmenu : Form
    {
        CacifoAtribuido uc = null;
        public mainmenu()
        {
            InitializeComponent();
        }
        
        private void addUserControl(UserControl userControl)
        {
           userControl.Dock = DockStyle.Fill;
           panelContainer.Controls.Clear();
           panelContainer.Controls.Add(userControl); 
           userControl.BringToFront();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            AbandonarCacifo uc = new AbandonarCacifo();
            addUserControl(uc);
        }

        private void panelContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            this.uc = new CacifoAtribuido();
            addUserControl(uc);

            string connect = "server=localhost;uid=root;pwd=Horsegrupo4;database=4lock";
            //string connect = con.connect(); Falar ao tiago ?
            MySqlConnection connection = new MySqlConnection(connect);
            connection.Open();
            MySqlCommand login = new MySqlCommand("select CARGO from tag_cargo where TAG = '" + int.Parse(textBox1.Text) + "'", connection);
            MySqlDataReader reader = login.ExecuteReader();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            EscolherCacifo uc = new EscolherCacifo();
            addUserControl(uc);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
  
    }
}
