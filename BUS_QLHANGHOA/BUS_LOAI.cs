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
    public class BUS_LOAI
    {
        DAL_LOAI dalLoai = new DAL_LOAI();
        //get toàn bộ HÃNG từ datatable
        public DataTable GetLoai()
        {
            return dalLoai.GetLoai();
        }
        //get loai theo maloai
        public DataTable GetLoaiTheoMa(int maloai)
        {
            return dalLoai.GetLoai();
        }
        //thêm LOAI
        public bool AddLoai(DTO_LOAI loai)
        {
            return dalLoai.AddLoai(loai);
        }
        //sửa LOAI
        public bool UpdateLoai(DTO_LOAI loai)
        {
            return dalLoai.UpdateLoai(loai);
        }
        //xóa LOAI
        public bool DeleteLoai(int hang_ID)
        {
            return dalLoai.DeleteLoai(hang_ID);
        }
        
        
}
}
