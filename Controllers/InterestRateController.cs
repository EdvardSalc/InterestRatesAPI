using Data.Context;
using Data.DTO;
using Data.Models;
using InterestRatesAPI.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InterestRatesAPI.Controllers
{
    public class InterestRateController : ApiController
    {
        private AgreementHandler agreementHandler = new AgreementHandler();
        private CustomerHandler customerHandler= new CustomerHandler();
        private InterestRateService interestRateService = new InterestRateService();

            public HttpResponseMessage GetInterestRate(int agreementId, string baseRateCode)
        {

           

            RateResponse response = new RateResponse();
            try
            {
                AgreementDTO agreement = agreementHandler.GetAgreement((int)agreementId);

               bool isValid = interestRateService.ValidateRequestParams(agreement, baseRateCode);

                if (isValid)
                {
                    CustomerDTO customer = customerHandler.GetCustomerByAgreementId(agreementId);
                    response = interestRateService.GetRatesInformation(agreement, baseRateCode);
                    response.agreement = agreement;
                    response.customer = customer;

                    return Request.CreateResponse(HttpStatusCode.OK, response, Configuration.Formatters.JsonFormatter);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Wrong parameters", Configuration.Formatters.JsonFormatter);

                }

            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK, e.InnerException, Configuration.Formatters.JsonFormatter);

            }

            
        }



    }
}
