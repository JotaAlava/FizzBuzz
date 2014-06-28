using System.Collections.Generic;
using FizzBuzzCore;

namespace FlexOffersFizzBuzz.DAL.Services
{
    internal static class ServicesHelpers
    {
        internal static object TypeFactory(string typeOfObjectToUse)
        {
            switch (typeOfObjectToUse)
            {
                case "Cake":
                    return GetCake();
            }

            return null;
        }

        // For now this is where we determine how much objects are "worth"; for purposes of the division.
        private static Cake GetCake()
        {
            return new Cake("Chocolate", 10);
        }
    }
}
