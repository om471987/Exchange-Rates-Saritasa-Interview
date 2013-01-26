using System;
using System.Web.Mvc;
using ExchangeRates.Web.Models;

namespace ExchangeRates.Web.Controllers
{
    public class CurrencyController : Controller
    {
        public ActionResult Index()
        {
            var c = DatabaseWrapper.GetCurrencies();
            var model = new CurrencyModel(c);
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(DateTime startDate, DateTime endDate, int list1, int list2)
        {
            if (startDate > endDate)
            {
                ViewBag.Error = "Start Date must be smaller or equal to the end date";
            }
            else if (startDate > DateTime.Now || endDate > DateTime.Now)
            {
                ViewBag.Error = "Selected date should not be from future.";
            }
            else if (list1 == list2)
            {
                ViewBag.Error = "Please select different currencies for comapring.";
            }
            else if (startDate <= endDate.AddDays(-60))
            {
                ViewBag.Error = "Please select dates in the range of 60 days.";
            }
            else
            {
                var manager = new Manager();
                var model = manager.GetData(startDate, endDate, list1, list2);
                return View("ChartResult", model);
            }
            var c = DatabaseWrapper.GetCurrencies();
            var currencyModel = new CurrencyModel(c);
            return View(currencyModel);
        }

        public ActionResult ChartResult()
        {
            return View();
        }
    }
}



