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

namespace UI_4Lock.UserControls
{
    public partial class AtribuirBalneario : UserControl
    {
        public AtribuirBalneario()
        {
            InitializeComponent();
        }

        private void AtribuirBalneario_Load(object sender, EventArgs e)
        {
            //ver se ja tem cacido e so depois e que ira atribuir num sitio
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            MySqlConnection connectiochecknabandonarcacifo = new MySqlConnection(GlobalData.Connect());
            connectiochecknabandonarcacifo.Open();

            //*********************************************  Ver se existe  ***********************************************************************
            MySqlCommand checkabandonarcacifo = new MySqlCommand("select POS from balnearios where NMR = '" + richTextBox1.Text + "'", connectiochecknabandonarcacifo);
            MySqlDataReader readcheckabandonarcacifo = checkabandonarcacifo.ExecuteReader();
            if (readcheckabandonarcacifo.Read()) // Check if the reader has rows
            {
                MessageBox.Show("Remover Cacifo primeiro", "Colaborador já tem cacifo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                readcheckabandonarcacifo.Close();
                connectiochecknabandonarcacifo.Close();
            }
            else
            {

            }
        }
    }
}
