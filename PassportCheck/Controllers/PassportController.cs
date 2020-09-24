using BaseLayer.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PassportCheck.Controllers
{
    public class PassportController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult CheckPassport(string passportNumber)
        {
            var passportService = new PassportService();
            var t = Task.Run(() => passportService.CheckPassport(passportNumber));
            t.Wait();
            var result = t.Result;
            if (result == 1)
            {
                var passportData = passportService.GetPassportData(passportNumber);
                return Json(passportData, JsonRequestBehavior.AllowGet);
            }
            return Json("Номер паспорта не правильный", JsonRequestBehavior.AllowGet);
        }

    }
}