using System;
using System.Windows.Forms;

namespace Arkanoid
{
    public partial class MainMenu : UserControl
    {
        private UserControl Current = null;
        public MainMenu()
        {
            InitializeComponent();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            ptbLogo.Show();
            btnSignIn.Show();
            btnTop10.Show();
            btnExit.Show();
        }
        
        private void btnSignIn_Click(object sender, EventArgs e)
        {
            ptbLogo.Hide();
            btnSignIn.Hide();
            btnTop10.Hide();
            btnExit.Hide();
            Current = new Login();
            tableLayoutPanel1.Controls.Add(Current, 0, 0);
            tableLayoutPanel1.SetColumnSpan(Current,1);
            tableLayoutPanel1.SetRowSpan(Current,4);
            Current.Dock = DockStyle.Fill;
        }
        private void btnTop10_Click(object sender, EventArgs e)
        {
            ptbLogo.Hide();
            btnSignIn.Hide();
            btnTop10.Hide();
            btnExit.Hide();
            Current = new Top10();
            tableLayoutPanel1.Controls.Add(Current, 0, 0);
            tableLayoutPanel1.SetColumnSpan(Current,1);
            tableLayoutPanel1.SetRowSpan(Current,4);
            Current.Dock = DockStyle.Fill;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Gracias por jugar!");
            Application.Exit();
        }
    }
}