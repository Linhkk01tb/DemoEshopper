using AutoMapper;
using Eshopper.Data;
using Eshopper.Helpers;
using Eshopper.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Eshopper.Controllers
{
    public class KhachHangController : Controller
    {
        private readonly Hshop2023Context db;
        private readonly IMapper _mapper;

        public KhachHangController(Hshop2023Context context, IMapper mapper)
        {
            db = context;
            _mapper = mapper;
        }

        #region Đăng ký
        //[Route("/DangKy")]
        [HttpGet]
        public IActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DangKy(DangKyVM model, IFormFile? Hinh)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var taikhoan = _mapper.Map<KhachHang>(model);
                    taikhoan.RandomKey = Util.GenerateRandomKey();
                    taikhoan.MatKhau = model.MatKhau.ToMd5Hash(taikhoan.RandomKey);
                    taikhoan.HieuLuc = true; //xử lý khi sử dụng email để active
                    taikhoan.VaiTro = 0;//Mặc định 0 là khách hàng
                    if (Hinh != null)
                    {
                        taikhoan.Hinh = await Util.UploadHinh(Hinh, "KhachHang");
                    }
                    else
                    {
                        taikhoan.Hinh = "Penguins.jpg";
                    }
                    db.Add(taikhoan);
                    db.SaveChanges();
                    return RedirectToAction("Index", "HangHoa");
                }
                catch (Exception ex)
                {

                }
            }
            return View();
        }
        #endregion

        #region Đăng Nhập

        [HttpGet]
        public IActionResult DangNhap(string? ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DangNhap(DangNhapVM model, string? ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            if(ModelState.IsValid)
            {
                var taikhoan = db.KhachHangs.SingleOrDefault(tk => tk.MaKh == model.UserName);
                if(taikhoan == null)
                {
                    ModelState.AddModelError("loi", "Tài khoản không tồn tại!");
                }
                else
                {
                    if (!taikhoan.HieuLuc)
                    {
                        ModelState.AddModelError("loi","Tài khoản đã bị vô hiệu hóa! Vui lòng liện hệ Admin!");
                    }
                    else
                    {
                        if(taikhoan.MatKhau !=  model.Password.ToMd5Hash(taikhoan.RandomKey))
                        {
							ModelState.AddModelError("loi", "Thông tin đăng nhập không đúng! Vui lòng nhập lại!");
						}
                        else
                        {
                            var claims = new List<Claim>
                            {
								new Claim("Avatar", taikhoan.Hinh??""),
								new Claim(ClaimTypes.Email, taikhoan.Email),
								new Claim(ClaimTypes.Name, taikhoan.MaKh),
								new Claim("AccountId", taikhoan.MaKh),
                                //claim động cho phân quyền
                                new Claim(ClaimTypes.Role, "Customer")
							};
                            var claimsIdentity = new ClaimsIdentity(claims,"DangNhap");
                            var claimPrincipal = new ClaimsPrincipal(claimsIdentity);
                            await HttpContext.SignInAsync(claimPrincipal);
                            if (Url.IsLocalUrl(ReturnUrl))
                            {
                                return Redirect(ReturnUrl);
                            }
                            else
                            {
                                return RedirectToAction("Index","Home");
                            }
                        }
                    }
                }
            }
            return View();
        }
        #endregion

        #region Chỉnh sửa tài khoản
        [Authorize]        
        public IActionResult Profile()
        {
            return View();
        }
		#endregion
		#region Đăng xuất
		[Authorize]
		public async Task<IActionResult> DangXuat()
		{
            await HttpContext.SignOutAsync();
			return RedirectToAction("DangNhap","KhachHang");
		}
		#endregion
	}


}
