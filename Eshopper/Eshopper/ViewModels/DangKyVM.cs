using System.ComponentModel.DataAnnotations;

namespace Eshopper.ViewModels
{
	public class DangKyVM
	{
		[Key]
		[Display(Name="Tên tài khoản")]
		[Required(ErrorMessage = "Đây là trường bắt buộc!")]
		[MaxLength(20,ErrorMessage ="Tối đa 20 ký tự!")]
		public string MaKh {  get; set; }

		[Display(Name = "Mật khẩu")]
		[Required(ErrorMessage = "Đây là trường bắt buộc!")]
		[DataType(DataType.Password)]
		public string MatKhau { get; set; }

		[Display(Name = "Họ tên")]
		[Required(ErrorMessage = "Đây là trường bắt buộc!")]
		[MaxLength(50, ErrorMessage = "Tối đa 50 ký tự!")]
		public string HoTen { get; set;}

		[Display(Name = "Giới tính")]
		public bool GioiTinh { get; set; } = true;
		[Display(Name = "Ngày sinh")]
		[DataType (DataType.Date)]
		public DateTime? NgaySinh { get; set;}

		[Display(Name = "Địa chỉ")]
		[Required(ErrorMessage = "Đây là trường bắt buộc!")]
		[MaxLength(60, ErrorMessage = "Tối đa 60 ký tự!")]
		public string DiaChi {  get; set;}

		[Display(Name = "Số điện thoại")]
		[Required(ErrorMessage = "Đây là trường bắt buộc!")]
		[MaxLength(24, ErrorMessage = "Tối đa 24 ký tự!")]
		[RegularExpression(@"0[987654321]\d{8}",ErrorMessage ="Vui lòng nhập đúng định dạng!")]
		public string DienThoai {get; set;}

		[Display(Name = "Ảnh đại diện")]
		public string? Hinh { get; set; }

		[Display(Name = "Email")]
		[Required(ErrorMessage = "Đây là trường bắt buộc!")]
		[EmailAddress(ErrorMessage ="Vui lòng nhập đúng định dạng email!")]
		public string Email {  get; set;}
	}
}
