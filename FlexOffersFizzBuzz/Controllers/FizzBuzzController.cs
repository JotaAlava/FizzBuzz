using System.Collections.Generic;
using System.Web.Http;
using FlexOffersFizzBuzz.DAL.Services;

namespace FlexOffersFizzBuzz.Controllers
{
    public class FizzBuzzController : ApiController
    {
        private FizzBuzzService _operationService;

        /// <summary>
        /// This method returns all the Operations in the system as DTOs
        /// Route: api/fizzbuzz/
        /// Verb: GET 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// This method will create a record for the operation performed!
        /// Route: api/fizzbuzz/{values}
        /// Verb: POST
        /// </summary>
        /// <param name="typeOfObjectToUse"> A string matching one of the names in our Type tables </param>
        /// <param name="lowValue"> Low value for FizzBuzz </param>
        /// <param name="highValue"> High value for FizzBuzz </param>
        /// <returns></returns>
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
