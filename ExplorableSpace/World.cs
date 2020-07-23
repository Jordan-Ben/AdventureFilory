using System;
using System.Collections.Generic;
using static System.Console;

namespace ExplorableSpace

{
    class World
    {
        string Name = "New Filory";
        List<Location> Locations;
        Person player;

        public World()
        {
            SetUpWorld();
            SetUpPlayer();
            LocationMenu();
        }

        private void SetUpWorld()
        {
            Locations = new List<Location>();

            Title = Name + " by Jordan";
            WriteLine($"Welcome to {Name}");


            //Mountains
            List<Item> Mount = new List<Item>();
            Mount.Add(new Item("leaf", "generic leaf"));

            Locations.Add(new Location("Cairn Barrens", "Field of tall grass with .", Mount, ConsoleColor.Gray));

            //Flying Forrest
            List<Item> FF = new List<Item>();
            FF.Add(new Item("leaf", "generic leaf"));
           

            Locations.Add(new Location("___", "___", FF , ConsoleColor.Green));


            //Lake
            List<Item> Lake = new List<Item>();
            Lake.Add(new Item("leaf", "generic leaf"));

            Locations.Add(new Location("___", "___", Lake, ConsoleColor.DarkBlue));
        

            //Castle Whitespire
            List<Item> Castle = new List<Item>();
            Castle.Add(new Item("Painting", " Oil Painting of two goatlike males"));
            Castle.Add(new Item("Intricate Key", "Golden key with a chalice design for the bow "));

            Locations.Add(new Location("Castle Whitespire", "Built by Dwarves. It looks farmiliar....", Castle, ConsoleColor.Gray ));

            

        }

        private void SetUpPlayer()
        {
            WriteLine("Hello explorer! What is your name?");
            string input = ReadLine();
            player = new Person(input, new List<Item>());
            WriteLine("Welcome " + player.Name);

        }

        private void LocationMenu()
        {
            ResetColor();
            Clear();
            //player.PlayerStatus();
            //if

            {


            }






            WriteLine("These are the places you can visit... enter a number to travel:");
            int choice = 1;
            foreach (Location location in Locations)
            {
                WriteLine(choice + ") " + location.About());
                choice++;
            }
            string input = ReadLine();
            switch (input)
            {
                case "1":
                    //0
                    Travel(0);
                    break;

                case "2":
                    //1
                    Travel(1);
                    break;

                case "3":
                    //2
                    bool mask = false;
                    bool tube = false;
                    bool fins = false;
                    foreach (Item item in player.Inventory)
                    {
                        if (item.Name.Contains("mask"))
                        {
                            mask = true;
                        }
                        else if (item.Name.Contains("tube"))
                        {
                            tube = true;
                        }
                        else if (item.Name.Contains("fin"))
                        {
                            fins = true;
                        }

                    }
                    if (mask && tube && fins)
                    { Travel(2); }
                    else
                    {
                        WriteLine("You are missing essential snorkeling gear. Make sure you have a mask, a breathing tube, and fins.");
                        WriteLine("Press any key to continue...");
                        ReadKey();
                    }
                    break;
                case "4":
                    Travel(3);
                    break;
            }

            //TODO:
            //convert input to a number
            //find that number inside of the Locations list and use that as target location
            //See the Travel method for example of how to do this : )

            LocationMenu();
        }


        private void Travel(int choice)
        {
            BackgroundColor = Locations[choice].LocationColor;
            ForegroundColor = ConsoleColor.White;
            Clear();
            WriteLine($"Welcome {player.Name} to {Locations[choice].Name}");

            WriteLine(Locations[choice].Description);

            //you could build up with three lines...
            //int listSize = Locations[choice].Items.Count;
            //int randomNumber = Utility.GetRandomNumber(listSize);
            //Item randomLocationItem = Locations[choice].Items[randomNumber];

            //or just have one line...
            Item randomItem = Locations[choice].Items[Utility.GetRandomNumber(Locations[choice].Items.Count)];

            WriteLine($"You see a {randomItem.Name} ({randomItem.Description}) lying on the ground. Do you pick it up and take it with you?");
            string input = ReadLine();
            if (input.Contains("y"))
                
            {
                player.Inventory.Add(randomItem);
            }



            WriteLine("Here is what is in your inventory:");
            foreach (Item item in player.Inventory)
            {
                WriteLine(item.Name);
            }

            //eat?
           /* if (player.Hunger > 0)
            {
                WriteLine("test");
                input = ReadLine();
                if (input.Contains("y") == "yes" || "y");
                { WriteLine("   ")};
                else
                {
                    WriteLine ("0");
                }
            }
           */




            WriteLine("Press any key to continue...");
            ReadKey();
        }

    }
}