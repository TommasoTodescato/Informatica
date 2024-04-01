namespace GiocoVita
{
    internal class CCampo
    {
        public (int rows, int cols) FieldSize { get; }
        public CPersonaggio[,] Field { get; }
        public List<CPersonaggio> Players; // lista di personaggi in gioco
        private bool Running;

        // Singleton design pattern, costruttore di default privatizzato
        // La properità Campo rappresenta l'unica istanza della classe
        private CCampo() : this(8, 8) { }

        private static CCampo? campo = null;
        public static CCampo Campo
        {
            get
            {
                if (campo == null) campo = new CCampo();
                return campo;
            }
        }

        // Costruttore con parametri di grandezza del campo
        public CCampo(int rows, int cols)
        {
            campo = this;
            FieldSize = (rows, cols);
            Field = new CPersonaggio[rows, cols];
            Players = new List<CPersonaggio>();

            Random r = new Random();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    // Circa il 33% delle caselle sarà occupato da un personaggio casuale
                    if (r.Next(0, 4) != 0) continue;

                    Field[i, j] = new CPersonaggioFactory().create(r.Next(0, 4), (i,j));
                    Players.Add(Field[i, j]);
                    PictureBox? p = Main.Table.GetControlFromPosition(i, j) as PictureBox;
                    p.Image = Field[i, j].Img;
                }
            }
        }

        // Rimuove dalla tabella del form il personaggio a (row, col) coordinate
        public void RemoveFromTable(int row, int col)
        {
            Field[row, col] = null;
            PictureBox? p = Main.Table.GetControlFromPosition(row, col) as PictureBox;
            if (p is null) return;
            p.Image = null;
        }

        // Aggiunge alla tabella del form il personaggio player a (row, col) coordinate
        public void AddToTable(int row, int col, CPersonaggio player)
        {
            Field[row, col] = player;
            PictureBox? p = Main.Table.GetControlFromPosition(row, col) as PictureBox;
            if (p is null) return;
            p.Image = player.Img;
        }

        // Funzione che fa partire il mainloop e fa procedere il gioco
        public void StartGame()
        {
            Running = true;
            while (Running)
            {
                for (int i = 0; i < Players.Count; i++)
                {
                    // Durata del round
                    Thread.Sleep(1000);

                    Players[Players.Count-1-i].PlayRound();
                    if (i >= Players.Count) break;

                }
                // Fine della partita quando rimane solo un giocatore o meno
                Running = Players.Count > 1;
            }
        }
    }
}
