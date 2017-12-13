using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HomeWork.Models;

namespace HomeWork.Controllers
{
    public class CustomerContactController : Controller
    {
        客戶聯絡人Repository repo = RepositoryHelper.Get客戶聯絡人Repository();
        客戶資料Repository repo2 = RepositoryHelper.Get客戶資料Repository();

        // GET: CostomerContact
        public ActionResult Index(string keyword)
        {
            var query = repo.All();

            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(m => m.姓名.Contains(keyword));

            }
            return View(query.ToList());
        }

        // GET: CostomerContact/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶聯絡人 客戶聯絡人 = repo.Find(id);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            return View(客戶聯絡人);
        }

        // GET: CostomerContact/Create
        public ActionResult Create()
        {
            //ViewBag.客戶Id = new SelectList(db.客戶資料, "Id", "客戶名稱");
            客戶聯絡人 客戶聯絡人 = new 客戶聯絡人();
            InitDropDownList(客戶聯絡人);

            return View();
        }

        // POST: CostomerContact/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,客戶Id,職稱,姓名,Email,手機,電話")] 客戶聯絡人 客戶聯絡人)
        {
            if (ModelState.IsValid)
            {
                repo.Add(客戶聯絡人);
                repo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }
            InitDropDownList(客戶聯絡人);

            return View(客戶聯絡人);
        }

        // GET: CostomerContact/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶聯絡人 客戶聯絡人 = repo.Find(id);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            InitDropDownList(客戶聯絡人);
            return View(客戶聯絡人);
        }

        // POST: CostomerContact/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,客戶Id,職稱,姓名,Email,手機,電話")] 客戶聯絡人 客戶聯絡人)
        {
            if (ModelState.IsValid)
            {
                repo.Update(客戶聯絡人);
                repo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }
            InitDropDownList(客戶聯絡人);

            return View(客戶聯絡人);
        }

        // GET: CostomerContact/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶聯絡人 客戶聯絡人 = repo.Find(id);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            return View(客戶聯絡人);
        }

        // POST: CostomerContact/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            客戶聯絡人 客戶聯絡人 =repo.Find(id);
            repo.Delete(客戶聯絡人);
            repo.UnitOfWork.Commit();

            return RedirectToAction("Index");
        }

        private void InitDropDownList(客戶聯絡人 客戶聯絡人)
        {
            List<SelectListItem> data = new List<SelectListItem>();
            foreach(客戶資料 m in repo2.All())
            {
                data.Add(new SelectListItem { Text = m.客戶名稱, Value = m.Id.ToString() });
            }
        }
    }
}
