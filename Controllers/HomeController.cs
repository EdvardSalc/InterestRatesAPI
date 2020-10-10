using Data.Context;
using System.Linq;
using System.Web.Mvc;

namespace InterestRatesAPI.Controllers
{
    public class HomeController : Controller
    {
        AgreementHandler agreementHandler = new AgreementHandler();
        public ActionResult Index()
        {
            ViewBag.Title = "Demo Page";

            return View();
        }

        public ActionResult GetAgreementData()
        {
            var query = agreementHandler.GetAgreements();
            var agreementsIds = agreementHandler.GetAgreements().Select(a => new { Id = a.Id });

            return Json(agreementsIds.ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}