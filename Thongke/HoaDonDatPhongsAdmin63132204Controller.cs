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
    public class HoaDonDatPhongsAdmin63132204Controller : Controller
    {
        private Project_63132204Entities db = new Project_63132204Entities();

        
        public ActionResult Thongke63132204(String ngaydau, String ngaycuoi)
        {
            
            var thongkes = db.HoaDonDatPhongs.SqlQuery("exec ThongKe_HoaDon '"+ngaydau+"', '"+ngaycuoi+"'");
            return View(thongkes.ToList());
        }
        public ActionResult Duyet(int id)
        {
            var hoaDonDatphong = db.HoaDonDatPhongs.Find(id);
            if (hoaDonDatphong != null)
            {
                hoaDonDatphong.ThanhToan = true; // Đặt tình trạng là "Đã duyệt"
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // GET: Admin/HoaDonDatPhongsAdmin63132204
        public ActionResult Index()
        {
            var hoaDonDatPhongs = db.HoaDonDatPhongs.Include(h => h.Phong).Include(h => h.KhachHang).Include(h => h.NhanVien);
            return View(hoaDonDatPhongs.ToList());
        }

        // GET: Admin/HoaDonDatPhongsAdmin63132204/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDonDatPhong hoaDonDatPhong = db.HoaDonDatPhongs.Find(id);
            if (hoaDonDatPhong == null)
            {
                return HttpNotFound();
            }
            return View(hoaDonDatPhong);
        }

        // GET: Admin/HoaDonDatPhongsAdmin63132204/Create
        public ActionResult Create()
        {
            ViewBag.MaPhong = new SelectList(db.Phongs, "MaPhong", "TenPhong");
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "HoKH");
            ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "HoNV");
            return View();
        }

        // POST: Admin/HoaDonDatPhongsAdmin63132204/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDatPhong,MaNV,MaKH,MaPhong,NgayDat,NgayVao,NgayRa,ThanhToan")] HoaDonDatPhong hoaDonDatPhong)
        {
            if (ModelState.IsValid)
            {
                db.HoaDonDatPhongs.Add(hoaDonDatPhong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaPhong = new SelectList(db.Phongs, "MaPhong", "TenPhong", hoaDonDatPhong.MaPhong);
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "HoKH", hoaDonDatPhong.MaKH);
            ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "HoNV", hoaDonDatPhong.MaNV);
            return View(hoaDonDatPhong);
        }

        // GET: Admin/HoaDonDatPhongsAdmin63132204/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDonDatPhong hoaDonDatPhong = db.HoaDonDatPhongs.Find(id);
            if (hoaDonDatPhong == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaPhong = new SelectList(db.Phongs, "MaPhong", "TenPhong", hoaDonDatPhong.MaPhong);
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "HoKH", hoaDonDatPhong.MaKH);
            ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "HoNV", hoaDonDatPhong.MaNV);
            return View(hoaDonDatPhong);
        }

        // POST: Admin/HoaDonDatPhongsAdmin63132204/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDatPhong,MaNV,MaKH,MaPhong,NgayDat,NgayVao,NgayRa,ThanhToan")] HoaDonDatPhong hoaDonDatPhong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hoaDonDatPhong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaPhong = new SelectList(db.Phongs, "MaPhong", "TenPhong", hoaDonDatPhong.MaPhong);
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "HoKH", hoaDonDatPhong.MaKH);
            ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "HoNV", hoaDonDatPhong.MaNV);
            return View(hoaDonDatPhong);
        }

        // GET: Admin/HoaDonDatPhongsAdmin63132204/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDonDatPhong hoaDonDatPhong = db.HoaDonDatPhongs.Find(id);
            if (hoaDonDatPhong == null)
            {
                return HttpNotFound();
            }
            return View(hoaDonDatPhong);
        }

        // POST: Admin/HoaDonDatPhongsAdmin63132204/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HoaDonDatPhong hoaDonDatPhong = db.HoaDonDatPhongs.Find(id);
            db.HoaDonDatPhongs.Remove(hoaDonDatPhong);
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
