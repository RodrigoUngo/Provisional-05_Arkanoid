using System.Windows.Forms;

namespace Arka
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