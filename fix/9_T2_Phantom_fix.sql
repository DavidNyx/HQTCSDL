﻿USE DATH1
GO

INSERT dbo.SANPHAM(MASP,MALOAI,TENSP,MOTA,GIA)
      VALUES('SP0000000037', 'LSP000000001', 'Tà tưa', 'Béo', 20000)

INSERT dbo.QUANLYKHO(MADOITAC,MACN,MASP,SLSP)
        VALUES('DT0000000001', 1, 'SP0000000037', 1)