/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2014                    */
/* Created on:     11/7/2021 8:59:45 PM                         */
/*==============================================================*/

create database DATH1
go
use DATH1
go

/*==============================================================*/
/* Table: CHINHANH                                              */
/*==============================================================*/
create table CHINHANH (
   MADOITAC             char(12)             not null,
   MACN                 INT                  not null,
   TENCN                nvarchar(50)         null,
   DIACHICN             nvarchar(100)        NULL,
   MATHUE               CHAR(12)             NULL
   constraint PK_CHINHANH primary key (MADOITAC, MACN)
)
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
/* Table: HOPDONG                                               */
/*==============================================================*/
create table HOPDONG (
   MADOITAC             char(12)             not null,
   MATHUE               char(12)             NOT NULL,
   SOCNDK               int                  null,
   TGHIEULUC            date             null,
   PHANTRAMHOAHONG      float                null,
   PHIHOAHONG           float                null,
   constraint PK_HOPDONG primary key (MADOITAC, MATHUE)
)
GO

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
   MADOITAC             char(12)             not null,
   MACN                 INT                  not null,
   MASP                 char(12)             not null,
   SLSP                 int                  null,
   constraint PK_QUANLYKHO primary key (MADOITAC, MACN, MASP)
)
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
GO

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
   add constraint FK_QUANLYKH_QUANLYKHO_CHINHANH foreign key (MADOITAC, MACN)
      references CHINHANH (MADOITAC, MACN)
go

alter table QUANLYKHO
   add constraint FK_QUANLYKH_QUANLYKHO_SANPHAM foreign key (MASP)
      references SANPHAM (MASP)
go

alter table SANPHAM
   add constraint FK_SANPHAM_PHANLOAI_LOAISP foreign key (MALOAI)
      references LOAISP (MALOAI)
go

