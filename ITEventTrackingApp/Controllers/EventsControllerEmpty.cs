using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITEventTrackingApp.Controllers
{
    public class EventsControllerEmpty : Controller
    {
        // GET: Events
        public ActionResult Index()
        {
            return View();
        }
    }
}