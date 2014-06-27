using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzCore
{
    public class Cake : FlexOffersFizzBuzzFoodBase
    {
        public Cake(string flavor, int portions)
            : base(portions)
        {
            this.Flavor = flavor;
        }

        public string Flavor { get; set; }
    }
}
