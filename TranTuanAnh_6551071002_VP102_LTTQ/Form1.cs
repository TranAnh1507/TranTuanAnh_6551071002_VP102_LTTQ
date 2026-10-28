using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using TranTuanAnh_6551071002_VP102_LTTQ.Models;

namespace TranTuanAnh_6551071002_VP102_LTTQ
{
    public partial class Form1 : Form
    {
        private int cheDo = 0;
        private string? maDangChon = null;
        public Form1()
        {
            InitializeComponent();
            Load -= Form1_Load;
            Load += Form1_Load;
            btnThem.Click -= btnThem_Click;
            btnThem.Click += btnThem_Click;
            btnSua.Click -= btnSua_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click -= btnXoa_Click;
            btnXoa.Click += btnXoa_Click;
            btnThoat.Click -= btnThoat_Click;
            btnThoat.Click += btnThoat_Click;
            dgvSinhVien.CellClick -= dgvSinhVien_CellClick;
            dgvSinhVien.CellClick += dgvSinhVien_CellClick;
            FormClosing -= Form1_FormClosing;
            FormClosing += Form1_FormClosing;
        }

        private void Form1_Load(object? sender, EventArgs e)
        {
            txtMaSinhVien.MaxLength = 10;
            txtTenSinhVien.MaxLength = 100;
            dgvSinhVien.AutoGenerateColumns = true;

            dgvSinhVien.AllowUserToAddRows = false;
            dgvSinhVien.AllowUserToDeleteRows = false;
            dgvSinhVien.MultiSelect = false;
            dgvSinhVien.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            XoaTrang();
            CapNhatNut();
            TaiDanhSach();
        }

        private void TaiDanhSach()
        {
            try
            {
                using var db = new DuLieuContext();

                var ds = db.Set<SinhVien>()
                    .AsNoTracking()
                    .OrderBy(s => s.MaSinhVien)
                    .Select(s => new
                    {
                        s.MaSinhVien,
                        s.TenSinhVien,
                        s.DiemTrungBinh
                    })
                    .ToList();

                dgvSinhVien.DataSource = null;
                dgvSinhVien.DataSource = ds;

                if (dgvSinhVien.Columns["MaSinhVien"]
                    is DataGridViewColumn cotMa)
                {
                    cotMa.HeaderText = "Mã sinh viên";
                }

                if (dgvSinhVien.Columns["TenSinhVien"]
                    is DataGridViewColumn cotTen)
                {
                    cotTen.HeaderText = "Tên sinh viên";
                }

                if (dgvSinhVien.Columns["DiemTrungBinh"]
                    is DataGridViewColumn cotDiem)
                {
                    cotDiem.HeaderText = "Điểm trung bình";
                }

                dgvSinhVien.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                dgvSinhVien.ClearSelection();
                dgvSinhVien.CurrentCell = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi tải dữ liệu: " +
                    ex.GetBaseException().Message
                );
            }
        }

        private void CapNhatNut()
        {
            btnThem.Text = cheDo == 1 ? "Lưu" : "Thêm";
            btnSua.Text = cheDo == 2 ? "Lưu" : "Sửa";

            btnThem.Enabled = cheDo == 0 || cheDo == 1;

            btnSua.Enabled = cheDo == 2 ||
                (cheDo == 0 && maDangChon != null);

            btnXoa.Enabled =
                cheDo == 0 && maDangChon != null;

            btnThoat.Enabled = true;

            dgvSinhVien.Enabled = cheDo == 0;

            txtMaSinhVien.ReadOnly = cheDo != 1;
            txtTenSinhVien.ReadOnly = cheDo == 0;
            txtDiemTrungBinh.ReadOnly = cheDo == 0;
        }

        private void XoaTrang()
        {
            txtMaSinhVien.Clear();
            txtTenSinhVien.Clear();
            txtDiemTrungBinh.Clear();
        }

        private void VeBanDau()
        {
            cheDo = 0;
            maDangChon = null;

            XoaTrang();

            dgvSinhVien.ClearSelection();
            dgvSinhVien.CurrentCell = null;

            CapNhatNut();
        }

        private bool KiemTraDuLieu(out decimal diem)
        {
            diem = 0;

            string ma = txtMaSinhVien.Text.Trim();
            string ten = txtTenSinhVien.Text.Trim();
            string diemNhap = txtDiemTrungBinh.Text.Trim()
                .Replace(',', '.');

            if (string.IsNullOrWhiteSpace(ma) || ma.Length > 10)
            {
                MessageBox.Show(
                    "Mã sinh viên không hợp lệ!"
                );

                txtMaSinhVien.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(ten) || ten.Length > 100)
            {
                MessageBox.Show(
                    "Tên sinh viên không hợp lệ!"
                );

                txtTenSinhVien.Focus();
                return false;
            }

            if (!decimal.TryParse(
                diemNhap,
                NumberStyles.AllowDecimalPoint |
                NumberStyles.AllowLeadingSign,
                CultureInfo.InvariantCulture,
                out diem))
            {
                MessageBox.Show(
                    "Điểm trung bình phải là số!"
                );

                txtDiemTrungBinh.Focus();
                return false;
            }

            if (diem < 0 || diem > 10)
            {
                MessageBox.Show(
                    "Điểm trung bình phải từ 0 đến 10!"
                );

                txtDiemTrungBinh.Focus();
                return false;
            }

            if (decimal.Round(diem, 1) != diem)
            {
                MessageBox.Show(
                    "Điểm chỉ được có tối đa 1 chữ số thập phân!"
                );

                txtDiemTrungBinh.Focus();
                return false;
            }

            return true;
        }

        private void btnThem_Click(object? sender, EventArgs e)
        {
            if (cheDo == 0)
            {
                cheDo = 1;
                maDangChon = null;

                dgvSinhVien.ClearSelection();
                dgvSinhVien.CurrentCell = null;

                XoaTrang();
                CapNhatNut();

                txtMaSinhVien.Focus();
                return;
            }

            if (cheDo != 1)
                return;

            if (!KiemTraDuLieu(out decimal diem))
                return;

            try
            {
                using var db = new DuLieuContext();

                string ma = txtMaSinhVien.Text.Trim();

                bool tonTai = db.Set<SinhVien>()
                    .Any(s => s.MaSinhVien == ma);

                if (tonTai)
                {
                    MessageBox.Show(
                        "Mã sinh viên đã tồn tại!"
                    );

                    txtMaSinhVien.Focus();
                    return;
                }

                SinhVien sv = new SinhVien
                {
                    MaSinhVien = ma,
                    TenSinhVien = txtTenSinhVien.Text.Trim(),
                    DiemTrungBinh = diem.ToString(
                        "0.0",
                        CultureInfo.InvariantCulture
                    )
                };

                db.Set<SinhVien>().Add(sv);
                db.SaveChanges();

                MessageBox.Show(
                    "Thêm sinh viên thành công!"
                );

                TaiDanhSach();
                VeBanDau();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi thêm sinh viên: " +
                    ex.GetBaseException().Message
                );
            }
        }

        private void btnSua_Click(object? sender, EventArgs e)
        {
            if (cheDo == 0)
            {
                if (maDangChon == null)
                {
                    MessageBox.Show(
                        "Vui lòng chọn sinh viên cần sửa!"
                    );

                    return;
                }

                cheDo = 2;
                CapNhatNut();

                txtTenSinhVien.Focus();
                return;
            }

            if (cheDo != 2)
                return;

            if (!KiemTraDuLieu(out decimal diem))
                return;

            try
            {
                using var db = new DuLieuContext();

                var sv = db.Set<SinhVien>()
                    .Find(maDangChon);

                if (sv == null)
                {
                    MessageBox.Show(
                        "Không tìm thấy sinh viên!"
                    );

                    TaiDanhSach();
                    VeBanDau();
                    return;
                }

                sv.TenSinhVien =
                    txtTenSinhVien.Text.Trim();

                sv.DiemTrungBinh = diem.ToString(
                    "0.0",
                    CultureInfo.InvariantCulture
                );

                db.SaveChanges();

                MessageBox.Show(
                    "Sửa sinh viên thành công!"
                );

                TaiDanhSach();
                VeBanDau();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi sửa sinh viên: " +
                    ex.GetBaseException().Message
                );
            }
        }

        private void btnXoa_Click(object? sender, EventArgs e)
        {
            if (cheDo != 0 || maDangChon == null)
                return;

            DialogResult ketQua = MessageBox.Show(
                "Bạn có chắc muốn xóa sinh viên này?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (ketQua != DialogResult.Yes)
                return;

            try
            {
                using var db = new DuLieuContext();

                var sv = db.Set<SinhVien>()
                    .Find(maDangChon);

                if (sv == null)
                {
                    MessageBox.Show(
                        "Sinh viên không tồn tại!"
                    );
                }
                else
                {
                    db.Set<SinhVien>().Remove(sv);
                    db.SaveChanges();

                    MessageBox.Show(
                        "Xóa sinh viên thành công!"
                    );
                }

                TaiDanhSach();
                VeBanDau();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi xóa sinh viên: " +
                    ex.GetBaseException().Message
                );
            }
        }

        private void dgvSinhVien_CellClick(
            object? sender,
            DataGridViewCellEventArgs e)
        {
            if (cheDo != 0 || e.RowIndex < 0)
                return;

            DataGridViewRow row =
                dgvSinhVien.Rows[e.RowIndex];

            maDangChon =
                row.Cells["MaSinhVien"].Value?.ToString();

            txtMaSinhVien.Text = maDangChon ?? "";

            txtTenSinhVien.Text =
                row.Cells["TenSinhVien"].Value?.ToString() ?? "";

            txtDiemTrungBinh.Text =
                row.Cells["DiemTrungBinh"].Value?.ToString() ?? "";

            CapNhatNut();
        }

        protected override bool ProcessCmdKey(
            ref Message msg,
            Keys keyData)
        {
            if (keyData == Keys.Escape && cheDo != 0)
            {
                VeBanDau();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnThoat_Click(object? sender, EventArgs e)
        {
            Close();
        }

        private void Form1_FormClosing(
            object? sender,
            FormClosingEventArgs e)
        {
            DialogResult ketQua = MessageBox.Show(
                "Bạn có muốn thoát chương trình?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (ketQua != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

        private void label1_Click(object? sender, EventArgs e)
        {
        }
    }
}
