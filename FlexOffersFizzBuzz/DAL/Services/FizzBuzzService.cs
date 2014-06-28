using System;
using System.Collections.Generic;
using System.Linq;
using FizzBuzzCore;
using FlexOffersFizzBuzz.DAL.Repositories;
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
                result.ServiceCallResults.Add(operation);
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

            var fizzBuzzResult = FizzBuzz.Run(listOfTypesSelected, int.Parse(lowValue), int.Parse(highValue));
            newRecordOfOperation = ProcessRequest(listOfTypesSelected, lowValue, highValue, fizzBuzzResult[0]);

            uow.OperationRepository.Insert(newRecordOfOperation);
            uow.Commit();

            return result;
        }

        private Operation ProcessRequest(List<object> typeOfObjectToUse, string lowValue,
            string highValue, FizzBuzzOperationResults fizzBuzzResult)
        {
            var typeUsed = new List<Models.Type>()
            {
                new Models.Type() {Name = fizzBuzzResult.ResultDictionary.First().Value}
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