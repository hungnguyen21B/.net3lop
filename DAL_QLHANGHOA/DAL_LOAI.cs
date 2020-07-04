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
    public class DAL_LOAI:DBConnect
    {
        //get toàn bộ LOẠI vào datatable
        public DataTable GetLoai()
        {
            DataTable dtLoai = new DataTable();
            try {
                cnn.Open();
                SqlCommand com = new SqlCommand("Select * from Loai", cnn);
                com.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(dtLoai);
                cnn.Close();
            }
            catch(Exception e)
            {             
            }
            return dtLoai;          
        }

        public DataTable GetLoaiTheoMa(int maloai)
        {
            DataTable dtLoai = new DataTable();
            try
            {
                cnn.Open();
                string SQL = string.Format("select * from loai where maloai='{0}'", maloai);
                SqlCommand com = new SqlCommand(SQL, cnn);
                com.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(dtLoai);
                cnn.Close();
            }
            catch (Exception e)
            {
            }
            return dtLoai;
        }
        //thêm Loại
        public bool AddLoai(DTO_LOAI loai)
        {
            try
            {
                // Ket noi
                cnn.Open();

                // Query string - vì maloai là identity (giá trị tự tăng dần) nên ko cần fải insert ID
                string SQL = string.Format("INSERT INTO LOAI(tenloai) VALUES ('{0}')", loai.TenLoai);

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

        //sửa Loại
        public bool UpdateLoai(DTO_LOAI loai )
        {
            try
            {
                // Ket noi
                cnn.Open();

                // Query string
                string SQL = string.Format("UPDATE LOAI SET TENLOAI = '{0}',MAHANGSX='{1}' WHERE MALOAI = {2}", loai.TenLoai,loai.MaHangSx,loai.MaLoai);

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

        //xóa Loại
        public bool DeleteLoai(int loai_ID)
        {
            try
            {
                // Ket noi
                cnn.Open();

                // Query string - vì xóa chỉ cần ID nên chúng ta ko cần 1 DTO, ID là đủ
                string SQL = string.Format("DELETE FROM LOAI WHERE maloai = {0})", loai_ID);

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
