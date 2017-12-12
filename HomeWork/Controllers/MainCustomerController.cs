using HomeWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeWork.Controllers
{
    public class MainCustomerController : Controller
    {
        private 客戶資料Entities db = new 客戶資料Entities();

        // GET: MainCustomer
        public ActionResult Index()
        {
            var query = db.NewTable.AsQueryable();

            return View(query.ToList());
        }
    }
}