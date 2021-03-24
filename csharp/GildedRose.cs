using System.Collections.Generic;

namespace csharp
{
    public static class GildedRose
    {
        public static void UpdateQuality(IList<Item> items)
        {
            foreach (Item i in items)
            {
                if (i.Name != "Sulfuras, Hand of Ragnaros")
                {
                    int denote = 0;
                    if (i.Name == "Aged Brie")
                    {
                        denote++;
                    }
                    else if (i.Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        denote++;
                        if (i.SellIn < 11)
                        {
                            denote++;
                        }
                        if (i.SellIn < 6)
                        {
                            denote++;
                        }
                    }
                    else
                    {
                        denote--;
                        if (i.Name.Contains("Conjured"))
                        {
                            //"Conjured" items degrade in Quality twice as fast as normal items
                            denote = denote * 2;
                        }
                    }
                    
                    i.SellIn--;

                    if (i.SellIn < 0)
                    {
                        //Once the sell by date has passed, Quality degrades twice as fast
                        //Quality drops to 0 after the concert
                        if (i.Name == "Backstage passes to a TAFKAL80ETC concert")
                        {
                            i.Quality -= i.Quality;
                            denote = 0;
                        }
                        else
                        {
                            denote = denote * 2;
                        }
                    }
                    //We add the coeficient "denote" to the quality witch he increase or not the value
                    i.Quality += denote;

                    if (i.Quality > 50)
                    {
                        i.Quality = 50;
                    }
                    else if (i.Quality < 0)
                    {
                        i.Quality = 0;
                    }
                }
            }
        }
    }
}
