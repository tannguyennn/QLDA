using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project_63132204.Models;

namespace Project_63132204.Areas.Admin.Controllers
{
    public class DichVusAdmin63132204Controller : Controller
    {
        private Project_63132204Entities db = new Project_63132204Entities();

        // GET: Admin/DichVusAdmin63132204
        public ActionResult Index()
        {
            var dichVus = db.DichVus.Include(d => d.LoaiDichVu);
            return View(dichVus.ToList());
        }

        // GET: Admin/DichVusAdmin63132204/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DichVu dichVu = db.DichVus.Find(id);
            if (dichVu == null)
            {
                return HttpNotFound();
            }
            return View(dichVu);
        }

        // GET: Admin/DichVusAdmin63132204/Create
        public ActionResult Create()
        {
            ViewBag.MaLDV = new SelectList(db.LoaiDichVus, "MaLDV", "TenLDV");
            return View();
        }

        // POST: Admin/DichVusAdmin63132204/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDV,TenDV,MaLDV,Gia,TonKho,DonVi,Anh")] DichVu dichVu)
        {
            if (ModelState.IsValid)
            {
                db.DichVus.Add(dichVu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLDV = new SelectList(db.LoaiDichVus, "MaLDV", "TenLDV", dichVu.MaLDV);
            return View(dichVu);
        }

        // GET: Admin/DichVusAdmin63132204/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DichVu dichVu = db.DichVus.Find(id);
            if (dichVu == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLDV = new SelectList(db.LoaiDichVus, "MaLDV", "TenLDV", dichVu.MaLDV);
            return View(dichVu);
        }

        // POST: Admin/DichVusAdmin63132204/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDV,TenDV,MaLDV,Gia,TonKho,DonVi,Anh")] DichVu dichVu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dichVu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLDV = new SelectList(db.LoaiDichVus, "MaLDV", "TenLDV", dichVu.MaLDV);
            return View(dichVu);
        }

        // GET: Admin/DichVusAdmin63132204/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DichVu dichVu = db.DichVus.Find(id);
            if (dichVu == null)
            {
                return HttpNotFound();
            }
            return View(dichVu);
        }

        // POST: Admin/DichVusAdmin63132204/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DichVu dichVu = db.DichVus.Find(id);
            db.DichVus.Remove(dichVu);
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
