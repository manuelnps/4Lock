using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;
using FireSharp;
using Newtonsoft.Json;
using System.Windows.Forms;

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

            IFirebaseConfig firebaseConfig = new FirebaseConfig()
            {
                AuthSecret = "Dn3ed7cubq8f1x9ycDH28gtWg0AL0Xxpcit8BonH",
                BasePath = "https://testcacifos-default-rtdb.firebaseio.com/",
            };

            IFirebaseClient firebaseClient = new FireSharp.FirebaseClient(firebaseConfig);

            SetResponse response = firebaseClient.Set(@"TheUsers/12/Manut", "true");

        }

        private void AbandonarCacifo_Load(object sender, EventArgs e)
        {
            /*
            try
            {
                client = new FirebaseClient(ifc);
            }
            catch
            {
                MessageBox.Show("there was a problem in your internet");
            }
            */
        }
    }
}
