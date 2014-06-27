using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FizzBuzzCore
{
    public class FizzBuzzOperationResults
    {
        /// <summary>
        /// Our good'ol contructor!
        /// </summary>
        public FizzBuzzOperationResults(Exception exception, Dictionary<int, int> resultDictionary)
        {
            this.Exception = exception;
            this.ResultDictionary = resultDictionary;
        }

        /// <summary>
        /// This property will help us buble up the errors to a logger or perhaps the GUI.
        /// </summary>
        public Exception Exception { get; set; }

        /// <summary>
        /// This property stores a index of operation - result pair.
        /// Key: Number of times the operatoin ocurred.
        /// Value: Result of operation.
        /// </summary>
        public Dictionary <int, int> ResultDictionary { get; set; }
    }
}
