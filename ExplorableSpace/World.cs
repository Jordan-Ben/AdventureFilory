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
            WriteLine($"Thank you for coming to explore {Name}!!\n");


            //Crumbing Ruins
            List<Item> Ruins = new List<Item>();
            Ruins.Add(new Item("leaf", "generic leaf"));
            Ruins.Add(new Item("rock", "broken rock from the castle"));
            Ruins.Add(new Item("Golden Little Cake", "resting on a stump."));

            Locations.Add(new Location("Crumbling Ruins", "Field of tall grass with a decaying castle.", Ruins));


            //Flying Forest
            List<Item> FF = new List<Item>();
            FF.Add(new Item("Poppy Flower", "Flower from a poppy plant"));
            FF.Add(new Item("stick", "basic stick"));
            
            Locations.Add(new Location("Flying Forest", "Large forest with poppy fields. ", FF, ConsoleColor.Green));


            //Castle Whitespire
            List<Item> Castle = new List<Item>();
            Castle.Add(new Item("Painting", " Oil Painting of two goatlike males"));
            Castle.Add(new Item("Intricate Key", "Golden key with a chalice design for the bow "));

            Locations.Add(new Location("Castle Whitespire", "A castle built by Dwarves. It looks farmiliar....", Castle, ConsoleColor.DarkMagenta));
       


            //Silver Banks
            List<Item> Silver = new List<Item>();
            Silver.Add(new Item("Silver Chest" , " A glistening silver chest"));

            Locations.Add(new Location("Silver Banks", "Tranquil shore hidden behind a locked door", Silver, ConsoleColor.DarkBlue));


            //Silver Chest
            List<Item> Vial = new List<Item>();
            Vial.Add(new Item("Vial", " in the glistening silver chest"));
            


        }

        private void SetUpPlayer()
        {
            WriteLine("Hello explorer! What is your name?");
            string input = ReadLine();
            player = new Person(input, new List<Item>());
            WriteLine("Welcome " + player.Name);
            ReadKey();

        }

        private void LocationMenu()
        {
            string input = "";
            ResetColor();
            Clear();
            player.PlayerStatus();
            if (player.Hunger > 5)
            {
                WriteLine("You are to hungry to travel. Do you want to eat from your inventory? Y/N \n If you have no food in your inventory you may purchase for 5 coins by entering 'C");
                input = ReadLine();
                if (input.Contains("y"))
                {
                    player.Eat();
                    LocationMenu();
                }
                else if (input.Contains("c"))
                {
                    int choice = 0;
                    Locations[choice].FoodChest(player);
                    LocationMenu();

                }
            }
            else
            {

                WriteLine("This is the current list of places in " + Name + ". Please enter the number of the location you want to visit: ");
                int choice = 1;
                foreach (Location location in Locations)
                {
                    WriteLine(choice + ") " + location.About());
                    choice++;

                } WriteLine("5) Open Silver chest");
                   input = ReadLine();
                switch (input)
                {
                    case "1":
                        //0 ruins
                        Travel(0);
                        break;

                    case "2":
                        //1 Forest
                        Travel(1);
                        break;

                    case "3":
                        //2 Castle
                        Travel(2);
                        break;


                    case "4":
                        //3 Silver Banks
                        bool Cake = false;
                        bool Key = false;
                        bool Flower = false;
                        foreach (Item item in player.Inventory)
                        {
                            if (item.Name.Contains("Cake"))
                            {
                                Cake = true;

                            }
                            else if (item.Name.Contains("Key"))
                            {
                                Key = true;
                            }
                            else if (item.Name.Contains("Flower"))
                            {
                                Flower = true;
                            }

                        }
                        if (Flower && Cake && Key)
                        { Travel(3); }
                        else
                        {
                            WriteLine("You are unable to unlock the door. A Red Flower, Golden Key and a small sweet treat are needed to enter.");
                            WriteLine("Press any key to continue...");
                            ReadKey();
                        }
                        break;

                    case "5":
                        //4 Silver Chest
                        {
                            bool Chest = false;
                            foreach (Item item in player.Inventory)
                            {
                                if (item.Name.Contains("Chest"))
                                {
                                    Chest = true;
                                }

                                if (Chest)
                                {
                                    Clear();
                                    WriteLine("You slowly open the chest,");
                                    player.OpenChest();
                                    List<Item> Vial = new List<Item>();
                                    Vial.Add(new Item("Vial", " with a odd liquid inside."));
                                    WriteLine("and see a Vial with an odd liquid inside");
                                    WriteLine("Would you like to pick it up?");
                                    input = ReadLine();
                                    if (input.Contains("y"))
                                    {
                                        player.Inventory.Add(item);
                                    }

                                    WriteLine("As you remove the Vial words aprear on the lid\n\n press enter to continue");
                                    ReadKey();
                                    Clear();
                                    WriteLine("You have unlocked a secret location.");
                                    WriteLine("Enter 6 as your travel choice");
                                    ReadKey();
                                    break;

                                }
                            }
                        }
                        break;

                    case "6":
                        {
                            bool Vial = true;
                            foreach (Item item in player.Inventory)
                            {
                                if (item.Name.Contains("V"))
                                {
                                    Vial = true;

                                }

                            }
                            if (Vial)
                            {
                                
                                WinGame();
                                ReadKey();
                            }
                            
                        }
                    break;

                }

                LocationMenu();
            }
        }

        private void Travel(int choice)
        {
            BackgroundColor = Locations[choice].LocationColor;
            Clear();
            player.Hunger++;
            player.PlayerStatus();
            WriteLine(" ");
            

            WriteLine($"Welcome to {Locations[choice].Name}. Good luck {player.Name}!");

            WriteLine(Locations[choice].Description);


            Item randomItem = Locations[choice].Items[Utility.GetRandomNumber(Locations[choice].Items.Count)];

            WriteLine($"You see a {randomItem.Name} ({randomItem.Description}) in front of you. Would you like to take it with you?");


            string input = ReadLine();
            if (input.Contains("y"))
            {
                player.Inventory.Add(randomItem);
            }
            
            Locations[choice].SpecialChest(player);


            player.ShowInventory();


                


            //eat?
            if (player.Hunger > 0)
            {
                WriteLine($"You are hungry. Would you like to eat? Yes or No");
                input = ReadLine();
                if (input.Contains("y"))
                {
                    player.Eat();
                }

            }
            WriteLine("Press any key to continue");
            ReadKey();
            Clear();
        }
        public void WinGame()
        {
            Clear();
            ResetColor();
            BackgroundColor = ConsoleColor.DarkGray;
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine("You have won!");
            player.PlayerStatus();
            player.ShowInventory();
            ReadKey();
        }
    }
}


