using System;
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
            result.ResultDictionary = new Dictionary<DividendQuotientPair, string>();

            if (lowNumber > highNumber)
            {
                result.RunStatus = FizzBuzzOperationResultCodes.LowerNumberIsHigherThanHighNumber;
                return result;
            }

            var isImplementingIAmDivisibleInterface = objectToDivide as IAmDivisible != null;
            var areNumbersEqual = lowNumber == highNumber;
            var objToDivide = objectToDivide as IAmDivisible;

            if (isImplementingIAmDivisibleInterface)
            {
                bool divisibleByMinValue = objToDivide.AmDivisibleBy(lowNumber);
                bool divisibleByMaxValue = objToDivide.AmDivisibleBy(highNumber);

                if (divisibleByMinValue && divisibleByMaxValue)
                {
                    result.RunStatus = FizzBuzzOperationResultCodes.FizzBuzz;
                    result.ResultDictionary = PopulateDicitonary(areNumbersEqual, objToDivide, lowNumber, highNumber);
                    result.logger.LogValidAction(objectToDivide.GetType().ToString(), lowNumber, highNumber, result.RunStatus.ToString());
                }
                else if (divisibleByMaxValue)
                {
                    result.RunStatus = FizzBuzzOperationResultCodes.Buzz;
                    result.ResultDictionary = PopulateDicitonary(areNumbersEqual, objToDivide, lowNumber, highNumber);
                    result.logger.LogValidAction(objectToDivide.GetType().ToString(), lowNumber, highNumber, result.RunStatus.ToString());
                }
                else if (divisibleByMinValue)
                {
                    result.RunStatus = FizzBuzzOperationResultCodes.Fizz;
                    result.ResultDictionary = PopulateDicitonary(areNumbersEqual, objToDivide, lowNumber, highNumber);
                    result.logger.LogValidAction(objectToDivide.GetType().ToString(), lowNumber, highNumber, result.RunStatus.ToString());
                }
            }
            else
            {
                result.RunStatus = FizzBuzzOperationResultCodes.InvalidType;
                if (objectToDivide == null)
                {
                    result.ResultDictionary = PopulateDicitonary(areNumbersEqual, null, lowNumber, highNumber);
                    result.logger.LogInvalidAction("null", lowNumber, highNumber, result.RunStatus.ToString());
                }
                else
                {
                    result.ResultDictionary = PopulateDicitonary(areNumbersEqual, objectToDivide, lowNumber, highNumber);
                    result.logger.LogInvalidAction(objectToDivide.GetType().ToString(), lowNumber, highNumber, result.RunStatus.ToString());
                }
            }

            return result;
        }

        private static Dictionary<DividendQuotientPair, string> PopulateDicitonary(bool areNumbersEqual, IAmDivisible objectToDivide, int lowNumber, int highNumber)
        {
            string typeAsString = String.Empty;
            if (objectToDivide == null)
            {
                typeAsString = "null";
                return new Dictionary<DividendQuotientPair, string>()
                {
                    {new DividendQuotientPair(), typeAsString},
                };
            }

            typeAsString = objectToDivide.GetType().ToString();

            if (areNumbersEqual)
            {
                return new Dictionary<DividendQuotientPair, string>()
                        {
                            {new DividendQuotientPair(lowNumber, objectToDivide.DivibeMe(lowNumber)), typeAsString},
                        };
            }
            return new Dictionary<DividendQuotientPair, string>()
                        {
                            {new DividendQuotientPair(lowNumber, objectToDivide.DivibeMe(lowNumber)), typeAsString},
                            {new DividendQuotientPair(highNumber, objectToDivide.DivibeMe(highNumber)), typeAsString},
                        };
        }

        private static Dictionary<DividendQuotientPair, string> PopulateDicitonary(bool areNumbersEqual, object objectToDivide, int lowNumber, int highNumber)
        {
            string typeAsString = String.Empty;
            if (objectToDivide == null)
            {
                typeAsString = "null";
                return new Dictionary<DividendQuotientPair, string>()
                {
                    {new DividendQuotientPair(), typeAsString},
                };
            }

            typeAsString = objectToDivide.GetType().ToString();

            if (areNumbersEqual)
            {
                return new Dictionary<DividendQuotientPair, string>()
                        {
                            {new DividendQuotientPair(), typeAsString},
                        };
            }
            return new Dictionary<DividendQuotientPair, string>()
                        {
                            {new DividendQuotientPair(), typeAsString},
                        };
        }
    }

    public interface IAmDivisible
    {
        bool AmDivisibleBy(int divisor);
        int DivibeMe(int divisor);
    }
}
