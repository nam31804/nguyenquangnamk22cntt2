using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NguyenQuangNamK22CNTT2.Models;

namespace NguyenQuangNamK22CNTT2.Controllers
{
    public class ctdonhangsController : Controller
    {
        private NguyenQuangNamK22CNTT2Entities db = new NguyenQuangNamK22CNTT2Entities();

        // GET: ctdonhangs
        public ActionResult Index()
        {
            var ctdonhangs = db.ctdonhangs.Include(c => c.donhang).Include(c => c.sanpham);
            return View(ctdonhangs.ToList());
        }

        // GET: ctdonhangs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ctdonhang ctdonhang = db.ctdonhangs.Find(id);
            if (ctdonhang == null)
            {
                return HttpNotFound();
            }
            return View(ctdonhang);
        }

        // GET: ctdonhangs/Create
        public ActionResult Create()
        {
            ViewBag.donhang_id = new SelectList(db.donhangs, "donhang_id", "trangthai");
            ViewBag.tranhve_id = new SelectList(db.sanphams, "tranhve_id", "tieude");
            return View();
        }

        // POST: ctdonhangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "orderdetails_id,donhang_id,tranhve_id,soluong,gia")] ctdonhang ctdonhang)
        {
            if (ModelState.IsValid)
            {
                db.ctdonhangs.Add(ctdonhang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.donhang_id = new SelectList(db.donhangs, "donhang_id", "trangthai", ctdonhang.donhang_id);
            ViewBag.tranhve_id = new SelectList(db.sanphams, "tranhve_id", "tieude", ctdonhang.tranhve_id);
            return View(ctdonhang);
        }

        // GET: ctdonhangs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ctdonhang ctdonhang = db.ctdonhangs.Find(id);
            if (ctdonhang == null)
            {
                return HttpNotFound();
            }
            ViewBag.donhang_id = new SelectList(db.donhangs, "donhang_id", "trangthai", ctdonhang.donhang_id);
            ViewBag.tranhve_id = new SelectList(db.sanphams, "tranhve_id", "tieude", ctdonhang.tranhve_id);
            return View(ctdonhang);
        }

        // POST: ctdonhangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "orderdetails_id,donhang_id,tranhve_id,soluong,gia")] ctdonhang ctdonhang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ctdonhang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.donhang_id = new SelectList(db.donhangs, "donhang_id", "trangthai", ctdonhang.donhang_id);
            ViewBag.tranhve_id = new SelectList(db.sanphams, "tranhve_id", "tieude", ctdonhang.tranhve_id);
            return View(ctdonhang);
        }

        // GET: ctdonhangs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ctdonhang ctdonhang = db.ctdonhangs.Find(id);
            if (ctdonhang == null)
            {
                return HttpNotFound();
            }
            return View(ctdonhang);
        }

        // POST: ctdonhangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ctdonhang ctdonhang = db.ctdonhangs.Find(id);
            db.ctdonhangs.Remove(ctdonhang);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
