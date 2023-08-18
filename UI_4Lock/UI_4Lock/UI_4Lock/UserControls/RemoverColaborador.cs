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
    public partial class RemoverColaborador : UserControl
    {
        public string tabela;
        public RemoverColaborador()
        {
            InitializeComponent();
        }

        private void RemoverColaborador_Load(object sender, EventArgs e)
        {
            //ver se funcionario existe e depois libertar os cacifos de balneario e retirar
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {

            MySqlConnection connectionRemoveColab = new MySqlConnection(GlobalData.Connect());
            connectionRemoveColab.Open();
            //*********************************************  Ver se existe  ***********************************************************************
            MySqlCommand removeColab = new MySqlCommand("delete from balnearios where NMR = '" + richTextBox1.Text + "'", connectionRemoveColab);
            MySqlDataReader executeremoverColab = removeColab.ExecuteReader();
            if (executeremoverColab.Read()) // Check if the reader has rows
            {
                MessageBox.Show("Erro ao apagar funcionario do balneario ", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                executeremoverColab.Close();   
            }
            executeremoverColab.Close();
           
            //LER A POSIÇAO PARA SABER A QUE TABELA IR 
            MySqlCommand zprox = new MySqlCommand("select ZPROX from tag_cargo where NMR = '" + richTextBox1.Text + "'", connectionRemoveColab);
            MySqlDataReader readremoverColabprox = zprox.ExecuteReader();
            if (readremoverColabprox.Read())
            {
              tabela = readremoverColabprox["ZPROX"].ToString();
              readremoverColabprox.Close();
            }

            readremoverColabprox.Close();
            //

            MySqlCommand removeColabcargo = new MySqlCommand("delete from tag_cargo where NMR = '" + richTextBox1.Text + "'", connectionRemoveColab);
            MySqlDataReader executeremoverColabcargo = removeColabcargo.ExecuteReader();
            if (executeremoverColabcargo.Read()) // Check if the reader has rows
            {
                MessageBox.Show("Erro ao apagar funcionario do cargo ", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                executeremoverColabcargo.Close();
            }

            executeremoverColabcargo.Close();


            MySqlCommand removeColabprox = new MySqlCommand("delete from "+ Form1.getTablenameArg(tabela) + " where NMR = '" + richTextBox1.Text + "'", connectionRemoveColab);
           MySqlDataReader executeremoverColabprox = removeColabprox.ExecuteReader();
           if (executeremoverColabprox.Read()) // Check if the reader has rows
           {
               MessageBox.Show("Erro ao apagar funcionario de prox ", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
               executeremoverColabprox.Close();
           }
           executeremoverColabprox.Close();
           connectionRemoveColab.Close();
            MessageBox.Show("Funcionário removido com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
