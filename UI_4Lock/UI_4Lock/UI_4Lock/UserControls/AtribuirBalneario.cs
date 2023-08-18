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
                MessageBox.Show("Remover Balneario primeiro", "Colaborador já tem Balneário atribuído", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                                                                                                                
                readcheckabandonarcacifo.Close();
                connectiochecknabandonarcacifo.Close();
            }
            else
            {
                MySqlConnection connectionchangeBalneary = new MySqlConnection(GlobalData.Connect());
                connectionchangeBalneary.Open();

                //MySqlCommand changeBalneary = new MySqlCommand("update balnearios set NMR = '" + richTextBox1.Text + "' where NMR >= 100000 and ZONA = A LIMIT 1", connectionchangeBalneary);
                MySqlCommand changeBalneary = new MySqlCommand("update balnearios set NMR = '" + richTextBox1.Text + "' where NMR >= 100000 and ZONA = 'A' LIMIT 1", connectionchangeBalneary);

                int BalnearyAffected = changeBalneary.ExecuteNonQuery();
                if (BalnearyAffected > 0)
                {
                    MessageBox.Show("Balneário alterado com sucesso", "Balneário Escolhido com sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("ERRO", "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            MySqlConnection connectiochecknabandonarcacifo = new MySqlConnection(GlobalData.Connect());
            connectiochecknabandonarcacifo.Open();

            //*********************************************  Ver se existe  ***********************************************************************
            MySqlCommand checkabandonarcacifo = new MySqlCommand("select POS from balnearios where NMR = '" + richTextBox1.Text + "'", connectiochecknabandonarcacifo);
            MySqlDataReader readcheckabandonarcacifo = checkabandonarcacifo.ExecuteReader();
            if (readcheckabandonarcacifo.Read()) // Check if the reader has rows
            {
                MessageBox.Show("Remover Balneario primeiro", "Colaborador já tem Balneário atribuído", MessageBoxButtons.OK, MessageBoxIcon.Information);

                readcheckabandonarcacifo.Close();
                connectiochecknabandonarcacifo.Close();
            }
            else
            {
                MySqlConnection connectionchangeBalneary = new MySqlConnection(GlobalData.Connect());
                connectionchangeBalneary.Open();

                //MySqlCommand changeBalneary = new MySqlCommand("update balnearios set NMR = '" + richTextBox1.Text + "' where NMR >= 100000 and ZONA = A LIMIT 1", connectionchangeBalneary);
                MySqlCommand changeBalneary = new MySqlCommand("update balnearios set NMR = '" + richTextBox1.Text + "' where NMR >= 100000 and ZONA = 'B' LIMIT 1", connectionchangeBalneary);

                int BalnearyAffected = changeBalneary.ExecuteNonQuery();
                if (BalnearyAffected > 0)
                {
                    MessageBox.Show("Balneário alterado com sucesso", "Balneário Escolhido com sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("ERRO", "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }
    }
}
