using System.Collections.Generic;
using FizzBuzzCore;
using FlexOffersFizzBuzz.DAL.Repositories;
using FlexOffersFizzBuzz.DAL.Services;

namespace FlexOffersFizzBuzz.Tests.Controllers.TestHooks
{
    internal class TestingFactory
    {
        public static FizzBuzzService GetFizzBuzzService()
        {
            var testingContext = new EFTestHookContext("FlexOffersFizzBuzzTestDb");
            var unitOfWorkAssembledWithTestingContext = new UnitOfWork(testingContext);

            return new FizzBuzzService(unitOfWorkAssembledWithTestingContext);
        }

        public static Dictionary<DividendQuotientPair, string> GetDictionary(int numberOfSimilarResults)
        {
            var result = new Dictionary<DividendQuotientPair, string>();
            for (int i = 0; i < numberOfSimilarResults; i++)
            {
                result.Add(new DividendQuotientPair(i, 1), "damage");
            }

            return result;
        }

        public static Dictionary<DividendQuotientPair, string> GetDictionary()
        {
            return new Dictionary<DividendQuotientPair, string>()
            {
                { new DividendQuotientPair(1,1), "damage" },
            };
        }

        public static Dictionary<DividendQuotientPair, string> GetDictionary(int lowValue, int highValue, int resultOfDivisionWithLow, int resultOfDivisionWithHigh)
        {
            return new Dictionary<DividendQuotientPair, string>()
            {
                { new DividendQuotientPair(lowValue, resultOfDivisionWithLow), "damage" },
                { new DividendQuotientPair(highValue, resultOfDivisionWithHigh), "damage" }
            };
        }
    }
}

