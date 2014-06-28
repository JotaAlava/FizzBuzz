namespace FizzBuzzCore
{
    public struct DividendQuotientPair
    {
        /// <summary>
        /// This is basically the value of the object. NOTE: Dividend = Divisor x Quotient
        /// </summary>
        public int Dividend { get; set; }
        public int Quotient { get; set; }

        public DividendQuotientPair(int dividend = -1, int quotient = -1) : this()
        {
            Dividend = dividend;
            Quotient = quotient;
        }
    }
}
