using System;
using System.Collections.Generic;
using static System.Console;


namespace ExplorableSpace
{
    class Person
    {
        public string Name;
        public List<Item> Inventory;
        public int Currency = 1;
        public int Hunger = 0;

        public Person(string name, List<Item> inventory)
        {
            if (name != "")
            { Name = name; }
            else
            { Name = "Nobody"; }

            Inventory = inventory;
            Currency += Utility.GetRandomNumber(10);
            Inventory.Add(new Item("Little Cake", "Treat of the gods"));
        }

        public void PlayerStatus()
        {

            Write($"{Name}'s Status:, \n{Currency} coins, Hunger level is {Hunger}\n");
        }



        private bool SearchInvintory()
        {
            foreach (Item item in Inventory)
            {
                if (item.Name == "Little Cake")
                {
                    return true;
                }
            }
            return false;
        }




        private int SearchInventory(string term)
        {
            int i = 0;
            foreach (Item item in Inventory)
            {
                if (item.Name == term)
                {
                    return i;
                }
                i++;
            }
            return -1;
        }

        public void ShowInventory()
        {
            WriteLine("You are currently carrying: ");
            foreach (Item item in Inventory)
            {
                WriteLine(item.Name);
            }
        }

        public void Eat()
        {
            if (Hunger > 0)
            {

                int indexNumber = SearchInventory(("Little Cake"));
                if (indexNumber != -1)
                {
                    //eat
                    WriteLine($" {Name}, you have consumed {Inventory[indexNumber].Name}.");
                    Inventory.Remove(Inventory[indexNumber]);
                    Hunger--;
                    ShowInventory();
                }

                else
                {
                    WriteLine("No food availible!");

                    ReadKey();
                }
            }

            else
            {
                WriteLine("You are allready full. No Little Cakes have been consumed.");
                ReadKey();
            }
        }
        public void Vial()
        {
            foreach (Item item in Inventory)
            {
                if (item.Name == "Vial")
                {
                    WriteLine("You have compleated the game!");

                }
            }
        }
        public void OpenChest()
        {

            {

                int indexNumber = SearchInventory(("Silver Chest"));
                if (indexNumber != -1)
                {
                    Inventory.Remove(Inventory[indexNumber]);

                }
            }
        }
    }
}
        
