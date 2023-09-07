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
using UI_4Lock.UserControls;
using static UI_4Lock.GlobalData;
using System.IO.Ports;

namespace UI_4Lock
{
    
    public partial class Form1 : Form
    {
        public static string NMR;
        public static string ZPROX;
        public static string tablename;

        //private SerialPort serialPort;
        private SerialPort comPort;
        public Form1()
        {
            InitializeComponent();
            //InitializeSerialPort();
            comPort = ComPortManager.GetSerialPort();
            comPort.DataReceived += SerialPort_DataReceived;
        }

        //private void InitializeSerialPort()
        //{
        //    serialPort = new SerialPort("COM5", 9600); // Substitua pela porta COM correta e pela taxa de transmissão

        //    try
        //    {
        //        serialPort.Open();
        //        serialPort.DataReceived += SerialPort_DataReceived;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Erro ao abrir a porta serial: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //string cardNumber = serialPort.ReadLine().Trim(); // Lê o número do cartão e remove espaços em branco
            //UpdateTextBox(cardNumber);
            string cardNumber = comPort.ReadLine().Trim();
            UpdateTextBox(cardNumber);
        }

        private void UpdateTextBox(string cardNumber)
        {
            if (textBox1.InvokeRequired)
            {
                textBox1.Invoke(new Action<string>(UpdateTextBox), new object[] { cardNumber });
            }
            else
            {
                textBox1.Text = cardNumber;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public static string getNMR()
        {
            return NMR;
        }

        public static string getZPROX()
        {

            MySqlConnection connectionGetZPROX = new MySqlConnection(GlobalData.Connect());
            connectionGetZPROX.Open();
            MySqlCommand querygetZPROX = new MySqlCommand("select ZPROX from tag_cargo where NMR = '" + getNMR() + "'", connectionGetZPROX);
            MySqlDataReader readerZPROX = querygetZPROX.ExecuteReader();
            if (readerZPROX.Read())
            {
                ZPROX = readerZPROX["ZPROX"].ToString();
                readerZPROX.Close();
                connectionGetZPROX.Close();
            }
            else
            {
                MessageBox.Show("Zona de Proximidade não foi encontrada", "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            return ZPROX;
        }

        public static string getTablenameArg(string name)
        {
            return "prox_" + name;
        }
        public static string getTablename()
        {
            return "prox_" + getZPROX();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(GlobalData.Connect());
            connection.Open();
            string tagValue = textBox1.Text; // Assumindo que o valor lido da tag está na textBox1
            MySqlCommand login = new MySqlCommand("select CARGO from tag_cargo where TAG = @tag", connection);
            login.Parameters.AddWithValue("@tag", tagValue);
            MySqlDataReader reader = login.ExecuteReader();


            if (reader.Read()) // Check if the reader has rows
            {
                string cargo = reader["CARGO"].ToString(); // Get the cargo value from the reader
                if (string.Equals(cargo, "COLAB", StringComparison.OrdinalIgnoreCase))
                {
                    reader.Close();
                    MySqlCommand getNMR = new MySqlCommand("select NMR, ZPROX from tag_cargo where TAG = " + "@tag" + "", connection);
                    getNMR.Parameters.AddWithValue("@tag", tagValue);
                    MySqlDataReader readNMR = getNMR.ExecuteReader();
                    //arranjar a string
                    if (readNMR.Read())
                    {
                        NMR = readNMR["NMR"].ToString();
                        //ZPROX = readNMR["ZPROX"].ToString();
                        readNMR.Close();
                        connection.Close();
                    }

                    new mainmenu().Show();
                    this.Hide();                  
                }
                else if(string.Equals(cargo, "CUET", StringComparison.OrdinalIgnoreCase))
                {
                    reader.Close();
                    MySqlCommand getNMR = new MySqlCommand("select NMR, ZPROX from tag_cargo where TAG = " + "@tag" + "", connection);
                    getNMR.Parameters.AddWithValue("@tag", tagValue);
                    MySqlDataReader readNMR = getNMR.ExecuteReader();
                    //arranjar a string
                    if (readNMR.Read())
                    {
                        NMR = readNMR["NMR"].ToString();
                        //ZPROX = readNMR["ZPROX"].ToString();
                        readNMR.Close();
                        connection.Close();
                    }

                    new mainmenuCUET().Show();
                    this.Hide();
                }
                else if (string.Equals(cargo,"RH", StringComparison.OrdinalIgnoreCase))
                {
                    reader.Close();
                    connection.Close();
                    new mainmenuRH().Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Por favor fale com os Recursos Humanos","Cartão não encontrado",MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Clear();
                textBox1.Focus();
                reader.Close();
                connection.Close();
            }
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Feche a porta COM quando o formulário estiver prestes a ser fechado
            ComPortManager.CloseSerialPort();
        }
    }
}
