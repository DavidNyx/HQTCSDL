﻿CREATE PROC UPDATE_SOLUONG
	@MADT CHAR(12),
    @MACN INT,
    @MASP CHAR(12),
    @LUONG_TANG INT
AS
BEGIN
	BEGIN TRAN
		IF NOT EXISTS (SELECT * FROM QUANLYKHO WHERE QUANLYKHO.MASP = @MASP AND QUANLYKHO.MACN = @MACN AND dbo.QUANLYKHO.MADOITAC = @MADT)
		BEGIN
			ROLLBACK
			RAISERROR(N'Sản phẩm không tồn tại trong kho này', 16, 1)
		END
		DECLARE @SO_LUONG INT
		SET @SO_LUONG = (SELECT dbo.QUANLYKHO.SLSP FROM QUANLYKHO WHERE QUANLYKHO.MASP = @MASP AND QUANLYKHO.MACN = @MACN AND dbo.QUANLYKHO.MADOITAC = @MADT)
		WAITFOR DELAY '00:00:05'
		UPDATE dbo.QUANLYKHO
		SET SLSP = @SO_LUONG + @LUONG_TANG
		WHERE MACN = @MACN AND MASP = @MASP AND MADOITAC = @MADT
		DECLARE @SLSP INT
		SET @SLSP = (SELECT dbo.QUANLYKHO.SLSP FROM QUANLYKHO WHERE QUANLYKHO.MASP = @MASP AND QUANLYKHO.MACN = @MACN AND dbo.QUANLYKHO.MADOITAC = @MADT)
		IF @SLSP < 0
		BEGIN
			ROLLBACK
			RAISERROR(N'Nhập sai số lượng tăng',16,1)
			RETURN
		END
	COMMIT TRAN
END
GO

EXEC dbo.UPDATE_SOLUONG 
	@MADT = 'DT0000000001',
	@MACN = 1,
	@MASP = 'SP0000000002',   -- char(12)
	@LUONG_TANG = 20
GO