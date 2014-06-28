using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using FlexOffersFizzBuzz.DAL.Services;
using FlexOffersFizzBuzz.Models;

namespace FlexOffersFizzBuzz.Controllers
{
    public class FizzBuzzController : ApiController
    {
        private FizzBuzzService _operationService = new FizzBuzzService();

        /// <summary>
        /// This method returns all the Operations in the system as DTOs
        /// Route: api/fizzbuzz/
        /// Verb: GET 
        /// </summary>
        /// <returns></returns>
        public JsonResult<FizzBuzzServiceResponse> Get()
        {
            return Json(_operationService.GetHistoryOfOperations());
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
        public HttpResponseMessage Post(
                [FromUri]string typeOfObjectToUse,
                [FromUri]string lowValue,
                [FromUri]string highValue
            )
        {
            var response = new HttpResponseMessage();

            try
            {
                var resultOfServiceCall =_operationService.CreateRecordOfOperation(typeOfObjectToUse, lowValue, highValue);
                response = Request.CreateResponse(HttpStatusCode.Created, resultOfServiceCall);
            }
            catch (Exception e)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, e);
                throw;
            }

            return response;
        }
    }
}
