using System;
using System.Web.Mvc;
using ExchangeRates.DataService;
using ExchangeRates.Web.Models;

namespace ExchangeRates.Web.Controllers
{
    public class CurrencyController : Controller
    {
        private readonly IManager _manager;

        public CurrencyController()
        {
            var r = ResolveType.GetInstance();
            _manager = r.Manager();
        }

        /// <summary>
        /// First user comes here
        /// </summary>
        public ActionResult Index()
        {
            var c = _manager.GetCurrencies();
            var model = new CurrencyModel(c);
            return View(model);
        }
        
        /// <summary>
        /// Data is passed to display chart
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="list1"></param>
        /// <param name="list2"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(DateTime startDate, DateTime endDate, int list1, int list2)
        {
            var firstDate = new DateTime(1999, 01, 01);
            if (startDate > endDate)
            {
                ViewBag.Error = "Start Date must be smaller or equal to the end date";
            }
            else if (startDate < firstDate || endDate < firstDate)
            {
                ViewBag.Error = "Selected date should not be before 1999.";
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
                var model = _manager.GetRateCollection(startDate, endDate, list1, list2);
                return View("ChartResult", model);
            }
            var c = _manager.GetCurrencies();
            var currencyModel = new CurrencyModel(c);
            return View(currencyModel);
        }

        /// <summary>
        /// Chart is displayed
        /// </summary>
        /// <returns></returns>
        public ActionResult ChartResult()
        {
            return View();
        }
    }
}