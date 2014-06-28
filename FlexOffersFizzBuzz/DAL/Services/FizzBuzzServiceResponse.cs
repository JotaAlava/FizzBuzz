using System;
using System.Collections.Generic;
using FizzBuzzCore;
using FlexOffersFizzBuzz.DTO;

namespace FlexOffersFizzBuzz.DAL.Services
{
    public class FizzBuzzServiceResponse
    {
        public FizzBuzzServiceResponse()
        {
            this.OperationResults = new List<FizzBuzzOperationResults>();
            this.ServiceCallResults = new List<OperationDTO>();
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

        /// <summary>
        /// This is what the POST method returns.
        /// </summary>
        public List<FizzBuzzOperationResults> OperationResults { get; set; }

        /// <summary>
        /// This is what the GET method returns.
        /// </summary>
        public List<OperationDTO> ServiceCallResults { get; set; }
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
