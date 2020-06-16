using System;
using System.Drawing;
using System.Windows.Forms;

namespace Arka
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
            pictureBox1.BackgroundImage = Image.FromFile("../../../Resources/Player.png");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Top = Height - pictureBox1.Height - 80;
            pictureBox1.Left = Width/2 - pictureBox1.Width/2;
        }
    }
}