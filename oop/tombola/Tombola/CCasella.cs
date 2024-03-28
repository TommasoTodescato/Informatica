using System;

namespace Tombola
{
    internal class CCasella
    {
        public int Number { get; set; }
        public bool Active { get; set; }
        public bool Ticked { get; set; }

        private (int, int) mCords;

        public int X
        {
            get { return mCords.Item1; }
            set
            {
                if (value < 0 || value > 9)
                    throw new ArgumentOutOfRangeException("value");
                else
                    mCords.Item1 = value;
            }
        }

        public int Y
        {
            get { return mCords.Item2; }
            set
            {
                if (value < 0 || value > 3)
                    throw new ArgumentOutOfRangeException("value");
                else
                    mCords.Item2 = value;
            }
        }

        public (int, int) Cords
        {
            get { return mCords; }
            set
            {
                if ((value.Item1 < 0 || value.Item1 > 9) && (value.Item2 < 0 || value.Item2 > 3))
                    throw new ArgumentOutOfRangeException("value");
                else
                    mCords = value;
            }
        }

        public CCasella(int X, int Y, int Number, bool Active)
        {
            this.X = X;
            this.Y = Y;
            this.Number = Number;
            this.Active = Active;
            Ticked = false;

            if (!this.Active)
                this.Number = -1;
        }
    }
}