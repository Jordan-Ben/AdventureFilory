using System;
using System.Collections.Generic;
using static System.Console;

namespace ExplorableSpace
{
    class Utility
    {
        public static Random random = new Random();

        public static int GetRandomNumber(int min,int max)
        {
            return random.Next(min, max);
        }
    }
}

