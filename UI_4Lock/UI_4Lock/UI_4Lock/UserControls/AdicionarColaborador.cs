using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static UI_4Lock.GlobalData;
using System.IO.Ports;
using System.Web.UI.WebControls;

namespace UI_4Lock.UserControls
{
    public partial class AdicionarColaborador : UserControl
    {
        private MySqlConnection conexao;
        private string connectionString = "Server=127.0.0.1;Port=3306;Database=project4lock;Uid=Cacifos;Pwd=1234;";
        private SerialPort comPort;

        public AdicionarColaborador()
        {
            InitializeComponent();
            conexao = new MySqlConnection(connectionString); // Inicialize a conexão aqui
            comPort = ComPortManager.GetSerialPort();
            comPort.DataReceived += SerialPort_DataReceived;
        }
        private void AdicionarColaborador_Load(object sender, EventArgs e)
        {
            guna2Button100.Click     += guna2Button100_Click;
            richTextBox5.TextChanged += RichTextBox_TextChanged;
            richTextBox1.TextChanged += RichTextBox_TextChanged;
            richTextBox2.TextChanged += RichTextBox_TextChanged;
            listBox1.TextChanged     += RichTextBox_TextChanged;
        }

        private bool TodosRichTextBoxPreenchidos()
        {
            return !string.IsNullOrEmpty(richTextBox5.Text) &&
                   !string.IsNullOrEmpty(richTextBox1.Text) &&
                   !string.IsNullOrEmpty(richTextBox2.Text) &&
                   !string.IsNullOrEmpty(listBox1.Text);
        }

        private void AtualizarEstadoDoBotao()
        {
            guna2Button100.Enabled = TodosRichTextBoxPreenchidos();
        }

        private void RichTextBox_TextChanged(object sender, EventArgs e)
        {
            AtualizarEstadoDoBotao();
        }

        private void guna2Button100_Click(object sender, EventArgs e)
        {
            if (TodosRichTextBoxPreenchidos())
            {
                try
                {
                    conexao.Open();
                    string textoNumber = richTextBox5.Text;
                    string textoTag = richTextBox1.Text;
                    string textoName = richTextBox2.Text;
                    string textoCargo = listBox1.Text;
                    string query = "INSERT INTO tag_cargo (NMR,TAG,NOME,CARGO,ZPROX) VALUES (@textoNumber,@textoTag,@textoName,@textoCargo,'')";
                    using (MySqlCommand cmd = new MySqlCommand(query, conexao))
                    {
                        cmd.Parameters.AddWithValue("@textoNumber", textoNumber);
                        cmd.Parameters.AddWithValue("@textoTag", textoTag);
                        cmd.Parameters.AddWithValue("@textoName", textoName);
                        cmd.Parameters.AddWithValue("@textoCargo", textoCargo);

                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Texto inserido com sucesso no banco de dados.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao inserir texto: " + ex.Message);
                }
                finally
                {
                    conexao.Close();
                }
            }
            else
            {
                MessageBox.Show("Por favor, preencha todos os campos antes de continuar.", "Campos em falta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string cardNumber = comPort.ReadLine().Trim(); // Lê o número do cartão e remove espaços em branco
            Debug.WriteLine("Dados recebidos: " + cardNumber); // Mensagem de depuração
            UpdateTextBox(cardNumber);
        }

        private void UpdateTextBox(string cardNumber)
        {
            if (richTextBox1.InvokeRequired)
            {
                richTextBox1.Invoke(new Action<string>(UpdateTextBox), new object[] { cardNumber });
            }
            else
            {
                richTextBox1.Text = cardNumber;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
