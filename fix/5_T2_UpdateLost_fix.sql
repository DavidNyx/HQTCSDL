SELECT * FROM dbo.QUANLYKHO
EXEC dbo.INSERT_GHINHAN @MADH = 'HD0000000003',  -- char(12)
                        @MASP = 'SP0000000001',  -- char(12)
                        @SOLUONG = 300 -- int
GO