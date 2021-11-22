﻿CREATE PROC CAPNHATSP
    @MASP CHAR(12),
    @MALOAI CHAR(12),
    @TENSP NVARCHAR(50),
    @MOTA NVARCHAR(250),
    @GIA FLOAT
AS
BEGIN
    BEGIN TRAN
        IF NOT EXISTS(SELECT * FROM dbo.SANPHAM WHERE MASP = @MASP)
        BEGIN
            ROLLBACK TRAN
            raiserror(N'Sản phẩm không tồn tại', 16, 1)
        END
        UPDATE dbo.SANPHAM
		SET MALOAI = @MALOAI, TENSP = @TENSP, MOTA = @MOTA, GIA = @GIA
		WHERE MASP = @MASP
		WAITFOR DELAY '00:00:05'
		IF NOT EXISTS(SELECT * FROM dbo.LOAISP WHERE MALOAI = @MALOAI)
        BEGIN
            ROLLBACK TRAN
            raiserror(N'Loại sản phẩm không tồn tại', 16, 1)
        END
    COMMIT TRAN
END
GO

EXEC dbo.CAPNHATSP @MASP = 'SP0000000001',   -- char(12)
                @MALOAI = 'LSP000000001', -- char(12)
                @TENSP = N'Bánh bò', -- nvarchar(50)
                @MOTA = N'Thơm ngon.',  -- nvarchar(250)
                @GIA = 3000.0    -- float
GO