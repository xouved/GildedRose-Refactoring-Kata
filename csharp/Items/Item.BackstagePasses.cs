using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp
{
    public class BackstagePasses : Item
    {
        public override string Name { get { return "Backstage passes to a TAFKAL80ETC concert"; } set { Name = value; } }
        public override int SellIn { get; set; }
        public override int Quality { get; set; }

        public BackstagePasses(int sellIn, int quality)
        {
            SellIn = sellIn;
            Quality = quality;
        }
        protected override int GetNote()
        {
            int note = 1;
            if (SellIn < 10)
            {
                note++;
            }
            if (SellIn < 5)
            {
                note++;
            }
            if (SellIn < 0)
            {
                note = -Quality;
            }
            return note;
        }
    }
}
