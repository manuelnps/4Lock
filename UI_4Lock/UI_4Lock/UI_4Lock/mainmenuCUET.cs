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
    public partial class mainmenuCUET : Form
    {
        CacifoAtribuido uc = null;
        public mainmenuCUET()
        {
            InitializeComponent();
        }

        public void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panelContainerCUET.Controls.Clear();
            panelContainerCUET.Controls.Add(userControl);
            userControl.BringToFront();
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            AbandonarCacifo uc = new AbandonarCacifo();
            addUserControl(uc);
        }

        private void mainmenuCUET_Load(object sender, EventArgs e)
        {

        }

        private void panelContainerCUET_Paint(object sender, PaintEventArgs e)
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

            //Não entra nestes Ifs por alguma razao e explode aqui <-----------------------------------------------------------------
            if (getzonabalneario.Read())
            {
                uc.setBoxText(getzonabalneario["ZONA"].ToString()); // Get the cargo value from the reader
                
            }
            getzonabalneario.Close();
            MySqlCommand balneariopos = new MySqlCommand("select POS from balnearios where NMR = '" + int.Parse(Form1.getNMR()) + "'", connectionatribuircacifo);
            MySqlDataReader getposbalneario = balneariopos.ExecuteReader();

            //Não entra nestes Ifs por alguma razao e explode aqui <-----------------------------------------------------------------
            if (getposbalneario.Read())
            {
                uc.setBoxText2(getposbalneario["POS"].ToString()); // Get the cargo value from the reader
                
            }
            getposbalneario.Close();

            uc.setBoxText3(Form1.getZPROX()); // Get the cargo value from the reader

            MySqlCommand proxpos1 = new MySqlCommand("select POS1 from " + Form1.getTablename() + " where NMR = '" + int.Parse(Form1.getNMR()) + "'", connectionatribuircacifo);
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

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            //Validar cacifo
            ValidarCacifo uc = new ValidarCacifo();
            addUserControl(uc);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            AberturaForcada uc = new AberturaForcada();
            addUserControl(uc);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
