using FlexOffersFizzBuzz.DAL.Services;
using Microsoft.AspNet.SignalR;

namespace FlexOffersFizzBuzz.Hubs
{
    public class FizzBuzzHub: Hub
    {
        private FizzBuzzService _fizzBuzzService = new FizzBuzzService();

        public void Post(string typeOfObjectToUse, string lowValue, string highValue)
        {
            var data = _fizzBuzzService.CreateRecordOfOperation(typeOfObjectToUse, lowValue, highValue);
            Clients.All.runFizzBuzz(data);
        }

    }
}