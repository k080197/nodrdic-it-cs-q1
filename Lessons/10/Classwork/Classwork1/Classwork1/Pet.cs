using System;

namespace Classwork1
{
    enum Kind: byte
    {
        Mouse,
        Cat,
        Dog,
        Bird
    }

    enum Sex : byte
    {
        F,
        M
    }
    class Pet
    {
        public Kind Kind { get; set; }

        public string Name { get; set; }

        public Sex Sex { get; set; }

        public int Age { get; set; }
        public Pet()
        {

        }

        public string Description =>
            $"Вид: {Kind}, Имя: {Name}, Пол: {Sex}, Возраст: {Age}";

    }
}
