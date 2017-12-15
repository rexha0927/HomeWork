using HomeWork.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace HomeWork.Controllers
{
    public class CustomerController : Controller
    {
        客戶資料Repository repo = RepositoryHelper.Get客戶資料Repository();
        客戶資料Entities db = new 客戶資料Entities();

        // GET: Customer
        public ActionResult Index(string keyword)
        {
            var query = repo.All();

            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(m => m.客戶名稱.Contains(keyword));

            }
            PrepareViewBag();
            return View(query.ToList());
        }

        // GET: Customer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶資料 客戶資料 = repo.Find(id);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            PrepareViewBag();
            return View();
        }

        // POST: Customer/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,客戶名稱,統一編號,電話,傳真,地址,Email,客戶分類")] 客戶資料 客戶資料)
        {
            if (ModelState.IsValid)
            {
                db.客戶資料.Add(客戶資料);
                db.SaveChanges();
                //repo.Add(客戶資料)
                //repo.Update(客戶資料);
                //repo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }
            PrepareViewBag();
            //客戶資料.客戶分類清單= Get客戶分類清單();
            //ViewData.Model = 客戶資料;

            return View(客戶資料);
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶資料 客戶資料 = repo.Find(id);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            PrepareViewBag();
            return View(客戶資料);
        }

        // POST: Customer/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,客戶名稱,統一編號,電話,傳真,地址,Email")] 客戶資料 客戶資料)
        {
            if (ModelState.IsValid)
            {
                repo.Update(客戶資料);
                repo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }

            return View(客戶資料);
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶資料 客戶資料 = repo.Find(id);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        // POST: Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            客戶資料 客戶資料 = repo.Find(id);

            客戶資料.IsDelete = true;
            repo.Delete(客戶資料);
            repo.UnitOfWork.Commit();

            return RedirectToAction("Index");
        }

        public void PrepareViewBag()
        {
            //鈦金會員/白金會員/金牌會員/一般會員
            ViewBag.CustomerType = new List<SelectListItem>()
                        {
                            new SelectListItem { Value = "T", Text = "鈦金會員" },
                            new SelectListItem { Value = "P", Text = "白金會員" },
                            new SelectListItem { Value = "G", Text = "金牌會員" },
                            new SelectListItem { Value = "S", Text = "一般會員" }
                        };
        }
    }
}
