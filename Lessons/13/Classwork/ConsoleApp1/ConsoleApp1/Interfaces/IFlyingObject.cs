using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Interfaces
{
    interface IFlyingObject
    {
        int MaxHeight { get; }
        int CurrentHeight { get;}
        void TakeUpper(int delta);
        void TakeLower(int delta);
    }
}
