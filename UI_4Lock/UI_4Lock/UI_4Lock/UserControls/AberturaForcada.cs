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
using System.IO.Ports;


namespace UI_4Lock.UserControls
{
    public partial class AberturaForcada : UserControl
    {
        private AberturaForcada aberturaForcada;
        


        public AberturaForcada()
        {
            InitializeComponent();
            Application.ApplicationExit += Application_ApplicationExit;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        bool VerificarCodigoValidacao(string destinatario, int codigoInserido)
        {
            string caminhoDoArquivo = "caminho_do_arquivo.txt";

            if (File.Exists(caminhoDoArquivo))
            {
                string[] linhas = File.ReadAllLines(caminhoDoArquivo);
                foreach (string linha in linhas)
                {
                    string[] partes = linha.Split(':');
                    if (partes.Length == 2)
                    {
                        string arquivoDestinatario = partes[0].Trim();
                        int codigoArmazenado;

                        if (int.TryParse(partes[1].Trim(), out codigoArmazenado))
                        {
                            if (destinatario.Equals(arquivoDestinatario, StringComparison.OrdinalIgnoreCase))
                            {
                                return codigoInserido == codigoArmazenado;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Erro: Conteúdo do arquivo não é um número válido.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Erro: Formato da linha no arquivo incorreto.");
                    }
                }
            }
            return false;
        }

        // Função para obter o código inserido pelo destinatário a partir de uma caixa de texto
        int ObterCodigoInserido(RichTextBox richTextBox)
        {
            int codigoInserido;
            if (int.TryParse(richTextBox.Text, out codigoInserido))
            {
                return codigoInserido;
            }
            // Se a conversão falhar, você pode lidar com isso aqui, como mostrar uma mensagem de erro.
            return -1; // Valor de erro, você pode escolher um valor apropriado.
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string textoRichTextBox5 = richTextBox5.Text.Trim(); // Remove espaços em branco do início e do final
            string textoRichTextBox6 = richTextBox6.Text.Trim(); // Remove espaços em branco do início e do final
            string textoRichTextBox7 = richTextBox7.Text.Trim(); // Remove espaços em branco do início e do final

            if (string.IsNullOrWhiteSpace(textoRichTextBox5) || string.IsNullOrWhiteSpace(textoRichTextBox6) || string.IsNullOrWhiteSpace(textoRichTextBox7))
            {
                MessageBox.Show("Preencha todos os campos referentes às observações, por favor. Caso não tenha nada a assinalar, refira isso.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Suponha que você tenha obtido os códigos inseridos de alguma forma
                int codigoInserido1 = ObterCodigoInserido(richTextBox1); // Para a primeira caixa de texto
                int codigoInserido2 = ObterCodigoInserido(richTextBox2); // Para a segunda caixa de texto
                int codigoInserido3 = ObterCodigoInserido(richTextBox3); // Para a terceira caixa de texto

                if (VerificarCodigoValidacao("bruna.pires-extern@renault.com", codigoInserido1))
                {
                    MessageBox.Show("Código válido para bruna.pires-extern@renault.com. Acesso permitido.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Código inválido para bruna.pires-extern@renault.com. Acesso negado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (VerificarCodigoValidacao("manuel.silva-extern@renault.com", codigoInserido2))
                {
                    MessageBox.Show("Código válido para manuel.silva-extern@renault.com. Acesso permitido.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Código inválido para manuel.silva-extern@renault.com. Acesso negado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (VerificarCodigoValidacao("duarte.jorge-extern@renault.com", codigoInserido3))
                {
                    MessageBox.Show("Código válido para duarte.jorge-extern@renault.com. Acesso permitido.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Código inválido para duarte.jorge-extern@renault.com. Acesso negado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Remetente", "bruna.ramos.pires98@gmail.com"));

                // Adicione todos os destinatários aqui
                message.To.Add(new MailboxAddress("CUET", "bruna.pires-extern@renault.com"));
                message.To.Add(new MailboxAddress("RH", "manuel.silva-extern@renault.com"));
                message.To.Add(new MailboxAddress("CT", "duarte.jorge-extern@renault.com"));

                message.Subject = "Registo de Abertura Forçada de Cacifo";

                string conteudoFinal = "Observações relativas à abertura forçada do cacifo:\n\n";

                // Concatenar o conteúdo das três RichTextBox em uma única string
                string conteudoRichTextBox5 = richTextBox5.Text;
                string conteudoRichTextBox6 = richTextBox6.Text;
                string conteudoRichTextBox7 = richTextBox7.Text;

                conteudoFinal +=       $"CUET: {conteudoRichTextBox5}\n\n" +
                                       $"RH: {conteudoRichTextBox6}\n\n" +
                                       $"CT: {conteudoRichTextBox7}\n\n";

                // Configurar o corpo do e-mail usando o conteúdo concatenado
                var builder = new BodyBuilder();
                builder.TextBody = conteudoFinal;

                // Adicionar o corpo do e-mail ao MimeMessage
                message.Body = builder.ToMessageBody();

                // Configuração do servidor SMTP (no exemplo, o Gmail)
                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                    client.Authenticate("bruna.ramos.pires98@gmail.com", "ertpyvyiyxwauvwx"); // Substitua pelo seu e-mail e senha
                    client.Send(message);
                    client.Disconnect(true);
                }

                MessageBox.Show("E-mail enviado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao enviar o e-mail: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            
        }

        private void AberturaForcada_Load(object sender, EventArgs e)
        {
            guna2Button1.Click += guna2Button1_Click; // Associa o evento de clique ao botão
            guna2Button2.Click += guna2Button2_Click;
            guna2Button3.Click += guna2Button3_Click;
        }

        private void Application_ApplicationExit(object sender, EventArgs e)
        {
            // Limpar o arquivo quando o aplicativo é encerrado
            string caminhoDoArquivo = "caminho_do_arquivo.txt";

            try
            {
                File.WriteAllText(caminhoDoArquivo, string.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao limpar o arquivo: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

            private void label4_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}