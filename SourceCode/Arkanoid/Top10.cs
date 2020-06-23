using System;
using System.Drawing;
using System.Windows.Forms;

namespace Arkanoid
{
    public partial class Top10 : Form
    {
        public delegate void OnClosedWindow();

        private UserControl Current;
        public OnClosedWindow CloseAction;
        private Label[,] players;
        public Top10()
        {
            InitializeComponent();
        }
        
        //Regresar al menú principal
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        //Cargar listado
        private void LoadPlayers()
        {
            string[10] playerslist;
            players = new Label[10, 2];
            int sampleTop = label1.Bottom + 50, sampleLeft = 20;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    players[i,j]= new Label();
                    if (j==0)
                    {
                        players[i, j].Text = playerslist[i].ToString();
                        players[i, j].Left = sampleLeft;
                    }
                    else
                    {
                        players[i, j].Text = playerslist[i].ToString();
                        players[i, j].Left = Width/2 + sampleLeft;
                    }

                    players[i, j].Top = sampleTop + sampleTop * i;
                    players[i,j].Font = new Font("Microsoft YaHei", 14F);
                    players[i, j].ForeColor = Color.White;
                    players[i, j].TextAlign = ContentAlignment.MiddleCenter;
                    Controls.Add(players[i,j]);
                }
            }
        }

        private void Top10_Load(object sender, EventArgs e)
        {
            LoadPlayers();
        }
    }
}