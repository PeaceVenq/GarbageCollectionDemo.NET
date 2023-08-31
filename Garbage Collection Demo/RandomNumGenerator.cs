using System;

namespace Garbage_Collection_Demo
{
    public static class RandomNumGenerator
    {
        public static int GenerateRandomFourDigitNum()
        {
            int _min = 1000;
            int _max = 9999;
            Random _rdm = new Random();
            return _rdm.Next(_min, _max);
        }
    }
}


//https://learn.microsoft.com/en-us/dotnet/standard/garbage-collection/fundamentals


