using HomeWork.Models;
using System.Linq;
using System.Web.Mvc;

namespace HomeWork.Controllers
{
    public class MainCustomerController : Controller
    {
        //NewTableRepository repo = new NewTableRepository();
        private 客戶資料Entities db = new 客戶資料Entities();

        // GET: MainCustomer
        public ActionResult Index()
        {
            var query = db.VW客戶關聯資料統計表.AsQueryable();

            return View(query.ToList());
        }
    }
}