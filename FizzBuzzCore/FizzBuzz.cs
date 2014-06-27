using System.Collections.Generic;
using System.Linq;

namespace FizzBuzzCore
{
    public static class FizzBuzz
    {
        /// <summary>
        /// This method will return an empty FizzBuzzOperationResults. So if count == 0 then an empty collection was passed.
        /// </summary>
        /// <param name="objectToDivide">Object to run throught fizzbuzz!</param>
        /// <param name="lowNumber">Low number to divide by</param>
        /// <param name="highNumber">High number to divide by</param>
        /// <returns></returns>
        public static List<FizzBuzzOperationResults> Run(List<object> objectToDivide, int lowNumber, int highNumber)
        {
            return objectToDivide.Select(obj => ExecuteFizzBuzz(obj, lowNumber, highNumber)).ToList();
        }

        public static FizzBuzzOperationResults ExecuteFizzBuzz(object objectToDivide, int lowNumber, int highNumber)
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
                    if (lowNumber == highNumber)
                    {
                        result.ResultDictionary = new Dictionary<int, int>()
                        {
                            {lowNumber, isImplementingIAmDivisibleInterface.DivibeMe(lowNumber)},
                        };
                    }
                    else
                    {
                        result.ResultDictionary = new Dictionary<int, int>()
                        {
                            {lowNumber, isImplementingIAmDivisibleInterface.DivibeMe(lowNumber)},
                            {highNumber, isImplementingIAmDivisibleInterface.DivibeMe(highNumber)}
                        };
                    }

                    result.logger.LogValidAction(objectToDivide.GetType().ToString(), lowNumber, highNumber, result.RunStatus.ToString());
                }
                else if (divisibleByMaxValue)
                {
                    result.RunStatus = FizzBuzzOperationResultCodes.Buzz;
                    result.logger.LogValidAction(objectToDivide.GetType().ToString(), lowNumber, highNumber, result.RunStatus.ToString());
                }
                else if (divisibleByMinValue)
                {
                    result.RunStatus = FizzBuzzOperationResultCodes.Fizz;
                    result.logger.LogValidAction(objectToDivide.GetType().ToString(), lowNumber, highNumber, result.RunStatus.ToString());
                }
            }
            else
            {
                result.RunStatus = FizzBuzzOperationResultCodes.InvalidType;
                if (objectToDivide == null)
                {
                    result.logger.LogInvalidAction("null", lowNumber, highNumber, result.RunStatus.ToString());
                }
                else
                {
                    result.logger.LogInvalidAction(objectToDivide.GetType().ToString(), lowNumber, highNumber, result.RunStatus.ToString());
                }
            }

            return result;
        }
    }

    public interface IAmDivisible
    {
        bool AmDivisibleBy(int divisor);
        int DivibeMe(int divisor);
    }
}
