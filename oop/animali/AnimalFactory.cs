namespace Animali
{
    public class CAnimalFactory
    {
        public CAnimal? create(string name)
        {
            switch (name)
            {
                case "scimmia": return new Monke();
                case "anatra": return new Duck();
                case "smurfgatto": return new SmurfCat();
                case "cavallo": return new Horse();
                case "gatto": return new Cat();
                case "furetto": return new Ferret();
                case "tartaruga": return new Turtle();
                case "serpente": return new Snake();
                case "cane": return new Dog();
            }
            Console.WriteLine("[FACTORY] Nome animale non valido");
            return null;
        }

        public CAnimal? create(int id)
        {
            switch (id)
            {
                case 0: return new Monke();
                case 1: return new Duck();
                case 2: return new SmurfCat();
                case 3: return new Horse();
                case 4: return new Cat();
                case 5: return new Ferret();
                case 6: return new Turtle();
                case 7: return new Snake();
                case 8: return new Dog();
            }
            Console.WriteLine("[FACTORY] Id animale non valido");
            return null;
        }
    }

    public class CAnimalRandomFactory : CAnimalFactory
    {
        public CAnimal? create()
        {
            int id = new Random().Next(0, 8);
            return create(id);
        }

        public CAnimal[,] createMatrix(int x, int y)
        {
            CAnimalRandomFactory fact = new CAnimalRandomFactory();
            CAnimal[,] m = new CAnimal[x, y];
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    m[i, j] = fact.create();
                }
            }
            return m;
        }
    }
}