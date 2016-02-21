﻿using System;
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
        private readonly ITestMessage _message;

        public DashboardController(ITestMessage message)
        {
            _message = message;
        }

        // GET: Message
        public ActionResult Index(MessageModel model)
        {
            model.TestMessage = _message.GetMessage("Chhai", "18");
            return View(model);
        }
    }
}