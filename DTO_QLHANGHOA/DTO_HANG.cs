using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLHANGHOA
{
    public class DTO_HANG
    {
        private int _mahangsx;
        private string _tenHangsx;

        public int MaHangSx { get => _mahangsx; set => _mahangsx = value; }
        public string TenHangSx { get => _tenHangsx; set => _tenHangsx = value; }

        //constructor
        public DTO_HANG()
        {
        }

        public DTO_HANG(int maHangSx, string tenHangSx)
        {
            MaHangSx = maHangSx;
            TenHangSx = tenHangSx;
        }
    }
}


