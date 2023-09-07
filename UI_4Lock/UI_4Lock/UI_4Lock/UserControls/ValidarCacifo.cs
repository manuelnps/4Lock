using System;
using System.Net;
//using System.Net.Mail;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using System.IO;

//falar com o tiago porque a parte de validaçao diz que esta a inserir duplicado ?

namespace UI_4Lock.UserControls
{
    public partial class ValidarCacifo : UserControl
    {
        public static int i = 0;
        public static int biggerNMR;


        public ValidarCacifo()
        {
            InitializeComponent();
        }

        private void ValidarCacifo_Load(object sender, EventArgs e)
        {
            guna2Button2.Text = "Enviar E-mail"; // Texto do botão
            guna2Button2.Click += guna2Button2_Click; // Associa o evento de clique ao botão
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            //fazer comando MySQL para adicionar tudo numa lista
            MySqlConnection connection = new MySqlConnection(GlobalData.Connect());
            connection.Open();
            MySqlCommand login = new MySqlCommand("select POS2 from " +Form1.getTablename() + " where NMR < 100000 and MANUT = 1 and POS1 = 9999 and POS2 != 9999", connection);
            MySqlDataReader reader = login.ExecuteReader();
            string[] Positions = new string[1000];
            while (reader.Read())
            {
                Positions[i] = reader["POS2"].ToString();
                checkedListBox1.Items.Add(Positions[i]);    
                i++;
            }
        }

        private int FindNextAvailableNMR()
        {
            MySqlConnection connection = new MySqlConnection(GlobalData.Connect());
            connection.Open();
            MySqlCommand checkBiggerNMR = new MySqlCommand("select MAX(NMR) as maxNMR from " + Form1.getTablename(), connection);
            object result = checkBiggerNMR.ExecuteScalar();

            int maxNMR = result == DBNull.Value ? 0 : Convert.ToInt32(result);
            int nextAvailableNMR = maxNMR + 1000;

            while (true)
            {
                MySqlCommand checkDuplicateNMR = new MySqlCommand("select NMR from " + Form1.getTablename() + " where NMR = " + nextAvailableNMR, connection);
                object duplicateResult = checkDuplicateNMR.ExecuteScalar();

                if (duplicateResult == null)
                    break;

                nextAvailableNMR += 1000;
            }

            connection.Close();
            return nextAvailableNMR;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            foreach(object item in checkedListBox1.CheckedItems)
            {
                string ItemValue = item.ToString();
                biggerNMR = FindNextAvailableNMR();
                /*
                MySqlConnection ConnectioncheckBiggerNMR = new MySqlConnection(GlobalData.Connect());
                ConnectioncheckBiggerNMR.Open();
                MySqlCommand CheckBiggerNmr = new MySqlCommand("select MAX(NMR) as maxNMR from " + Form1.getTablename(), ConnectioncheckBiggerNMR);
                MySqlDataReader readBiggerNMR = CheckBiggerNmr.ExecuteReader();
                if (readBiggerNMR.Read())
                {
                   string prov = readBiggerNMR["maxNMR"].ToString();
                    MessageBox.Show(prov);
                   //biggerNMR = int.Parse(prov) + 1000;

                    readBiggerNMR.Close();
                }
                

                ConnectioncheckBiggerNMR.Close(); 
                */
                MySqlConnection connection = new MySqlConnection(GlobalData.Connect());
                connection.Open();
                MySqlCommand validar = new MySqlCommand("update " + Form1.getTablename() + " set NMR = '" + biggerNMR + "', POS1 = POS2, POS2 = 9999, MANUT = 0 where NMR < 100000 and MANUT = 1 and POS1 = 9999 and POS2 != 9999", connection);
                int rowsAffected = validar.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    //Query teve sucesso
                    MessageBox.Show("Cacifos Validados com sucesso", "Cacifo validado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Query query não encontrou nenhum funcionário
                    MessageBox.Show("Ocorreu um erro", "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                connection.Close();
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            // Informações do remetente
            string remetenteEmail = "bruna.ramos.pires98@gmail.com";
            string remetenteSenha = "ertpyvyiyxwauvwx";

            // Lista de destinatários
            List<string> destinatarios = new List<string>
{
                "bruna.pires-extern@renault.com",   //Enviar e-mail para o CUET
                "manuel.silva-extern@renault.com",  //Enviar e-mail para os RH
                "duarte.jorge-extern@renault.com"   //Enviar e-mail para a CT                             
};

            // Configuração do servidor SMTP
            string smtpHost = "smtp.gmail.com";
            int smtpPort = 587;

            try
            {
                foreach (var destinatario in destinatarios)
                {
                    var message = new MimeMessage();
                    message.From.Add(new MailboxAddress("Remetente", remetenteEmail));
                    message.To.Add(new MailboxAddress("", destinatario));
                    message.Subject = "Aviso de Abertura de Cacifo Forçada";

                    // Verifica se algum item foi marcado no CheckedListBox
                    List<int> numerosSelecionados = new List<int>();
                    foreach (int index in checkedListBox1.CheckedIndices)
                    {
                        numerosSelecionados.Add(Convert.ToInt32(checkedListBox1.Items[index]));
                    }

                    if (numerosSelecionados.Count > 0)
                    {
                        // Gera um código de validação aleatório para cada destinatário
                        int codigo = CodigoGerado.GerarCodigo(); // Certifique-se de que esta função existe e gera um código aleatório

                        var builder = new BodyBuilder();
                        builder.TextBody = $"Notificação para abertura de cacifo forçada. De forma a validar esta abertura, referente ao(s) cacifo(s) - {string.Join(", ", numerosSelecionados)} - segue-se abaixo o código de validação.\n\nCódigo de validação: {codigo}";
                        message.Body = builder.ToMessageBody();

                        using (var client = new SmtpClient())
                        {
                            client.Connect(smtpHost, smtpPort, SecureSocketOptions.StartTls);
                            client.Authenticate(remetenteEmail, remetenteSenha);
                            client.Send(message);
                            client.Disconnect(true);
                        }

                        MessageBox.Show($"E-mail enviado com sucesso para {destinatario}!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Após enviar o e-mail com sucesso, armazene o código gerado e o destinatário no arquivo
                        using (StreamWriter writer = new StreamWriter("caminho_do_arquivo.txt", true))
                        {
                            writer.WriteLine($"{destinatario}:{codigo}");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Por favor, selecione pelo menos um número na lista.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao enviar os e-mails: " + ex.Message);
            }
        }
    }
}
