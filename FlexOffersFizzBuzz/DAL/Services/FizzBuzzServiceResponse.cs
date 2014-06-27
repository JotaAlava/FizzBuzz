using System;
using System.Collections.Generic;
using FizzBuzzCore;

namespace FlexOffersFizzBuzz.DAL.Services
{
    public class FizzBuzzServiceResponse
    {
        public FizzBuzzServiceResponse()
        {
            
        }

        public FizzBuzzServiceResponse(FizzBuzzOperationResults operationResults)
        {
                
        }

        public FizzBuzzServiceResponse(FizzBuzzServiceResponseCode ServiceResponseCode)
        {

        }

        public FizzBuzzServiceResponse(Exception Exception)
        {

        }

        public FizzBuzzServiceResponse(FizzBuzzOperationResults operationResults, FizzBuzzServiceResponseCode ServiceResponseCode, Exception Exception)
        {

        }

        public List<FizzBuzzOperationResults> OperationResults { get; set; }
        public FizzBuzzServiceResponseCode ServiceResponseCode { get; set; }
        public Exception Exception { get; set; }
    }

    public enum FizzBuzzServiceResponseCode
    {
        GetSuccess,
        PostSuccess,
        GetFailed,
        PostFailed
    }
}
