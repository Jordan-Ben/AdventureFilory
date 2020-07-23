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
            Currency += Utility.GetRandomNumber(1,7);
        }
        private bool SearchInvintory()
        {
            foreach(Item item in Inventory)
            {
                if (item.Name == "Little Cakes")
                {
                    return true;
                }
            }
            return false;
        }

       /* private int SearchInventory(string term)
        {
            int(1);
        }*/





       /* public void Eat()
        {
            if (Hunger > 0 ) ;
            {
                if (SearchInvintory()) ;
            }
            else
            {
                WriteLine("try again");
            }


        }*/



    }
}