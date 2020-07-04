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
    public class DAL_HANG:DBConnect
    {
        //get toàn bộ HÃNG vào datatable
        public DataTable GetHang()
        {
            DataTable dtHang = new DataTable();
            try
            {
                cnn.Open();
                SqlCommand com = new SqlCommand("Select * from HANG", cnn);
                com.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(dtHang);
                cnn.Close();
            }
            catch (Exception e)
            {
            }
            return dtHang;
        }

        //thêm Hãng
        public bool AddHang(DTO_HANG hang)
        {
            try
            {
                // Ket noi
                cnn.Open();

                // Query string - vì maloai là identity (giá trị tự tăng dần) nên ko cần fải insert ID
                string SQL = string.Format("INSERT INTO HANG(tenhangsx) VALUES ('{0}')", hang.TenHangSx);

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

        //sửa HÃNG
        public bool UpdateHang(DTO_HANG hang)
        {
            try
            {
                // Ket noi
                cnn.Open();

                // Query string
                string SQL = string.Format("UPDATE HANG SET TENHANGSX = '{0}' WHERE MAHANGSX = {1}", hang.TenHangSx, hang.MaHangSx);

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

        //xóa HÃNG
        public bool DeleteHang(int hang_ID)
        {
            try
            {
                // Ket noi
                cnn.Open();

                // Query string - vì xóa chỉ cần ID nên chúng ta ko cần 1 DTO, ID là đủ
                string SQL = string.Format("DELETE FROM HANG WHERE mahangsx = {0})", hang_ID);

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
    }
}
