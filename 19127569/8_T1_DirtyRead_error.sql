﻿use DATH1
GO

CREATE PROC INSERT_GHINHAN
	@MADH CHAR(12),
	@MASP CHAR(12),
	@SOLUONG INT
AS
BEGIN
	BEGIN TRAN
	IF NOT EXISTS(SELECT*FROM dbo.DONHANG WHERE MADH = @MADH)
	BEGIN
		ROLLBACK TRAN
		RAISERROR(N'Đơn hàng không tồn tại.', 16, 1)
	END
	IF NOT EXISTS(SELECT*FROM dbo.SANPHAM WHERE MASP = @MASP)
	BEGIN
		ROLLBACK TRAN
		RAISERROR(N'Sản phẩm không tồn tại.', 16, 1)
	END

	INSERT dbo.GHINHAN
	(
	    MASP,
	    MADH,
	    SL
	)
	VALUES
	(   @MASP,  -- MASP - char(12)
	    @MADH,  -- MADH - char(12)
	    @SOLUONG -- SL - int
	    )

	DECLARE @GIA FLOAT
	SET @GIA = (SELECT GIA FROM dbo.SANPHAM WHERE MASP = @MASP)

	UPDATE dbo.DONHANG
	SET SLSP = SLSP + @SOLUONG, PHISP = PHISP + @SOLUONG * @GIA
	WHERE MADH = @MADH

	DECLARE @TONKHO INT
	SET @TONKHO = (SELECT SLSP FROM dbo.QUANLYKHO WHERE MACN = (SELECT MIN(MACN) FROM dbo.QUANLYKHO WHERE  dbo.QUANLYKHO.MASP = @MASP AND dbo.QUANLYKHO.MADOITAC = @MADH AND dbo.QUANLYKHO.SLSP > @SOLUONG)
	AND dbo.QUANLYKHO.MADOITAC = @MADH AND dbo.QUANLYKHO.MASP = @MASP)

	UPDATE dbo.QUANLYKHO
	SET SLSP = @TONKHO - @SOLUONG
	FROM dbo.DONHANG
	WHERE MACN = (SELECT MIN(MACN) FROM dbo.QUANLYKHO WHERE  dbo.QUANLYKHO.MASP = @MASP AND dbo.QUANLYKHO.MADOITAC = dbo.DONHANG.MADOITAC)
	AND dbo.DONHANG.MADH = @MADH AND dbo.QUANLYKHO.MADOITAC = dbo.DONHANG.MADOITAC AND dbo.QUANLYKHO.MASP = @MASP

	WAITFOR DELAY '00:00:05'
	IF NOT EXISTS(SELECT dbo.QUANLYKHO.*FROM dbo.QUANLYKHO, dbo.DONHANG WHERE dbo.DONHANG.MADH = @MADH AND dbo.QUANLYKHO.MADOITAC = dbo.DONHANG.MADOITAC
	AND dbo.QUANLYKHO.MASP = @MASP AND dbo.QUANLYKHO.SLSP > @SOLUONG)
	BEGIN
		ROLLBACK TRAN
		RAISERROR(N'Số lượng hàng trong kho không đủ.', 16, 1)
		RETURN
	END
	COMMIT TRAN
END
GO

DROP PROCEDURE dbo.INSERT_GHINHAN
GO

SELECT * FROM dbo.DONHANG
GO

EXEC dbo.INSERT_GHINHAN @MADH = 'HD0000000002',  -- char(12)
                        @MASP = 'SP0000000005',  -- char(12)
                        @SOLUONG = 600 -- int
GO

DROP PROCEDURE dbo.INSERT_GHINHAN

DELETE dbo.GHINHAN