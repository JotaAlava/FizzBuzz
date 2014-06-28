using System.Collections.Generic;
using System.Diagnostics;
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
                case "Stopwatch":
                    return GetStopwatch();
                case "Null":
                    return GetNull();
                case "Int32":
                    return GetInt();
            }

            return null;
        }

        private static object GetInt()
        {
            return 1;
        }

        private static object GetNull()
        {
            return null;
        }

        private static Stopwatch GetStopwatch()
        {
            return new Stopwatch();
        }

        // For now this is where we determine how much objects are "worth"; for purposes of the division.
        private static Cake GetCake()
        {
            return new Cake("Chocolate", 10);
        }
    }
}
