﻿CREATE PROC UPDATE_HOPDONG2
	@MADOITAC CHAR(12),
	@MATHUE CHAR(12),
	@DATE DATE,
	@HOAHONG FLOAT
AS
BEGIN
	BEGIN TRAN
		SET TRAN ISOLATION LEVEL READ UNCOMMITTED
		IF NOT EXISTS (SELECT * FROM DOITAC WHERE DOITAC.MADOITAC = @MADOITAC)
		BEGIN
			ROLLBACK
			RAISERROR(N'Đối tác không tồn tại', 16, 1)
		END
		DECLARE @HIEULUC DATE
		SET @HIEULUC = (SELECT TGHIEULUC FROM dbo.HOPDONG WHERE MADOITAC = @MADOITAC AND MATHUE = @MATHUE)
		UPDATE dbo.HOPDONG
		SET TGHIEULUC = @DATE, PHANTRAMHOAHONG = @HOAHONG
		WHERE MADOITAC = @MADOITAC AND MATHUE = @MATHUE

		IF @DATE < @HIEULUC
		BEGIN
			ROLLBACK
			RAISERROR(N'Ngày gia hạn trước thời gian hiệu lực',16,1)
			RETURN
		END
	COMMIT TRAN
END
GO
EXEC dbo.UPDATE_HOPDONG2 @MADOITAC = 'DT0000000001',       -- char(12)
                        @MATHUE = 'MT0000000001',         -- char(12)
                        @DATE = '2022-01-04', -- date
                        @HOAHONG = 4        -- float

DROP PROC UPDATE_HOPDONG2