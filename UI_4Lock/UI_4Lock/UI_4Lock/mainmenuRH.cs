using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI_4Lock.UserControls;

namespace UI_4Lock
{
    public partial class mainmenuRH : Form
    {
        public mainmenuRH()
        {
            InitializeComponent();
        }

        public void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panelContainerRH.Controls.Clear();
            panelContainerRH.Controls.Add(userControl);
            userControl.BringToFront();
        }
        private void mainmenuRH_Load(object sender, EventArgs e)
        {

        }

        private void panelContainerRH_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            AbandonarBalneario uc = new AbandonarBalneario();
            addUserControl(uc);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            RemoverColaborador uc = new RemoverColaborador();
            addUserControl(uc);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            AtribuirBalneario uc = new AtribuirBalneario(); 
            addUserControl(uc); 
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
