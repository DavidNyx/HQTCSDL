USE DATH1
GO
--SELECT * FROM SANPHAM
BEGIN TRANSACTION
SET TRAN ISOLATION LEVEL REPEATABLE READ
SELECT * FROM SANPHAM WHERE MASP = 'SP0000000001'

WAITFOR DELAY '00:00:05'

SELECT * FROM SANPHAM WHERE MASP = 'SP0000000001'
COMMIT TRANSACTION