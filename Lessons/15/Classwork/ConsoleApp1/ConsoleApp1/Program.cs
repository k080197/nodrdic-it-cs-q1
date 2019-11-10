using System;

namespace ConsoleApp1
{
    class Program
    {
        class Account<T>
        {
            public Account(T id, string name)
            {
                Id = id;
                Name = name;
            }

            public T Id { get; private set; }
            public string Name { get; private set; }
            public void WriteProperties() =>
                Console.WriteLine($"{Id} - {Name}");

        }

        enum Guid
        {
            One,
            Two,
            Three
        }
        public sealed class Circle
        {
            private double _radius;
            public Circle(double radius)
            {
                _radius = radius;
            }



            public double Calculate(Func<double, double> operation)
            {
                return operation(_radius);
            }

        }
        static void Main(string[] args)
        {
            var user1 = new Account<int>(1, "User 1");
            var user2 = new Account<string>("U2", "User 2");
            var user3 = new Account<Guid>(Guid.Three, "User 3");

            user1.WriteProperties();
            user2.WriteProperties();
            user3.WriteProperties();

            var circle = new Circle(1.5);

            Console.WriteLine($"For the circle with radius 1.5\n" +
                $"\tPerimeter is\t{circle.Calculate(Perimeter)}\n" +
                $"\tSquare is\t{circle.Calculate(Square)}");

            Console.ReadKey();
        }

        public static double Perimeter(double radius)
        {
            return Math.PI * 2 * radius;
        }

        public static double Square(double radius)
        {
            return Math.PI * radius * radius;
        }

    }
}
