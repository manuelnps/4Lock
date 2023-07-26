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
using static UI_4Lock.GlobalData;
using MindFusion.Charting;
using Org.BouncyCastle.Utilities.Collections;
using MindFusion.Charting.Commands;

namespace UI_4Lock.UserControls
{
    public partial class AbandonarCacifo : UserControl
    {
        public AbandonarCacifo()
        {
            InitializeComponent();
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
           

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            MySqlConnection connectiochecknabandonarcacifo = new MySqlConnection(GlobalData.Connect());
            connectiochecknabandonarcacifo.Open();
            //*********************************************     Procurar onde alterar    *************************************************************************
            
            
            
            
            //*********************************************  condição ja abandonou cacifo  ***********************************************************************
            MySqlCommand checkabandonarcacifo = new MySqlCommand("select POS1 from " + Form1.getTablename() + " where NMR = '" + Form1.getNMR() + "' and POS1 is NULL", connectiochecknabandonarcacifo);
            MySqlDataReader readcheckabandonarcacifo = checkabandonarcacifo.ExecuteReader();
            if (readcheckabandonarcacifo.Read()) // Check if the reader has rows
            {
                MessageBox.Show("Já abandonou um cacifo", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Fazer alguma coisa ???
                readcheckabandonarcacifo.Close();
                connectiochecknabandonarcacifo.Close();

            }
            else
            {
                //*********************************************   Ação de remover o cacifo  **************************************************************************
                MySqlConnection connectionabandonarcacifo = new MySqlConnection(GlobalData.Connect());
                connectionabandonarcacifo.Open();
                MySqlCommand leaveprox = new MySqlCommand("update "+ Form1.getTablename() + " set POS2 = POS1, POS1 = NULL, MANUT = 1 where NMR = '" + Form1.getNMR() + "'", connectionabandonarcacifo);
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
        }

    }
}
