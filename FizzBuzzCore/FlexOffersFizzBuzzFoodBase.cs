using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzCore
{
    public class FlexOffersFizzBuzzFoodBase
    {
        public FlexOffersFizzBuzzFoodBase(int portions)
        {
            this.Portions = portions;
        }
        public int Portions { get; set; }
        public static int operator /(FlexOffersFizzBuzzFoodBase self, int numberToDivideBy)
        {
            return self.Portions / numberToDivideBy;
        }
    }
}
