using System;
using System.Drawing;
using System.Windows.Forms;

namespace Arkanoid
{
    public partial class Play : UserControl
    {
        private CustomPictureBox[,] cpb;
        private PictureBox ball;
        public Play()
        {
            InitializeComponent();
        }

        private void Play_Load(object sender, EventArgs e)
        {
            //Cargar jugador
            pictureBox1.BackgroundImage = Image.FromFile("../../Recursos/Player.png");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Top = Height - pictureBox1.Height;
            pictureBox1.Left = Width / 2 - pictureBox1.Width / 2;

            ball = new PictureBox();
            ball.Width = ball.Height = 40;
            ball.BackgroundImage = Image.FromFile("../../Recursos/Ball.png");
            ball.Top = Height - pictureBox1.Height - ball.Height;
            ball.Left = Width / 2 - ball.Width / 2;
            ball.BackgroundImageLayout = ImageLayout.Stretch;
            Controls.Add(ball);
            
            LoadTiles();
            
            timer1.Start();
        }
        
        //Cargar bloques
        private void LoadTiles()
        {
            int xAxis = 10, yAxis = 7;

            //Altura y anchura de los bloques
            int cpbheight = (int)(Height * 0.5) / yAxis;
            int cpbwidth = Width / xAxis;
            
            cpb = new CustomPictureBox[yAxis, xAxis];

            for (int i = 0; i < yAxis; i++)
            {
                for(int j = 0; j < xAxis ; j++)
                {
                    //Cantidad de golpes necesarios
                    cpb[i,j] = new CustomPictureBox();
                    if (i == 0)
                        cpb[i, j].Hits = 3;
                    else if (i == 1)
                        cpb[i, j].Hits = 2;
                    else
                        cpb[i, j].Hits = 1;

                    //Altura y anchura
                    cpb[i, j].Height = cpbheight;
                    cpb[i, j].Width = cpbwidth;

                    //Posiciones
                    cpb[i, j].Top = i * cpbheight;
                    cpb[i, j].Left = j * cpbwidth;
                    
                    //Cargar imagen
                    cpb[i,j].BackgroundImage = Image.FromFile($"../../Recursos/{i+1}.png");
                    cpb[i, j].BackgroundImageLayout = ImageLayout.Stretch;

                    cpb[i, j].Tag = "tileTag";
                    Controls.Add(cpb[i, j]);
                }
            }
        }

        private void Play_MouseMove(object sender, MouseEventArgs e)
        {
            if (!GameData.gamestarted)
            {
                if (e.X < Width - (pictureBox1.Width/2) && e.X > (pictureBox1.Width/2))
                {
                    pictureBox1.Left = e.X - (pictureBox1.Width/2);
                    ball.Left = pictureBox1.Left + pictureBox1.Width / 2 - ball.Width / 2;
                }
                
            }
            else
            {
                if (e.X < Width - (pictureBox1.Width/2) && e.X > (pictureBox1.Width/2))
                {
                    pictureBox1.Left = e.X - (pictureBox1.Width/2);
                }
            }
        }

        private void Play_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                GameData.gamestarted = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(!GameData.gamestarted)
                return;

            ball.Left += GameData.dirX;
            ball.Top += GameData.dirY;
            
            bounceball();
        }

        private void bounceball()
        {
            if (ball.Bottom > Height)
            {
                Application.Exit();
            }

            if (ball.Left < 0 || ball.Right > Width)
            {
                GameData.dirX = -GameData.dirX;
                return;
            }

            if (ball.Bounds.IntersectsWith(pictureBox1.Bounds))
            {
                GameData.dirY = -GameData.dirY;
            }
            
            for (int i = 6; i >= 0; i--)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (ball.Bounds.IntersectsWith(cpb[i, j].Bounds))
                    {
                        if (i == 0)
                            GameData.points += 50;
                        else if (i == 1)
                            GameData.points += 35;
                        else
                            GameData.points += (7 - i) * 5;
                        
                        cpb[i, j].Hits--;
                        
                        if (cpb[i, j].Hits == 0)
                            Controls.Remove(cpb[i, j]);

                        GameData.dirY = -GameData.dirY;

                        return;
                    }
                }
            }
        }
    }
}