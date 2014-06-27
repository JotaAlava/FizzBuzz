namespace FizzBuzzCore
{
    /// <summary>
    /// This class is deprecated. I have changed my approach.
    /// </summary>
    public class FlexOffersFizzBuzzFoodBase
    {
        /// <summary>
        /// A constructor is here!
        /// </summary>
        /// <param name="portions"> This number is very important, this is the number that will be used for division </param>
        public FlexOffersFizzBuzzFoodBase(int portions)
        {
            this.Portions = portions;
        }

        /// <summary>
        /// This is the number that will be used for the division of the object
        /// </summary>
        public int Portions { get; set; }

        /// <summary>
        /// This is the overwriten operator in order to be able to divide objects that inherti from this class
        /// </summary>
        /// <param name="self"> The object to divide </param>
        /// <param name="numberToDivideBy"> The number of division for the object </param>
        /// <returns></returns>
        public static int operator /(FlexOffersFizzBuzzFoodBase self, int numberToDivideBy)
        {
            return self.Portions / numberToDivideBy;
        }
    }
}
