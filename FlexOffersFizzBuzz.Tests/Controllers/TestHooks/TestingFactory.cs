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
    }
}

