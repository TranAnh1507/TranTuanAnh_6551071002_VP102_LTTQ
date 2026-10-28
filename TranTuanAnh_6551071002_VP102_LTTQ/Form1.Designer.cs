namespace TranTuanAnh_6551071002_VP102_LTTQ
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnThoat = new Button();
            grbSinhVien = new GroupBox();
            dgvSinhVien = new DataGridView();
            grbThongTin = new GroupBox();
            lblDiemTB = new Label();
            lblTenSV = new Label();
            txtDiemTrungBinh = new TextBox();
            txtTenSinhVien = new TextBox();
            txtMaSinhVien = new TextBox();
            lblMaSV = new Label();
            grbSinhVien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSinhVien).BeginInit();
            grbThongTin.SuspendLayout();
            SuspendLayout();
            // 
            // btnThem
            // 
            btnThem.Location = new Point(36, 18);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(93, 45);
            btnThem.TabIndex = 0;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(150, 17);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(95, 45);
            btnSua.TabIndex = 1;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(277, 16);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(101, 47);
            btnXoa.TabIndex = 2;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(406, 18);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(102, 45);
            btnThoat.TabIndex = 3;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            // 
            // grbSinhVien
            // 
            grbSinhVien.Controls.Add(dgvSinhVien);
            grbSinhVien.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            grbSinhVien.Location = new Point(23, 95);
            grbSinhVien.Name = "grbSinhVien";
            grbSinhVien.Size = new Size(445, 286);
            grbSinhVien.TabIndex = 4;
            grbSinhVien.TabStop = false;
            grbSinhVien.Text = "Danh sách sinh viên";
            // 
            // dgvSinhVien
            // 
            dgvSinhVien.AllowUserToAddRows = false;
            dgvSinhVien.AllowUserToDeleteRows = false;
            dgvSinhVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSinhVien.Location = new Point(13, 36);
            dgvSinhVien.MultiSelect = false;
            dgvSinhVien.Name = "dgvSinhVien";
            dgvSinhVien.ReadOnly = true;
            dgvSinhVien.RowHeadersWidth = 51;
            dgvSinhVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSinhVien.Size = new Size(420, 230);
            dgvSinhVien.TabIndex = 0;
            dgvSinhVien.CellClick += dgvSinhVien_CellClick;
            // 
            // grbThongTin
            // 
            grbThongTin.Controls.Add(lblDiemTB);
            grbThongTin.Controls.Add(lblTenSV);
            grbThongTin.Controls.Add(txtDiemTrungBinh);
            grbThongTin.Controls.Add(txtTenSinhVien);
            grbThongTin.Controls.Add(txtMaSinhVien);
            grbThongTin.Controls.Add(lblMaSV);
            grbThongTin.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            grbThongTin.Location = new Point(501, 95);
            grbThongTin.Name = "grbThongTin";
            grbThongTin.Size = new Size(276, 286);
            grbThongTin.TabIndex = 5;
            grbThongTin.TabStop = false;
            grbThongTin.Text = "Thông tin sinh viên";
            // 
            // lblDiemTB
            // 
            lblDiemTB.AutoSize = true;
            lblDiemTB.Location = new Point(17, 197);
            lblDiemTB.Name = "lblDiemTB";
            lblDiemTB.Size = new Size(136, 23);
            lblDiemTB.TabIndex = 5;
            lblDiemTB.Text = "Điểm trung bình";
            // 
            // lblTenSV
            // 
            lblTenSV.AutoSize = true;
            lblTenSV.Location = new Point(23, 118);
            lblTenSV.Name = "lblTenSV";
            lblTenSV.Size = new Size(108, 23);
            lblTenSV.TabIndex = 4;
            lblTenSV.Text = "Tên sinh viên";
            // 
            // txtDiemTrungBinh
            // 
            txtDiemTrungBinh.Location = new Point(17, 239);
            txtDiemTrungBinh.Name = "txtDiemTrungBinh";
            txtDiemTrungBinh.Size = new Size(244, 30);
            txtDiemTrungBinh.TabIndex = 3;
            // 
            // txtTenSinhVien
            // 
            txtTenSinhVien.Location = new Point(21, 146);
            txtTenSinhVien.Name = "txtTenSinhVien";
            txtTenSinhVien.Size = new Size(244, 30);
            txtTenSinhVien.TabIndex = 2;
            // 
            // txtMaSinhVien
            // 
            txtMaSinhVien.Location = new Point(19, 73);
            txtMaSinhVien.Name = "txtMaSinhVien";
            txtMaSinhVien.Size = new Size(245, 30);
            txtMaSinhVien.TabIndex = 1;
            // 
            // lblMaSV
            // 
            lblMaSV.AutoSize = true;
            lblMaSV.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMaSV.Location = new Point(17, 38);
            lblMaSV.Name = "lblMaSV";
            lblMaSV.Size = new Size(110, 23);
            lblMaSV.TabIndex = 0;
            lblMaSV.Text = "Mã sinh viên:";
            lblMaSV.Click += label1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(grbThongTin);
            Controls.Add(grbSinhVien);
            Controls.Add(btnThoat);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Name = "Form1";
            Text = "Quản lý Hồ sơ sinh viên / Học phần - VP102";
            grbSinhVien.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSinhVien).EndInit();
            grbThongTin.ResumeLayout(false);
            grbThongTin.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnThoat;
        private GroupBox grbSinhVien;
        private GroupBox grbThongTin;
        private Label lblMaSV;
        private Label lblTenSV;
        private TextBox txtDiemTrungBinh;
        private TextBox txtTenSinhVien;
        private TextBox txtMaSinhVien;
        private DataGridView dgvSinhVien;
        private Label lblDiemTB;
    }
}
