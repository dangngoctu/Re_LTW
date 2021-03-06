USE [master]
GO
/****** Object:  Database [LIBRARYK29]    Script Date: 9/8/2018 7:08:26 PM ******/
CREATE DATABASE [LIBRARYK29]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LIBRARYK29', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\LIBRARYK29.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'LIBRARYK29_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\LIBRARYK29_log.ldf' , SIZE = 1088KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [LIBRARYK29] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LIBRARYK29].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LIBRARYK29] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LIBRARYK29] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LIBRARYK29] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LIBRARYK29] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LIBRARYK29] SET ARITHABORT OFF 
GO
ALTER DATABASE [LIBRARYK29] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [LIBRARYK29] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LIBRARYK29] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LIBRARYK29] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LIBRARYK29] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LIBRARYK29] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LIBRARYK29] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LIBRARYK29] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LIBRARYK29] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LIBRARYK29] SET  ENABLE_BROKER 
GO
ALTER DATABASE [LIBRARYK29] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LIBRARYK29] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LIBRARYK29] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LIBRARYK29] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LIBRARYK29] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LIBRARYK29] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LIBRARYK29] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LIBRARYK29] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [LIBRARYK29] SET  MULTI_USER 
GO
ALTER DATABASE [LIBRARYK29] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LIBRARYK29] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LIBRARYK29] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LIBRARYK29] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [LIBRARYK29] SET DELAYED_DURABILITY = DISABLED 
GO
USE [LIBRARYK29]
GO
/****** Object:  UserDefinedFunction [dbo].[fChuyenCoDauThanhKhongDau]    Script Date: 9/8/2018 7:08:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fChuyenCoDauThanhKhongDau](@inputVar NVARCHAR(MAX) )
RETURNS NVARCHAR(MAX)
AS
BEGIN    
    IF (@inputVar IS NULL OR @inputVar = '') RETURN ''
   
    DECLARE @RT NVARCHAR(MAX)
    DECLARE @SIGN_CHARS NCHAR(256)
    DECLARE @UNSIGN_CHARS NCHAR (256)
 
    SET @SIGN_CHARS = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệếìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵýĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ' + NCHAR(272) + NCHAR(208)
    SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeeeiiiiiooooooooooooooouuuuuuuuuuyyyyyAADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIIIOOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD'
 
    DECLARE @COUNTER int
    DECLARE @COUNTER1 int
   
    SET @COUNTER = 1
    WHILE (@COUNTER <= LEN(@inputVar))
    BEGIN  
        SET @COUNTER1 = 1
        WHILE (@COUNTER1 <= LEN(@SIGN_CHARS) + 1)
        BEGIN
            IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1)) = UNICODE(SUBSTRING(@inputVar,@COUNTER ,1))
            BEGIN          
                IF @COUNTER = 1
                    SET @inputVar = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@inputVar, @COUNTER+1,LEN(@inputVar)-1)      
                ELSE
                    SET @inputVar = SUBSTRING(@inputVar, 1, @COUNTER-1) +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@inputVar, @COUNTER+1,LEN(@inputVar)- @COUNTER)
                BREAK
            END
            SET @COUNTER1 = @COUNTER1 +1
        END
        SET @COUNTER = @COUNTER +1
    END
    -- SET @inputVar = replace(@inputVar,' ','-')
    RETURN @inputVar
END
GO
/****** Object:  Table [dbo].[ChiTietDonMuonSach]    Script Date: 9/8/2018 7:08:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietDonMuonSach](
	[machitietdonmuonsach] [nvarchar](50) NOT NULL,
	[madonmuonsach] [nvarchar](50) NOT NULL,
	[madausach] [nvarchar](50) NOT NULL,
	[soluong] [int] NOT NULL,
 CONSTRAINT [PK_ChiTietDonMuonSach] PRIMARY KEY CLUSTERED 
(
	[machitietdonmuonsach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChuDe]    Script Date: 9/8/2018 7:08:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChuDe](
	[machude] [nvarchar](50) NOT NULL,
	[tenchude] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_ChuDe] PRIMARY KEY CLUSTERED 
(
	[machude] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DanhGia]    Script Date: 9/8/2018 7:08:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhGia](
	[madanhgia] [nvarchar](50) NOT NULL,
	[manguoidung] [nvarchar](50) NOT NULL,
	[madausach] [nvarchar](50) NOT NULL,
	[diemdanhgia] [int] NOT NULL,
 CONSTRAINT [PK_DanhGia] PRIMARY KEY CLUSTERED 
(
	[madanhgia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DauSach]    Script Date: 9/8/2018 7:08:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DauSach](
	[madausach] [nvarchar](50) NOT NULL,
	[tensach] [nvarchar](100) NOT NULL,
	[matacgia] [nvarchar](50) NOT NULL,
	[manhaxuatban] [nvarchar](50) NOT NULL,
	[soluong] [int] NULL,
	[bia] [nvarchar](100) NULL,
	[tomtat] [nvarchar](max) NULL,
	[filesach] [nvarchar](100) NULL,
	[ngaydang] [datetime] NOT NULL,
	[machude] [nvarchar](50) NOT NULL,
	[luotxem] [int] NOT NULL,
 CONSTRAINT [PK_DauSach] PRIMARY KEY CLUSTERED 
(
	[madausach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DonMuonSach]    Script Date: 9/8/2018 7:08:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonMuonSach](
	[madonmuonsach] [nvarchar](50) NOT NULL,
	[manguoidung] [nvarchar](50) NOT NULL,
	[ngaydat] [datetime] NOT NULL,
	[ngaymuon] [datetime] NULL,
	[ngayhentra] [datetime] NULL,
	[ngaytra] [datetime] NULL,
	[matrangthai] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_DonMuonSach] PRIMARY KEY CLUSTERED 
(
	[madonmuonsach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LoaiNguoiDung]    Script Date: 9/8/2018 7:08:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LoaiNguoiDung](
	[maloainguoidung] [nvarchar](50) NOT NULL,
	[tenloainguoidung] [nvarchar](100) NOT NULL,
	[phanquyen] [varchar](2) NOT NULL,
 CONSTRAINT [PK_LoaiNguoiDung] PRIMARY KEY CLUSTERED 
(
	[maloainguoidung] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NguoiDung]    Script Date: 9/8/2018 7:08:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NguoiDung](
	[manguoidung] [nvarchar](50) NOT NULL,
	[tendangnhap] [nvarchar](100) NOT NULL,
	[matkhau] [nvarchar](100) NOT NULL,
	[hovaten] [nvarchar](100) NOT NULL,
	[diachi] [nvarchar](1000) NULL,
	[email] [nvarchar](100) NULL,
	[sodienthoai] [nvarchar](50) NULL,
	[gioitinh] [varchar](1) NULL,
	[ngaysinh] [date] NULL,
	[motangan] [nvarchar](max) NULL,
	[anhdaidien] [nvarchar](100) NULL,
	[maloainguoidung] [nvarchar](50) NOT NULL,
	[khoanguoidung] [varchar](1) NOT NULL,
 CONSTRAINT [PK_NguoiDung] PRIMARY KEY CLUSTERED 
(
	[manguoidung] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NhanXet]    Script Date: 9/8/2018 7:08:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanXet](
	[manhanxet] [nvarchar](50) NOT NULL,
	[manguoidung] [nvarchar](50) NOT NULL,
	[madausach] [nvarchar](50) NOT NULL,
	[noidung] [nvarchar](4000) NOT NULL,
	[thoidiem] [datetime] NOT NULL,
 CONSTRAINT [PK_NhanXet] PRIMARY KEY CLUSTERED 
(
	[manhanxet] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NhaXuatBan]    Script Date: 9/8/2018 7:08:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaXuatBan](
	[manhaxuatban] [nvarchar](50) NOT NULL,
	[tennhaxuatban] [nvarchar](100) NOT NULL,
	[diachi] [nvarchar](1000) NULL,
 CONSTRAINT [PK_NhaXuatBan] PRIMARY KEY CLUSTERED 
(
	[manhaxuatban] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PhanHoi]    Script Date: 9/8/2018 7:08:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhanHoi](
	[maphanhoi] [nvarchar](50) NOT NULL,
	[manguoidung] [nvarchar](50) NULL,
	[email] [nvarchar](100) NOT NULL,
	[ngaydang] [datetime] NOT NULL,
	[noidung] [nvarchar](4000) NOT NULL,
 CONSTRAINT [PK_PhanHoi] PRIMARY KEY CLUSTERED 
(
	[maphanhoi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TacGia]    Script Date: 9/8/2018 7:08:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TacGia](
	[matacgia] [nvarchar](50) NOT NULL,
	[tentacgia] [nvarchar](100) NOT NULL,
	[namsinh] [smallint] NULL,
	[anhtacgia] [nvarchar](100) NULL,
	[butdanh] [nvarchar](100) NULL,
	[motangan] [nvarchar](max) NULL,
	[luotxem] [int] NOT NULL,
 CONSTRAINT [PK_TacGia] PRIMARY KEY CLUSTERED 
(
	[matacgia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ThamSo]    Script Date: 9/8/2018 7:08:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThamSo](
	[mathamso] [nvarchar](50) NOT NULL,
	[tendulieu] [nvarchar](50) NOT NULL,
	[giatridulieu] [nvarchar](1000) NOT NULL,
 CONSTRAINT [PK_ThamSo] PRIMARY KEY CLUSTERED 
(
	[mathamso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ThongBaoEmail]    Script Date: 9/8/2018 7:08:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThongBaoEmail](
	[mathongbaoemail] [nvarchar](50) NOT NULL,
	[email] [nvarchar](50) NOT NULL,
	[ngaydangky] [datetime] NOT NULL,
 CONSTRAINT [PK_ThongBaoEmail] PRIMARY KEY CLUSTERED 
(
	[mathongbaoemail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TrangThai]    Script Date: 9/8/2018 7:08:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TrangThai](
	[matrangthai] [nvarchar](50) NOT NULL,
	[tentrangthai] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_TrangThai] PRIMARY KEY CLUSTERED 
(
	[matrangthai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [AK_DauSach_tensach]    Script Date: 9/8/2018 7:08:26 PM ******/
CREATE NONCLUSTERED INDEX [AK_DauSach_tensach] ON [dbo].[DauSach]
(
	[tensach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ChiTietDonMuonSach]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietDonMuonSach_DauSach] FOREIGN KEY([madausach])
REFERENCES [dbo].[DauSach] ([madausach])
GO
ALTER TABLE [dbo].[ChiTietDonMuonSach] CHECK CONSTRAINT [FK_ChiTietDonMuonSach_DauSach]
GO
ALTER TABLE [dbo].[ChiTietDonMuonSach]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietDonMuonSach_DonMuonSach] FOREIGN KEY([madonmuonsach])
REFERENCES [dbo].[DonMuonSach] ([madonmuonsach])
GO
ALTER TABLE [dbo].[ChiTietDonMuonSach] CHECK CONSTRAINT [FK_ChiTietDonMuonSach_DonMuonSach]
GO
ALTER TABLE [dbo].[DanhGia]  WITH CHECK ADD  CONSTRAINT [FK_DanhGia_DauSach] FOREIGN KEY([madausach])
REFERENCES [dbo].[DauSach] ([madausach])
GO
ALTER TABLE [dbo].[DanhGia] CHECK CONSTRAINT [FK_DanhGia_DauSach]
GO
ALTER TABLE [dbo].[DanhGia]  WITH CHECK ADD  CONSTRAINT [FK_DanhGia_NguoiDung] FOREIGN KEY([manguoidung])
REFERENCES [dbo].[NguoiDung] ([manguoidung])
GO
ALTER TABLE [dbo].[DanhGia] CHECK CONSTRAINT [FK_DanhGia_NguoiDung]
GO
ALTER TABLE [dbo].[DauSach]  WITH CHECK ADD  CONSTRAINT [FK_DauSach_ChuDe] FOREIGN KEY([machude])
REFERENCES [dbo].[ChuDe] ([machude])
GO
ALTER TABLE [dbo].[DauSach] CHECK CONSTRAINT [FK_DauSach_ChuDe]
GO
ALTER TABLE [dbo].[DauSach]  WITH CHECK ADD  CONSTRAINT [FK_DauSach_NhaXuatBan] FOREIGN KEY([manhaxuatban])
REFERENCES [dbo].[NhaXuatBan] ([manhaxuatban])
GO
ALTER TABLE [dbo].[DauSach] CHECK CONSTRAINT [FK_DauSach_NhaXuatBan]
GO
ALTER TABLE [dbo].[DauSach]  WITH CHECK ADD  CONSTRAINT [FK_DauSach_TacGia] FOREIGN KEY([matacgia])
REFERENCES [dbo].[TacGia] ([matacgia])
GO
ALTER TABLE [dbo].[DauSach] CHECK CONSTRAINT [FK_DauSach_TacGia]
GO
ALTER TABLE [dbo].[DonMuonSach]  WITH CHECK ADD  CONSTRAINT [FK_DonMuonSach_NguoiDung] FOREIGN KEY([manguoidung])
REFERENCES [dbo].[NguoiDung] ([manguoidung])
GO
ALTER TABLE [dbo].[DonMuonSach] CHECK CONSTRAINT [FK_DonMuonSach_NguoiDung]
GO
ALTER TABLE [dbo].[DonMuonSach]  WITH CHECK ADD  CONSTRAINT [FK_DonMuonSach_TrangThai] FOREIGN KEY([matrangthai])
REFERENCES [dbo].[TrangThai] ([matrangthai])
GO
ALTER TABLE [dbo].[DonMuonSach] CHECK CONSTRAINT [FK_DonMuonSach_TrangThai]
GO
ALTER TABLE [dbo].[NguoiDung]  WITH CHECK ADD  CONSTRAINT [FK_NguoiDung_LoaiNguoiDung] FOREIGN KEY([maloainguoidung])
REFERENCES [dbo].[LoaiNguoiDung] ([maloainguoidung])
GO
ALTER TABLE [dbo].[NguoiDung] CHECK CONSTRAINT [FK_NguoiDung_LoaiNguoiDung]
GO
ALTER TABLE [dbo].[NhanXet]  WITH CHECK ADD  CONSTRAINT [FK_NhanXet_DauSach] FOREIGN KEY([madausach])
REFERENCES [dbo].[DauSach] ([madausach])
GO
ALTER TABLE [dbo].[NhanXet] CHECK CONSTRAINT [FK_NhanXet_DauSach]
GO
ALTER TABLE [dbo].[NhanXet]  WITH CHECK ADD  CONSTRAINT [FK_NhanXet_NguoiDung] FOREIGN KEY([manguoidung])
REFERENCES [dbo].[NguoiDung] ([manguoidung])
GO
ALTER TABLE [dbo].[NhanXet] CHECK CONSTRAINT [FK_NhanXet_NguoiDung]
GO
ALTER TABLE [dbo].[PhanHoi]  WITH CHECK ADD  CONSTRAINT [FK_PhanHoi_NguoiDung] FOREIGN KEY([manguoidung])
REFERENCES [dbo].[NguoiDung] ([manguoidung])
GO
ALTER TABLE [dbo].[PhanHoi] CHECK CONSTRAINT [FK_PhanHoi_NguoiDung]
GO
ALTER TABLE [dbo].[DanhGia]  WITH CHECK ADD  CONSTRAINT [CK_DanhGia_diemdanhgia] CHECK  (([diemdanhgia]>=(0) AND [diemdanhgia]<=(5)))
GO
ALTER TABLE [dbo].[DanhGia] CHECK CONSTRAINT [CK_DanhGia_diemdanhgia]
GO
/****** Object:  StoredProcedure [dbo].[sp_DuyetKhoSachPhanTrang]    Script Date: 9/8/2018 7:08:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[sp_DuyetKhoSachPhanTrang]
@sosachtrongtrang int,
@tranghientai int,
@cotsapxep nvarchar(100)
as
begin
	if @cotsapxep =N'tensach'
		begin
			select * from (select * from DauSach order by tensach desc
			offset ((@tranghientai - 1 )*@sosachtrongtrang ) rows fetch next @sosachtrongtrang rows only ) ds,
			TacGia tg, NhaXuatBan nxb , ChuDe cd
			where ds.matacgia = tg.matacgia and ds.manhaxuatban =nxb.manhaxuatban and cd.machude= ds.machude
		end
	else if @cotsapxep =N'matacgia'
		begin
			select * from (select * from DauSach order by matacgia desc
			offset ((@tranghientai - 1 )*@sosachtrongtrang ) rows fetch next @sosachtrongtrang rows only ) ds,
			TacGia tg, NhaXuatBan nxb , ChuDe cd
			where ds.matacgia = tg.matacgia and ds.manhaxuatban =nxb.manhaxuatban and cd.machude= ds.machude
		end
	else if @cotsapxep =N'manhaxuatban'
		begin
			select * from (select * from DauSach order by manhaxuatban desc
			offset ((@tranghientai - 1 )*@sosachtrongtrang ) rows fetch next @sosachtrongtrang rows only ) ds,
			TacGia tg, NhaXuatBan nxb , ChuDe cd
			where ds.matacgia = tg.matacgia and ds.manhaxuatban =nxb.manhaxuatban and cd.machude= ds.machude
		end
	else
		begin
			select * from (select * from DauSach order by ngaydang asc
			offset ((@tranghientai - 1 )*@sosachtrongtrang ) rows fetch next @sosachtrongtrang rows only ) ds,
			TacGia tg, NhaXuatBan nxb , ChuDe cd
			where ds.matacgia = tg.matacgia and ds.manhaxuatban =nxb.manhaxuatban and cd.machude= ds.machude
		end
end
GO
/****** Object:  StoredProcedure [dbo].[sp_DuyetKhoSachTheoChuDePhanTrang]    Script Date: 9/8/2018 7:08:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_DuyetKhoSachTheoChuDePhanTrang]
@machude nvarchar(50),
@sosachtrongtrang int,
@tranghientai int,
@cotsapxep nvarchar(100)
as
begin
	if @cotsapxep =N'tensach'
		begin
			select * from (select * from DauSach where machude=@machude order by tensach desc
			offset ((@tranghientai - 1 )*@sosachtrongtrang ) rows fetch next @sosachtrongtrang rows only ) ds,
			TacGia tg, NhaXuatBan nxb , ChuDe cd
			where ds.matacgia = tg.matacgia and ds.manhaxuatban =nxb.manhaxuatban and cd.machude= ds.machude
		end
	else if @cotsapxep =N'matacgia'
		begin
			select * from (select * from DauSach where machude=@machude order by matacgia desc
			offset ((@tranghientai - 1 )*@sosachtrongtrang ) rows fetch next @sosachtrongtrang rows only ) ds,
			TacGia tg, NhaXuatBan nxb , ChuDe cd
			where ds.matacgia = tg.matacgia and ds.manhaxuatban =nxb.manhaxuatban and cd.machude= ds.machude
		end
	else if @cotsapxep =N'manhaxuatban'
		begin
			select * from (select * from DauSach where machude=@machude order by manhaxuatban desc
			offset ((@tranghientai - 1 )*@sosachtrongtrang ) rows fetch next @sosachtrongtrang rows only ) ds,
			TacGia tg, NhaXuatBan nxb , ChuDe cd
			where ds.matacgia = tg.matacgia and ds.manhaxuatban =nxb.manhaxuatban and cd.machude= ds.machude
		end
	else
		begin
			select * from (select * from DauSach where machude=@machude order by ngaydang asc
			offset ((@tranghientai - 1 )*@sosachtrongtrang ) rows fetch next @sosachtrongtrang rows only ) ds,
			TacGia tg, NhaXuatBan nxb , ChuDe cd
			where ds.matacgia = tg.matacgia and ds.manhaxuatban =nxb.manhaxuatban and cd.machude= ds.machude
		end
end
GO
/****** Object:  StoredProcedure [dbo].[sp_LayDanhSachChuDe]    Script Date: 9/8/2018 7:08:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Thêm dữ liệu Cho Bảng Đánh Giá
--Thêm dữ liệu Cho Bảng Nhận Xét
--Thêm dữ liệu Cho Bảng Đơn Mượn Sách
--Thêm dữ liệu Cho Bảng Chi Tiết Đơn Mượn Sách
--Thêm dữ liệu Cho Bảng Phản Hồi
/*--------------------------------CÁC LỆNH TAO STORED PROCEDURED-----------------------------------------*/

/*Lấy chủ đề sách*/
create procedure [dbo].[sp_LayDanhSachChuDe]
as
begin
	select * from ChuDe
end

GO
/****** Object:  StoredProcedure [dbo].[sp_LayThongTinChiTietChuDeBoiMa]    Script Date: 9/8/2018 7:08:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_LayThongTinChiTietChuDeBoiMa]
@machude nvarchar(50)
as
begin 
	select * from ChuDe where machude= @machude
end
GO
/****** Object:  StoredProcedure [dbo].[sp_LayThongTinChiTietCuaDauSachBoiMa]    Script Date: 9/8/2018 7:08:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_LayThongTinChiTietCuaDauSachBoiMa]
@madausach nvarchar(50)
as
begin
	select * from DauSach ds,TacGia tg, NhaXuatBan nxb , ChuDe cd
	 where ds.madausach =@madausach and ds.matacgia = tg.matacgia and ds.manhaxuatban =nxb.manhaxuatban and cd.machude= ds.machude
end
GO
/****** Object:  StoredProcedure [dbo].[sp_LayThongTinNguoiDungBoiUsernameVaPassword]    Script Date: 9/8/2018 7:08:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*Đăng nhập*/
create procedure [dbo].[sp_LayThongTinNguoiDungBoiUsernameVaPassword]
@matkhau			nvarchar(50),
@tendangnhap		nvarchar(100)
as
begin
	select * from NguoiDung nd, LoaiNguoiDung lnd where nd.maloainguoidung=lnd.maloainguoidung and nd.matkhau=@matkhau and nd.tendangnhap=@tendangnhap
end

GO
/****** Object:  StoredProcedure [dbo].[sp_SoLuongSachCoTrongHeThongCuaMotChuDe]    Script Date: 9/8/2018 7:08:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_SoLuongSachCoTrongHeThongCuaMotChuDe]
@machude nvarchar(50)
as
begin
	select COUNT(*) from DauSach where machude = @machude
end
GO
/****** Object:  StoredProcedure [dbo].[sp_SoLuongSachTimKiemDuoc]    Script Date: 9/8/2018 7:08:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_SoLuongSachTimKiemDuoc]
@khoa nvarchar(100)
as
begin
	select count(*) from DauSach where dbo.fChuyenCoDauThanhKhongDau(tensach) like N'%'+dbo.fChuyenCoDauThanhKhongDau(@khoa)+'%' 
end
GO
/****** Object:  StoredProcedure [dbo].[sp_SoLuongSachTrongHeThong]    Script Date: 9/8/2018 7:08:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_SoLuongSachTrongHeThong]
as
begin
	select COUNT(*) from DauSach
end
GO
/****** Object:  StoredProcedure [dbo].[sp_ThemNguoiDungMoi]    Script Date: 9/8/2018 7:08:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*Thêm mới người dùng*/
create procedure [dbo].[sp_ThemNguoiDungMoi]
@tendangnhap		nvarchar(100),
@matkhau			nvarchar(100),
@hovaten			nvarchar(100),
@diachi				nvarchar(1000),
@email				nvarchar(100),
@sodienthoai		nvarchar(50),
@gioitinh			varchar(1),		
@ngaysinh			date,		
@motangan			nvarchar(MAX),
@maloainguoidung	nvarchar(50),
@khoanguoidung		varchar(1),
@tenanhdaidien		nvarchar(50) output
as
begin
	declare @manguoidung nvarchar(50)
	set @manguoidung = NEWID()
	if @tenanhdaidien=N'Y'
	begin
		set @tenanhdaidien = CONCAT(NEWID(),N'.jpg')
	end
	else
	begin
		set @tenanhdaidien = N'noimage.jpg'
	end
	insert into NguoiDung(manguoidung,tendangnhap,matkhau,hovaten,diachi,email,sodienthoai,gioitinh,ngaysinh,motangan,anhdaidien,maloainguoidung,khoanguoidung)
	values (@manguoidung,@tendangnhap,@matkhau,@hovaten,@diachi,@email,@sodienthoai,@gioitinh,@ngaysinh,@motangan,@tenanhdaidien,@maloainguoidung,@khoanguoidung)
end

GO
/****** Object:  StoredProcedure [dbo].[sp_TimKiemSachVaPhanTrang]    Script Date: 9/8/2018 7:08:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_TimKiemSachVaPhanTrang]
@khoa nvarchar(100),
@sosachtrongtrang int,
@tranghientai int,
@cotsapxep nvarchar(100)
as
begin
	if @cotsapxep =N'tensach'
		begin
			select * from (select * from DauSach where dbo.fChuyenCoDauThanhKhongDau(tensach) like N'%'+dbo.fChuyenCoDauThanhKhongDau(@khoa)+'%' order by tensach desc
			offset ((@tranghientai - 1 )*@sosachtrongtrang ) rows fetch next @sosachtrongtrang rows only ) ds,
			TacGia tg, NhaXuatBan nxb , ChuDe cd
			where ds.matacgia = tg.matacgia and ds.manhaxuatban =nxb.manhaxuatban and cd.machude= ds.machude
		end
	else if @cotsapxep =N'matacgia'
		begin
			select * from (select * from DauSach where dbo.fChuyenCoDauThanhKhongDau(tensach) like N'%'+dbo.fChuyenCoDauThanhKhongDau(@khoa)+'%' order by matacgia desc
			offset ((@tranghientai - 1 )*@sosachtrongtrang ) rows fetch next @sosachtrongtrang rows only ) ds,
			TacGia tg, NhaXuatBan nxb , ChuDe cd
			where ds.matacgia = tg.matacgia and ds.manhaxuatban =nxb.manhaxuatban and cd.machude= ds.machude
		end
	else if @cotsapxep =N'manhaxuatban'
		begin
			select * from (select * from DauSach where dbo.fChuyenCoDauThanhKhongDau(tensach) like N'%'+dbo.fChuyenCoDauThanhKhongDau(@khoa)+'%' order by manhaxuatban desc
			offset ((@tranghientai - 1 )*@sosachtrongtrang ) rows fetch next @sosachtrongtrang rows only ) ds,
			TacGia tg, NhaXuatBan nxb , ChuDe cd
			where ds.matacgia = tg.matacgia and ds.manhaxuatban =nxb.manhaxuatban and cd.machude= ds.machude
		end
	else
		begin
			select * from (select * from DauSach where dbo.fChuyenCoDauThanhKhongDau(tensach) like N'%'+dbo.fChuyenCoDauThanhKhongDau(@khoa)+'%' order by ngaydang asc
			offset ((@tranghientai - 1 )*@sosachtrongtrang ) rows fetch next @sosachtrongtrang rows only ) ds,
			TacGia tg, NhaXuatBan nxb , ChuDe cd
			where ds.matacgia = tg.matacgia and ds.manhaxuatban =nxb.manhaxuatban and cd.machude= ds.machude
		end
end

GO
/****** Object:  StoredProcedure [dbo].[sp_Top10DauSachXemNhieuNhat]    Script Date: 9/8/2018 7:08:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_Top10DauSachXemNhieuNhat]
as
begin 
	select * from (select Top(10)* from DauSach order by luotxem desc) ds,
			TacGia tg, NhaXuatBan nxb , ChuDe cd
			where ds.matacgia = tg.matacgia and ds.manhaxuatban =nxb.manhaxuatban and cd.machude= ds.machude
end
GO
/****** Object:  StoredProcedure [dbo].[sp_Top10DauSachXemNhieuNhatTheoMaChuDe]    Script Date: 9/8/2018 7:08:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_Top10DauSachXemNhieuNhatTheoMaChuDe]
@machude nvarchar(50)
as
begin 
	select * from (select Top(10)* from DauSach where machude = @machude order by luotxem desc) ds,
			TacGia tg, NhaXuatBan nxb , ChuDe cd
			where ds.matacgia = tg.matacgia and ds.manhaxuatban =nxb.manhaxuatban and cd.machude= ds.machude
end
GO
USE [master]
GO
ALTER DATABASE [LIBRARYK29] SET  READ_WRITE 
GO
