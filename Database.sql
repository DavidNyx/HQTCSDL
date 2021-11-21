/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2014                    */
/* Created on:     11/7/2021 8:59:45 PM                         */
/*==============================================================*/

create database DATH1
go
use DATH1
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CHINHANH') and o.name = 'FK_CHINHANH_QUANLY_DOITAC')
alter table CHINHANH
   drop constraint FK_CHINHANH_QUANLY_DOITAC
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('DOITAC') and o.name = 'FK_DOITAC_LAPHD_HOPDONG')
alter table DOITAC
   drop constraint FK_DOITAC_LAPHD_HOPDONG
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('DONHANG') and o.name = 'FK_DONHANG_GIAO_TAIXE')
alter table DONHANG
   drop constraint FK_DONHANG_GIAO_TAIXE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('DONHANG') and o.name = 'FK_DONHANG_NHAN_DOITAC')
alter table DONHANG
   drop constraint FK_DONHANG_NHAN_DOITAC
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('DONHANG') and o.name = 'FK_DONHANG_THANHTOAN_KHACHHAN')
alter table DONHANG
   drop constraint FK_DONHANG_THANHTOAN_KHACHHAN
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('GHINHAN') and o.name = 'FK_GHINHAN_GHINHAN_SANPHAM')
alter table GHINHAN
   drop constraint FK_GHINHAN_GHINHAN_SANPHAM
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('GHINHAN') and o.name = 'FK_GHINHAN_GHINHAN2_DONHANG')
alter table GHINHAN
   drop constraint FK_GHINHAN_GHINHAN2_DONHANG
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('HOPDONG') and o.name = 'FK_HOPDONG_LAPHD2_DOITAC')
alter table HOPDONG
   drop constraint FK_HOPDONG_LAPHD2_DOITAC
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('LOAIHANGVANCHUYEN') and o.name = 'FK_LOAIHANG_LOAIHANGV_LOAISP')
alter table LOAIHANGVANCHUYEN
   drop constraint FK_LOAIHANG_LOAIHANGV_LOAISP
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('LOAIHANGVANCHUYEN') and o.name = 'FK_LOAIHANG_LOAIHANGV_DOITAC')
alter table LOAIHANGVANCHUYEN
   drop constraint FK_LOAIHANG_LOAIHANGV_DOITAC
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('QUANLYKHO') and o.name = 'FK_QUANLYKH_QUANLYKHO_CHINHANH')
alter table QUANLYKHO
   drop constraint FK_QUANLYKH_QUANLYKHO_CHINHANH
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('QUANLYKHO') and o.name = 'FK_QUANLYKH_QUANLYKHO_SANPHAM')
alter table QUANLYKHO
   drop constraint FK_QUANLYKH_QUANLYKHO_SANPHAM
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('SANPHAM') and o.name = 'FK_SANPHAM_PHANLOAI_LOAISP')
alter table SANPHAM
   drop constraint FK_SANPHAM_PHANLOAI_LOAISP
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('CHINHANH')
            and   name  = 'QUANLY_FK'
            and   indid > 0
            and   indid < 255)
   drop index CHINHANH.QUANLY_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CHINHANH')
            and   type = 'U')
   drop table CHINHANH
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('DOITAC')
            and   name  = 'LAPHD_FK'
            and   indid > 0
            and   indid < 255)
   drop index DOITAC.LAPHD_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('DOITAC')
            and   type = 'U')
   drop table DOITAC
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('DONHANG')
            and   name  = 'THANHTOAN_FK'
            and   indid > 0
            and   indid < 255)
   drop index DONHANG.THANHTOAN_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('DONHANG')
            and   name  = 'GIAO_FK'
            and   indid > 0
            and   indid < 255)
   drop index DONHANG.GIAO_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('DONHANG')
            and   name  = 'NHAN_FK'
            and   indid > 0
            and   indid < 255)
   drop index DONHANG.NHAN_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('DONHANG')
            and   type = 'U')
   drop table DONHANG
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('GHINHAN')
            and   name  = 'GHINHAN2_FK'
            and   indid > 0
            and   indid < 255)
   drop index GHINHAN.GHINHAN2_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('GHINHAN')
            and   name  = 'GHINHAN_FK'
            and   indid > 0
            and   indid < 255)
   drop index GHINHAN.GHINHAN_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('GHINHAN')
            and   type = 'U')
   drop table GHINHAN
go

if exists (select 1
            from  sysobjects
           where  id = object_id('HOPDONG')
            and   type = 'U')
   drop table HOPDONG
go

if exists (select 1
            from  sysobjects
           where  id = object_id('KHACHHANG')
            and   type = 'U')
   drop table KHACHHANG
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('LOAIHANGVANCHUYEN')
            and   name  = 'LOAIHANGVANCHUYEN2_FK'
            and   indid > 0
            and   indid < 255)
   drop index LOAIHANGVANCHUYEN.LOAIHANGVANCHUYEN2_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('LOAIHANGVANCHUYEN')
            and   name  = 'LOAIHANGVANCHUYEN_FK'
            and   indid > 0
            and   indid < 255)
   drop index LOAIHANGVANCHUYEN.LOAIHANGVANCHUYEN_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('LOAIHANGVANCHUYEN')
            and   type = 'U')
   drop table LOAIHANGVANCHUYEN
go

if exists (select 1
            from  sysobjects
           where  id = object_id('LOAISP')
            and   type = 'U')
   drop table LOAISP
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('QUANLYKHO')
            and   name  = 'QUANLYKHO2_FK'
            and   indid > 0
            and   indid < 255)
   drop index QUANLYKHO.QUANLYKHO2_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('QUANLYKHO')
            and   name  = 'QUANLYKHO_FK'
            and   indid > 0
            and   indid < 255)
   drop index QUANLYKHO.QUANLYKHO_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('QUANLYKHO')
            and   type = 'U')
   drop table QUANLYKHO
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('SANPHAM')
            and   name  = 'PHANLOAI_FK'
            and   indid > 0
            and   indid < 255)
   drop index SANPHAM.PHANLOAI_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('SANPHAM')
            and   type = 'U')
   drop table SANPHAM
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TAIXE')
            and   type = 'U')
   drop table TAIXE
go

/*==============================================================*/
/* Table: CHINHANH                                              */
/*==============================================================*/
create table CHINHANH (
   MACN                 char(12)             not null,
   MADOITAC             char(12)             not null,
   TENCN                nvarchar(50)         null,
   DIACHICN             nvarchar(100)        null,
   constraint PK_CHINHANH primary key (MACN)
)
go

/*==============================================================*/
/* Index: QUANLY_FK                                             */
/*==============================================================*/




create nonclustered index QUANLY_FK on CHINHANH (MADOITAC ASC)
go

/*==============================================================*/
/* Table: DOITAC                                                */
/*==============================================================*/
create table DOITAC (
   MADOITAC             char(12)             not null,
   TENDOITAC            nvarchar(50)         null,
   NGUOIDAIDIEN         nvarchar(50)         null,
   QUAN                 nvarchar(20)         null,
   THANHPHO             nvarchar(20)         null,
   SOCHINHANH           int                  null,
   SLHANGNGAY           int                  null,
   DIACHIKD             nvarchar(100)        null,
   SDTDOITAC            char(10)             null,
   EMAIL                varchar(50)          null,
   constraint PK_DOITAC primary key (MADOITAC)
)
go

/*==============================================================*/
/* Index: LAPHD_FK                                              */
/*==============================================================*/




create nonclustered index LAPHD_FK on DOITAC (MADOITAC ASC)
go

/*==============================================================*/
/* Table: DONHANG                                               */
/*==============================================================*/
create table DONHANG (
   MADH                 char(12)             not null,
   MADOITAC             char(12)             not null,
   CMND                 char(12)             not null,
   MAKH                 char(12)             not null,
   SLSP                 int                  null,
   PHISP                float                null,
   PHIVC                float                null,
   QTVC                 nvarchar(100)        null,
   HTTHANHTOAN          nvarchar(20)         null,
   constraint PK_DONHANG primary key (MADH)
)
go

/*==============================================================*/
/* Index: NHAN_FK                                               */
/*==============================================================*/




create nonclustered index NHAN_FK on DONHANG (MADOITAC ASC)
go

/*==============================================================*/
/* Index: GIAO_FK                                               */
/*==============================================================*/




create nonclustered index GIAO_FK on DONHANG (CMND ASC)
go

/*==============================================================*/
/* Index: THANHTOAN_FK                                          */
/*==============================================================*/




create nonclustered index THANHTOAN_FK on DONHANG (MAKH ASC)
go

/*==============================================================*/
/* Table: GHINHAN                                               */
/*==============================================================*/
create table GHINHAN (
   MASP                 char(12)             not null,
   MADH                 char(12)             not null,
   SL                   int                  null,
   constraint PK_GHINHAN primary key (MASP, MADH)
)
go

/*==============================================================*/
/* Index: GHINHAN_FK                                            */
/*==============================================================*/




create nonclustered index GHINHAN_FK on GHINHAN (MADH ASC)
go

/*==============================================================*/
/* Index: GHINHAN2_FK                                           */
/*==============================================================*/




create nonclustered index GHINHAN2_FK on GHINHAN (MASP ASC)
go

/*==============================================================*/
/* Table: HOPDONG                                               */
/*==============================================================*/
create table HOPDONG (
   MADOITAC             char(12)             not null,
   MATHUE               char(12)             NOT NULL,
   SOCNDK               int                  null,
   DIACHICN             nvarchar(100)        null,
   TGHIEULUC            datetime             null,
   PHANTRAMHOAHONG      float                null,
   PHIHOAHONG           float                null,
   TINHTRANGHD          nvarchar(20)         null,
   constraint PK_HOPDONG primary key (MADOITAC, MATHUE)
)
go

/*==============================================================*/
/* Table: KHACHHANG                                             */
/*==============================================================*/
create table KHACHHANG (
   MAKH                 char(12)             not null,
   HOTENKH              nvarchar(50)         null,
   SDTKH                char(10)             null,
   DIACHIKH             nvarchar(100)        null,
   EMAILKH              varchar(50)          null,
   constraint PK_KHACHHANG primary key (MAKH)
)
go

/*==============================================================*/
/* Table: LOAIHANGVANCHUYEN                                     */
/*==============================================================*/
create table LOAIHANGVANCHUYEN (
   MALOAI               char(12)             not null,
   MADOITAC             char(12)             not null,
   constraint PK_LOAIHANGVANCHUYEN primary key (MALOAI, MADOITAC)
)
go

/*==============================================================*/
/* Index: LOAIHANGVANCHUYEN_FK                                  */
/*==============================================================*/




create nonclustered index LOAIHANGVANCHUYEN_FK on LOAIHANGVANCHUYEN (MALOAI ASC)
go

/*==============================================================*/
/* Index: LOAIHANGVANCHUYEN2_FK                                 */
/*==============================================================*/




create nonclustered index LOAIHANGVANCHUYEN2_FK on LOAIHANGVANCHUYEN (MADOITAC ASC)
go

/*==============================================================*/
/* Table: LOAISP                                                */
/*==============================================================*/
create table LOAISP (
   MALOAI               char(12)             not null,
   TENLOAI              nvarchar(20)         null,
   constraint PK_LOAISP primary key (MALOAI)
)
go

/*==============================================================*/
/* Table: QUANLYKHO                                             */
/*==============================================================*/
create table QUANLYKHO (
   MACN                 char(12)             not null,
   MASP                 char(12)             not null,
   SLSP                 int                  null,
   constraint PK_QUANLYKHO primary key (MACN, MASP)
)
go

/*==============================================================*/
/* Index: QUANLYKHO_FK                                          */
/*==============================================================*/




create nonclustered index QUANLYKHO_FK on QUANLYKHO (MASP ASC)
go

/*==============================================================*/
/* Index: QUANLYKHO2_FK                                         */
/*==============================================================*/




create nonclustered index QUANLYKHO2_FK on QUANLYKHO (MACN ASC)
go

/*==============================================================*/
/* Table: SANPHAM                                               */
/*==============================================================*/
create table SANPHAM (
   MASP                 char(12)             not null,
   MALOAI               char(12)             not null,
   TENSP                nvarchar(50)         null,
   MOTA                 nvarchar(250)        null,
   GIA                  float                null,
   constraint PK_SANPHAM primary key (MASP)
)
go

/*==============================================================*/
/* Index: PHANLOAI_FK                                           */
/*==============================================================*/




create nonclustered index PHANLOAI_FK on SANPHAM (MALOAI ASC)
go

/*==============================================================*/
/* Table: TAIXE                                                 */
/*==============================================================*/
create table TAIXE (
   CMND                 char(12)             not null,
   HOTEN                nvarchar(50)         null,
   SDTTAIXE             char(10)             null,
   DIACHITX             nvarchar(100)        null,
   BIENSO               char(12)             null,
   KHUVUCHD             nvarchar(100)        null,
   EMAILTAIXE           varchar(50)          null,
   TKNGH                char(12)             null,
   SODONHANG            int                  null,
   THUNHAP              float                null,
   constraint PK_TAIXE primary key (CMND)
)
go

alter table CHINHANH
   add constraint FK_CHINHANH_QUANLY_DOITAC foreign key (MADOITAC)
      references DOITAC (MADOITAC)
go

alter table HOPDONG
   add constraint FK_DOITAC_LAPHD_HOPDONG foreign key (MADOITAC)
      references DOITAC (MADOITAC)
go

alter table DONHANG
   add constraint FK_DONHANG_GIAO_TAIXE foreign key (CMND)
      references TAIXE (CMND)
go

alter table DONHANG
   add constraint FK_DONHANG_NHAN_DOITAC foreign key (MADOITAC)
      references DOITAC (MADOITAC)
go

alter table DONHANG
   add constraint FK_DONHANG_THANHTOAN_KHACHHAN foreign key (MAKH)
      references KHACHHANG (MAKH)
go

alter table GHINHAN
   add constraint FK_GHINHAN_GHINHAN_SANPHAM foreign key (MASP)
      references SANPHAM (MASP)
go

alter table GHINHAN
   add constraint FK_GHINHAN_GHINHAN2_DONHANG foreign key (MADH)
      references DONHANG (MADH)
go

alter table LOAIHANGVANCHUYEN
   add constraint FK_LOAIHANG_LOAIHANGV_LOAISP foreign key (MALOAI)
      references LOAISP (MALOAI)
go

alter table LOAIHANGVANCHUYEN
   add constraint FK_LOAIHANG_LOAIHANGV_DOITAC foreign key (MADOITAC)
      references DOITAC (MADOITAC)
go

alter table QUANLYKHO
   add constraint FK_QUANLYKH_QUANLYKHO_CHINHANH foreign key (MACN)
      references CHINHANH (MACN)
go

alter table QUANLYKHO
   add constraint FK_QUANLYKH_QUANLYKHO_SANPHAM foreign key (MASP)
      references SANPHAM (MASP)
go

alter table SANPHAM
   add constraint FK_SANPHAM_PHANLOAI_LOAISP foreign key (MALOAI)
      references LOAISP (MALOAI)
go

