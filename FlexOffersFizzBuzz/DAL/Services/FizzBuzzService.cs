using FlexOffersFizzBuzz.DAL.Repositories;

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

        internal FizzBuzzServiceResponse GetHistoryOfOperations()
        {
            var result = new FizzBuzzServiceResponse();
            return result;
        }
    }
}