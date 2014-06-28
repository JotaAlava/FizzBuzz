namespace FizzBuzzCore
{
    public struct DividendQuotientPair
    {
        public int Dividend { get; set; }
        public int Quotient { get; set; }

        public DividendQuotientPair(int dividend = -1, int quotient = -1) : this()
        {
            Dividend = dividend;
            Quotient = quotient;
        }
    }
}
