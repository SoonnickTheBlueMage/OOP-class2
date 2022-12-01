namespace Task2
{
    abstract class Animal
    {
        private readonly string _creature;
        private readonly string _verb;
        private readonly string _sound;
        internal Animal(string creature, string verb, string sound)
        {
            _creature = creature;
            _verb = verb;
            _sound = sound;
        }

        internal void Talk()
        {
            Console.WriteLine($"{_creature} {_verb} {_sound}");
        }
    }

    class Cat : Animal
    {
        public Cat() : base("Кошка", "мяучит", "'мяу-мяу'")
        {}
    }

    class Dog : Animal
    {
        public Dog() : base("Собака", "гавкает", "'гав-гав-гав'")
        {}
    }

    class Goose : Animal
    {
        public Goose() : base("Гусь", "гогочет", "'га-га-га'")
        {}
    }

    public class Task2
    {
        public static void Main(string[] args)
        {
            RunTest();
        }

        internal static void RunTest()
        {
            foreach (var animal in new List<Animal> { new Cat(), new Dog(), new Goose() })
            {
                animal.Talk();
            }
        }
    }
}