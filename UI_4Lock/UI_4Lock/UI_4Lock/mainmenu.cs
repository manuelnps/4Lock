//using CacifoAtribuida;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;
using FireSharp;
using Newtonsoft.Json;
using UI_4Lock.UserControls;


namespace UI_4Lock
{
    public partial class mainmenu : Form
    {
        CacifoAtribuido uc = null;
        public mainmenu()
        {
            InitializeComponent();
        }
        
        
        IFirebaseConfig ifc = new FirebaseConfig()
        {
            AuthSecret = "Dn3ed7cubq8f1x9ycDH28gtWg0AL0Xxpcit8BonH",
            BasePath = "https://testcacifos-default-rtdb.firebaseio.com/",
        };
    


        IFirebaseClient client;
        private void addUserControl(UserControl userControl)
        {
           userControl.Dock = DockStyle.Fill;
           panelContainer.Controls.Clear();
           panelContainer.Controls.Add(userControl); 
           userControl.BringToFront();
        }

        
        private void mainmenu_Load(object sender, EventArgs e)
        {
            try
            {
                client = new FirebaseClient(ifc);
            }
            catch
            {
                MessageBox.Show("there was a problem in your internet");
            }
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            AbandonarCacifo uc = new AbandonarCacifo();
            addUserControl(uc);
        }

        private void panelContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            this.uc = new CacifoAtribuido();
            addUserControl(uc);
            LiveCall();      
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            EscolherCacifo uc = new EscolherCacifo();
            addUserControl(uc);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        async void LiveCall()
        {
            while (true)
            {
                await Task.Delay(1000);
                FirebaseResponse res = await client.GetAsync(@"TheUsers/12");
                Dictionary<string, string> data = JsonConvert.DeserializeObject<Dictionary<string, string>>(res.Body.ToString());
                updateRTB(data);
            }
        }
        

        
        void updateRTB(Dictionary<string, string> record)
        {
            //parte de limpar
            string info1 = record.ElementAt(0).Key + ": " + record.ElementAt(0).Value;
            uc.setBoxText(info1);
            
            /*
            string info1 = record.ElementAt(0).Key + ": " + record.ElementAt(0).Value;
            string info2 = record.ElementAt(1).Key + ": " + record.ElementAt(1).Value;
            string info3 = record.ElementAt(2).Key + ": " + record.ElementAt(2).Value;

            string finalText = info1 + Environment.NewLine + info2 + Environment.NewLine + info3 + Environment.NewLine;
            uc.setBoxText(finalText);
            */
        }
  
    }
}
