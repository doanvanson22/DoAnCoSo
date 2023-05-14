using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Booking_Dental_Clinic.Areas.NhaSi.Controllers
{
    [Authorize(Roles = "NhaSi")]
    public class NhaSiController : Controller
    {
        // GET: NhaSi/NhaSi
        public ActionResult Index()
        {
            return View();
        }
    }
}