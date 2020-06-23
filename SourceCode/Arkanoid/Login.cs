using System;
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
            try
            {
                if (txtName.Text.Equals("") || txtName.Text.Equals(null))
                {
                    throw new EmptyFieldException("No puedes dejar campos vacios. Por favor escribe un nombre");
                }
            }
            catch (EmptyFieldException ex)
            {
                MessageBox.Show(ex.Message);
            }
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
            GameData.username = txtName.Text;
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
    }
}