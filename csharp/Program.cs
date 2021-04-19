using System;
using System.Collections.Generic;

namespace csharp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");

            IList<Item> items = new List<Item>{
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new AgedBrie(2,0),
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Sufuras(0),
                new Sufuras(-1),
                new BackstagePasses(15,20),
                new BackstagePasses(10,49),
                new BackstagePasses(5,49),
				// this conjured item does not work properly yet
				new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };

            for (var i = 0; i < 31; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");
                foreach(Item j in items)
                {
                    System.Console.WriteLine(j.ToString());
                }
                Console.WriteLine("");

                GildedRose.UpdateQuality(items);
            }

            Console.ReadLine();
        }
    }
}
