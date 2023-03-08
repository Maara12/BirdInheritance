using System;

namespace BirdInheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            
            while (true)
            {
                Bird bird;
                Console.Write("\nPress P for pigeon, O for ostrich: ");
                char key = Char.ToUpper(Console.ReadKey().KeyChar);
                if (key == 'P') bird = new Pigeon();
                else if (key == 'O') bird = new Ostrich();
                else return;
                Console.Write("\nHow many eggs should it lay? ");
                if (!int.TryParse(Console.ReadLine(), out int numberOfEggs)) return;
                Egg[] eggs = bird.LayEggs(numberOfEggs);
                foreach (Egg egg in eggs)
                {
                    Console.WriteLine(egg.Description);
                }
            }

           
        }
    }

    class Egg
    {
        public double Size { get; private set; }
        public string Color { get; private set; }
        public Egg(double size, string color)
        {
            Size = size;
            Color = color;
        }
        public string Description
        {
            get { return $"A {Size:0.0}cm {Color} egg"; }
        }
    }

    class Bird
    {
        public static Random Randomizer = new Random();
        public virtual Egg[] LayEggs(int numberOfEggs)
        {
            Console.Error.WriteLine("Bird.LayEggs should never get called");
            return new Egg[0];
        }
    }

    class Pigeon : Bird
    {
        
        public override Egg[] LayEggs(int numberOfEggs)
        {
            
            Egg[] pigeonEggs = new Egg[numberOfEggs];

            for (int i =0; i < numberOfEggs; i++)
            {
                double pigeonSize = Randomizer.Next(1, 3) + Randomizer.NextDouble();
                string pigeonColor = "white";
                pigeonEggs[i] = new Egg(pigeonSize, pigeonColor);
            }
            return pigeonEggs;
        }
        
    }

    class Ostrich : Bird
    {
        
        public override Egg[] LayEggs(int numberOfEggs)
        {
            
            Egg[] ostrichEggs = new Egg[numberOfEggs];

            for (int i = 0; i < numberOfEggs; i++)
            {
                double ostrichSize = Randomizer.Next(12, 13) + Randomizer.NextDouble();
                string ostrichColor = "speckled";
                ostrichEggs[i] = new Egg(ostrichSize, ostrichColor);
            }
            return ostrichEggs;
        }

    }

 }
}
