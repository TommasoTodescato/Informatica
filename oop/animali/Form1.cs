using System.Media;

namespace Animali
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitMatrix(3, 3);
        }

        public static void makeSound(UnmanagedMemoryStream? SoundPath)
        {
            if (SoundPath is null) return;

            SoundPlayer player = new SoundPlayer();
            SoundPath.Position = 0;
            player.Stream = SoundPath;
            player.Play();
        }

        private void InitMatrix(int x, int y)
        {
            CAnimalRandomFactory f = new CAnimalRandomFactory();
            CAnimal[,] animals = f.createMatrix(x, y);

            foreach (var button in tableLayoutPanel1.Controls.OfType<Button>())
            {
                int _x = tableLayoutPanel1.GetColumn(button);
                int _y = tableLayoutPanel1.GetRow(button);
                button.Tag = animals[_x, _y];
                button.BackgroundImage = animals[_x, _y].ImagePath;
            }
        }


        private void btnPlay(object sender, EventArgs e)
        {
            if (sender is Button tmp && tmp.Tag is not null)
            {
                CAnimal a = (CAnimal)tmp.Tag;
                a.Touch();
            }
        }
    }
}