using System;
using System.Collections.Generic;
using System.Data;
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
            var playerslist = ObtainTopPlayers();
            players = new Label[10, 2];
            int sampleTop = label1.Bottom, sampleLeft = 20;
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        players[i, j] = new Label();
                        if (j == 0)
                        {
                            players[i, j].Text = playerslist[i].Nickname;
                            players[i, j].Left = sampleLeft;
                        }
                        else
                        {
                            players[i, j].Text = playerslist[i].Score.ToString();
                            players[i, j].Left = Width / 2 + sampleLeft;
                        }

                        players[i, j].Top = sampleTop + 40 * i;

                        players[i, j].Height += 4;
                        players[i, j].Width += 160;

                        players[i, j].Font = new Font("Showcard Gothic", 14F);
                        players[i, j].ForeColor = Color.Black;
                        players[i, j].TextAlign = ContentAlignment.MiddleCenter;
                        Controls.Add(players[i, j]);
                    }
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show("Todavía no hay 10 o más puntajes");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error en la carga del Top 10");
            }
        }

        private void Top10_Load(object sender, EventArgs e)
        {
            LoadPlayers();
        }
        
        //Obtener la lista Top 10 de BD
        private List<Player> ObtainTopPlayers()
                {
                    var topPlayers = new List<Player>();
                    DataTable dt = DataBaseController.ExecuteQuery("SELECT pl.nickname, sc.score " +
                                                            "FROM PLAYER pl, SCORES sc " +
                                                            "WHERE pl.idPlayer = sc.idPlayer " +
                                                            "ORDER BY sc.score DESC " +
                                                            "LIMIT 10");
        
                    foreach(DataRow dr in dt.Rows)
                    {
                        topPlayers.Add(new Player(dr[0].ToString(), Convert.ToInt32(dr[1])));
                    }
        
                    return topPlayers;
                }
    }
}