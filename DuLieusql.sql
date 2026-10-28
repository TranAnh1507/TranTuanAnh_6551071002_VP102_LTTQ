CREATE TABLE SinhVien (
    MaSinhVien NVARCHAR(10) PRIMARY KEY,
    TenSinhVien NVARCHAR(100) NOT NULL,
    DiemTrungBinh DECIMAL(3,1) NOT NULL
)

INSERT INTO SinhVien (MaSinhVien, TenSinhVien, DiemTrungBinh)
VALUES
('SV001', N'Nguyễn Văn A', 8.5),
('SV002', N'Trần Thị B', 7.0),
('SV003', N'Lê Văn C', 9.0),
('SV004', N'Phạm Thị D', 6.5),
('SV005', N'Hoàng Văn E', 8.0)