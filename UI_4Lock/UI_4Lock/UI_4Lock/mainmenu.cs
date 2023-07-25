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

            
            //string connect = "server=localhost;uid=root;pwd=Horsegrupo4;database=4lock";
           //string connect = con.connect(); Falar ao tiago ?
            
            MySqlConnection connectionatribuircacifo = new MySqlConnection(GlobalData.Connect());
            connectionatribuircacifo.Open();
            string nmrgotten = Form1.getNMR();
            //MessageBox.Show(nmrgotten);
            MySqlCommand balneariozona = new MySqlCommand("select ZONA from balnearios where NMR = '" + int.Parse(nmrgotten) + "'", connectionatribuircacifo);
            MySqlDataReader getzonabalneario = balneariozona.ExecuteReader();
            if (getzonabalneario.Read())
            {
                uc.setBoxText(getzonabalneario["ZONA"].ToString()); // Get the cargo value from the reader
                getzonabalneario.Close();
                //connectionatribuircacifo.Close();
            }
            
            MySqlCommand balneariopos = new MySqlCommand("select POS from balnearios where NMR = '" + int.Parse(nmrgotten) + "'", connectionatribuircacifo);
            MySqlDataReader getposbalneario = balneariopos.ExecuteReader();
            if (getposbalneario.Read())
            {
                uc.setBoxText2(getposbalneario["POS"].ToString()); // Get the cargo value from the reader
                getposbalneario.Close();
            }
            /*
             * Adicionar método para procurar em todas as tabelas. Se retornar nulo não é essa zona, se retornar não nulo então é esse o cacifo de proximidade.
            */

            uc.setBoxText3("V"); // Get the cargo value from the reader


            MySqlCommand proxpos1 = new MySqlCommand("select POS1 from prox_v where NMR = '" + int.Parse(nmrgotten) + "'", connectionatribuircacifo);
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
