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
            
            LoadTiles();
            
            ball = new PictureBox();
            ball.Width = ball.Height = 40;
            ball.BackgroundImage = Image.FromFile("../../Recursos/Ball.png");
            ball.Top = Height - pictureBox1.Height - ball.Height;
            ball.Left = Width / 2 - ball.Width / 2;
            ball.BackgroundImageLayout = ImageLayout.Stretch;
            Controls.Add(ball);
        }
        
        //Cargar bloques
        private void LoadTiles()
        {
            int xAxis = 10, yAxis = 7;

            //Altura y anchura de los bloques
            int cpbheight = (int)(Height * 0.5) / yAxis;
            int cpbwidth = Width / xAxis;
            
            var cpb = new CustomPictureBox[yAxis, xAxis];

            for (int i = 0; i < yAxis; i++)
            {
                for(int j = 0; j < xAxis ; j++)
                {
                    //Cantidad de golpes necesarios
                    cpb[i,j] = new CustomPictureBox();
                    if (i == 0)
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
    }
}