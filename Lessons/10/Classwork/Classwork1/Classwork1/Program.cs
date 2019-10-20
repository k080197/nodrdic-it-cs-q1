using System;

namespace Classwork1
{
    class Program
    {
        static void Main(string[] args)
        {
            var pet1 = new Pet()
            {
                Kind = Kind.Bird,
                Name = "Kesha",
                Sex = Sex.M,
                Age = 10
            };

            var pet2 = new Pet();
            pet2.Kind = Kind.Dog;
            pet2.Name = "The ball";
            pet2.Sex = Sex.F;
            pet2.Age = 12;

            Console.WriteLine(pet1.Description);
            Console.WriteLine(pet2.Description);

            Console.ReadKey();
        }
    }
}
