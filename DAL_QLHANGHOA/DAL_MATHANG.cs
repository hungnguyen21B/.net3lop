using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO_QLHANGHOA;

namespace DAL_QLHANGHOA
{
    public class DAL_MATHANG:DBConnect
    {

        //get toàn bộ MATHANG vào datatable
        public DataTable GetMatHang()
        {
            DataTable dtMatHang = new DataTable();
            try
            {
                cnn.Open();
                SqlCommand com = new SqlCommand("Select a.*,b.tenloai from mathang a,loai b where a.maloai=b.maloai", cnn);
                com.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(dtMatHang);
                cnn.Close();
            }
            catch (Exception e)
            {
            }
            return dtMatHang;
        }
        public DataTable GetMatHangTheoLoai(int maloai)
        {
            DataTable dtMatHang = new DataTable();
            try
            {
                cnn.Open();
                string SQL = string.Format("select * from where maloai={0}",maloai);
                SqlCommand com = new SqlCommand(SQL, cnn);
                com.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(dtMatHang);
                cnn.Close();
            }
            catch (Exception e)
            {
            }
            return dtMatHang;
        }


        //thêm mặt hàng
        public bool AddMatHang(DTO_MATHANG matHang)
        {
            try
            {
                // Ket noi
                cnn.Open();

                // Query string - vì maloai là identity (giá trị tự tăng dần) nên ko cần fải insert ID
                string SQL = string.Format("INSERT INTO MATHANG(MAHANGHOA,TENHANGHOA,DONGIA,GHICHU,MALOAI) VALUES ('{0}','{1}','{2}','{3}','{4}')", matHang.MaHangHoa,matHang.TenHangHoa,matHang.DonGia,matHang.GhiChu,matHang.MaLoai);

                // Command (mặc định command type = text nên chúng ta khỏi fải làm gì nhiều).
                SqlCommand cmd = new SqlCommand(SQL, cnn);

                // Query và kiểm tra
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception e)
            {

            }
            finally
            {
                // Dong ket noi
                cnn.Close();
            }
            return false;
        }

        //sửa MẶT HÀNG
        public bool UpdateMatHang(DTO_MATHANG matHang)
        {
            try
            {
                // Ket noi
                cnn.Open();

                // Query string
                string SQL = string.Format("UPDATE MATHANG SET TENHANGHOA='{0}',DONGIA='{1}',GHICHU='{2}',MALOAI='{3}' WHERE MAHANGHOA = '{4}'", matHang.TenHangHoa, matHang.DonGia,matHang.GhiChu,matHang.MaLoai,matHang.MaHangHoa);

                // Command (mặc định command type = text nên chúng ta khỏi fải làm gì nhiều).
                SqlCommand cmd = new SqlCommand(SQL, cnn);

                // Query và kiểm tra
                if (cmd.ExecuteNonQuery() > 0)
                    return true;

            }
            catch (Exception e)
            {

            }
            finally
            {
                // Dong ket noi
                cnn.Close();
            }

            return false;
        }

        //xóa MẶT HÀNG
        public bool DeleteMatHang(string matHang_ID)
        {
            try
            {
                // Ket noi
                cnn.Open();

                // Query string - vì xóa chỉ cần ID nên chúng ta ko cần 1 DTO, ID là đủ
                string SQL = string.Format("DELETE FROM MATHANG WHERE mahanghoa = '{0}'", matHang_ID);

                // Command (mặc định command type = text nên chúng ta khỏi fải làm gì nhiều).
                SqlCommand cmd = new SqlCommand(SQL, cnn);

                // Query và kiểm tra
                if (cmd.ExecuteNonQuery() > 0)  //ExecuteNonQuery: trả về kết quả là số dòng dữ liệu bị ảnh hưởng 
                    return true;

            }
            catch (Exception e)
            {

            }
            finally
            {
                // Dong ket noi
                cnn.Close();
            }

            return false;
        }
    }
}
