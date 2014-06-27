namespace FizzBuzzCore
{
    public static class FizzBuzz
    {
        public static FizzBuzzOperationResults Run(object objectToDivide, int lowNumber, int highNumber)
        {
            var result = new FizzBuzzOperationResults();
            var isImplementingIAmDivisibleInterface = objectToDivide as IAmDivisible;

            if (isImplementingIAmDivisibleInterface != null)
            {
                bool divisibleByMinValue = isImplementingIAmDivisibleInterface.AmDivisibleBy(lowNumber);
                bool divisibleByMaxValue = isImplementingIAmDivisibleInterface.AmDivisibleBy(highNumber);

                if (divisibleByMinValue && divisibleByMaxValue)
                {
                    result.RunStatus = FizzBuzzOperationResultCodes.FizzBuzz;
                    result.logger.LogValidAction(objectToDivide.GetType(), lowNumber, highNumber, result.RunStatus.ToString());
                }
                else if (divisibleByMaxValue)
                {
                    result.RunStatus = FizzBuzzOperationResultCodes.Buzz;
                    result.logger.LogValidAction(objectToDivide.GetType(), lowNumber, highNumber, result.RunStatus.ToString());
                }
                else if (divisibleByMinValue)
                {
                    result.RunStatus = FizzBuzzOperationResultCodes.Fizz;
                    result.logger.LogValidAction(objectToDivide.GetType(), lowNumber, highNumber, result.RunStatus.ToString());
                }
            }
            else
            {
                result.RunStatus = FizzBuzzOperationResultCodes.InvalidType;
                result.logger.LogInvalidAction(objectToDivide.GetType(), lowNumber, highNumber, result.RunStatus.ToString());
            }
            return result;
        }
    }

    public interface IAmDivisible
    {
        bool AmDivisibleBy(int divisor);
    }
}
