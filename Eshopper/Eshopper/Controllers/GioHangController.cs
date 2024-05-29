using Eshopper.Data;
using Eshopper.Helpers;
using EShopper.Helpers;
using EShopper.ViewModels;
<<<<<<< HEAD
=======
using Microsoft.AspNetCore.Authorization;
>>>>>>> developer
using Microsoft.AspNetCore.Mvc;

namespace EShop.Controllers
{
    public class GioHangController : Controller
    {
        private readonly Hshop2023Context db;

        public GioHangController(Hshop2023Context context)
        {
            db = context;
        }
        
        public List<GioHangItem> GioHang => HttpContext.Session.Get<List<GioHangItem>>(PrjConst.CART_KEY) ?? new List<GioHangItem>();
<<<<<<< HEAD
=======
        [Authorize]
>>>>>>> developer
        public IActionResult Index()
        {
            return View(GioHang);
        }
<<<<<<< HEAD
=======
        [Authorize]
>>>>>>> developer
        public IActionResult ThemVaoGioHang(int id, int soluong = 1)
        {
            var giohang = GioHang;
            var item = giohang.SingleOrDefault(p => p.MaHangHoa == id);
            if (item == null)
            {
                var hanghoa = db.HangHoas.SingleOrDefault(p => p.MaHh == id);
                if (hanghoa == null)
                {
                    TempData["Message"] = $"Không tìm thấy loại hàng hóa này!";
                    return Redirect("/404");
                }
                item = new GioHangItem
                {
                    MaHangHoa = hanghoa.MaHh,
                    TenHangHoa = hanghoa.TenHh,
                    DonGia = hanghoa.DonGia ?? 0,
                    SoLuong = soluong,
                    AnhDaiDien = hanghoa.Hinh ?? ""
                };
                giohang.Add(item);
            }
            else
            {
                item.SoLuong += soluong;
            }
            HttpContext.Session.Set(PrjConst.CART_KEY, giohang);
            return RedirectToAction("Index");

        }
<<<<<<< HEAD
=======
        [Authorize]
>>>>>>> developer
        public IActionResult XoaKhoiGioHang(int id)
        {
            var giohang = GioHang;
            var item = giohang.SingleOrDefault(p =>p.MaHangHoa == id);
            if (item != null)
            {
                giohang.Remove(item);
                HttpContext.Session.Set(PrjConst.CART_KEY, giohang);
            }
            
            return RedirectToAction("Index");
            
        }
    }
}
