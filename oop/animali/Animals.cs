namespace Animali
{
    public class CAnimalEventArgs : EventArgs { public CAnimal? Animal; }

    public abstract class CAnimal
    {
        public UnmanagedMemoryStream? SoundPath { get; set; }
        public Bitmap? ImagePath { get; set; }

        public int fame { get; set; }
        public int cap { get; set; }

        public event EventHandler? OnTouched;

        public CAnimal()
        {
            OnTouched += wakeUp;
            OnTouched += playSound;
            fame = 0;
        }

        public void Touch()
        {
            if (OnTouched is null) return;
            OnTouched(this, new CAnimalEventArgs { Animal = this });
        }

        public virtual void wakeUp(object? sender, EventArgs? e)
        {
            fame++;
            if (fame >= cap) hoFame();
        }

        public virtual void hoFame()
        {
            Form2 form = new Form2();
            form.Show();
        }

        private void playSound(object? sender, EventArgs? e)
        {
            Form1.makeSound(SoundPath);
        }
    }

    public class Dog : CAnimal
    {
        public Dog()
        {
            SoundPath = Properties.Resources.sndDog;
            ImagePath = Properties.Resources.imgDog;
            cap = 3;
        }
    }

    public class Cat : CAnimal
    {
        public Cat()
        {
            SoundPath = Properties.Resources.sndCat;
            ImagePath = Properties.Resources.imgCat;
            cap = 3;
        }
    }

    public class Monke : CAnimal
    {
        public Monke()
        {
            SoundPath = Properties.Resources.sndMonke;
            ImagePath = Properties.Resources.imgMonke;
            cap = 3;
        }
    }

    public class SmurfCat : CAnimal
    {
        public SmurfCat()
        {
            SoundPath = Properties.Resources.sndSmurfcat;
            ImagePath = Properties.Resources.imgSmurfcat;
            cap = 3;
        }
    }

    public class Snake : CAnimal
    {
        public Snake()
        {
            SoundPath = Properties.Resources.sndSnake;
            ImagePath = Properties.Resources.imgSnake;
            cap = 3;
        }
    }

    public class Ferret : CAnimal
    {
        public Ferret()
        {
            SoundPath = Properties.Resources.sndFerret;
            ImagePath = Properties.Resources.imgFerret;
            cap = 3;
        }
    }

    public class Turtle : CAnimal
    {
        public Turtle()
        {
            SoundPath = Properties.Resources.sndTurtle;
            ImagePath = Properties.Resources.imgTurtle;
            cap = 3;
        }
    }

    public class Duck : CAnimal
    {
        public Duck()
        {
            SoundPath = Properties.Resources.sndAnitra;
            ImagePath = Properties.Resources.imgAnitra;
            cap = 3;
        }
    }

    public class Horse : CAnimal
    {
        public Horse()
        {
            SoundPath = Properties.Resources.sndHorse;
            ImagePath = Properties.Resources.imgHorse;
            cap = 3;
        }
    }
}