﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingTech.Controllers
{
    public class StoreController : Controller
    {
        // GET: Store
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Browse(string Id)
        {
            return View();
        }

        public ActionResult Details(int Id)
        {
            return View();
        }
    }
}