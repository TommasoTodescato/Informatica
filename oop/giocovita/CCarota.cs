namespace GiocoVita
{
    internal class CCarota : CPersonaggio
    {
        public override Bitmap Img { get { return Properties.Resources.carota; } }
        public override int Hierarchy { get { return 0; } }

        public CCarota((int x, int y) position) : base(position) { }

    }
}
