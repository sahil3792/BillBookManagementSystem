USE [master]
GO
/****** Object:  Database [BillingSystem]    Script Date: 30-09-2024 00:22:31 ******/
CREATE DATABASE [BillingSystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BillingSystem', FILENAME = N'C:\Users\kirti\BillingSystem.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BillingSystem_log', FILENAME = N'C:\Users\kirti\BillingSystem_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [BillingSystem] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BillingSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BillingSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BillingSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BillingSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BillingSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BillingSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [BillingSystem] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [BillingSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BillingSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BillingSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BillingSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BillingSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BillingSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BillingSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BillingSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BillingSystem] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BillingSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BillingSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BillingSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BillingSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BillingSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BillingSystem] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [BillingSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BillingSystem] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BillingSystem] SET  MULTI_USER 
GO
ALTER DATABASE [BillingSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BillingSystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BillingSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BillingSystem] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BillingSystem] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BillingSystem] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [BillingSystem] SET QUERY_STORE = OFF
GO
USE [BillingSystem]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 30-09-2024 00:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[inventories]    Script Date: 30-09-2024 00:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[inventories](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ItemType] [nvarchar](max) NOT NULL,
	[CategoryID] [bigint] NOT NULL,
	[ItemName] [nvarchar](max) NOT NULL,
	[SalesPrice] [decimal](18, 2) NOT NULL,
	[GSTTaxRate] [nvarchar](max) NOT NULL,
	[MeasuringUnit] [nvarchar](max) NOT NULL,
	[OpeningStock] [decimal](18, 2) NOT NULL,
	[PurchasePrice] [decimal](18, 2) NOT NULL,
	[ItemCode] [nvarchar](max) NOT NULL,
	[HSNCode] [bigint] NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Image] [nvarchar](max) NOT NULL,
	[BusinessId] [bigint] NOT NULL,
 CONSTRAINT [PK_inventories] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[invoicedItems]    Script Date: 30-09-2024 00:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[invoicedItems](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[SalesId] [int] NOT NULL,
	[InvoiceId] [int] NOT NULL,
	[InventoryId] [int] NOT NULL,
	[Quantity] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_invoicedItems] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[invoices]    Script Date: 30-09-2024 00:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[invoices](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Status] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_invoices] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[itemReportbyParties]    Script Date: 30-09-2024 00:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[itemReportbyParties](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ItemType] [nvarchar](max) NOT NULL,
	[CategoryID] [bigint] NOT NULL,
	[ItemName] [nvarchar](max) NOT NULL,
	[SalesPrice] [decimal](18, 2) NOT NULL,
	[GSTTaxRate] [nvarchar](max) NOT NULL,
	[MeasuringUnit] [nvarchar](max) NOT NULL,
	[OpeningStock] [decimal](18, 2) NOT NULL,
	[PurchasePrice] [decimal](18, 2) NOT NULL,
	[ItemCode] [nvarchar](max) NOT NULL,
	[HSNCode] [bigint] NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Image] [nvarchar](max) NOT NULL,
	[BusinessId] [bigint] NOT NULL,
	[SalesQuantity] [decimal](18, 2) NOT NULL,
	[PartyName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_itemReportbyParties] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[party]    Script Date: 30-09-2024 00:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[party](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[PartyName] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[PhoneNumber] [bigint] NOT NULL,
	[OpeningBalance] [bigint] NOT NULL,
	[GSTINNumber] [nvarchar](max) NOT NULL,
	[PanCardNumber] [nvarchar](max) NOT NULL,
	[PartyType] [nvarchar](max) NOT NULL,
	[PartyCategory] [int] NOT NULL,
	[BillingAddress] [nvarchar](max) NOT NULL,
	[ShippingAddress] [nvarchar](max) NOT NULL,
	[CreditPeriod] [bigint] NOT NULL,
	[CreditLimit] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_party] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PartyCategories]    Script Date: 30-09-2024 00:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PartyCategories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_PartyCategories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[partynames]    Script Date: 30-09-2024 00:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[partynames](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PartyName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_partynames] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[purchases]    Script Date: 30-09-2024 00:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[purchases](
	[PurchaseOrderId] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceDate] [nvarchar](max) NOT NULL,
	[PurchaseAmount] [decimal](18, 2) NOT NULL,
	[ValidTill] [nvarchar](max) NOT NULL,
	[CurrentStock] [bigint] NOT NULL,
	[PurchaseQuantity] [bigint] NOT NULL,
 CONSTRAINT [PK_purchases] PRIMARY KEY CLUSTERED 
(
	[PurchaseOrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[purchasesViewModel]    Script Date: 30-09-2024 00:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[purchasesViewModel](
	[PurchaseOrderId] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceDate] [nvarchar](max) NOT NULL,
	[PurchaseAmount] [decimal](18, 2) NOT NULL,
	[ValidTill] [nvarchar](max) NOT NULL,
	[PartyName] [nvarchar](max) NOT NULL,
	[GSTINNumber] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_purchasesViewModel] PRIMARY KEY CLUSTERED 
(
	[PurchaseOrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sales]    Script Date: 30-09-2024 00:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sales](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[BillTo] [int] NOT NULL,
	[ShipTo] [int] NOT NULL,
	[InvoiceId] [int] NOT NULL,
	[InvoiceDate] [nvarchar](max) NOT NULL,
	[SalesQuantity] [decimal](18, 2) NOT NULL,
	[InvoicedItemsId] [int] NOT NULL,
 CONSTRAINT [PK_sales] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[salesViewModel]    Script Date: 30-09-2024 00:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[salesViewModel](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BillTo] [int] NOT NULL,
	[ShipTo] [int] NOT NULL,
	[InvoiceId] [int] NOT NULL,
	[InvoiceDate] [nvarchar](max) NOT NULL,
	[ItemID] [int] NOT NULL,
	[SalesQuantity] [decimal](18, 2) NOT NULL,
	[PartyName] [nvarchar](max) NOT NULL,
	[SalesPrice] [decimal](18, 2) NOT NULL,
	[GSTINNumber] [nvarchar](max) NOT NULL,
	[Status] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_salesViewModel] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[itemReportbyParties] ADD  DEFAULT (N'') FOR [PartyName]
GO
ALTER TABLE [dbo].[sales] ADD  DEFAULT ((0)) FOR [InvoicedItemsId]
GO
/****** Object:  StoredProcedure [dbo].[Fetchallpartydefaultcategorydate]    Script Date: 30-09-2024 00:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Fetchallpartydefaultcategorydate]
@partycategory int = 0
as
begin
if (@partycategory =0)
begin

select p.id,PartyName,Email,PhoneNumber,OpeningBalance,GSTINNumber,PanCardNumber,PartyType,PartyCategory,BillingAddress,ShippingAddress,CreditPeriod,CreditLimit from party p
Inner join Sales s on p.id = s.BillTo
end
else
begin
select p.id,PartyName,Email,PhoneNumber,OpeningBalance,GSTINNumber,PanCardNumber,PartyType,PartyCategory,BillingAddress,ShippingAddress,CreditPeriod,CreditLimit from party p
Inner join Sales s on p.id = s.BillTo
where p.PartyCategory = @partycategory
end
end
GO
/****** Object:  StoredProcedure [dbo].[FetchthePartyCategory]    Script Date: 30-09-2024 00:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[FetchthePartyCategory]
as
begin
	select * from PartyCategories;
end
GO
/****** Object:  StoredProcedure [dbo].[GetPartyName]    Script Date: 30-09-2024 00:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetPartyName]
  as
  begin
  select id, PartyName from party
  end
GO
/****** Object:  StoredProcedure [dbo].[ItemReportproc]    Script Date: 30-09-2024 00:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  CREATE proc [dbo].[ItemReportproc]
  @partycategory int
 as
 begin
  select i.id, i.ItemCode,i.ItemName,i.OpeningStock,i.PurchasePrice,i.SalesPrice,ItemType,CategoryID,GSTTaxRate,MeasuringUnit,HSNCode,p.partyname,Description,Image,BusinessId,s.SalesQuantity from inventories i 
  inner join invoiceditems it on i.id = it.InventoryId
  inner join Sales s on s.id = it.SalesId
  inner join party p on p.PartyCategory = @partycategory
  end
GO
/****** Object:  StoredProcedure [dbo].[ItemReportprocbyPartyname]    Script Date: 30-09-2024 00:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  create proc [dbo].[ItemReportprocbyPartyname]
   @partyid int
 as
 begin
  select i.id, i.ItemCode,i.ItemName,i.OpeningStock,i.PurchasePrice,i.SalesPrice,ItemType,CategoryID,GSTTaxRate,MeasuringUnit,HSNCode,p.partyname,Description,Image,BusinessId,s.SalesQuantity from inventories i 
  inner join invoiceditems it on i.id = it.InventoryId
  inner join Sales s on s.id = it.SalesId
  inner join party p on p.id = @partyid
  end
GO
/****** Object:  StoredProcedure [dbo].[PurchaseDaybookProcdefault]    Script Date: 30-09-2024 00:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PurchaseDaybookProcdefault]
AS
BEGIN
select PurchaseOrderId, InvoiceDate, PurchaseAmount,ValidTill,CurrentStock,PurchaseQuantity,p.PartyName, p.GSTINNumber from Purchases pur
inner join Party p on pur.PurchaseOrderId= p.id
END;
GO
/****** Object:  StoredProcedure [dbo].[SalesDaybookProcdefault]    Script Date: 30-09-2024 00:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SalesDaybookProcdefault]
AS
BEGIN
    SELECT 
	s.id,
        s.BillTo, 
        s.ShipTo, 
        s.InvoiceId, 
        s.InvoiceDate, 
        s.invoicedItemsID as ItemId, 
        s.SalesQuantity, 
        p.PartyName, 
        ii.SalesPrice, 
        p.GSTINNumber, 
        i.Status 
    FROM Sales s
    INNER JOIN Party p ON s.BillTo = p.id
    INNER JOIN Invoices i ON s.BillTo = i.id
    INNER JOIN Inventories ii ON s.id = ii.id
END;
GO
USE [master]
GO
ALTER DATABASE [BillingSystem] SET  READ_WRITE 
GO
