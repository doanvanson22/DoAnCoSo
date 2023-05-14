using Booking_Dental_Clinic.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Booking_Dental_Clinic.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        DentalClinicEntities db = new DentalClinicEntities();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Price()
        {
            // lay ra danh sach goi dich vu
            List<GoiDichVu> ketqua = db.GoiDichVus.ToList();
            return View(ketqua);
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Service()
        {
            return View();
        }
        public ActionResult BlogGrid()
        {
            return View();
        }
        public ActionResult BlogDetail()
        {
            return View();
        }
        public ActionResult Team()
        {
            return View();
        }
        public ActionResult Testimonial()
        {
            return View();
        }
        [Authorize]
        public ActionResult Appointment()
        {
            var a = User.Identity.GetUserName();
            var id =  User.Identity.GetUserId();
            var user = db.AspNetUsers.Find(id);
            //var fullName = user.UserName;
            ViewBag.IDBACSI = new SelectList(db.NhaSis, "IDBACSI", "Ten");
            ViewBag.IDDICHVU = new SelectList(db.LoaiDichVus, "IDDICHVU", "Ten");
            ViewBag.Id = new SelectList(db.AspNetUsers, "Id", "UserName");
            ViewBag.a = a;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Appointment([Bind(Include = "IdLich,Tenkhachhang,Sdt,IDDICHVU,IDBACSI,Ngaydat,Id")] LichHen dATLICH)
        {
            if (ModelState.IsValid)
            {
                db.LichHens.Add(dATLICH);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            ViewBag.IDBACSI = new SelectList(db.NhaSis, "IDBACSI", "Ten", dATLICH.IDBACSI);
            ViewBag.IDDICHVU = new SelectList(db.LoaiDichVus, "IDDICHVU", "Ten", dATLICH.IDDICHVU);
            ViewBag.Id = new SelectList(db.AspNetUsers, "Id", "Id", dATLICH.Id);
            return View(dATLICH);
        }
        public ActionResult Search()
        {
            return View();
        }

        public ActionResult Thanhtoan()
        {
            //if (Session["Id"] == null || Session["Id"].ToString() == "")
            //{
            //    return RedirectToAction("Login", "Account");
            //}
            var a = User.Identity.GetUserId();
            var b = User.Identity.GetUserName();
            if (a == null )
            {
                return RedirectToAction("Login", "Account");
            }
            ViewBag.Id_GoiDichVu = new SelectList(db.GoiDichVus, "Id_DichVu", "TenDichVu");
            ViewBag.ID_ThanhToan = new SelectList(db.HinhThucThanhToans, "ID_ThanhToan", "TenHinhThuc");
            ViewBag.Id = new SelectList(db.AspNetUsers, "Id", "UserName");
            return View();


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Thanhtoan([Bind(Include = "ID_HoaDon,TongTien,Id,Id_GoiDichVu,ID_ThanhToan")] HoaDon HoaDon)
        {
            {
                if (ModelState.IsValid)
                {
                    db.HoaDons.Add(HoaDon);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
                ViewBag.Id_GoiDichVu = new SelectList(db.GoiDichVus, "Id_DichVu", "TenDichVu", HoaDon.Id_GoiDichVu);
                ViewBag.ID_ThanhToan = new SelectList(db.HinhThucThanhToans, "ID_ThanhToan", "TenHinhThuc",HoaDon.ID_ThanhToan);
                ViewBag.Id = new SelectList(db.AspNetUsers, "Id", "Id", HoaDon.Id);
                return View(HoaDon);
            }
        }
    }
}