﻿USE DATH1
GO
--SELECT * FROM SANPHAM
BEGIN TRANSACTION
SELECT * FROM SANPHAM SP, QUANLYKHO QL 
	WHERE SP.MASP = QL.MASP AND QL.MADOITAC = 'DT0000000001'

WAITFOR DELAY '00:00:10'

SELECT * FROM SANPHAM SP, QUANLYKHO QL 
	WHERE SP.MASP = QL.MASP AND QL.MADOITAC = 'DT0000000001'
COMMIT TRANSACTION