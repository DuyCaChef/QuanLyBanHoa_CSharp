namespace QuanLyBanHoa.Models
{
    public class Hoa
    {
        public int MaHoa { get; set; }
        public string TenHoa { get; set; } = string.Empty;
        public decimal Gia { get; set; }
        public int SoLuong { get; set; }
        public string? MoTa { get; set; }
        // Backwards-compat aliases
        public string? PhanLoai { get => MoTa; set => MoTa = value; }
        public string? Ghichu { get => MoTa; set => MoTa = value; }
    }
}
