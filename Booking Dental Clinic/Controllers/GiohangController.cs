using Booking_Dental_Clinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Booking_Dental_Clinic.Controllers
{
    public class GiohangController : Controller
    {
        DentalClinicEntities db = new DentalClinicEntities();

        public ActionResult Index()
        {
            return View();
        }
        // GET: Giohang
        public List<Giohang> LayGioHang()
        {
            List<Giohang> lstGioHang = Session["Giohang"] as List<Giohang>;
            if (lstGioHang == null)
            {
                lstGioHang = new List<Giohang>();
                Session["Giohang"] = lstGioHang;
            }
            return lstGioHang;
        }
        //thêm 1 sản phẩm vào giỏ hàng
        public ActionResult ThemGioHang(int idMaDV, string strURL)
        {
            List<Giohang> lstGioHang = LayGioHang();
            Giohang giohang = lstGioHang.Find(n => n.idMaDV == idMaDV);
            if (giohang == null)
            {
                giohang = new Giohang(idMaDV);
                lstGioHang.Add(giohang);
                return Redirect(strURL);

            }
            else
            {
                giohang.sSoluong++;
                var d = db.GoiDichVus.Find(idMaDV);
                return Redirect(strURL);
            }
        }
        //cap nhap gio hang
        public ActionResult CapNhatGioHang(int idMaDV, FormCollection f)
        {
            List<Giohang> lstGioHang = LayGioHang();
            Giohang giohang = lstGioHang.SingleOrDefault(n => n.idMaDV == idMaDV);
            if (giohang != null)
            {
                giohang.sSoluong = int.Parse(f["txtSoLuong"].ToString());

            }
            return RedirectToAction("GioHang");
        }
        //Xay dung trang gio hang
        public ActionResult Giohang()
        {
            if (Session["Giohang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }    
            List<Giohang> lstGioHang = LayGioHang();
            return View(lstGioHang);
        }
        //tinh tong
        private int TongSoLuong()
        {
            int tong = 0;
            List<Giohang> lstGioHang = Session["Giohang"] as List<Giohang>;
            if (lstGioHang != null)
            {
                tong = lstGioHang.Sum(n => n.sSoluong);
            }
            return tong;
        }
        private double TongTien()
        {
            double tongTien = 0;
            List<Giohang> lstGioHang = Session["Giohang"] as List<Giohang>;
            if (lstGioHang != null)
            {
                tongTien = lstGioHang.Sum(n => n.ThanhTien);
            }
            return tongTien;
        }
    }
}