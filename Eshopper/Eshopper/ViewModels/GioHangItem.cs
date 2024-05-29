namespace EShopper.ViewModels
{
    public class GioHangItem
    {
        public int MaHangHoa { get; set; }
        public string AnhDaiDien {  get; set; }
        public string TenHangHoa { get; set; }
        public double DonGia {  get; set; }
        public int SoLuong {  get; set; }
        public double ThanhTien => SoLuong * DonGia;
    }
}
