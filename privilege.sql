use DATH1
go

--admin
sp_addlogin 'adminA', 'suisui'
create user adminA for login adminA
go


alter role db_datareader
add member adminA
GO

alter role db_securityadmin
add member adminA
go

alter role db_datawriter
add member adminA
go

--guest
sp_addlogin 'guest','guest'
create user guest_dky for login guest
go

alter role db_datawriter
add member guest_dky
go

exec sp_addrole 'coop'
exec sp_addrole 'customer'
exec sp_addrole 'driver'
exec sp_addrole 'employee' --nhap role hmu hmu


--Đối tác
grant insert on DOITAC to coop
grant insert on HOPDONG to coop
grant insert on SANPHAM to coop
grant delete on SANPHAM to coop
grant update on SANPHAM(TENSP, MOTA, GIA) to coop
grant insert on CHINHANH to coop
grant delete on CHINHANH to coop
grant update on CHINHANH(TENCN, DIACHICN) to coop
grant update on DONHANG(QTVC) to coop
grant update on QUANLYKHO(SLSP) to coop
grant select on QUANLYKHO to coop
grant insert on QUANLYKHO to coop
grant delete on QUANLYKHO to coop
grant execute on object::dbo.UPDATE_SOLUONG to coop
grant execute on object::dbo.CAPNHATSP to coop
grant execute on object::dbo.THEMSP to coop
grant execute on object::dbo.XOASP to coop
grant execute on object::dbo.UPDATE_DONHANG to coop


-- Khách hàng
grant insert on KHACHHANG to customer
grant select on DOITAC(MADOITAC,TENDOITAC) to customer
grant select on SANPHAM to customer
grant insert on DONHANG to customer
grant select on DONHANG to customer
grant insert on GHINHAN to customer
grant update on GHINHAN(SL) to customer
grant select on HOPDONG(MADT,TGHIEULUC) to customer
grant execute on object::dbo.FOLLOW_DONHANG_KH to customer
grant execute on object::dbo.INSERT_GHINHAN to customer

--Tài xế
grant insert on TAIXE to driver
grant select on DONHANG to driver
grant update on DONHANG(QTVC) to driver
grant select on TAIXE to driver
grant execute on object::dbo.FOLLOW_DONHANG_TX to driver
grant execute on object::dbo.VIEW_DONHANG to driver
grant execute on object::dbo.UPDATE_DONHANG to driver

--Nhân viên
grant select on DOITAC to employee
grant select on HOPDONG to employee
grant update on HOPDONG(TGHIEULUC,PHANTRAMHOAHONG,PHIHOAHONG) to employee
grant execute on object::dbo.XEMHD to employee
