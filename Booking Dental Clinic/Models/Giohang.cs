using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Booking_Dental_Clinic.Models
{
    public class Giohang
    {
        DentalClinicEntities db = new DentalClinicEntities();
        public int idMaDV { get; set; }
        public string sTenSanPham { get; set; }
        public double sDongia { get; set; }
        public int sSoluong { get; set; }
        public double ThanhTien
        {
            get { return sSoluong * sDongia; }
        }
        //HÀM TẠO
        public Giohang(int MaDV)
        {
            idMaDV = MaDV;
            GoiDichVu dichvu = db.GoiDichVus.FirstOrDefault(n => n.Id_DichVu == idMaDV);
            sTenSanPham = dichvu.TenDichVu;
            sDongia = double.Parse( dichvu.GiaDichVu.ToString());
            sSoluong = 1;
        }
    }
}