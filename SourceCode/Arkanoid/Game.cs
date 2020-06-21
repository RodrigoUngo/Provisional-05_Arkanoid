using System;
using System.Drawing;
using System.Windows.Forms;

namespace Arkanoid
{
    public partial class Game : UserControl
    {
        public Game()
        {
            InitializeComponent();
        }

        private void Game_Load(object sender, EventArgs e)
        {
            label1.Text = "Vidas:";
            label2.Text = "Puntos:";
            pointsLabel.Text = "0";
            pictureBox1.BackgroundImage = Image.FromFile("../../Recursos/Heart.png");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.BackgroundImage = Image.FromFile("../../Recursos/Heart.png");
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox3.BackgroundImage = Image.FromFile("../../Recursos/Heart.png");
            pictureBox3.BackgroundImageLayout = ImageLayout.Stretch;

            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pointsLabel.Text = Convert.ToString(GameData.points); 
            
            if (GameData.livesleft == 2)
                pictureBox3.Hide();
            else if (GameData.livesleft == 1)
                pictureBox2.Hide();
            else if (GameData.livesleft == 0)
            {
                pictureBox1.Hide();
                GameData.gameover = true;
            }
        }
    }
}