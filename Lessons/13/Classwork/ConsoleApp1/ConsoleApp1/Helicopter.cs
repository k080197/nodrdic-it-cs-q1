using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Helicopter : FlyingObject, Interfaces.IHelicopter
    {
        public byte BladesCount { get; private set; }

        public Helicopter(int maxHeight, byte bladesCount) : base(maxHeight)
        {
            BladesCount = bladesCount;
            Console.WriteLine("It’s a helicopter, welcome aboard!");
        }

        public override void WriteAllProperties()
        {
            Console.WriteLine(
                $"Properties of {GetType().Name}:" +
                $"\n\t{nameof(BladesCount)}:\t{BladesCount}" +
                $"\n\t{nameof(MaxHeight)}:\t{MaxHeight}" +
                $"\n\t{nameof(CurrentHeight)}:\t{CurrentHeight}\n");
        }

        public override void WriteAllProperties2()
        {
            Console.Write(
                $"Properties of {GetType().Name}:" +
                $"\n\t{nameof(BladesCount)}:\t{BladesCount}");

            base.WriteAllProperties2();
        }
    }
}
