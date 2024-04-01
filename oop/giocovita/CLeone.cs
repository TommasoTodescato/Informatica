namespace GiocoVita
{
    internal class CLeone : CPersonaggio
    {
        public override Bitmap Img { get { return Properties.Resources.leone; } }
        public override int Hierarchy { get { return 3; } }

        public CLeone((int x, int y) position) : base(position) { }

        public override bool PlayRound()
        {
            // Diminuisco la vita e controllo se sono morto
            if (--Life <= 0)
            {
                CCampo.Campo.RemoveFromTable(Position.x, Position.y);
                CCampo.Campo.Players.Remove(this);
                return false;
            }

            // Provo tutte le direzioni possibili in ordine casuale
            List<int> Directions = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7 };
            while (Directions.Count > 0)
            {
                int i = new Random().Next(0, Directions.Count);
                Direction dir = (Direction)Directions[i];
                if (!Move(dir))
                    Directions.RemoveAt(i);
                else break;
            }
            // Se non sono riuscito a muovermi
            return true;
        }
    }
}
