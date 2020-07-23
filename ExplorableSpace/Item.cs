using System;
using System.Collections.Generic;
using static System.Console;

namespace ExplorableSpace
{
    class Item
    {
        public string Name;
        public string Description;

        public Item(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}