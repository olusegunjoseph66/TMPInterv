USE [master]
GO
/****** Object:  Database [tmp-db]    Script Date: 2/9/2023 4:34:39 PM ******/
CREATE DATABASE [tmp-db]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'tmp-db', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\tmp-db.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'tmp-db_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\tmp-db_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [tmp-db] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [tmp-db].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [tmp-db] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [tmp-db] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [tmp-db] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [tmp-db] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [tmp-db] SET ARITHABORT OFF 
GO
ALTER DATABASE [tmp-db] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [tmp-db] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [tmp-db] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [tmp-db] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [tmp-db] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [tmp-db] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [tmp-db] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [tmp-db] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [tmp-db] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [tmp-db] SET  DISABLE_BROKER 
GO
ALTER DATABASE [tmp-db] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [tmp-db] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [tmp-db] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [tmp-db] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [tmp-db] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [tmp-db] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [tmp-db] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [tmp-db] SET RECOVERY FULL 
GO
ALTER DATABASE [tmp-db] SET  MULTI_USER 
GO
ALTER DATABASE [tmp-db] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [tmp-db] SET DB_CHAINING OFF 
GO
ALTER DATABASE [tmp-db] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [tmp-db] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [tmp-db] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [tmp-db] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'tmp-db', N'ON'
GO
ALTER DATABASE [tmp-db] SET QUERY_STORE = ON
GO
ALTER DATABASE [tmp-db] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [tmp-db]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 2/9/2023 4:34:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](20) NULL,
	[firstname] [nvarchar](100) NOT NULL,
	[middlename] [nvarchar](100) NOT NULL,
	[lastname] [nvarchar](100) NOT NULL,
	[emailAddress] [nvarchar](100) NOT NULL,
	[phoneNumber] [nvarchar](50) NOT NULL,
	[userId] [int] NULL,
	[birthday] [datetime2](7) NULL,
	[clientId] [int] NULL,
	[creatorUserId] [int] NULL,
	[modifiedByUserId] [bigint] NULL,
	[bloodType] [nvarchar](50) NULL,
	[heightMetres] [float] NULL,
	[weightKg] [float] NULL,
	[customerTypeId] [smallint] NOT NULL,
	[gender] [nvarchar](50) NULL,
	[companyName] [nvarchar](50) NULL,
	[sendPromoDetails] [bit] NULL,
	[sendBirthdayEmail] [bit] NULL,
	[activateReward] [nvarchar](50) NULL,
	[purchaseLimit] [decimal](18, 0) NULL,
	[dateCreated] [datetime2](7) NOT NULL,
	[dateModified] [datetime2](7) NULL,
	[UniqueCustomerCode] [nvarchar](20) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerType]    Script Date: 2/9/2023 4:34:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerType](
	[id] [smallint] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_CustomerType] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([id], [title], [firstname], [middlename], [lastname], [emailAddress], [phoneNumber], [userId], [birthday], [clientId], [creatorUserId], [modifiedByUserId], [bloodType], [heightMetres], [weightKg], [customerTypeId], [gender], [companyName], [sendPromoDetails], [sendBirthdayEmail], [activateReward], [purchaseLimit], [dateCreated], [dateModified], [UniqueCustomerCode]) VALUES (1, NULL, N'Mark', N'U', N'Wood', N'woods@gwd.com', N'0805677', NULL, CAST(N'2001-10-19T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, 1, N'Male', NULL, NULL, NULL, NULL, NULL, CAST(N'2023-02-09T10:53:23.5554056' AS DateTime2), CAST(N'2023-02-09T10:36:04.4468350' AS DateTime2), NULL)
INSERT [dbo].[Customer] ([id], [title], [firstname], [middlename], [lastname], [emailAddress], [phoneNumber], [userId], [birthday], [clientId], [creatorUserId], [modifiedByUserId], [bloodType], [heightMetres], [weightKg], [customerTypeId], [gender], [companyName], [sendPromoDetails], [sendBirthdayEmail], [activateReward], [purchaseLimit], [dateCreated], [dateModified], [UniqueCustomerCode]) VALUES (2, NULL, N'tester', N'W', N'lada', N'lada@yahoo.com', N'0807888', NULL, CAST(N'1993-12-23T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, 1, N'Female', NULL, NULL, NULL, NULL, NULL, CAST(N'2023-02-09T11:56:24.6736715' AS DateTime2), CAST(N'2023-02-09T11:56:24.6737451' AS DateTime2), NULL)
INSERT [dbo].[Customer] ([id], [title], [firstname], [middlename], [lastname], [emailAddress], [phoneNumber], [userId], [birthday], [clientId], [creatorUserId], [modifiedByUserId], [bloodType], [heightMetres], [weightKg], [customerTypeId], [gender], [companyName], [sendPromoDetails], [sendBirthdayEmail], [activateReward], [purchaseLimit], [dateCreated], [dateModified], [UniqueCustomerCode]) VALUES (3, N'Mrs', N'I', N'L', N'claren', N'claren@gmail.com', N'string', NULL, CAST(N'1950-06-24T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, 1, N'Female', NULL, NULL, NULL, NULL, NULL, CAST(N'2023-02-09T12:06:16.7849803' AS DateTime2), CAST(N'2023-02-09T12:23:30.7135347' AS DateTime2), NULL)
INSERT [dbo].[Customer] ([id], [title], [firstname], [middlename], [lastname], [emailAddress], [phoneNumber], [userId], [birthday], [clientId], [creatorUserId], [modifiedByUserId], [bloodType], [heightMetres], [weightKg], [customerTypeId], [gender], [companyName], [sendPromoDetails], [sendBirthdayEmail], [activateReward], [purchaseLimit], [dateCreated], [dateModified], [UniqueCustomerCode]) VALUES (4, N'Mr', N'Andrew', N'P', N'Waltes', N'waltes@end.com', N'099555', NULL, CAST(N'1965-08-13T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, 2, N'Male', NULL, NULL, NULL, NULL, NULL, CAST(N'2023-02-09T12:25:54.4228383' AS DateTime2), CAST(N'2023-02-09T12:25:54.4230277' AS DateTime2), NULL)
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[CustomerType] ON 

INSERT [dbo].[CustomerType] ([id], [name]) VALUES (1, N'Active')
INSERT [dbo].[CustomerType] ([id], [name]) VALUES (2, N'NonActive')
SET IDENTITY_INSERT [dbo].[CustomerType] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_CustomerType]    Script Date: 2/9/2023 4:34:39 PM ******/
ALTER TABLE [dbo].[CustomerType] ADD  CONSTRAINT [IX_CustomerType] UNIQUE NONCLUSTERED 
(
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_CustomerType] FOREIGN KEY([customerTypeId])
REFERENCES [dbo].[CustomerType] ([id])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_CustomerType]
GO
USE [master]
GO
ALTER DATABASE [tmp-db] SET  READ_WRITE 
GO
