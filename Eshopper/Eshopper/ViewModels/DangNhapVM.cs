using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Eshopper.ViewModels
{
    public class DangNhapVM
    {
        [Display(Name = "Tên tài khoản")]
        [Required(ErrorMessage ="Đây là trường bắt buộc!")]
        [MaxLength(20,ErrorMessage ="Tối đa 20 ký tự")]
        public string  UserName { get; set; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Đây là trường bắt buộc!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
