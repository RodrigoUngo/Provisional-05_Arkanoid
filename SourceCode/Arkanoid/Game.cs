using System;
using System.Drawing;
using System.Windows.Forms;

namespace Arkanoid
{
    public partial class Game : UserControl
    {
        private UserControl Current = null;
        private UserControl play1 = new Play();
        public Game()
        {
            InitializeComponent();
        }

        //Cargar objetos
        private void Game_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            //Cargar contadores
            GameData.livesleft = 3;
            GameData.points = 0;
            GameData.gamestarted = false;
            GameData.gamewon = false;
            label1.Text = "Vidas:";
            label2.Text = "Puntos:";
            pointsLabel.Text = "0";
            pictureBox1.BackgroundImage = Image.FromFile("../../Recursos/Heart.png");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.BackgroundImage = Image.FromFile("../../Recursos/Heart.png");
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox3.BackgroundImage = Image.FromFile("../../Recursos/Heart.png");
            pictureBox3.BackgroundImageLayout = ImageLayout.Stretch;

            //Cargar jugabilidad
            tableLayoutPanel1.Controls.Add(play1,0,1);
            tableLayoutPanel1.SetColumnSpan(play1,6);
            
            timer1.Start();
        }

        //Comprobante de vidas y puntaje
        private void timer1_Tick(object sender, EventArgs e)
        {
            pointsLabel.Text = Convert.ToString(GameData.points); 
            
            if (GameData.livesleft == 2)
                pictureBox3.Hide();
            else if (GameData.livesleft == 1)
                pictureBox2.Hide();
            //Juego Perdido
            else if (GameData.livesleft == 0)
            {
                pictureBox1.Hide();
                play1.Hide();
                label1.Hide();
                label2.Hide();
                pointsLabel.Hide();
                Current = new MainMenu();
                tableLayoutPanel1.Controls.Add(Current,0,0);
                tableLayoutPanel1.SetColumnSpan(Current,6);
                tableLayoutPanel1.SetRowSpan(Current,2);
                Current.Dock = DockStyle.Fill;
                
                timer1.Stop();
            }
            
            //Juego Ganado
            if (GameData.gamewon)
            {
                pictureBox3.Hide();
                pictureBox2.Hide();
                pictureBox1.Hide();
                play1.Hide();
                label1.Hide();
                label2.Hide();
                pointsLabel.Hide();
                Current = new MainMenu();
                tableLayoutPanel1.Controls.Add(Current,0,0);
                tableLayoutPanel1.SetColumnSpan(Current,6);
                tableLayoutPanel1.SetRowSpan(Current,2);
                Current.Dock = DockStyle.Fill;
                
                timer1.Stop();
            }
        }
    }
}