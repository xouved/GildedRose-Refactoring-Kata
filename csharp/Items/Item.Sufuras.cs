using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp
{
    public class Sufuras : Item
    {
        public override string Name { get { return "Sulfuras, Hand of Ragnaros"; } set { Name = value; } }
        public override int SellIn { get; set; }
        public override int Quality { get; set; }

        public Sufuras(int sellIn)
        {
            SellIn = sellIn;
            Quality = 80;
        }
        public override void UpdateQuality()
        {
            //do nothing
        }

        public override void UpdateSellIn()
        {
            //do nothing
        }
    }
}
