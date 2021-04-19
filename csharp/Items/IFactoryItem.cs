using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp
{
    public interface IFactoryItem
    {
        void UpdateQuality();
        void UpdateSellIn();
        void CheckQuality();
        bool IsConjured();

    }
}
