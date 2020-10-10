using Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace InterestRatesAPI.Controllers
{
    public class AgreementController : Controller
    {
        AgreementHandler agreementHandler = new AgreementHandler();
        public ActionResult GetAgreementData()
        {
            var query = agreementHandler.GetAgreements();
            var agreementsIds = agreementHandler.GetAgreements().Select(a => new { Id = a.Id });

            return Json(agreementsIds.ToList(), JsonRequestBehavior.AllowGet);
        }

    }
}