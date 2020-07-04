using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL_QLHANGHOA;
using DTO_QLHANGHOA;

namespace BUS_QLHANGHOA
{
    public class BUS_HANG
    {
        DAL_HANG dalHang = new DAL_HANG();
        //get toàn bộ HÃNG vào datatable
        public DataTable GetHang()
        {
            return dalHang.GetHang();
        }
        //thêm Hãng
        public bool AddHang(DTO_HANG hang)
        {
            return dalHang.AddHang(hang);
        }
        //sửa HÃNG
        public bool UpdateHang(DTO_HANG hang)
        {
            return dalHang.UpdateHang(hang);
        }
        //xóa HÃNG
        public bool DeleteHang(int hang_ID)
        {
            return dalHang.DeleteHang(hang_ID);
        }
    }
}
