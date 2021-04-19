using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp
{
    public class AgedBrie : Item
    {
        public override string Name { get { return "Aged Brie"; } set { Name = value; } }
        public override int SellIn { get; set; }
        public override int Quality { get; set; }

        public AgedBrie(int sellIn, int quality)
        {
            SellIn = sellIn;
            Quality = quality;
        }

        protected override int GetNote()
        {
            int note = 1;

            if (SellIn < 0)
                note *= 2;

            return note;
        }
        public override void CheckQuality()
        {
            if (Quality > 50)
            {
                Quality = 50;
            }
        }
    }
}
