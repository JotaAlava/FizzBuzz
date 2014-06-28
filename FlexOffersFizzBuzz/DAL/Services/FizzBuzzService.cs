using System;
using System.Collections.Generic;
using System.Linq;
using FizzBuzzCore;
using FlexOffersFizzBuzz.DAL.Repositories;
using FlexOffersFizzBuzz.DTO;
using FlexOffersFizzBuzz.Models;

namespace FlexOffersFizzBuzz.DAL.Services
{
    public class FizzBuzzService
    {
        private IUnitOfWork uow;

        public FizzBuzzService()
        {
            uow = new UnitOfWork();
        }

        public FizzBuzzService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public FizzBuzzServiceResponse GetHistoryOfOperations()
        {
            var result = new FizzBuzzServiceResponse();
            var operationsInDb = uow.OperationRepository.Get();

            foreach (var operation in operationsInDb)
            {
                result.ServiceCallResults.Add(new OperationDTO(operation));
            }

            return result;
        }

        public FizzBuzzServiceResponse CreateRecordOfOperation(string typeOfObjectToUse, string lowValue, string highValue)
        {
            var result = new FizzBuzzServiceResponse();
            Operation newRecordOfOperation;

            var listOfTypesSelected = new List<object>()
            {
                ServicesHelpers.TypeFactory(typeOfObjectToUse)
            };

            var fizzBuzzResult = FizzBuzz.Run(listOfTypesSelected, Int32.Parse(lowValue), Int32.Parse(highValue));
            newRecordOfOperation = ProcessRequest(typeOfObjectToUse, lowValue, highValue, fizzBuzzResult[0]);
            result.ServiceCallResults.Add(new OperationDTO(newRecordOfOperation));

            uow.OperationRepository.Insert(newRecordOfOperation);
            uow.Commit();

            return result;
        }

        private Operation ProcessRequest(string typeOfObjectToUse, string lowValue,
            string highValue, FizzBuzzOperationResults fizzBuzzResult)
        {
            var typeUsed = new List<Models.Type>()
            {
                new Models.Type() {Name = typeOfObjectToUse}
            };

            var result = new Operation()
            {
                LowNumber = int.Parse(lowValue),
                HighNumber = int.Parse(highValue),
                DateExecuted = DateTime.Now,
                Output = fizzBuzzResult.RunStatus.ToString(),
                Result = fizzBuzzResult.ToString(),
                Types = typeUsed
            };

            return result;
        }
    }
}