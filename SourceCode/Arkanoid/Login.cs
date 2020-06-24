using System;
using System.Data;
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

        //Regresar al menú principal
        private void button1_Click(object sender, EventArgs e)
        {
            label1.Hide();
            txtName.Hide();
            button1.Hide();
            button2.Hide();
            Current = new MainMenu();
            tableLayoutPanel1.Controls.Add(Current,0,0);
            tableLayoutPanel1.SetColumnSpan(Current,2);
            tableLayoutPanel1.SetRowSpan(Current,3);
            Current.Dock = DockStyle.Fill;
        }

        //Entrar al juego
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text.Equals("") || txtName.Text.Equals(null))
                    throw new EmptyFieldException("No puedes dejar campos vacios. Por favor escribe un nombre");
                if(txtName.Text.Length > 20)
                    throw  new ExceededMaxCharacterException("Tu nombre es muy largo. Por favor elige un nombre mas corto");
                GameData.username = txtName.Text;
                bool verifier = CreatePlayer(txtName.Text);
                if (verifier)
                    MessageBox.Show($"Bienvenido de vuelta {txtName.Text}!");
                else
                    MessageBox.Show($"Bienvenido {txtName.Text}. Un gusto conocerte!");
                label1.Hide();
            	txtName.Hide();
            	button1.Hide();
            	button2.Hide();
            	Current = new Game();
            	tableLayoutPanel1.Controls.Add(Current,0,0);
            	tableLayoutPanel1.SetColumnSpan(Current,2);
            	tableLayoutPanel1.SetRowSpan(Current,3);
            	Current.Dock = DockStyle.Fill;
            }
            catch (EmptyFieldException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Crear jugador y comprobar si ya existe en BD
        private bool CreatePlayer(string nickname)
        {
            var dt = DataBaseController.ExecuteQuery($"SELECT * FROM PLAYER WHERE nickname = '{nickname}'");

            if (dt.Rows.Count > 0)
            {
                var dt2 = DataBaseController.ExecuteQuery($"SELECT idPlayer FROM PLAYER WHERE nickname = '{nickname}'");
                foreach (DataRow dr in dt2.Rows)
                {
                    GameData.idPlayer = Convert.ToInt32(dr[0]);
                }
                return true;
            }
            else
            {
                DataBaseController.ExecuteNonQuery("INSERT INTO PLAYER(nickname) VALUES" +
                                                   $"('{nickname}')");
                var dt3 = DataBaseController.ExecuteQuery($"SELECT idPlayer FROM PLAYER WHERE nickname = '{nickname}'");
                foreach (DataRow dr in dt3.Rows)
                {
                    GameData.idPlayer = Convert.ToInt32(dr[0]);
                }
                
                return false;
            }
        }
    }
}