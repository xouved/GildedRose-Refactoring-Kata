namespace csharp
{
    public class Item : IFactoryItem
    {
        public virtual string Name { get; set; }
        public virtual int SellIn { get; set; }
        public virtual int Quality { get; set; }


        public override string ToString()
        {
            return this.Name + ", " + this.SellIn + ", " + this.Quality;
        }

        public bool IsConjured()
        {
            return this.Name.Contains("Conjured");
        }
        public virtual void UpdateQuality()
        {
            Quality += GetNote();
            CheckQuality();
        }

        public virtual void UpdateSellIn()
        {
            SellIn--;
        }
         
        protected virtual int GetNote()
        {
            int note = -1;
            if (IsConjured())
                note *= 2;
            if(SellIn < 0 )
                note *= 2;
            return note;
        }

        public virtual void CheckQuality()
        {
            if (Quality > 50)
            {
                Quality = 50;
            }
            if (Quality < 0)
            {
                Quality = 0;
            }
        }
    }
}
