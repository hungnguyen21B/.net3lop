using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DAL_QLHANGHOA;
using DTO_QLHANGHOA;

namespace BUS_QLHANGHOA
{
    public class BUS_MATHANG
    {
        DAL_MATHANG dalMatHang = new DAL_MATHANG();
        //get toàn bộ MẶT HÀNG vào datatable
        public DataTable GetMatHang()
        {
            return dalMatHang.GetMatHang();
        }
        //thêm MẶT HÀNG
        public bool AddMatHang(DTO_MATHANG matHang)
        {
            return dalMatHang.AddMatHang(matHang);
        }
        //sửa MẶT HÀNG
        public bool UpdateMatHang(DTO_MATHANG matHang)
        {
            return dalMatHang.UpdateMatHang(matHang);
        }
        //xóa MẶT HÀNG
        public bool DeleteMatHang(string matHang_ID)
        {
            return dalMatHang.DeleteMatHang(matHang_ID);
        }
    }
}
