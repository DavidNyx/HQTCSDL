USE DATH1
GO

INSERT dbo.LOAISP
(
    MALOAI,
    TENLOAI
)
VALUES
(   'LSP000000001',  -- MALOAI - char(12)
    N'Bánh kẹo' -- TENLOAI - nvarchar(20)
    ),
(   'LSP000000002',  -- MALOAI - char(12)
    N'Đồ đa dụng' -- TENLOAI - nvarchar(20)
    ),
(   'LSP000000003',  -- MALOAI - char(12)
    N'Thiết bị điện tử' -- TENLOAI - nvarchar(20)
    ),
(   'LSP000000004',  -- MALOAI - char(12)
    N'Nước uống' -- TENLOAI - nvarchar(20)
    ),
(   'LSP000000005',  -- MALOAI - char(12)
    N'Văn phòng phẩm' -- TENLOAI - nvarchar(20)
    ),
(   'LSP000000006',  -- MALOAI - char(12)
    N'Trái cây' -- TENLOAI - nvarchar(20)
    ),
(   'LSP000000007',  -- MALOAI - char(12)
    N'Rau củ' -- TENLOAI - nvarchar(20)
    ),
(   'LSP000000008',  -- MALOAI - char(12)
    N'Thực phẩm khô' -- TENLOAI - nvarchar(20)
    ),
(   'LSP000000009',  -- MALOAI - char(12)
    N'Thực phẩm tươi' -- TENLOAI - nvarchar(20)
    ),
(   'LSP000000010',  -- MALOAI - char(12)
    N'Quần áo' -- TENLOAI - nvarchar(20)
    )

INSERT dbo.SANPHAM
(
    MASP,
    MALOAI,
    TENSP,
    MOTA,
    GIA
)
VALUES
(   'SP0000000001',   -- MASP - char(12)
    'LSP000000001',   -- MALOAI - char(12)
    N'Chocolate', -- TENSP - nvarchar(50)
    N'Ngon.', -- MOTA - nvarchar(250)
    10000  -- GIA - float
    ),
(   'SP0000000002',   -- MASP - char(12)
    'LSP000000001',   -- MALOAI - char(12)
    N'Kẹo dừa', -- TENSP - nvarchar(50)
    N'Ngọt.', -- MOTA - nvarchar(250)
    3000  -- GIA - float
    ),
(   'SP0000000003',   -- MASP - char(12)
    'LSP000000001',   -- MALOAI - char(12)
    N'Kẹo sữa', -- TENSP - nvarchar(50)
    N'Béo.', -- MOTA - nvarchar(250)
    4000  -- GIA - float
    ),
(   'SP0000000004',   -- MASP - char(12)
    'LSP000000001',   -- MALOAI - char(12)
    N'Bánh bông lan', -- TENSP - nvarchar(50)
    N'Bình thường.', -- MOTA - nvarchar(250)
    5000  -- GIA - float
    ),
(   'SP0000000005',   -- MASP - char(12)
    'LSP000000002',   -- MALOAI - char(12)
    N'Ghế', -- TENSP - nvarchar(50)
    N'Dùng để ngồi.', -- MOTA - nvarchar(250)
    15000  -- GIA - float
    ),
(   'SP0000000006',   -- MASP - char(12)
    'LSP000000002',   -- MALOAI - char(12)
    N'Bàn', -- TENSP - nvarchar(50)
    N'Dùng để đặt đồ vật bên trên.', -- MOTA - nvarchar(250)
    20000  -- GIA - float
    ),
(   'SP0000000007',   -- MASP - char(12)
    'LSP000000003',   -- MALOAI - char(12)
    N'Quạt', -- TENSP - nvarchar(50)
    N'Dùng lúc nóng.', -- MOTA - nvarchar(250)
    50000  -- GIA - float
    ),
(   'SP0000000008',   -- MASP - char(12)
    'LSP000000003',   -- MALOAI - char(12)
    N'Máy lạnh', -- TENSP - nvarchar(50)
    N'Dùng lúc rất nóng.', -- MOTA - nvarchar(250)
    3000000  -- GIA - float
    ),
(   'SP0000000009',   -- MASP - char(12)
    'LSP000000002',   -- MALOAI - char(12)
    N'Sofa', -- TENSP - nvarchar(50)
    N'Là ghế nhưng êm hơn.', -- MOTA - nvarchar(250)
    100000  -- GIA - float
    ),
(   'SP0000000010',   -- MASP - char(12)
    'LSP000000002',   -- MALOAI - char(12)
    N'Tủ', -- TENSP - nvarchar(50)
    N'Dùng để chứa đồ.', -- MOTA - nvarchar(250)
    30000  -- GIA - float
    ),
(   'SP0000000011',   -- MASP - char(12)
    'LSP000000003',   -- MALOAI - char(12)
    N'Tủ lạnh', -- TENSP - nvarchar(50)
    N'Dùng để bảo quản thực phẩm.', -- MOTA - nvarchar(250)
    4000000  -- GIA - float
    ),
(   'SP0000000012',   -- MASP - char(12)
    'LSP000000003',   -- MALOAI - char(12)
    N'Máy giặt', -- TENSP - nvarchar(50)
    N'Dùng để giặt đồ.', -- MOTA - nvarchar(250)
    2000000  -- GIA - float
    ),
(   'SP0000000013',   -- MASP - char(12)
    'LSP000000004',   -- MALOAI - char(12)
    N'Nước suối', -- TENSP - nvarchar(50)
    N'Tiện dụng', -- MOTA - nvarchar(250)
    5000  -- GIA - float
    ),
(   'SP0000000014',   -- MASP - char(12)
    'LSP000000004',   -- MALOAI - char(12)
    N'Nước ngọt có ga', -- TENSP - nvarchar(50)
    N'Không tốt cho sức khỏe.', -- MOTA - nvarchar(250)
    7000  -- GIA - float
    ),
(   'SP0000000015',   -- MASP - char(12)
    'LSP000000004',   -- MALOAI - char(12)
    N'Nước tăng lực', -- TENSP - nvarchar(50)
    N'Rất không tốt cho sức khỏe.', -- MOTA - nvarchar(250)
    11000  -- GIA - float
    ),
(   'SP0000000016',   -- MASP - char(12)
    'LSP000000005',   -- MALOAI - char(12)
    N'Bút chì', -- TENSP - nvarchar(50)
    N'Xóa được.', -- MOTA - nvarchar(250)
    3000  -- GIA - float
    ),
(   'SP0000000017',   -- MASP - char(12)
    'LSP000000005',   -- MALOAI - char(12)
    N'Bút bi', -- TENSP - nvarchar(50)
    N'Không xóa được.', -- MOTA - nvarchar(250)
    4000  -- GIA - float
    ),
(   'SP0000000018',   -- MASP - char(12)
    'LSP000000005',   -- MALOAI - char(12)
    N'Tẩy', -- TENSP - nvarchar(50)
    N'Xóa vết bút chì.', -- MOTA - nvarchar(250)
    2000  -- GIA - float
    ),
(   'SP0000000019',   -- MASP - char(12)
    'LSP000000006',   -- MALOAI - char(12)
    N'Táo', -- TENSP - nvarchar(50)
    N'Tốt cho sức khỏe.', -- MOTA - nvarchar(250)
    5000  -- GIA - float
    ),
(   'SP0000000020',   -- MASP - char(12)
    'LSP000000006',   -- MALOAI - char(12)
    N'Lê', -- TENSP - nvarchar(50)
    N'Thơm.', -- MOTA - nvarchar(250)
    15000  -- GIA - float
    ),
(   'SP0000000021',   -- MASP - char(12)
    'LSP000000006',   -- MALOAI - char(12)
    N'Thơm', -- TENSP - nvarchar(50)
    N'Ngọt.', -- MOTA - nvarchar(250)
    10000  -- GIA - float
    ),
(   'SP0000000022',   -- MASP - char(12)
    'LSP000000006',   -- MALOAI - char(12)
    N'Quýt', -- TENSP - nvarchar(50)
    N'Lúc chua lúc ngọt, nói chung là quýt.', -- MOTA - nvarchar(250)
    13000  -- GIA - float
    ),
(   'SP0000000023',   -- MASP - char(12)
    'LSP000000007',   -- MALOAI - char(12)
    N'Cà rốt', -- TENSP - nvarchar(50)
    N'Tốt cho mắt.', -- MOTA - nvarchar(250)
    4000  -- GIA - float
    ),
(   'SP0000000024',   -- MASP - char(12)
    'LSP000000007',   -- MALOAI - char(12)
    N'Cà chua', -- TENSP - nvarchar(50)
    N'Chua.', -- MOTA - nvarchar(250)
    3000  -- GIA - float
    ),
(   'SP0000000025',   -- MASP - char(12)
    'LSP000000007',   -- MALOAI - char(12)
    N'Rau muống', -- TENSP - nvarchar(50)
    N'Rẻ.', -- MOTA - nvarchar(250)
    1000  -- GIA - float
    ),
(   'SP0000000026',   -- MASP - char(12)
    'LSP000000007',   -- MALOAI - char(12)
    N'Bắp cải', -- TENSP - nvarchar(50)
    N'Không biết mô tả gì.', -- MOTA - nvarchar(250)
    7000  -- GIA - float
    ),
(   'SP0000000027',   -- MASP - char(12)
    'LSP000000008',   -- MALOAI - char(12)
    N'Ngũ cốc', -- TENSP - nvarchar(50)
    N'Tốt cho sức khỏe.', -- MOTA - nvarchar(250)
    7000  -- GIA - float
    ),
(   'SP0000000028',   -- MASP - char(12)
    'LSP000000008',   -- MALOAI - char(12)
    N'Gạo', -- TENSP - nvarchar(50)
    N'Thơm.', -- MOTA - nvarchar(250)
    15000  -- GIA - float
    ),
(   'SP0000000029',   -- MASP - char(12)
    'LSP000000009',   -- MALOAI - char(12)
    N'Cá', -- TENSP - nvarchar(50)
    N'Tươi.', -- MOTA - nvarchar(250)
    30000  -- GIA - float
    ),
(   'SP0000000030',   -- MASP - char(12)
    'LSP000000009',   -- MALOAI - char(12)
    N'Thịt gà', -- TENSP - nvarchar(50)
    N'Gà.', -- MOTA - nvarchar(250)
    35000  -- GIA - float
    ),
(   'SP0000000031',   -- MASP - char(12)
    'LSP000000009',   -- MALOAI - char(12)
    N'Thịt heo', -- TENSP - nvarchar(50)
    N'Heo.', -- MOTA - nvarchar(250)
    40000  -- GIA - float
    ),
(   'SP0000000032',   -- MASP - char(12)
    'LSP000000009',   -- MALOAI - char(12)
    N'Thịt bò.', -- TENSP - nvarchar(50)
    N'Đắt.', -- MOTA - nvarchar(250)
    60000  -- GIA - float
    ),
(   'SP0000000033',   -- MASP - char(12)
    'LSP000000010',   -- MALOAI - char(12)
    N'Áo sơ mi', -- TENSP - nvarchar(50)
    N'Lịch sự.', -- MOTA - nvarchar(250)
    200000  -- GIA - float
    ),
(   'SP0000000034',   -- MASP - char(12)
    'LSP000000010',   -- MALOAI - char(12)
    N'Áo thun', -- TENSP - nvarchar(50)
    N'Thoải mái.', -- MOTA - nvarchar(250)
    150000  -- GIA - float
    ),
(   'SP0000000035',   -- MASP - char(12)
    'LSP000000010',   -- MALOAI - char(12)
    N'Quần jean', -- TENSP - nvarchar(50)
    N'Không thoải mái.', -- MOTA - nvarchar(250)
    170000  -- GIA - float
    )

INSERT dbo.DOITAC
(
    MADOITAC,
    TENDOITAC,
    NGUOIDAIDIEN,
    QUAN,
    THANHPHO,
    SOCHINHANH,
    SLHANGNGAY,
    DIACHIKD,
    SDTDOITAC,
    EMAIL
)
VALUES
(   'DT0000000001',   -- MADOITAC - char(12)
    N'Đối tác A', -- TENDOITAC - nvarchar(50)
    N'Nguyễn Văn A', -- NGUOIDAIDIEN - nvarchar(50)
    N'1', -- QUAN - nvarchar(20)
    N'HCM', -- THANHPHO - nvarchar(20)
    1, -- SOCHINHANH - int
    0, -- SLHANGNGAY - int
    N'1, Lê Lai', -- DIACHIKD - nvarchar(100)
    '0123456789', -- SDTDOITAC - char(10)
    'nva@gmail.com'  -- EMAIL - varchar(50)
    ),
(   'DT0000000002',   -- MADOITAC - char(12)
    N'Đối tác B', -- TENDOITAC - nvarchar(50)
    N'Nguyễn Thị B', -- NGUOIDAIDIEN - nvarchar(50)
    N'Hai Bà Trưng', -- QUAN - nvarchar(20)
    N'Hà Nội', -- THANHPHO - nvarchar(20)
    2, -- SOCHINHANH - int
    0, -- SLHANGNGAY - int
    N'1, Đại La', -- DIACHIKD - nvarchar(100)
    '1234567890', -- SDTDOITAC - char(10)
    'bnh@gmail.com'  -- EMAIL - varchar(50)
    ),
(   'DT0000000003',   -- MADOITAC - char(12)
    N'Đối tác D', -- TENDOITAC - nvarchar(50)
    N'Trần D', -- NGUOIDAIDIEN - nvarchar(50)
    N'Đà Lạt', -- QUAN - nvarchar(20)
    N'Lâm Đồng', -- THANHPHO - nvarchar(20)
    3, -- SOCHINHANH - int
    0, -- SLHANGNGAY - int
    N'60, Pasteur', -- DIACHIKD - nvarchar(100)
    '0987654321', -- SDTDOITAC - char(10)
    'tranD@gmail.com'  -- EMAIL - varchar(50)
    )

INSERT dbo.HOPDONG
(
    MADOITAC,
    MATHUE,
    SOCNDK,
    TGHIEULUC,
    PHANTRAMHOAHONG,
    PHIHOAHONG
)
VALUES
(   'DT0000000001',   -- MADOITAC - char(12)
    'MT0000000001',   -- MATHUE - char(12)
    1, -- SOCNDK - int
    '2022-01-01', -- TGHIEULUC - datetime
    5, -- PHANTRAMHOAHONG - float
    1000000 -- PHIHOAHONG - float
    ),
(   'DT0000000002',   -- MADOITAC - char(12)
    'MT0000000002',   -- MATHUE - char(12)
    2, -- SOCNDK - int
    '2021-12-20', -- TGHIEULUC - datetime
    5, -- PHANTRAMHOAHONG - float
    1000000 -- PHIHOAHONG - float
    ),
(   'DT0000000003',   -- MADOITAC - char(12)
    'MT0000000003',   -- MATHUE - char(12)
    3, -- SOCNDK - int
    '2022-01-01', -- TGHIEULUC - datetime
    5, -- PHANTRAMHOAHONG - float
    1000000 -- PHIHOAHONG - float
    )

INSERT dbo.CHINHANH
(
    MADOITAC,
	MACN,
    TENCN,
    DIACHICN,
	MATHUE
)
VALUES
(   'DT0000000001',   -- MADOITAC - char(12)
	1,   -- MACN - int
    N'Trụ sở', -- TENCN - nvarchar(50)
    N'1, Lê Lai, quận 1, HCM',  -- DIACHICN - nvarchar(100)
	'MT0000000001'   -- MATHUE - char(12)
    ),
(   'DT0000000002',   -- MADOITAC - char(12)
	1,   -- MACN - int
    N'Chi nhánh 1', -- TENCN - nvarchar(50)
    N'1, Đại La, quận Hai Bà Trưng, Hà Nội',  -- DIACHICN - nvarchar(100)
	'MT0000000002'   -- MATHUE - char(12)
    ),
(   'DT0000000002',   -- MADOITAC - char(12)
	2,   -- MACN - int
    N'Chi nhánh 2', -- TENCN - nvarchar(50)
    N'1, Thái Hà, quận Đống Đa, Hà Nội',  -- DIACHICN - nvarchar(100)
	'MT0000000002'   -- MATHUE - char(12)
    ),
(   'DT0000000003',   -- MADOITAC - char(12)
	1,   -- MACN - int
    N'Chi nhánh A', -- TENCN - nvarchar(50)
    N'24, Nguyễn Văn Trỗi, Đà Lạt, Lâm Đồng',  -- DIACHICN - nvarchar(100)
	'MT0000000003'   -- MATHUE - char(12)
    ),
(   'DT0000000003',   -- MADOITAC - char(12)
    2,   -- MACN - int
    N'Chi nhánh B', -- TENCN - nvarchar(50)
    N'23, Lê Hồng Phong, Đà Lạt, Lâm Đồng',  -- DIACHICN - nvarchar(100)
	'MT0000000003'   -- MATHUE - char(12)
    ),
(   'DT0000000003',   -- MADOITAC - char(12)
	3,   -- MACN - int
    N'Chi nhánh C', -- TENCN - nvarchar(50)
    N'27, Trần Lê, Đà Lạt, Lâm Đồng',  -- DIACHICN - nvarchar(100)
	'MT0000000003'   -- MATHUE - char(12)
    )

INSERT dbo.LOAIHANGVANCHUYEN
(
    MALOAI,
    MADOITAC
)
VALUES
(   'LSP000000001', -- MALOAI - char(12)
    'DT0000000001'  -- MADOITAC - char(12)
    ),
(   'LSP000000002', -- MALOAI - char(12)
    'DT0000000001'  -- MADOITAC - char(12)
    ),
(   'LSP000000003', -- MALOAI - char(12)
    'DT0000000001'  -- MADOITAC - char(12)
    ),
(   'LSP000000004', -- MALOAI - char(12)
    'DT0000000001'  -- MADOITAC - char(12)
    ),
(   'LSP000000005', -- MALOAI - char(12)
    'DT0000000001'  -- MADOITAC - char(12)
    ),
(   'LSP000000001', -- MALOAI - char(12)
    'DT0000000002'  -- MADOITAC - char(12)
    ),
(   'LSP000000002', -- MALOAI - char(12)
    'DT0000000002'  -- MADOITAC - char(12)
    ),
(   'LSP000000003', -- MALOAI - char(12)
    'DT0000000002'  -- MADOITAC - char(12)
    ),
(   'LSP000000010', -- MALOAI - char(12)
    'DT0000000002'  -- MADOITAC - char(12)
    ),
(   'LSP000000001', -- MALOAI - char(12)
    'DT0000000003'  -- MADOITAC - char(12)
    ),
(   'LSP000000006', -- MALOAI - char(12)
    'DT0000000003'  -- MADOITAC - char(12)
    ),
(   'LSP000000007', -- MALOAI - char(12)
    'DT0000000003'  -- MADOITAC - char(12)
    ),
(   'LSP000000008', -- MALOAI - char(12)
    'DT0000000003'  -- MADOITAC - char(12)
    ),
(   'LSP000000009', -- MALOAI - char(12)
    'DT0000000003'  -- MADOITAC - char(12)
    ),
(   'LSP000000010', -- MALOAI - char(12)
    'DT0000000003'  -- MADOITAC - char(12)
    )

INSERT dbo.QUANLYKHO
(
	MADOITAC,
    MACN,
    MASP,
    SLSP
)
VALUES
(   'DT0000000001',  -- MADT - char(12)
	1,  -- MACN - int
    'SP0000000001',  -- MASP - char(12)
    1000 -- SLSP - int
    ),
(   'DT0000000001',  -- MACN - char(12)
	1,  -- MACN - int
    'SP0000000002',  -- MASP - char(12)
    3000 -- SLSP - int
    ),
(   'DT0000000001',  -- MACN - char(12)
	1,  -- MACN - int
    'SP0000000005',  -- MASP - char(12)
    500 -- SLSP - int
    ),
(   'DT0000000001',  -- MACN - char(12)
	1,  -- MACN - int
    'SP0000000006',  -- MASP - char(12)
    500 -- SLSP - int
    ),
(   'DT0000000001',  -- MACN - char(12)
	1,  -- MACN - int
    'SP0000000008',  -- MASP - char(12)
    1000 -- SLSP - int
    ),
(   'DT0000000001',  -- MACN - char(12)
	1,  -- MACN - int
    'SP0000000009',  -- MASP - char(12)
    1000 -- SLSP - int
    ),
(   'DT0000000001',  -- MACN - char(12)
	1,  -- MACN - int
    'SP0000000013',  -- MASP - char(12)
    10000 -- SLSP - int
    ),
(   'DT0000000001',  -- MACN - char(12)
	1,  -- MACN - int
    'SP0000000014',  -- MASP - char(12)
    7000 -- SLSP - int
    ),
(   'DT0000000001',  -- MACN - char(12)
	1,  -- MACN - int
    'SP0000000015',  -- MASP - char(12)
    5000 -- SLSP - int
    ),
(   'DT0000000001',  -- MACN - char(12)
	1,  -- MACN - int
    'SP0000000016',  -- MASP - char(12)
    1000 -- SLSP - int
    ),
(   'DT0000000001',  -- MACN - char(12)
	1,  -- MACN - int
    'SP0000000017',  -- MASP - char(12)
    1000 -- SLSP - int
    ),
(   'DT0000000001',  -- MACN - char(12)
	1,  -- MACN - int
    'SP0000000018',  -- MASP - char(12)
    1000 -- SLSP - int
    ),
(   'DT0000000002',  -- MACN - char(12)
	1,  -- MACN - int
    'SP0000000001',  -- MASP - char(12)
    1000 -- SLSP - int
    ),
(   'DT0000000002',  -- MACN - char(12)
	1,  -- MACN - int
    'SP0000000003',  -- MASP - char(12)
    1000 -- SLSP - int
    ),
(   'DT0000000002',  -- MACN - char(12)
	1,  -- MACN - int
    'SP0000000004',  -- MASP - char(12)
    700 -- SLSP - int
    ),
(   'DT0000000002',  -- MACN - char(12)
	1,  -- MACN - int
    'SP0000000009',  -- MASP - char(12)
    1000 -- SLSP - int
    ),
(   'DT0000000002',  -- MACN - char(12)
	1,  -- MACN - int
    'SP0000000010',  -- MASP - char(12)
    600 -- SLSP - int
    ),
(   'DT0000000002',  -- MACN - char(12)
	1,  -- MACN - int
    'SP0000000007',  -- MASP - char(12)
    1000 -- SLSP - int
    ),
(   'DT0000000002',  -- MACN - char(12)
	1,  -- MACN - int
    'SP0000000011',  -- MASP - char(12)
    500 -- SLSP - int
    ),
(   'DT0000000002',  -- MACN - char(12)
	1,  -- MACN - int
    'SP0000000012',  -- MASP - char(12)
    400 -- SLSP - int
    ),
(   'DT0000000002',  -- MACN - char(12)
	1,  -- MACN - int
    'SP0000000033',  -- MASP - char(12)
    1000 -- SLSP - int
    ),
(   'DT0000000002',  -- MACN - char(12)
	1,  -- MACN - int
    'SP0000000034',  -- MASP - char(12)
    1000 -- SLSP - int
    ),
(   'DT0000000002',  -- MACN - char(12)
	1,  -- MACN - int
    'SP0000000035',  -- MASP - char(12)
    1000 -- SLSP - int
    ),
(   'DT0000000002',  -- MACN - char(12)
	2,  -- MACN - int
    'SP0000000001',  -- MASP - char(12)
    2000 -- SLSP - int
    ),
(   'DT0000000002',  -- MACN - char(12)
	2,  -- MACN - int
    'SP0000000003',  -- MASP - char(12)
    800 -- SLSP - int
    ),
(   'DT0000000002',  -- MACN - char(12)
	2,  -- MACN - int
    'SP0000000004',  -- MASP - char(12)
    1000 -- SLSP - int
    ),
(   'DT0000000002',  -- MACN - char(12)
	2,  -- MACN - int
    'SP0000000009',  -- MASP - char(12)
    750 -- SLSP - int
    ),
(   'DT0000000002',  -- MACN - char(12)
	2,  -- MACN - int
    'SP0000000010',  -- MASP - char(12)
    800 -- SLSP - int
    ),
(   'DT0000000002',  -- MACN - char(12)
	2,  -- MACN - int
    'SP0000000007',  -- MASP - char(12)
    3000 -- SLSP - int
    ),
(   'DT0000000002',  -- MACN - char(12)
	2,  -- MACN - int
    'SP0000000011',  -- MASP - char(12)
    400 -- SLSP - int
    ),
(   'DT0000000002',  -- MACN - char(12)
	2,  -- MACN - int
    'SP0000000012',  -- MASP - char(12)
    500 -- SLSP - int
    ),
(   'DT0000000002',  -- MACN - char(12)
	2,  -- MACN - int
    'SP0000000033',  -- MASP - char(12)
    5000 -- SLSP - int
    ),
(   'DT0000000002',  -- MACN - char(12)
	2,  -- MACN - int
    'SP0000000034',  -- MASP - char(12)
    5000 -- SLSP - int
    ),
(   'DT0000000002',  -- MACN - char(12)
	2,  -- MACN - int
    'SP0000000035',  -- MASP - char(12)
    5000 -- SLSP - int
    ),
(   'DT0000000003',  -- MACN - char(12)
	1,  -- MACN - int
    'SP0000000001',  -- MASP - char(12)
    1000 -- SLSP - int
    ),
(   'DT0000000003',  -- MACN - char(12)
	1,  -- MACN - int
    'SP0000000019',  -- MASP - char(12)
    1000 -- SLSP - int
    ),
(   'DT0000000003',  -- MACN - char(12)
	1,  -- MACN - int
    'SP0000000020',  -- MASP - char(12)
    1000 -- SLSP - int
    ),
(   'DT0000000003',  -- MACN - char(12)
	1,  -- MACN - int
    'SP0000000021',  -- MASP - char(12)
    1000 -- SLSP - int
    ),
(   'DT0000000003',  -- MACN - char(12)
	1,  -- MACN - int
    'SP0000000022',  -- MASP - char(12)
    1000 -- SLSP - int
    ),
(   'DT0000000003',  -- MACN - char(12)
	2,  -- MACN - int
    'SP0000000023',  -- MASP - char(12)
    1000 -- SLSP - int
    ),
(   'DT0000000003',  -- MACN - char(12)
	2,  -- MACN - int
    'SP0000000024',  -- MASP - char(12)
    1000 -- SLSP - int
    ),
(   'DT0000000003',  -- MACN - char(12)
	2,  -- MACN - int
    'SP0000000025',  -- MASP - char(12)
    1000 -- SLSP - int
    ),
(   'DT0000000003',  -- MACN - char(12)
	2,  -- MACN - int
    'SP0000000026',  -- MASP - char(12)
    1000 -- SLSP - int
    ),
(   'DT0000000003',  -- MACN - char(12)
	2,  -- MACN - int
    'SP0000000027',  -- MASP - char(12)
    1000 -- SLSP - int
    ),
(   'DT0000000003',  -- MACN - char(12)
	2,  -- MACN - int
    'SP0000000028',  -- MASP - char(12)
    1000 -- SLSP - int
    ),
(   'DT0000000003',  -- MACN - char(12)
	3,  -- MACN - int
    'SP0000000029',  -- MASP - char(12)
    1000 -- SLSP - int
    ),
(   'DT0000000003',  -- MACN - char(12)
	3,  -- MACN - int
    'SP0000000030',  -- MASP - char(12)
    1000 -- SLSP - int
    ),
(   'DT0000000003',  -- MACN - char(12)
	3,  -- MACN - int
    'SP0000000031',  -- MASP - char(12)
    1000 -- SLSP - int
    ),
(   'DT0000000003',  -- MACN - char(12)
	3,  -- MACN - int
    'SP0000000032',  -- MASP - char(12)
    1000 -- SLSP - int
    ),
(   'DT0000000003',  -- MACN - char(12)
	3,  -- MACN - int
    'SP0000000033',  -- MASP - char(12)
    1000 -- SLSP - int
    ),
(   'DT0000000003',  -- MACN - char(12)
	3,  -- MACN - int
    'SP0000000034',  -- MASP - char(12)
    1000 -- SLSP - int
    ),
(   'DT0000000003',  -- MACN - char(12)
	3,  -- MACN - int
    'SP0000000035',  -- MASP - char(12)
    1000 -- SLSP - int
    )

INSERT dbo.KHACHHANG
(
    MAKH,
    HOTENKH,
    SDTKH,
    DIACHIKH,
    EMAILKH
)
VALUES
(   'KH0000000001',   -- MAKH - char(12)
    N'Ngyễn X', -- HOTENKH - nvarchar(50)
    '0000000000', -- SDTKH - char(10)
    N'1, Ngyễn Tất Thành, quận 4, HCM', -- DIACHIKH - nvarchar(100)
    'x@gmail.com'  -- EMAILKH - varchar(50)
    ),
(   'KH0000000002',   -- MAKH - char(12)
    N'Lê Y', -- HOTENKH - nvarchar(50)
    '1111111111', -- SDTKH - char(10)
    N'456, Lê Lợi, quận Gò Vấp, HCM', -- DIACHIKH - nvarchar(100)
    'leY@gmail.com'  -- EMAILKH - varchar(50)
    )

INSERT dbo.TAIXE
(
    CMND,
    HOTEN,
    SDTTAIXE,
    DIACHITX,
    BIENSO,
    KHUVUCHD,
    EMAILTAIXE,
    TKNGH,
    SODONHANG,
    THUNHAP
)
VALUES
(   '000000000001',   -- CMND - char(12)
    N'Trần H', -- HOTEN - nvarchar(50)
    '1212121212', -- SDTTAIXE - char(10)
    N'2, Trần Hưng Đạo, quận 1, HCM', -- DIACHITX - nvarchar(100)
    '51-T1-000001', -- BIENSO - char(12)
    N'quận 4, HCM', -- KHUVUCHD - nvarchar(100)
    'TH@gmail.com', -- EMAILTAIXE - varchar(50)
    'xxxx00000001', -- TKNGH - char(12)
    0, -- SODONHANG - int
    0  -- THUNHAP - float
    ),
(   '000000000002',   -- CMND - char(12)
    N'Lê I', -- HOTEN - nvarchar(50)
    '1313131313', -- SDTTAIXE - char(10)
    N'135, Phan Đăng Lưu, quận Phú Nhuận, HCM', -- DIACHITX - nvarchar(100)
    '51-E1-000001', -- BIENSO - char(12)
    N'quận Gò Vấp, HCM', -- KHUVUCHD - nvarchar(100)
    'lei@gmail.com', -- EMAILTAIXE - varchar(50)
    'xxxx00000002', -- TKNGH - char(12)
    0, -- SODONHANG - int
    0  -- THUNHAP - float
    )

INSERT dbo.DONHANG
(
    MADH,
    MADOITAC,
    CMND,
    MAKH,
    SLSP,
    PHISP,
    PHIVC,
    QTVC,
    HTTHANHTOAN
)
VALUES
(   'HD0000000001',   -- MADH - char(12)
    'DT0000000003',   -- MADOITAC - char(12)
    '000000000001',   -- CMND - char(12)
    'KH0000000001',   -- MAKH - char(12)
    3, -- SLSP - int
    0, -- PHISP - float
    10000, -- PHIVC - float
    N'Hoàn tất', -- QTVC - nvarchar(100)
    N'Tiền mặt'  -- HTTHANHTOAN - nvarchar(20)
    ),
(   'HD0000000002',   -- MADH - char(12)
    'DT0000000001',   -- MADOITAC - char(12)
    '000000000002',   -- CMND - char(12)
    'KH0000000002',   -- MAKH - char(12)
    5, -- SLSP - int
    0, -- PHISP - float
    20000, -- PHIVC - float
    N'Hoàn tất', -- QTVC - nvarchar(100)
    N'Thẻ'  -- HTTHANHTOAN - nvarchar(20)
    )

INSERT dbo.GHINHAN
(
    MASP,
    MADH,
    SL
)
VALUES
(   'SP0000000001',  -- MASP - char(12)
    'HD0000000001',  -- MADH - char(12)
    3 -- SL - int
    ),
(   'SP0000000001',  -- MASP - char(12)
    'HD0000000002',  -- MADH - char(12)
    1 -- SL - int
    ),
(   'SP0000000002',  -- MASP - char(12)
    'HD0000000002',  -- MADH - char(12)
    4 -- SL - int
    )


SELECT*FROM dbo.LOAISP
SELECT*FROM dbo.SANPHAM
SELECT*FROM dbo.DOITAC
SELECT*FROM dbo.HOPDONG
SELECT*FROM dbo.CHINHANH
SELECT*FROM dbo.LOAIHANGVANCHUYEN
SELECT*FROM dbo.QUANLYKHO
SELECT*FROM dbo.KHACHHANG
SELECT*FROM dbo.TAIXE
SELECT*FROM dbo.DONHANG
SELECT*FROM dbo.GHINHAN