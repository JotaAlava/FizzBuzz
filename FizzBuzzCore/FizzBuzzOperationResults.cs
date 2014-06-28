using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlexOffersLogger;

namespace FizzBuzzCore
{
    public class FizzBuzzOperationResults
    {
        /// <summary>
        /// Default Ctor
        /// </summary>
        public FizzBuzzOperationResults()
        {
            
        }

        /// <summary>
        /// Our good'ol contructor!
        /// </summary>
        public FizzBuzzOperationResults(FizzBuzzOperationResultCodes operationResult)
        {
            this.RunStatus = operationResult;
            this.ResultDictionary = new Dictionary<DividendQuotientPair, string>();
        }

        /// <summary>
        /// This constructor is a test hook
        /// </summary>
        /// <param name="operationResult"> Count of operation results </param>
        public FizzBuzzOperationResults(FizzBuzzOperationResultCodes operationResult, Dictionary<DividendQuotientPair, string> resultDicitonary )
        {
            this.RunStatus = operationResult;
            this.ResultDictionary = resultDicitonary;
        }

        /// <summary>
        /// Will tell whoever is consuming this code what the result of the operation was
        /// </summary>
        public FizzBuzzOperationResultCodes RunStatus { get; set; }

        /// <summary>
        /// This property stores a index of operation - result pair.
        /// Key: Number used to for division.
        /// Value: Result of the operation.
        /// </summary>
        public Dictionary<DividendQuotientPair, string> ResultDictionary { get; set; }

        /// <summary>
        /// The logger will write to a text file in the system everytime an operation is performed.
        /// </summary>
        public FizzBuzzLogger logger = new FizzBuzzLogger();

        /// <summary>
        /// This overrides the toString in order to save the result as english in the Db
        /// </summary>
        /// <returns> English representation of the operation result </returns>
        public override string ToString()
        {
            var result = new StringBuilder();
            if (RunStatus == FizzBuzzOperationResultCodes.InvalidType ||
                RunStatus == FizzBuzzOperationResultCodes.LowerNumberIsHigherThanHighNumber
                || RunStatus == FizzBuzzOperationResultCodes.ObjectValueIsZero)
            {
                result.Append(String.Format("Output: {0}.\n\n\t\t\t-Results-\n\n", RunStatus.ToString()));

                // I use a for loop because I cannot access a dictionary by index, much easier to take advantage of this!
                foreach (var operation in ResultDictionary)
                {
                    var timesIterated = 0;

                    if (timesIterated == 0)
                    {
                        result.Append(String.Format("\tDivided:{0} by: {1}. - {1} is the lower number input.\n\n", operation.Key, operation.Value));
                    }
                    else
                    {
                        result.Append(String.Format("\tDivided:{0} by: {1}. - {1} is the higher number input.\n\n", operation.Key, operation.Value));
                    }

                    timesIterated++;
                }
            }
            else
            {
                result.Append(String.Format("<{1}> - N/A\n\nError Details: {0}", RunStatus, ResultDictionary.First().Value));
            }
            

            return result.ToString();
        }
    }

    public enum FizzBuzzOperationResultCodes
    {
        // Object has a mathematical value of 0 (ie. Can lead to 0 / 0) - INVALID PARTITION ERROR 1
        ObjectValueIsZero,
        // If the object does not implement the IAmDivisible interface - INVALID PARTITION ERROR 2
        InvalidType,
        // If the object is divisible by the low number then output the word "Fizz"
        Fizz,
        // If the object is divisible by the high number then output the word "Buzz"
        Buzz,
        // If the object is divisible by both numbers then output the word "FizzBuzzz"
        FizzBuzz,
        // To catch any sneaky mofos! - INVALID PARTITION ERROR 3
        LowerNumberIsHigherThanHighNumber 
    }
}
