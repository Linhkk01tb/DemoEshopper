using Eshopper.Data;
using EShopper.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EShop.Controllers
{
    public class HangHoaController : Controller
    {
        /// <summary>
        /// Khai báo biến db
        /// </summary>
        private readonly Hshop2023Context db;
        /// <summary>
        /// Nhúng cơ sở dữ liệu
        /// Người tạo: LQLinh(14/03/2024)
        /// </summary>
        /// <param name="context"></param>
        public HangHoaController(Hshop2023Context context)
        {
            db = context;
        }
        public IActionResult Index(int? loaihang)
        {
            var hangHoas = db.HangHoas.AsQueryable();
            if (loaihang.HasValue)
            {
                hangHoas = hangHoas.Where(p => p.MaLoai == loaihang.Value);

            }
            var result = hangHoas.Select(p => new HangHoaVM
            {
                MaHangHoa = p.MaHh,
                TenHangHoa = p.TenHh,
                DonGia = p.DonGia ?? 0,
                AnhDaiDien = p.Hinh ?? "",
                MoTaNgan = p.MoTaDonVi ?? "",
                TenLoai = p.MaLoaiNavigation.TenLoai
            });
            return View(result);
        }
        public IActionResult Search(string? query)
        {
            ViewBag.Query = query;
            var hangHoas = db.HangHoas.AsQueryable();
            if (query != null)
            {
                hangHoas = hangHoas.Where(p => p.TenHh.Contains(query));

            }
            var result = hangHoas.Select(p => new HangHoaVM
            {
                MaHangHoa = p.MaHh,
                TenHangHoa = p.TenHh,
                DonGia = p.DonGia ?? 0,
                AnhDaiDien = p.Hinh ?? "",
                MoTaNgan = p.MoTaDonVi ?? "",
                TenLoai = p.MaLoaiNavigation.TenLoai
            });
            return View(result);

        }
        public IActionResult Detail(int id)
        {
            var data = db.HangHoas.Include(p => p.MaLoaiNavigation).SingleOrDefault(p => p.MaHh == id);
            if (data == null)
            {
                TempData["Message"] = $"Không tìm thấy sản phẩm!";
                return Redirect("/404");
            }
            var result = new ChiTietHangHoaVM
            {
                MaHangHoa = data.MaHh,
                TenHangHoa = data.TenHh,
                DonGia = data.DonGia ?? 0,
                MoTaNgan = data.MoTaDonVi??"",
                ChiTiet = data.MoTa ?? "",
                DiemDanhGia = 5, //check sau
                SoLuongTon = 10, //Thêm sau
                AnhDaiDien = data.Hinh??"",
                TenLoai =data.MaLoaiNavigation.TenLoai,
            };
            return View(result);
        }
    }
}
