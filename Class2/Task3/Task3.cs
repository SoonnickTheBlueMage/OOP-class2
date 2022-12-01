namespace Task3
{
    abstract class Creature
    {
    }

    class Human : Creature
    {
        internal string Greeting() => "Привет, я человек!";
    }

    class Dog : Creature
    {
        internal string Bark() => "Гав!";
    }

    class Alien : Creature
    {
        internal string Command() => "Ты меня не видишь";
    }

    public class Task3
    {
        internal static void PrintMessageFrom(Creature creature)
        {
            string message = "";
            switch (creature)
            {
                case Dog dog:
                    message = dog.Bark();
                    break;
                case Human human:
                    message = human.Greeting();
                    break;
                case Alien alien:
                    message = alien.Command();
                    break;
            }
            Console.WriteLine(message);
        }

        static List<Dog> FindDogs(List<Creature> creatures) => 
            creatures.FindAll(x => x is Dog).ConvertAll(x => x as Dog)!;

        public static void Main(string[] args)
        {
            RunTest();
        }

        internal static void RunTest()
        {
            var creatures = new List<Creature> { new Alien(), new Dog(), new Human(), new Dog() };
            Console.WriteLine("Все сообщения:");

            foreach (var creature in creatures)
            {
                PrintMessageFrom(creature);
            }

            Console.WriteLine();
            Console.WriteLine("Сообщения только от собак:");
            foreach (var dog in FindDogs(creatures))
            {
                Console.WriteLine(dog.Bark());
            }
        }
    }
}