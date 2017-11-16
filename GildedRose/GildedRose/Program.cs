using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose
{
    class Program
    {
        static void Main(string[] args)
        {
            InventoryManager im = new InventoryManager();

            Console.WriteLine("Begin adding items to the inventory. Type 'Done' when complete");
            Console.WriteLine("Example 'Backstage passes -1 2'");

            bool scanning = true;

            while(scanning)
            {
                var input = Console.ReadLine();

                if(input != "Done")
                {
                    var items = input.Split(' ');

                    if (items.Count() == 3)
                        im.Add(items[0], int.Parse(items[1]), int.Parse(items[2]));

                    if (items.Count() == 4)
                        im.Add($"{items[0]} {items[1]}", int.Parse(items[2]), int.Parse(items[3]));
                }
                else
                {
                    scanning = false;

                    var items = im.IncrementDay();

                    Console.WriteLine();
                    Console.WriteLine("=== Day has been incremented ===");
                    
                    foreach(IDegradeableItem i in items)
                    {
                        if(i.Sellin == 0 & i.Quality == 0)
                        {
                            Console.WriteLine($"{i.Name}");
                            continue;
                        }

                        Console.WriteLine($"{i.Name} {i.Sellin} {i.Quality}");
                    }

                    Console.Read();
                }
            }

        }
    }
}
