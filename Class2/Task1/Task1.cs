namespace Task1
{
    class JsonIntProperty
    {
        
        public int SetValueCounter;
        public static int InstanceCounter = 0;
        private readonly string _propertyName;
        private int _propertyValue;

        public int Value
        {
            set
            {
                _propertyValue = value;
                SetValueCounter++;
            }
            get => _propertyValue;
        }
        public string StringRepresentation
        {
            get => ToString();
            set
            {
                var subs = string.Concat(value.Where(c => !char.IsWhiteSpace(c))).Split(':');
                if (subs.Length != 2)
                {
                    throw new ArgumentException($"System.ArgumentException: " +
                                                $"Incorrect JSON property format: '{value}'");
                }
                if (subs[0] != _propertyName)
                {
                    throw new ArgumentException("System.ArgumentException: Property name is immutable");
                }

                if (! int.TryParse(subs[1], out var result))
                {
                    throw new FormatException($"System.FormatException: For input string: \"{subs[1]}\"");
                }

                Value = result;
            }
        }
        public JsonIntProperty(string propertyName, int propertyValue)
        {
            InstanceCounter++;
            SetValueCounter = 0;
            _propertyName = propertyName;
            Value = propertyValue;
        }

        public JsonIntProperty(string propertyName)
        {
            InstanceCounter++;
            SetValueCounter = 0;
            _propertyName = propertyName;
            Value = 0;
        }

        public override string ToString()
        {
            return $"{_propertyName}: {Value}";
        }
    }

    public class Task1
    {
        public static void Main(string[] args)
        {
            RunTest();
        }
        
        internal static void RunTest()
        {
            var ageProperty = new JsonIntProperty("age", 21);
            Console.WriteLine(ageProperty);
            Console.WriteLine(ageProperty.StringRepresentation);
            ageProperty.Value += 1;
            Console.WriteLine(ageProperty);
            ageProperty.StringRepresentation = "age: 23";
            Console.WriteLine(ageProperty);
            ageProperty.StringRepresentation = "age   :   24";
            Console.WriteLine(ageProperty);
            try
            {
                ageProperty.StringRepresentation = "value : 10";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                ageProperty.StringRepresentation = "age: ?";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                ageProperty.StringRepresentation = "age = 10";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine($"JSON value of 'age' has been set {ageProperty.SetValueCounter} time(s)");
            var countProperty = new JsonIntProperty("count");
            Console.WriteLine(countProperty);
            Console.WriteLine($"JSON value of 'count' has been set {countProperty.SetValueCounter} time(s)");
            Console.WriteLine(
                $"Class 'JsonIntProperty' instance has been created {JsonIntProperty.InstanceCounter} time(s)");
        }

    }
}