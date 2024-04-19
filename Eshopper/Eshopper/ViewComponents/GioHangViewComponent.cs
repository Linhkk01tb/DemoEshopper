using Eshopper.Helpers;
using Eshopper.ViewModels;
using EShopper.Helpers;
using EShopper.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Eshopper.ViewComponents
{
	public class GioHangViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			var count = HttpContext.Session.Get<List<GioHangItem>>(PrjConst.CART_KEY) ?? new List<GioHangItem>();
			return View( "GioHangComponent", new GioHangModel
				{
					SoLuong = count.Sum(x => x.SoLuong),
					TongThanhTien = count.Sum(x => x.ThanhTien)
				});
		}
	}
}
