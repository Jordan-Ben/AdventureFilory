using System;
using System.Collections.Generic;
using static System.Console;

namespace ExplorableSpace
{
    class Location
    {
        public string Name;
        public string Description;
        public List<Item> Items = new List<Item>();
        public ConsoleColor LocationColor = new ConsoleColor();
        //TODO: add array or list of people that player can meet
        //use random names, dialogue, and items in the NPC inventories

        public Location(string name, string description, List<Item> items)
        {
            Name = name;
            Description = description;
            Items = items;
            LocationColor = ConsoleColor.DarkGreen;
        }
        public Location(string name, string description, List<Item> items, ConsoleColor color)
        {
            Name = name;
            Description = description;
            Items = items;
            LocationColor = color;
        }

        public string About()
        {
            return $"{Name}: {Description}";
        }

        public void SpecialChest(Person player)
        {
            if (Utility.GetRandomNumber(1, 2) == 1)
            {
                //chest apears
                if (Utility.GetRandomNumber(1, 2) ==2) 
                {
                    player.Inventory.Add(new Item("Little Cakes", "Tasty treats of the gods"));
                        }

                int coinAmount = Utility.GetRandomNumber(0,5);

                if (coinAmount > 0)
                {
                    player.Currency += coinAmount;
                    if (coinAmount > 1)
                        WriteLine("  ");
                    else
                        WriteLine("  ");//
                }


            }
        }


    }
}