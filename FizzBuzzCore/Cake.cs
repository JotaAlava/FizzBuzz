namespace FizzBuzzCore
{
    public class Cake : IAmDivisible
    {
        /// <summary>
        /// Le handy constructor
        /// </summary>
        /// <param name="flavor"> Ze flavor of ze cake </param>
        /// <param name="portions"> Le number of portions left </param>
        public Cake(string flavor, int portions)
        {
            this.Flavor = flavor;
            this.Portions = portions;
        }

        /// <summary>
        /// Flavor of the cake!
        /// </summary>
        public string Flavor { get; set; }

        /// <summary>
        /// How many portions are left!
        /// </summary>
        public int Portions { get; set; }


        /// <summary>
        /// Is the current number of portions divisible by the number specified
        /// </summary>
        /// <param name="divisor"> Number to divide our object by </param>
        /// <returns> Returns true if divisble, false if not divisible. </returns>
        public bool AmDivisibleBy(int divisor)
        {
            // Portions is the dividen in this operation
            if (divisor != 0 && Portions % divisor == 0)
            {
                return true;
            }

            return false;
        }


        public int DivibeMe(int divisor)
        {
            return this.Portions/divisor;
        }


        public int WhatAmIWorth()
        {
            return Portions;
        }
    }
}
