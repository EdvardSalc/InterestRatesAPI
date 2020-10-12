using Data.DTO;
using Data.Models;
using Microsoft.Ajax.Utilities;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Xml.Serialization;

namespace InterestRatesAPI.Services
{
    public class InterestRateService
    {
        public InterestRateService()
        {
        }

        public RateResponse GetRatesInformation(AgreementDTO agreement, string baseRateCode)
        {
            RateResponse rateResponse = new RateResponse();
            HttpClient client = new HttpClient();

            rateResponse.newInterestRate = GetInterestRateFromLBWeb(baseRateCode, agreement.Margin, client);
            rateResponse.currentInterestRate = GetInterestRateFromLBWeb(agreement.BaseRateCode, agreement.Margin, client);
            rateResponse.differenceBetweenRates= GetDifferenceBetweenRates(rateResponse.newInterestRate, rateResponse.currentInterestRate);

            return rateResponse;
        }

        public decimal GetInterestRateFromLBWeb(string baseRateCode, decimal agreementMargin, HttpClient client)
        {
            string url = string.Format("http://www.lb.lt/webservices/VilibidVilibor/VilibidVilibor.asmx/getLatestVilibRate?RateType={0}", baseRateCode);
            var response = client.GetAsync(url).Result;
            var responseString = response.Content.ReadAsStringAsync().Result;

            XmlSerializer serializer = new XmlSerializer(typeof(VilibidVilibor));
            StringReader sr = new StringReader(responseString);
            VilibidVilibor vilibidVilibor = (VilibidVilibor)serializer.Deserialize(sr);

            decimal baseRate = vilibidVilibor.Decimal;
            decimal result = baseRate + agreementMargin;

            return  result;
        }

        public decimal GetDifferenceBetweenRates(decimal oldRate, decimal newRate)
        {
            decimal result = oldRate - newRate;
            return result;
        }


        public bool ValidateRequestParams(AgreementDTO agreement, string baseRateCode)
        {
            string[] baseRateCodes = new string[]
                {
                    "VILIBOR1m",
                    "VILIBOR3m",
                    "VILIBOR6m",
                    "VILIBOR1y"
                };


            bool isValid = false;

            if (agreement != null && baseRateCodes.Contains(baseRateCode))
            {
                isValid = true;
            }


            return isValid;
        }


    }





    [XmlRoot(ElementName = "decimal", Namespace = "http://webservices.lb.lt/VilibidVilibor")]
    public class VilibidVilibor
    {
        [XmlAttribute(AttributeName = "xmlns")]
        public string Xmlns { get; set; }
        [XmlText]
        public decimal Decimal { get; set; }
    }

}