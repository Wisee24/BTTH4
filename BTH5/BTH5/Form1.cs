using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace BTH5
{
    public partial class Form1 : Form
    {
        BindingList<SinhVien> dsSV = new BindingList<SinhVien>();
        BindingSource bs = new BindingSource();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoGenerateColumns = false;
            if (dataGridView1.Columns["mssv"] != null) dataGridView1.Columns["mssv"].DataPropertyName = "MSSV";
            if (dataGridView1.Columns["hoten"] != null) dataGridView1.Columns["hoten"].DataPropertyName = "HoTen";
            if (dataGridView1.Columns["khoa"] != null) dataGridView1.Columns["khoa"].DataPropertyName = "Khoa";
            if (dataGridView1.Columns["diemtb"] != null) dataGridView1.Columns["diemtb"].DataPropertyName = "DiemTB";

            bs.DataSource = dsSV;
            dataGridView1.DataSource = bs;

            TaiLaiDataGrid();
        }

        void TaiLaiDataGrid()
        {
            bs.ResetBindings(false);
            dataGridView1.ClearSelection();
        }

        private void menuThemMoi_Click(object sender, EventArgs e)
        {
            MoFormThemMoi();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            MoFormThemMoi();
        }

        void MoFormThemMoi()
        {
            using (var f = new Form2())
            {
                if (f.ShowDialog() == DialogResult.OK && f.SinhVienMoi != null)
                {
                    dsSV.Add(f.SinhVienMoi);
                    TaiLaiDataGrid();
                }
            }
        }

        private void toolSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = toolSearch.Text.ToLower().Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                dataGridView1.DataSource = bs;
            }
            else
            {
                var kq = dsSV
                    .Where(s => s.HoTen != null && s.HoTen.ToLower().Contains(keyword))
                    .ToList();

                dataGridView1.DataSource = new BindingList<SinhVien>(kq);
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (dataGridView1.Rows[e.RowIndex].IsNewRow) return;
            if (dataGridView1.Columns[e.ColumnIndex].Name == "stt")
            {
                e.Value = e.RowIndex + 1;
            }
        }

        private void menuThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
