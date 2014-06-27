using System.Collections.Generic;

namespace FlexOffersFizzBuzz.Models
{
    public class Operation
    {
        /// <summary>
        /// This tracks the type of each of the elements inside the list of objects
        /// </summary>
        public List<string> TypesInsideCollection { get; set; }

        /// <summary>
        /// The low number that was used for this operation
        /// </summary>
        public int LowNumber { get; set; }

        /// <summary>
        /// The high number that was used for this operation
        /// </summary>
        public int HighNumber { get; set; }

        /// <summary>
        /// The string that was displayed on the screen after this an operation was executed.
        /// </summary>
        public string Output { get; set; }

        /// <summary>
        /// The actual FlexOffersFizzBuzzOperationResult Enum value as a string
        /// </summary>
        public string Result { get; set; }
    }
}