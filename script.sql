USE [master]
GO
/****** Object:  Database [ShoppingTech]    Script Date: 8/27/2015 4:47:56 PM ******/
CREATE DATABASE [ShoppingTech]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ShoppingTech.mdf', FILENAME = N'c:\users\thanh.phan\documents\visual studio 2013\Projects\ShoppingTech\ShoppingTech\App_Data\ShoppingTech.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ShoppingTech_log.ldf', FILENAME = N'c:\users\thanh.phan\documents\visual studio 2013\Projects\ShoppingTech\ShoppingTech\App_Data\ShoppingTech_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ShoppingTech] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ShoppingTech].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ShoppingTech] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ShoppingTech] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ShoppingTech] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ShoppingTech] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ShoppingTech] SET ARITHABORT OFF 
GO
ALTER DATABASE [ShoppingTech] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ShoppingTech] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ShoppingTech] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ShoppingTech] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ShoppingTech] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ShoppingTech] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ShoppingTech] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ShoppingTech] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ShoppingTech] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ShoppingTech] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ShoppingTech] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ShoppingTech] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ShoppingTech] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ShoppingTech] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ShoppingTech] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ShoppingTech] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [ShoppingTech] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ShoppingTech] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ShoppingTech] SET  MULTI_USER 
GO
ALTER DATABASE [ShoppingTech] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ShoppingTech] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ShoppingTech] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ShoppingTech] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [ShoppingTech]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 8/27/2015 4:47:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 8/27/2015 4:47:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryId] [uniqueidentifier] NOT NULL DEFAULT (newsequentialid()),
	[Name] [nvarchar](max) NULL,
	[ImageUrl] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Products]    Script Date: 8/27/2015 4:47:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductId] [uniqueidentifier] NOT NULL DEFAULT (newsequentialid()),
	[ProductCode] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[ListPrice] [decimal](18, 2) NOT NULL,
	[DiscountPercent] [decimal](18, 2) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[ImageUrl] [nvarchar](max) NULL,
	[Category_CategoryId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_dbo.Products] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Index [IX_Category_CategoryId]    Script Date: 8/27/2015 4:47:56 PM ******/
CREATE NONCLUSTERED INDEX [IX_Category_CategoryId] ON [dbo].[Products]
(
	[Category_CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Products_dbo.Categories_Category_CategoryId] FOREIGN KEY([Category_CategoryId])
REFERENCES [dbo].[Categories] ([CategoryId])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_dbo.Products_dbo.Categories_Category_CategoryId]
GO
USE [master]
GO
ALTER DATABASE [ShoppingTech] SET  READ_WRITE 
GO
