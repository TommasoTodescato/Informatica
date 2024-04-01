using GiocoVita;

namespace GiocoVita
{
    public partial class Main : Form
    {
        public static TableLayoutPanel Table { get; set; }

        public Main()
        {
            InitializeComponent();
        }

        private void Start(object sender, EventArgs e)
        {
            // Parsing dell'input
            if (int.TryParse(RowsInput.Text, out int a) && a >= 16) return;

            InitTable(a);

            // Prima assegnazione del singleton
            CCampo c = new CCampo(a, a);

            // Thread secondario al form dove gira il gioco
            Thread GameLoop = new Thread(c.StartGame);
            GameLoop.IsBackground = true;
            GameLoop.Start();
        }

    }
}