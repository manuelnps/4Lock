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
    public partial class AbandonarBalneario : UserControl
    {
        public AbandonarBalneario()
        {
            InitializeComponent();
        }

        private void AbandonarBalneario_Load(object sender, EventArgs e)
        {
            
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private int FindNextAvailableNMR()
        {
            MySqlConnection connection = new MySqlConnection(GlobalData.Connect());
            connection.Open();
            MySqlCommand checkBiggerNMR = new MySqlCommand("select MAX(NMR) as maxNMR from balnearios", connection);
            object result = checkBiggerNMR.ExecuteScalar();

            int maxNMR = result == DBNull.Value ? 0 : Convert.ToInt32(result);
            int nextAvailableNMR = maxNMR + 110000;

            while (true)
            {
                MySqlCommand checkDuplicateNMR = new MySqlCommand("select NMR from balnearios where NMR = " + nextAvailableNMR, connection);
                object duplicateResult = checkDuplicateNMR.ExecuteScalar();

                if (duplicateResult == null)
                    break;

                nextAvailableNMR += 1000;
            }

            connection.Close();
            return nextAvailableNMR;
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
                readcheckabandonarcacifo.Close();
                connectiochecknabandonarcacifo.Close();

                //ABANDONAR O CACIFO DO BALNEARIO

                MySqlConnection connectionabandonarcacifo = new MySqlConnection(GlobalData.Connect());
                connectionabandonarcacifo.Open();
                MySqlCommand leaveprox = new MySqlCommand("update balnearios set NMR = '"+ FindNextAvailableNMR() +"' where NMR = '" + richTextBox1.Text + "'", connectionabandonarcacifo);
                int rowsAffected = leaveprox.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    //Query teve sucesso
                    MessageBox.Show("Cacifo abandonado com sucesso", "Cacifo abandonado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Query query não encontrou nenhum funcionário
                    MessageBox.Show("Funcionário não encontrado", "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                connectionabandonarcacifo.Close();


            }
            else
            {
 
                MessageBox.Show("Colaborador não tem balneário atribuído ainda.");
            }
        }
    }
}
