using Eshopper.Data;
using EShopper.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EShop.ViewComponents
{

    public class MenuLoaiHangViewComponent : ViewComponent
    {
        /// <summary>
        /// Tạo View Component cho Menu loại hàng
        /// Người tạo: LQLinh(14/03/2024)
        /// </summary>
        private readonly Hshop2023Context db;

        public MenuLoaiHangViewComponent(Hshop2023Context context) => db = context;

        public IViewComponentResult Invoke()
        {
            var data = db.Loais.Select(loai => new MenuLoaiHangVM
            {
                MaLoai = loai.MaLoai,
                TenLoai = loai.TenLoai,
                SoLuong = loai.HangHoas.Count()
            }).OrderBy(p => p.TenLoai);

            return View(data);
            //return View("Default",data);
        }
    }
}
