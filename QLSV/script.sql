USE master
IF EXISTS(select * from sys.databases where name='db_QuanLySV')
DROP DATABASE db_QuanLySV
go
CREATE DATABASE db_QuanLySV
go

/*    ==Scripting Parameters==

    Source Server Version : SQL Server 2016 (13.0.1742)
    Source Database Engine Edition : Microsoft SQL Server Enterprise Edition
    Source Database Engine Type : Standalone SQL Server

    Target Server Version : SQL Server 2017
    Target Database Engine Edition : Microsoft SQL Server Standard Edition
    Target Database Engine Type : Standalone SQL Server
*/
USE [db_QuanLySV]
GO
/****** Object:  Table [dbo].[BaoCao]    Script Date: 11/5/2019 6:17:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BaoCao](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[id_SinhVien] [int] NOT NULL,
	[id_MonHoc] [int] NOT NULL,
	[id_DanhGia] [int] NOT NULL,
	[diemThi] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietGiangVien]    Script Date: 11/5/2019 6:17:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietGiangVien](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Id_Lop] [int] NOT NULL,
	[id_GiangVien] [int] NOT NULL,
	[id_MonHoc] [int] NOT NULL,
	[SiSo] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DanhGia]    Script Date: 11/5/2019 6:17:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhGia](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DanhGia] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GiangVien]    Script Date: 11/5/2019 6:17:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GiangVien](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[tenGV] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lop]    Script Date: 11/5/2019 6:17:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lop](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[tenLop] [nvarchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MonHoc]    Script Date: 11/5/2019 6:17:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MonHoc](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[tenMH] [nvarchar](max) NULL,
	[id_Nganh] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Nganh]    Script Date: 11/5/2019 6:17:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nganh](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[tenNganh] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SinhVien]    Script Date: 11/5/2019 6:17:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SinhVien](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ten] [nvarchar](50) NULL,
	[ngaySinh] [date] NULL,
	[gioiTinh] [nchar](10) NULL,
	[truongTHPT] [nvarchar](100) NULL,
	[diemThi] [float] NULL,
	[diemChuan] [float] NULL,
	[MSSV] [nchar](50) NULL,
	[id_Nganh] [int] NOT NULL,
	[id_Lop] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[BaoCao] ON 

INSERT [dbo].[BaoCao] ([Id], [id_SinhVien], [id_MonHoc], [id_DanhGia], [diemThi]) VALUES (1, 2, 2, 1, 10)
INSERT [dbo].[BaoCao] ([Id], [id_SinhVien], [id_MonHoc], [id_DanhGia], [diemThi]) VALUES (2, 3, 4, 2, 3)
SET IDENTITY_INSERT [dbo].[BaoCao] OFF
SET IDENTITY_INSERT [dbo].[ChiTietGiangVien] ON 

INSERT [dbo].[ChiTietGiangVien] ([id], [Id_Lop], [id_GiangVien], [id_MonHoc], [SiSo]) VALUES (1, 1, 1, 2, 40)
INSERT [dbo].[ChiTietGiangVien] ([id], [Id_Lop], [id_GiangVien], [id_MonHoc], [SiSo]) VALUES (2, 1, 1, 4, 40)
INSERT [dbo].[ChiTietGiangVien] ([id], [Id_Lop], [id_GiangVien], [id_MonHoc], [SiSo]) VALUES (3, 1, 1, 2, 40)
INSERT [dbo].[ChiTietGiangVien] ([id], [Id_Lop], [id_GiangVien], [id_MonHoc], [SiSo]) VALUES (4, 1, 1, 2, 40)
INSERT [dbo].[ChiTietGiangVien] ([id], [Id_Lop], [id_GiangVien], [id_MonHoc], [SiSo]) VALUES (5, 1, 1, 2, 40)
SET IDENTITY_INSERT [dbo].[ChiTietGiangVien] OFF
SET IDENTITY_INSERT [dbo].[DanhGia] ON 

INSERT [dbo].[DanhGia] ([Id], [DanhGia]) VALUES (1, N'ĐẬU')
INSERT [dbo].[DanhGia] ([Id], [DanhGia]) VALUES (2, N'RỚT')
SET IDENTITY_INSERT [dbo].[DanhGia] OFF
SET IDENTITY_INSERT [dbo].[GiangVien] ON 

INSERT [dbo].[GiangVien] ([Id], [tenGV]) VALUES (1, N'CÔ BÍCH NGÂN')
SET IDENTITY_INSERT [dbo].[GiangVien] OFF
SET IDENTITY_INSERT [dbo].[Lop] ON 

INSERT [dbo].[Lop] ([Id], [tenLop]) VALUES (1, N'TH1601')
INSERT [dbo].[Lop] ([Id], [tenLop]) VALUES (2, N'TH1602')
INSERT [dbo].[Lop] ([Id], [tenLop]) VALUES (3, N'TH1603')
INSERT [dbo].[Lop] ([Id], [tenLop]) VALUES (4, N'TH1604')
INSERT [dbo].[Lop] ([Id], [tenLop]) VALUES (5, N'TH1605')
INSERT [dbo].[Lop] ([Id], [tenLop]) VALUES (6, N'TH1606')
SET IDENTITY_INSERT [dbo].[Lop] OFF
SET IDENTITY_INSERT [dbo].[MonHoc] ON 

INSERT [dbo].[MonHoc] ([Id], [tenMH], [id_Nganh]) VALUES (2, N'KDCLPM', 1)
INSERT [dbo].[MonHoc] ([Id], [tenMH], [id_Nganh]) VALUES (3, N'MMT', 1)
INSERT [dbo].[MonHoc] ([Id], [tenMH], [id_Nganh]) VALUES (4, N'DU LỊCH', 4)
INSERT [dbo].[MonHoc] ([Id], [tenMH], [id_Nganh]) VALUES (5, N'KDCLPM', 1)
SET IDENTITY_INSERT [dbo].[MonHoc] OFF
SET IDENTITY_INSERT [dbo].[Nganh] ON 

INSERT [dbo].[Nganh] ([Id], [tenNganh]) VALUES (1, N'CN')
INSERT [dbo].[Nganh] ([Id], [tenNganh]) VALUES (2, N'QT')
INSERT [dbo].[Nganh] ([Id], [tenNganh]) VALUES (3, N'NG')
INSERT [dbo].[Nganh] ([Id], [tenNganh]) VALUES (4, N'DL')
SET IDENTITY_INSERT [dbo].[Nganh] OFF
SET IDENTITY_INSERT [dbo].[SinhVien] ON 

INSERT [dbo].[SinhVien] ([Id], [ten], [ngaySinh], [gioiTinh], [truongTHPT], [diemThi], [diemChuan], [MSSV], [id_Nganh], [id_Lop]) VALUES (2, N'NGUYEN QUOC TUAN', CAST(N'2019-10-02' AS Date), N'NAM       ', N'CB', 13, 13, N'16QT000001                                        ', 2, 2)
INSERT [dbo].[SinhVien] ([Id], [ten], [ngaySinh], [gioiTinh], [truongTHPT], [diemThi], [diemChuan], [MSSV], [id_Nganh], [id_Lop]) VALUES (3, N'NGUYEN HO CAO TRI', CAST(N'2019-10-01' AS Date), N'NAM       ', N'MARIE', 15, 12, N'16QT000002                                        ', 2, 3)
INSERT [dbo].[SinhVien] ([Id], [ten], [ngaySinh], [gioiTinh], [truongTHPT], [diemThi], [diemChuan], [MSSV], [id_Nganh], [id_Lop]) VALUES (4, N'NGUYEN LE PHUONG THAO', CAST(N'2019-10-01' AS Date), N'NU        ', N'KK', 12, 15, N'16CN000003                                        ', 1, 4)
INSERT [dbo].[SinhVien] ([Id], [ten], [ngaySinh], [gioiTinh], [truongTHPT], [diemThi], [diemChuan], [MSSV], [id_Nganh], [id_Lop]) VALUES (5, N'HITA', CAST(N'2019-10-01' AS Date), N'NU        ', N'JHJ', 12, 12, N'16CN000004                                        ', 1, 1)
INSERT [dbo].[SinhVien] ([Id], [ten], [ngaySinh], [gioiTinh], [truongTHPT], [diemThi], [diemChuan], [MSSV], [id_Nganh], [id_Lop]) VALUES (10, N'VCX', CAST(N'2019-10-22' AS Date), N'VC        ', N'VCX', 12, 1, N'16CN000005                                        ', 1, 1)
INSERT [dbo].[SinhVien] ([Id], [ten], [ngaySinh], [gioiTinh], [truongTHPT], [diemThi], [diemChuan], [MSSV], [id_Nganh], [id_Lop]) VALUES (11, N'VCXVCXVC', CAST(N'2019-10-22' AS Date), N'VC        ', N'VCX', 39, 39, N'16CN000010                                        ', 1, 1)
SET IDENTITY_INSERT [dbo].[SinhVien] OFF
ALTER TABLE [dbo].[BaoCao]  WITH CHECK ADD  CONSTRAINT [FK_BaoCao_DanhGia] FOREIGN KEY([id_DanhGia])
REFERENCES [dbo].[DanhGia] ([Id])
GO
ALTER TABLE [dbo].[BaoCao] CHECK CONSTRAINT [FK_BaoCao_DanhGia]
GO
ALTER TABLE [dbo].[BaoCao]  WITH CHECK ADD  CONSTRAINT [FK_BaoCao_Mon] FOREIGN KEY([id_MonHoc])
REFERENCES [dbo].[MonHoc] ([Id])
GO
ALTER TABLE [dbo].[BaoCao] CHECK CONSTRAINT [FK_BaoCao_Mon]
GO
ALTER TABLE [dbo].[BaoCao]  WITH CHECK ADD  CONSTRAINT [FK_BaoCao_SinhVien] FOREIGN KEY([id_SinhVien])
REFERENCES [dbo].[SinhVien] ([Id])
GO
ALTER TABLE [dbo].[BaoCao] CHECK CONSTRAINT [FK_BaoCao_SinhVien]
GO
ALTER TABLE [dbo].[ChiTietGiangVien]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietGiangVien_GiangVien] FOREIGN KEY([id_GiangVien])
REFERENCES [dbo].[GiangVien] ([Id])
GO
ALTER TABLE [dbo].[ChiTietGiangVien] CHECK CONSTRAINT [FK_ChiTietGiangVien_GiangVien]
GO
ALTER TABLE [dbo].[ChiTietGiangVien]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietGiangVien_Lop] FOREIGN KEY([Id_Lop])
REFERENCES [dbo].[Lop] ([Id])
GO
ALTER TABLE [dbo].[ChiTietGiangVien] CHECK CONSTRAINT [FK_ChiTietGiangVien_Lop]
GO
ALTER TABLE [dbo].[ChiTietGiangVien]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietGiangVien_MonHoc] FOREIGN KEY([id_MonHoc])
REFERENCES [dbo].[MonHoc] ([Id])
GO
ALTER TABLE [dbo].[ChiTietGiangVien] CHECK CONSTRAINT [FK_ChiTietGiangVien_MonHoc]
GO
ALTER TABLE [dbo].[MonHoc]  WITH CHECK ADD  CONSTRAINT [FK_MonHoc_Nganh] FOREIGN KEY([id_Nganh])
REFERENCES [dbo].[Nganh] ([Id])
GO
ALTER TABLE [dbo].[MonHoc] CHECK CONSTRAINT [FK_MonHoc_Nganh]
GO
ALTER TABLE [dbo].[SinhVien]  WITH CHECK ADD  CONSTRAINT [FK_SinhVien_Lop] FOREIGN KEY([id_Lop])
REFERENCES [dbo].[Lop] ([Id])
GO
ALTER TABLE [dbo].[SinhVien] CHECK CONSTRAINT [FK_SinhVien_Lop]
GO
ALTER TABLE [dbo].[SinhVien]  WITH CHECK ADD  CONSTRAINT [FK_SinhVien_Nganh] FOREIGN KEY([id_Nganh])
REFERENCES [dbo].[Nganh] ([Id])
GO
ALTER TABLE [dbo].[SinhVien] CHECK CONSTRAINT [FK_SinhVien_Nganh]
GO
