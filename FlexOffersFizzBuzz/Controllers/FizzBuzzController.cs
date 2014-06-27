using System.Collections.Generic;
using System.Web.Http;
using FlexOffersFizzBuzz.DAL.Services;

namespace FlexOffersFizzBuzz.Controllers
{
    public class FizzBuzzController : ApiController
    {
        private FizzBuzzService _operationService;
        // GET api/fizzbuzz/
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // POST api/fizzbuzz/{values}
        public string Post(
                [FromUri]string typeOfObjectToUse,
                [FromUri]string lowValue,
                [FromUri]string highValue
            )
        {
            return "success";
        }
    }
}
