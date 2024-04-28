using System;
using System.Windows.Forms;

namespace Tic_Tac_Toe_Game
{
    public partial class frmGameSettings : Form
    {
        public frmGameSettings()
        {
            InitializeComponent();
        }

        private void btnWithFriend_Click(object sender, EventArgs e)
        {
            frmMain frmMain = new frmMain(1);
            this.Hide();
            frmMain.ShowDialog();
            this.Visible = true;
        }

        private void btnWithComputer_Click(object sender, EventArgs e)
        {
            frmMain frmMain = new frmMain(0);
            this.Hide();
            frmMain.ShowDialog();
            this.Visible = true;

        }
    }
}
