using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleApp.Core.Services;
using SimpleApp.Models;

namespace SimpleApp.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        public DashboardController()
        {
        }

        // GET: Message
        public ActionResult Index()
        {
            return View();
        }
    }
}