using System.Windows.Forms;

namespace Arkanoid
{
    public partial class Game : UserControl
    {
        public Game()
        {
            InitializeComponent();
            Height = ClientSize.Height;
            Width = ClientSize.Width;
        }
    }
}