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
                if (Utility.GetRandomNumber(3) == 1) 
                {
                    player.Inventory.Add(new Item("Little Cake", "Tasty treat of the gods"));
                    WriteLine("You have found a Little Cake!");

                }

                int coinAmount = Utility.GetRandomNumber(5);

                if (coinAmount > 0)
                {
                    player.Currency += coinAmount;


                    if (coinAmount > 1)
                        WriteLine($"You have aquired {coinAmount} coins.");
                    else
                        WriteLine($"You have aquired {coinAmount} coin.");
                }




            }
        }
        public void FoodChest(Person player)
        {
            WriteLine("You have purchased a Large Cake! Press enter to eat it.");
           ReadKey();
           player.Currency -= (5);
            player.Hunger -= 6;
                }

        

                
        }


     }
