using System;
using System.Drawing;
using System.Windows.Forms;

namespace Arkanoid
{
    public partial class Play : UserControl
    {
        public Play()
        {
            InitializeComponent();
            Height = ClientSize.Height;
            Width = ClientSize.Width;
        }

        private void Play_Load(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Image.FromFile("../../Resources/Player.png");
        }
    }
}