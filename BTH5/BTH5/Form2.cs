using System;
using System.Globalization;
using System.Windows.Forms;

namespace BTH5
{
    public partial class Form2 : Form
    {
        public SinhVien SinhVienMoi { get; set; }

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            cboKhoa.Items.Add("Công nghệ thông tin");
            cboKhoa.Items.Add("Kỹ thuật phần mềm");
            cboKhoa.Items.Add("Hệ thống thông tin");
            cboKhoa.Items.Add("Khoa học máy tính");

            cboKhoa.SelectedIndex = 0;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMSSV.Text))
            {
                MessageBox.Show("Mã số sinh viên không được để trống.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMSSV.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Tên sinh viên không được để trống.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }

            var input = txtDiem.Text?.Trim() ?? string.Empty;
            double diem;
            if (!double.TryParse(input, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.CurrentCulture, out diem))
            {
                var normalized = input.Replace(',', '.');
                if (!double.TryParse(normalized, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out diem))
                {
                    MessageBox.Show("Điểm không hợp lệ. Vui lòng nhập một số hợp lệ (ví dụ: 7.5 hoặc 7,5).", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDiem.Focus();
                    return;
                }
            }

            SinhVienMoi = new SinhVien()
            {
                MSSV = txtMSSV.Text,
                HoTen = txtHoTen.Text,
                Khoa = cboKhoa.Text,
                DiemTB = diem
            };

            DialogResult = DialogResult.OK;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
