using AutoMapper;
using Eshopper.Data;
using Eshopper.ViewModels;

namespace Eshopper.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() {
            CreateMap<DangKyVM, KhachHang>();
            //CreateMap<DangKyVM, KhachHang>().ForMember(kh => kh.MaKh, option=> option.MapFrom(DangKyVM=>DangKyVM.MaKh)).ReverseMap();
        }
    }
}
