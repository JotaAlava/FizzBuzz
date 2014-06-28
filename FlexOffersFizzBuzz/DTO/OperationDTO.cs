using System.Linq;
using FlexOffersFizzBuzz.Models;

namespace FlexOffersFizzBuzz.DTO
{
    public class OperationDTO
    {
        public OperationDTO(Operation operationToConvert)
        {
            this.HighNumber = operationToConvert.HighNumber;
            this.LowNumber = operationToConvert.LowNumber;
            this.Result = operationToConvert.Result;
            this.Output = operationToConvert.Output;
            this.Types = operationToConvert.Types.First().Name;
        }
        public int    HighNumber { get; set; }
        public int    LowNumber { get; set; }
        public string Result { get; set; }
        public string Output { get; set; }
        public string Types { get; set; }
    }
}