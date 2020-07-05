using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS_QLHANGHOA;
using DTO_QLHANGHOA;

namespace GUI_QLHANGHOA
{
    public partial class FNHAPMATHANG : Form
    {
        BUS_LOAI busLoai = new BUS_LOAI();
        BUS_MATHANG busMatHang = new BUS_MATHANG();
        public FNHAPMATHANG()
        {
            InitializeComponent();
            LoadLoai();
            LoadMatHang();
            
            binding();
            
        }
        //hàm load Loại xuống combobox
        public void LoadLoai()
        {
            DataTable dt = new DataTable();
            dt = busLoai.GetLoai();
            foreach (DataRow i in dt.Rows)
            {
                DTO_LOAI loai = new DTO_LOAI()
                {
                    MaLoai = Convert.ToInt16(i["maloai"]),
                    TenLoai = i["tenloai"].ToString(),
                    MaHangSx= Convert.ToInt16(i["mahangsx"])
                };
                cboLoai.Items.Add(loai);
            }
        }

        //load mặt hàng xuống datagridview
        public void LoadMatHang()
        {
            DataTable dt = new DataTable();
            dt = busMatHang.GetMatHang();
            dgvMathang.DataSource = dt;
            int j = 1;
            foreach (DataGridViewRow i in dgvMathang.Rows)
            {
                if (i != null)
                {
                    i.Cells[0].Value = j;
                    j++;
                }
            }
        }
        //load mat hang theo ma loai xuong datalist view
        public void LoadMatHangTheoLoai(int maloai)
        {
            DataTable dt = new DataTable();
            dt = busMatHang.GetMatHangTheoLoai(maloai);
            dgvMathang.DataSource = dt;
            int j = 1;
            foreach (DataGridViewRow i in dgvMathang.Rows)
            {
                if (i != null)
                {
                    i.Cells[0].Value = j;
                    j++;
                }
            }
        }

        //phương thức ClearControl để xóa trống các điều khiển và đặt focus vào txtMaMatHang
        public void ClearControl()
        {
            txtMaMatHang.Clear();
            txtTenMatHang.Clear();
            txtDonGia.Clear();
            txtGhiChu.Clear();
            cboLoai.Text = "";
            txtMaMatHang.Focus();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            //Khi nhấn nút Thêm thì giá trị thuộc tính Text chuyển thành "Lưu"
            //và xóa trống các điều khiển
            if (btnThem.Text == "THÊM")
            {
                ClearControl();
                btnThem.Text = "LƯU";
            }
            else
             if (txtMaMatHang.Text != "" && txtTenMatHang.Text!="" &&txtDonGia.Text!="")
                {
                try
                {
                    string mahh = txtMaMatHang.Text;
                    string tenhh = txtTenMatHang.Text;
                    float dongia = Convert.ToSingle(txtDonGia.Text);
                    string ghichu = txtGhiChu.Text;
                    int maloai = Convert.ToInt16(((DTO_LOAI)cboLoai.SelectedItem).MaLoai);
                    DTO_MATHANG matHang = new DTO_MATHANG(mahh, tenhh, dongia, ghichu, maloai);
                    // Them mặt hàng
                    if (busMatHang.AddMatHang(matHang))
                    {
                        MessageBox.Show("Thêm thành công");
                        LoadMatHang(); // refresh datagridview
                    }
                    else
                    {
                        MessageBox.Show("Thêm ko thành công");
                    }
                    btnThem.Text = "THÊM";
                             
                }
                catch { MessageBox.Show("Lỗi nhập dữ liệu: "+e.ToString()); }
            }
            else
            {
                MessageBox.Show("Xin hãy nhập đầy đủ");
            }

        }

        private void FNHAPMATHANG_Load(object sender, EventArgs e)
        {
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            //disable mamh
            txtMaMatHang.Enabled = false;
            // Kiểm tra nếu có chọn dòng trên dgvMathang rồi
            if (dgvMathang.SelectedRows.Count > 0)
            {
                if (txtTenMatHang.Text != "" && txtGhiChu.Text != "" && txtDonGia.Text != "" && cboLoai.Text!="")
                {
                    // Lấy row hiện tại
                    DataGridViewRow row = dgvMathang.SelectedRows[0];
                    string mahh = row.Cells[1].Value.ToString();
                    //hoặc string mahh = txtMaMatHang.Text;
                    string tenhh = txtTenMatHang.Text;
                    float dongia = Convert.ToSingle(txtDonGia.Text);
                    string ghichu = txtGhiChu.Text;
                    int maloai = ((DTO_LOAI)cboLoai.SelectedItem).MaLoai;
                    MessageBox.Show(mahh+","+tenhh + "," + dongia + "," + ghichu + "," + maloai);
                    DTO_MATHANG matHang = new DTO_MATHANG(mahh, tenhh, dongia, ghichu, maloai);
                    //Sửa
                    if (busMatHang.UpdateMatHang(matHang))
                    {
                        MessageBox.Show("Sửa thành công");
                        dgvMathang.DataSource = busMatHang.GetMatHang(); // refresh datagridview
                    }
                    else
                    {
                        MessageBox.Show("Sửa ko thành công");
                    }
                }
                else
                {
                        MessageBox.Show("Xin hãy nhập đầy đủ");
                    }
                }
            else
            {
                MessageBox.Show("Hãy chọn dòng muốn sửa");
            }
        }

        //khi chọn 1 ô thì chọn luôn 1 hàng
        private void dgvMathang_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                dgvMathang.CurrentRow.Selected = true;
            }
            catch { }
           
           
        }
        //đưa dòng dữ liệu được chọn từ dataGridView dgvMathang lên các textbox
        private void binding()
        {
            txtMaMatHang.DataBindings.Clear();
            txtMaMatHang.DataBindings.Add("Text", dgvMathang.DataSource, "mahanghoa");
            txtTenMatHang.DataBindings.Clear();
            txtTenMatHang.DataBindings.Add("Text", dgvMathang.DataSource, "tenhanghoa");
            txtGhiChu.DataBindings.Clear();
            txtGhiChu.DataBindings.Add("Text", dgvMathang.DataSource, "ghichu");
            txtDonGia.DataBindings.Clear();
            txtDonGia.DataBindings.Add("Text", dgvMathang.DataSource, "dongia");

            //lấy về mã loại trên dòng được chọn rồi gán lại item được chọn cho combobox có mã loại tương ứng
            if (dgvMathang.SelectedRows.Count > 0)
            {

                // Lấy row hiện tại
                DataGridViewRow row = dgvMathang.SelectedRows[0];
                int maloai = Convert.ToInt16(row.Cells[5].Value.ToString());
                
                foreach (DTO_LOAI loai in cboLoai.Items)
                {
                    if (loai.MaLoai == maloai) cboLoai.SelectedItem = loai;
                }
            }
            else cboLoai.DataBindings.Add("Text", dgvMathang.DataSource, "tenloai");

        }


        private void dgvMathang_MouseClick(object sender, MouseEventArgs e)
        {
            binding();
        }

        private void dgvMathang_AllowUserToDeleteRowsChanged(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu có chọn hàng rồi
            if (dgvMathang.SelectedRows.Count > 0)
            {

                // Lấy row hiện tại
                DataGridViewRow row = dgvMathang.SelectedRows[0];
                string mahh = row.Cells[1].Value.ToString();

                // Xóa
                if (busMatHang.DeleteMatHang(mahh))
                {
                    MessageBox.Show("Xóa thành công");
                    dgvMathang.DataSource = busMatHang.GetMatHang(); // refresh datagridview
                }
                else
                {
                    MessageBox.Show("Xóa ko thành công");
                }

            }
            else
            {
                MessageBox.Show("Hãy chọn mặt hàng muốn xóa");
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void cboLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            int maLoai = ((DTO_LOAI)(cboLoai.SelectedItem)).MaLoai;
            LoadMatHangTheoLoai(maLoai);
        }
    }
}
