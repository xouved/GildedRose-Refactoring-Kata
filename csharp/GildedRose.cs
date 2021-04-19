using System.Collections.Generic;

namespace csharp
{
    public static class GildedRose
    {
        public static void UpdateQuality(IList<Item> items)
        {
            foreach (Item item in items)
            {
                item.UpdateSellIn();
                item.UpdateQuality();
            }
        }
    }
}
