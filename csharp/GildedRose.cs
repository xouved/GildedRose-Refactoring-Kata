using System.Collections.Generic;

namespace csharp
{
    public static class GildedRose
    {
        public static void UpdateQuality(IList<Item> items)
        {
            foreach (Item i in items)
            {
                //"Sulfuras", being a legendary item, never has to be sold or decreases in Quality
                if (i.Name != "Sulfuras, Hand of Ragnaros")
                {
                    int denote = 0;
                    if (i.Name == "Aged Brie")
                    {
                        //increases by 1 as usual
                        denote++;
                    }
                    else if (i.Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        //increases by 1 as usual
                        denote++;
                        //increases by 2 when there are 10 days or less
                        if (i.SellIn < 11)
                        {
                            denote++;
                        }
                        //increases by 3 when there are 5 days or less
                        if (i.SellIn < 6)
                        {
                            denote++;
                        }
                    }
                    else
                    {
                        //All items have a Quality value which denotes how valuable the item is
                        denote--;
                        if (i.Name.Contains("Conjured"))
                        {
                            //"Conjured" items degrade in Quality twice as fast as normal items
                            denote = denote * 2;
                        }
                    }
                    
                    //All items have a SellIn value which denotes the number of days we have to sell the item
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

                    // The Quality of an item is never more than 50
                    if (i.Quality > 50)
                    {
                        i.Quality = 50;
                    }
                    //The Quality of an item is never negative
                    else if (i.Quality < 0)
                    {
                        i.Quality = 0;
                    }
                }
            }
        }
    }
}
