using System;

namespace Classwork
{
    class Program
    {
        static void Main(string[] args)
        {
            var pet = new Pet
            {
                Name = "Kesha",
                Kind = "Parrot",
                Sex = 'M',
                DateOfBirth = new DateTime(2009, 2, 21)
            };

            pet.Display(true);
            Console.ReadKey();
        }
    }
}
