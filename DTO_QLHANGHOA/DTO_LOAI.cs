using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLHANGHOA
{
    public class DTO_LOAI
    {
        private int _maloai;   //biến viết theo quy cách camel
        private string _tenloai;
        private int _mahangsx;

        //thuộc tính viết theo quy cách Pascal
        public int MaLoai { get => _maloai; set => _maloai = value; }
        public string TenLoai { get => _tenloai; set => _tenloai = value; }
        public int MaHangSx { get => _mahangsx; set => _mahangsx = value; }

        //constructor
        public DTO_LOAI()
        {
         }

        public DTO_LOAI(int maLoai, string tenLoai, int maHangSx)
        {
            MaLoai = maLoai;
            TenLoai = tenLoai;
            MaHangSx = maHangSx;
        }

        public override string ToString()
        {
            return TenLoai+";"+MaHangSx;
        }
    }
}
