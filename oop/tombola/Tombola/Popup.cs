using System.Windows.Forms;

namespace Tombola
{
    public partial class Popup : Form
    {
        public string[] WinTexts = { "", "", "AMBO", "TERNA", "QUATERNA", "CINQUINA", "TOMBOLA", "TOMBOLINO" };
        public Popup()
        {
            InitializeComponent();
        }
    }
}
