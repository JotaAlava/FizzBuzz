using System.Collections.Generic;
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
        public Dictionary<int, int> ResultDictionary { get; set; }

        /// <summary>
        /// The logger will write to a text file in the system everytime an operation is performed.
        /// </summary>
        public FizzBuzzLogger logger = new FizzBuzzLogger();
    }

    public enum FizzBuzzOperationResultCodes
    {
        // Object has a mathematical value of 0 (ie. Can lead to 0 / 0)
        ObjectValueIsZero,
        // If the object does not implement the IAmDivisible interface
        InvalidType,
        // If the object is divisible by the low number then output the word "Fizz"
        Fizz,
        // If the object is divisible by the high number then output the word "Buzz"
        Buzz,
        // If the object is divisible by both numbers then output the word "FizzBuzzz"
        FizzBuzz
    }
}
