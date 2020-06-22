using System;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;


namespace Arkanoid
{
    public partial class Login : UserControl
    {
        private UserControl Current;
        public Login()
        {
            InitializeComponent();
            Height = ClientSize.Height;
            Width = ClientSize.Width;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var backMenu = new Form1();
            backMenu.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GameData.username = txtName.Text;
            label1.Hide();
            txtName.Hide();
            button1.Hide();
            button2.Hide();
            Current = new Game();
            tableLayoutPanel1.Controls.Add(Current);
            tableLayoutPanel1.SetColumnSpan(Current,2);
            tableLayoutPanel1.SetRowSpan(Current,3);
            Current.Dock = DockStyle.Fill;
        }
    }
}