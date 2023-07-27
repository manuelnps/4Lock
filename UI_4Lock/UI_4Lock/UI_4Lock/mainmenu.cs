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
        Form1 uc1;
        public mainmenu()
        {
            InitializeComponent();
        }
        
        public void addUserControl(UserControl userControl)
        {
           userControl.Dock = DockStyle.Fill;
           panelContainer.Controls.Clear();
           panelContainer.Controls.Add(userControl); 
           userControl.BringToFront();
        }

        public void addUserControl2(UserControl userControl)
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

            
            
            MySqlConnection connectionatribuircacifo = new MySqlConnection(GlobalData.Connect());
            connectionatribuircacifo.Open();
            MySqlCommand balneariozona = new MySqlCommand("select ZONA from balnearios where NMR = '" + int.Parse(Form1.getNMR()) + "'", connectionatribuircacifo);
            MySqlDataReader getzonabalneario = balneariozona.ExecuteReader();
            if (getzonabalneario.Read())
            {
                uc.setBoxText(getzonabalneario["ZONA"].ToString()); // Get the cargo value from the reader
                getzonabalneario.Close();
            }
            
            MySqlCommand balneariopos = new MySqlCommand("select POS from balnearios where NMR = '" + int.Parse(Form1.getNMR()) + "'", connectionatribuircacifo);
            MySqlDataReader getposbalneario = balneariopos.ExecuteReader();
            if (getposbalneario.Read())
            {
                uc.setBoxText2(getposbalneario["POS"].ToString()); // Get the cargo value from the reader
                getposbalneario.Close();
            }
           
            
            uc.setBoxText3(Form1.getZPROX()); // Get the cargo value from the reader

            MySqlCommand proxpos1 = new MySqlCommand("select POS1 from "+ Form1.getTablename() + " where NMR = '" + int.Parse(Form1.getNMR()) + "'", connectionatribuircacifo);
            MySqlDataReader getpos1prox = proxpos1.ExecuteReader();
            if (getpos1prox.Read())
            {
                uc.setBoxText4(getpos1prox["POS1"].ToString()); // Get the cargo value from the reader
                getpos1prox.Close();
            }
           
            connectionatribuircacifo.Close();

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
