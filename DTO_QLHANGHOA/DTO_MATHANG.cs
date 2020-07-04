using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLHANGHOA
{
    public class DTO_MATHANG
    {
        private string _maHangHoa;
        private string _tenHangHoa;
        private float _donGia;
        private string _ghiChu;
        private int _maLoai;

        public string MaHangHoa { get => _maHangHoa; set => _maHangHoa = value; }
        public string TenHangHoa { get => _tenHangHoa; set => _tenHangHoa = value; }
        public float DonGia { get => _donGia; set => _donGia = value; }
        public string GhiChu { get => _ghiChu; set => _ghiChu = value; }
        public int MaLoai { get => _maLoai; set => _maLoai = value; }

        public DTO_MATHANG(string maHangHoa, string tenHangHoa, float donGia, string ghiChu, int maLoai)
        {
            MaHangHoa = maHangHoa;
            TenHangHoa = tenHangHoa;
            DonGia = donGia;
            GhiChu = ghiChu;
            MaLoai = maLoai;
        }
    }
}
