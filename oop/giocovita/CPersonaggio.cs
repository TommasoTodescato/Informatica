namespace GiocoVita
{
    // Direzioni possibili in cui i personaggi si possono muovere
    enum Direction
    {
        Up,
        Down,
        Left,
        Right,
        UpLeft,
        UpRight,
        DownLeft,
        DownRight,
        Size
    }

    internal interface IMovable
    {
        // Ritorna false se la cella è occupata, true se libera
        public bool Move(Direction dir);
    }

    internal abstract class CPersonaggio : IMovable
    {
        public int Life { get; set; }
        public int MaxLife { get; }
        public (int x, int y) Position { get; set; }

        public abstract Bitmap Img { get; }
        public abstract int Hierarchy { get; }

        public CPersonaggio()
        {
            // Vita casuale da 10 a 20 HP
            Life = new Random().Next(10, 20);
            MaxLife = Life;
            Position = (0, 0);
        }

        public CPersonaggio((int x, int y) position) : this()
        {
            Position = position;
        }

        public virtual bool Move(Direction dir)
        {
            int stepx = 0, stepy = 0;

            // Controllo in che direzione andare
            switch (dir)
            {
                case Direction.Up: stepy = -1; break;
                case Direction.Down: stepy = 1; break;
                case Direction.Left: stepx = -1; break;
                case Direction.Right: stepx = 1; break;
                case Direction.UpRight: stepx = 1; stepy = -1; break;
                case Direction.UpLeft: stepx = -1; stepy = -1; break;
                case Direction.DownRight: stepx = 1; stepy = -1; break;
                case Direction.DownLeft: stepx = -1; stepy = 1; break;
            }
            int x = Position.x, y = Position.y;
            (int x, int y) Size = CCampo.Campo.FieldSize;
            
            // Calcolo della nuova posizione
            int c = 0;
            int newX = (c = x + stepx) >= 0 ? c % Size.x : (c % Size.x) + Size.x;
            int newY = (c = y + stepy) >= 0 ? c % Size.y : (c % Size.y) + Size.y;

            // Cella occupata
            if (CCampo.Campo.Field[newX, newY] != null)
            {
                // Se può mangiare:
                if (this.Hierarchy == CCampo.Campo.Field[newX, newY].Hierarchy + 1)
                {
                    Eat(CCampo.Campo.Field[newX, newY]);
                    CCampo.Campo.AddToTable(newX, newY, this);
                    CCampo.Campo.RemoveFromTable(Position.x, Position.y);

                    Position = (newX, newY);
                    return true;
                }
                return false;
            }
            // Cella libera

            CCampo.Campo.AddToTable(newX, newY, this);
            CCampo.Campo.RemoveFromTable(Position.x, Position.y);
            Position = (newX, newY);
            return true;
        }

        // Ritorna true se vivo, false se morto
        public virtual bool PlayRound()
        {
            return !(--Life <= 0);
        }

        public void Eat(CPersonaggio eaten)
        {
            Life = MaxLife;
            eaten.Life = 0;
            CCampo.Campo.RemoveFromTable(eaten.Position.x, eaten.Position.y);
            CCampo.Campo.Players.Remove(eaten);
        }
    }

    // Factory design pattern
    internal class CPersonaggioFactory
    {
        public CPersonaggio create(int id, (int x, int y) position)
        {
            switch (id)
            {
                case 0:
                    return new CCarota(position);
                case 1:
                    return new CConiglio(position);
                case 2:
                    return new CVolpe(position);
                case 3:
                    return new CLeone(position);
            }
            return null;
        }
    }
}
