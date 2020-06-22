using System;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;


namespace Arkanoid
{
    public partial class Login : UserControl
    {
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
            var newGame = new Game(textBox1.Text);
            newGame.Show();
        }

        
    }
}