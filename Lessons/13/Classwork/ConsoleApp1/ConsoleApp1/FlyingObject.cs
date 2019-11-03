﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    abstract class FlyingObject : Interfaces.IFlyingObject
    {
        public int MaxHeight { get; private set; }

        public int CurrentHeight { get; private set; }

        public FlyingObject(int maxHeight)
        {
            MaxHeight = maxHeight;
            CurrentHeight = 0;
        }

        public void TakeUpper(int delta)
        {
            if (delta <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(delta), "The value should be positive");
            }

            CurrentHeight = Math.Min(CurrentHeight + delta, MaxHeight);
        }

        public void TakeLower(int delta)
        {
            if (delta <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(delta), "The value should be positive");
            }

            int newPotentialHeight = CurrentHeight - delta;
            switch (Math.Sign(newPotentialHeight))
            {
                case 0:
                case 1:
                    CurrentHeight = newPotentialHeight;
                    break;
                case -1:
                    throw new InvalidOperationException("Crash!");
            }
        }

        public abstract void WriteAllProperties();

        public virtual void WriteAllProperties2()
        {
            Console.WriteLine(
                $"\n\t{nameof(MaxHeight)}:\t{MaxHeight}" +
                $"\n\t{nameof(CurrentHeight)}:\t{CurrentHeight}\n");
        }
    }
}
