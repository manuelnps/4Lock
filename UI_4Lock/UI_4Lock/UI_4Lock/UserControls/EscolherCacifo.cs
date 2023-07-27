using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI_4Lock.UserControls;
using System.Windows.Forms;

namespace UI_4Lock.UserControls
{
    public partial class EscolherCacifo : UserControl
    {

        public EscolherCacifo()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {

            MySqlConnection connectionhCheckEscolherCacifoM = new MySqlConnection(GlobalData.Connect());
            connectionhCheckEscolherCacifoM.Open();

            //*********************************************  condição ja abandonou cacifo  *************************************************************************************************************************
            //******************************************************************************************************************************************************************************************************
            MySqlCommand CheckEscolherCacifoM = new MySqlCommand("select POS1 from " + Form1.getTablename() + " where NMR = '" + Form1.getNMR() + "' and POS1 != 9999 and POS2 = 9999", connectionhCheckEscolherCacifoM);
            MySqlDataReader readcheckabandonarcacifoM = CheckEscolherCacifoM.ExecuteReader();
            if (readcheckabandonarcacifoM.Read()) // Check if the reader has rows
            {
                MessageBox.Show("Já tem um Cacifo atribuído, Abandone primeiro.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                readcheckabandonarcacifoM.Close();
                connectionhCheckEscolherCacifoM.Close();

            }
            else {

                /*ALTERAR TABELA DOS CARGOS COM POSIÇAO PROX*/
                MySqlConnection connectionMudarParaZonaM = new MySqlConnection(GlobalData.Connect());
                connectionMudarParaZonaM.Open();

                MySqlCommand MudarParaZonaM = new MySqlCommand("update tag_cargo set ZPROX = 'm' where NMR = '" + Form1.getNMR() + "'", connectionMudarParaZonaM);
                int rowsAffected = MudarParaZonaM.ExecuteNonQuery();
                
                if (rowsAffected > 0)
                {
                    connectionMudarParaZonaM.Close();
                    MySqlConnection connectionEscolherCacifoZonaM = new MySqlConnection(GlobalData.Connect());
                    connectionEscolherCacifoZonaM.Open();
                    MySqlCommand EscolherCacifoZonaM = new MySqlCommand("update " + Form1.getTablename() +" set NMR = '"+ int.Parse(Form1.getNMR()) + "' where NMR >= 100000  and POS1 != 9999 and POS2 = 9999 and MANUT = 0 LIMIT 1", connectionEscolherCacifoZonaM);
                    int rowsAffectedM = EscolherCacifoZonaM.ExecuteNonQuery();
                    
                    if( rowsAffectedM > 0)
                    {
                        MessageBox.Show("O seu cacifo é", "Cacifo Escolhido com sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("ERRO", "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                    //string updateQuery = $"UPDATE {tableName} SET TAG = @YourTagValue WHERE POS1 != 9999 AND POS2 = 9999 AND MANUT = 0 LIMIT 1";


                }
                else
                {
                    connectionMudarParaZonaM.Close();
                    // Query query não encontrou nenhum funcionário
                    MessageBox.Show("O cacifo nãO foi encontrada a sua zona atual", "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                /*Alterar o Cacifo*/
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

            MySqlConnection connectionhCheckEscolherCacifov = new MySqlConnection(GlobalData.Connect());
            connectionhCheckEscolherCacifov.Open();

            //*********************************************  condição ja abandonou cacifo  *************************************************************************************************************************
            //******************************************************************************************************************************************************************************************************
            MySqlCommand CheckEscolherCacifov = new MySqlCommand("select POS1 from " + Form1.getTablename() + " where NMR = '" + Form1.getNMR() + "' and POS1 != 9999 and POS2 = 9999", connectionhCheckEscolherCacifov);
            MySqlDataReader readcheckabandonarcacifov = CheckEscolherCacifov.ExecuteReader();
            if (readcheckabandonarcacifov.Read()) // Check if the reader has rows
            {
                MessageBox.Show("Já tem um Cacifo atribuído, Abandone primeiro.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                readcheckabandonarcacifov.Close();
                connectionhCheckEscolherCacifov.Close();

            }
            else
            {

                /*ALTERAR TABELA DOS CARGOS COM POSIÇAO PROX*/
                MySqlConnection connectionMudarParaZonav = new MySqlConnection(GlobalData.Connect());
                connectionMudarParaZonav.Open();

                MySqlCommand MudarParaZonav = new MySqlCommand("update tag_cargo set ZPROX = 'v' where NMR = '" + Form1.getNMR() + "'", connectionMudarParaZonav);
                int rowsAffected = MudarParaZonav.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    connectionMudarParaZonav.Close();
                    MySqlConnection connectionEscolherCacifoZonav = new MySqlConnection(GlobalData.Connect());
                    connectionEscolherCacifoZonav.Open();
                    MySqlCommand EscolherCacifoZonav = new MySqlCommand("update " + Form1.getTablename() + " set NMR = '" + int.Parse(Form1.getNMR()) + "' where NMR >= 100000  and POS1 != 9999 and POS2 = 9999 and MANUT = 0 LIMIT 1", connectionEscolherCacifoZonav);
                    int rowsAffectedv = EscolherCacifoZonav.ExecuteNonQuery();

                    if (rowsAffectedv > 0)
                    {
                        MessageBox.Show("O seu cacifo é", "Cacifo Escolhido com sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("ERRO", "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                    //string updateQuery = $"UPDATE {tableName} SET TAG = @YourTagValue WHERE POS1 != 9999 AND POS2 = 9999 AND MANUT = 0 LIMIT 1";


                }
                else
                {
                    connectionMudarParaZonav.Close();
                    // Query query não encontrou nenhum funcionário
                    MessageBox.Show("O cacifo nãO foi encontrada a sua zona atual", "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                /*Alterar o Cacifo*/
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            /*
            MySqlConnection connectionhCheckEscolherCacifoP = new MySqlConnection(GlobalData.Connect());
            connectionhCheckEscolherCacifoP.Open();

            //*********************************************  condição ja abandonou cacifo  *************************************************************************************************************************
            //******************************************************************************************************************************************************************************************************
            MySqlCommand CheckEscolherCacifoP = new MySqlCommand("select POS1 from " + Form1.getTablename() + " where NMR = '" + Form1.getNMR() + "' and POS1 != 9999 and POS2 = 9999", connectionhCheckEscolherCacifoP);
            MySqlDataReader readcheckabandonarcacifoP = CheckEscolherCacifoP.ExecuteReader();
            if (readcheckabandonarcacifoP.Read()) // Check if the reader has rows
            {
                MessageBox.Show("Já tem um Cacifo atribuído, Abandone primeiro.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                readcheckabandonarcacifoP.Close();
                connectionhCheckEscolherCacifoP.Close();

            }
            else
            {

                //ALTERAR TABELA DOS CARGOS COM POSIÇAO PROX
                MySqlConnection connectionMudarParaZonaP = new MySqlConnection(GlobalData.Connect());
                connectionMudarParaZonaP.Open();

                MySqlCommand MudarParaZonaP = new MySqlCommand("update tag_cargo set ZPROX = 'p' where NMR = '" + Form1.getNMR() + "'", connectionMudarParaZonaP);
                int rowsAffected = MudarParaZonaP.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    connectionMudarParaZonaP.Close();
                    MySqlConnection connectionEscolherCacifoZonaP = new MySqlConnection(GlobalData.Connect());
                    connectionEscolherCacifoZonaP.Open();
                    MySqlCommand EscolherCacifoZonaP = new MySqlCommand("update " + Form1.getTablename() + " set NMR = '" + int.Parse(Form1.getNMR()) + "' where NMR >= 100000  and POS1 != 9999 and POS2 = 9999 and MANUT = 0 LIMIT 1", connectionEscolherCacifoZonaP);
                    int rowsAffectedP = EscolherCacifoZonaP.ExecuteNonQuery();

                    if (rowsAffectedP > 0)
                    {
                        MessageBox.Show("O seu cacifo é", "Cacifo Escolhido com sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("ERRO", "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                    //string updateQuery = $"UPDATE {tableName} SET TAG = @YourTagValue WHERE POS1 != 9999 AND POS2 = 9999 AND MANUT = 0 LIMIT 1";


                }
                else
                {
                    connectionMudarParaZonaP.Close();
                    // Query query não encontrou nenhum funcionário
                    MessageBox.Show("O cacifo nãO foi encontrada a sua zona atual", "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //Alterar o Cacifo
            }
                    */
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            /*
            MySqlConnection connectionhCheckEscolherCacifo = new MySqlConnection(GlobalData.Connect());
            connectionhCheckEscolherCacifo.Open();

            //*********************************************  condição ja abandonou cacifo  *************************************************************************************************************************
            //******************************************************************************************************************************************************************************************************
            MySqlCommand CheckEscolherCacifo = new MySqlCommand("select POS1 from " + Form1.getTablename() + " where NMR = '" + Form1.getNMR() + "' and POS1 != 9999 and POS2 = 9999", connectionhCheckEscolherCacifo);
            MySqlDataReader readcheckabandonarcacifo = CheckEscolherCacifo.ExecuteReader();
            if (readcheckabandonarcacifo.Read()) // Check if the reader has rows
            {
                MessageBox.Show("Já tem um Cacifo atribuído, Abandone primeiro.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                readcheckabandonarcacifo.Close();
                connectionhCheckEscolherCacifo.Close();

            }
            else
            {

                //ALTERAR TABELA DOS CARGOS COM POSIÇAO PROX
                MySqlConnection connectionMudarParaZonaQ = new MySqlConnection(GlobalData.Connect());
                connectionMudarParaZonaQ.Open();

                MySqlCommand MudarParaZonaQ = new MySqlCommand("update tag_cargo set ZPROX = 'm' where NMR = '" + Form1.getNMR() + "'", connectionMudarParaZonaQ);
                int rowsAffected = MudarParaZonaQ.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    connectionMudarParaZonaQ.Close();
                    MySqlConnection connectionEscolherCacifoZonaQ = new MySqlConnection(GlobalData.Connect());
                    connectionEscolherCacifoZonaQ.Open();
                    MySqlCommand EscolherCacifoZonaQ = new MySqlCommand("update " + Form1.getTablename() + " set NMR = '" + int.Parse(Form1.getNMR()) + "' where NMR >= 100000  and POS1 != 9999 and POS2 = 9999 and MANUT = 0 LIMIT 1", connectionEscolherCacifoZonaQ);
                    int rowsAffectedQ = EscolherCacifoZonaQ.ExecuteNonQuery();

                    if (rowsAffectedQ > 0)
                    {
                        MessageBox.Show("O seu cacifo é", "Cacifo Escolhido com sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("ERRO", "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                    //string updateQuery = $"UPDATE {tableName} SET TAG = @YourTagValue WHERE POS1 != 9999 AND POS2 = 9999 AND MANUT = 0 LIMIT 1";


                }
                else
                {
                    connectionMudarParaZonaQ.Close();
                    // Query query não encontrou nenhum funcionário
                    MessageBox.Show("O cacifo nãO foi encontrada a sua zona atual", "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //Alterar o Cacifo
            }
            */
        }
            
    }
}
