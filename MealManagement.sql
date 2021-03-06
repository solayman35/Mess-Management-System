USE [master]
GO
/****** Object:  Database [MEAL-Management-C#]    Script Date: 12/4/2018 8:33:13 PM ******/
CREATE DATABASE [MEAL-Management-C#]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MEAL-Management-C#', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\MEAL-Management-C#.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'MEAL-Management-C#_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\MEAL-Management-C#_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [MEAL-Management-C#] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MEAL-Management-C#].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MEAL-Management-C#] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MEAL-Management-C#] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MEAL-Management-C#] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MEAL-Management-C#] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MEAL-Management-C#] SET ARITHABORT OFF 
GO
ALTER DATABASE [MEAL-Management-C#] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MEAL-Management-C#] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MEAL-Management-C#] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MEAL-Management-C#] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MEAL-Management-C#] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MEAL-Management-C#] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MEAL-Management-C#] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MEAL-Management-C#] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MEAL-Management-C#] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MEAL-Management-C#] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MEAL-Management-C#] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MEAL-Management-C#] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MEAL-Management-C#] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MEAL-Management-C#] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MEAL-Management-C#] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MEAL-Management-C#] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MEAL-Management-C#] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MEAL-Management-C#] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MEAL-Management-C#] SET  MULTI_USER 
GO
ALTER DATABASE [MEAL-Management-C#] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MEAL-Management-C#] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MEAL-Management-C#] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MEAL-Management-C#] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [MEAL-Management-C#] SET DELAYED_DURABILITY = DISABLED 
GO
USE [MEAL-Management-C#]
GO
/****** Object:  Table [dbo].[DailyMeal]    Script Date: 12/4/2018 8:33:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DailyMeal](
	[MealID] [int] IDENTITY(1,1) NOT NULL,
	[MemberID] [int] NOT NULL,
	[MealDate] [datetime] NOT NULL,
	[TotalMeal] [float] NOT NULL,
 CONSTRAINT [PK_DailyMeal] PRIMARY KEY CLUSTERED 
(
	[MealID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DailyShopping]    Script Date: 12/4/2018 8:33:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DailyShopping](
	[ShoppingID] [int] IDENTITY(1,1) NOT NULL,
	[MemberID] [int] NOT NULL,
	[ShoppingDate] [datetime] NOT NULL,
	[ShoppingCost] [int] NOT NULL,
 CONSTRAINT [PK_DailyShopping] PRIMARY KEY CLUSTERED 
(
	[ShoppingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Deposits]    Script Date: 12/4/2018 8:33:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Deposits](
	[DepositID] [int] IDENTITY(1,1) NOT NULL,
	[MemberID] [int] NOT NULL,
	[DepositAmount] [int] NOT NULL,
	[DepositDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Deposits] PRIMARY KEY CLUSTERED 
(
	[DepositID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Members]    Script Date: 12/4/2018 8:33:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Members](
	[MemberID] [int] IDENTITY(1,1) NOT NULL,
	[MemberName] [nvarchar](50) NOT NULL,
	[MemberEmail] [nvarchar](50) NOT NULL,
	[MemberPhone] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Members] PRIMARY KEY CLUSTERED 
(
	[MemberID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[DailyMeal] ON 

INSERT [dbo].[DailyMeal] ([MealID], [MemberID], [MealDate], [TotalMeal]) VALUES (1, 3, CAST(N'2018-11-25 00:00:00.000' AS DateTime), 3.5)
INSERT [dbo].[DailyMeal] ([MealID], [MemberID], [MealDate], [TotalMeal]) VALUES (2, 2, CAST(N'2018-11-25 00:00:00.000' AS DateTime), 3)
INSERT [dbo].[DailyMeal] ([MealID], [MemberID], [MealDate], [TotalMeal]) VALUES (3, 2, CAST(N'2018-11-26 00:00:00.000' AS DateTime), 3)
INSERT [dbo].[DailyMeal] ([MealID], [MemberID], [MealDate], [TotalMeal]) VALUES (4, 3, CAST(N'2018-11-26 00:00:00.000' AS DateTime), 3)
INSERT [dbo].[DailyMeal] ([MealID], [MemberID], [MealDate], [TotalMeal]) VALUES (5, 4, CAST(N'2018-11-26 00:00:00.000' AS DateTime), 3)
INSERT [dbo].[DailyMeal] ([MealID], [MemberID], [MealDate], [TotalMeal]) VALUES (6, 2, CAST(N'2018-11-27 00:00:00.000' AS DateTime), 3)
INSERT [dbo].[DailyMeal] ([MealID], [MemberID], [MealDate], [TotalMeal]) VALUES (7, 4, CAST(N'2018-11-27 00:00:00.000' AS DateTime), 3)
INSERT [dbo].[DailyMeal] ([MealID], [MemberID], [MealDate], [TotalMeal]) VALUES (10, 2, CAST(N'2018-12-01 00:00:00.000' AS DateTime), 3)
INSERT [dbo].[DailyMeal] ([MealID], [MemberID], [MealDate], [TotalMeal]) VALUES (11, 3, CAST(N'2018-12-01 00:00:00.000' AS DateTime), 2)
INSERT [dbo].[DailyMeal] ([MealID], [MemberID], [MealDate], [TotalMeal]) VALUES (12, 4, CAST(N'2018-12-01 00:00:00.000' AS DateTime), 3.5)
INSERT [dbo].[DailyMeal] ([MealID], [MemberID], [MealDate], [TotalMeal]) VALUES (13, 2, CAST(N'2018-12-02 00:00:00.000' AS DateTime), 2)
INSERT [dbo].[DailyMeal] ([MealID], [MemberID], [MealDate], [TotalMeal]) VALUES (14, 3, CAST(N'2018-12-02 00:00:00.000' AS DateTime), 5)
INSERT [dbo].[DailyMeal] ([MealID], [MemberID], [MealDate], [TotalMeal]) VALUES (15, 4, CAST(N'2018-12-02 00:00:00.000' AS DateTime), 3)
INSERT [dbo].[DailyMeal] ([MealID], [MemberID], [MealDate], [TotalMeal]) VALUES (16, 2, CAST(N'2018-12-03 00:00:00.000' AS DateTime), 5)
INSERT [dbo].[DailyMeal] ([MealID], [MemberID], [MealDate], [TotalMeal]) VALUES (17, 3, CAST(N'2018-12-03 00:00:00.000' AS DateTime), 3)
INSERT [dbo].[DailyMeal] ([MealID], [MemberID], [MealDate], [TotalMeal]) VALUES (18, 4, CAST(N'2018-12-03 00:00:00.000' AS DateTime), 3)
INSERT [dbo].[DailyMeal] ([MealID], [MemberID], [MealDate], [TotalMeal]) VALUES (19, 2, CAST(N'2018-12-04 00:00:00.000' AS DateTime), 5)
INSERT [dbo].[DailyMeal] ([MealID], [MemberID], [MealDate], [TotalMeal]) VALUES (20, 3, CAST(N'2018-12-04 00:00:00.000' AS DateTime), 3)
INSERT [dbo].[DailyMeal] ([MealID], [MemberID], [MealDate], [TotalMeal]) VALUES (21, 4, CAST(N'2018-12-04 00:00:00.000' AS DateTime), 2)
INSERT [dbo].[DailyMeal] ([MealID], [MemberID], [MealDate], [TotalMeal]) VALUES (22, 2, CAST(N'2018-12-05 00:00:00.000' AS DateTime), 2.5)
INSERT [dbo].[DailyMeal] ([MealID], [MemberID], [MealDate], [TotalMeal]) VALUES (23, 3, CAST(N'2018-12-05 00:00:00.000' AS DateTime), 3)
INSERT [dbo].[DailyMeal] ([MealID], [MemberID], [MealDate], [TotalMeal]) VALUES (24, 4, CAST(N'2018-12-05 00:00:00.000' AS DateTime), 4)
INSERT [dbo].[DailyMeal] ([MealID], [MemberID], [MealDate], [TotalMeal]) VALUES (25, 2, CAST(N'2018-12-06 00:00:00.000' AS DateTime), 4)
INSERT [dbo].[DailyMeal] ([MealID], [MemberID], [MealDate], [TotalMeal]) VALUES (26, 3, CAST(N'2018-12-06 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[DailyMeal] ([MealID], [MemberID], [MealDate], [TotalMeal]) VALUES (27, 4, CAST(N'2018-12-06 00:00:00.000' AS DateTime), 2)
INSERT [dbo].[DailyMeal] ([MealID], [MemberID], [MealDate], [TotalMeal]) VALUES (28, 2, CAST(N'2018-12-07 00:00:00.000' AS DateTime), 4)
INSERT [dbo].[DailyMeal] ([MealID], [MemberID], [MealDate], [TotalMeal]) VALUES (29, 3, CAST(N'2018-12-07 00:00:00.000' AS DateTime), 5)
INSERT [dbo].[DailyMeal] ([MealID], [MemberID], [MealDate], [TotalMeal]) VALUES (30, 4, CAST(N'2018-12-07 00:00:00.000' AS DateTime), 3)
SET IDENTITY_INSERT [dbo].[DailyMeal] OFF
SET IDENTITY_INSERT [dbo].[DailyShopping] ON 

INSERT [dbo].[DailyShopping] ([ShoppingID], [MemberID], [ShoppingDate], [ShoppingCost]) VALUES (5, 2, CAST(N'2018-11-23 00:00:00.000' AS DateTime), 100)
INSERT [dbo].[DailyShopping] ([ShoppingID], [MemberID], [ShoppingDate], [ShoppingCost]) VALUES (6, 3, CAST(N'2018-11-23 00:00:00.000' AS DateTime), 120)
INSERT [dbo].[DailyShopping] ([ShoppingID], [MemberID], [ShoppingDate], [ShoppingCost]) VALUES (7, 4, CAST(N'2018-11-24 00:00:00.000' AS DateTime), 200)
INSERT [dbo].[DailyShopping] ([ShoppingID], [MemberID], [ShoppingDate], [ShoppingCost]) VALUES (8, 2, CAST(N'2018-12-01 00:00:00.000' AS DateTime), 1500)
INSERT [dbo].[DailyShopping] ([ShoppingID], [MemberID], [ShoppingDate], [ShoppingCost]) VALUES (9, 3, CAST(N'2018-12-02 00:00:00.000' AS DateTime), 1200)
INSERT [dbo].[DailyShopping] ([ShoppingID], [MemberID], [ShoppingDate], [ShoppingCost]) VALUES (10, 4, CAST(N'2018-10-03 00:00:00.000' AS DateTime), 810)
INSERT [dbo].[DailyShopping] ([ShoppingID], [MemberID], [ShoppingDate], [ShoppingCost]) VALUES (11, 2, CAST(N'2018-10-04 00:00:00.000' AS DateTime), 310)
INSERT [dbo].[DailyShopping] ([ShoppingID], [MemberID], [ShoppingDate], [ShoppingCost]) VALUES (12, 4, CAST(N'2018-10-05 00:00:00.000' AS DateTime), 350)
INSERT [dbo].[DailyShopping] ([ShoppingID], [MemberID], [ShoppingDate], [ShoppingCost]) VALUES (15, 4, CAST(N'2018-12-03 00:00:00.000' AS DateTime), 100)
INSERT [dbo].[DailyShopping] ([ShoppingID], [MemberID], [ShoppingDate], [ShoppingCost]) VALUES (16, 2, CAST(N'2018-12-04 00:00:00.000' AS DateTime), 200)
INSERT [dbo].[DailyShopping] ([ShoppingID], [MemberID], [ShoppingDate], [ShoppingCost]) VALUES (17, 4, CAST(N'2018-12-05 00:00:00.000' AS DateTime), 350)
INSERT [dbo].[DailyShopping] ([ShoppingID], [MemberID], [ShoppingDate], [ShoppingCost]) VALUES (18, 2, CAST(N'2018-12-06 00:00:00.000' AS DateTime), 500)
INSERT [dbo].[DailyShopping] ([ShoppingID], [MemberID], [ShoppingDate], [ShoppingCost]) VALUES (19, 3, CAST(N'2018-12-07 00:00:00.000' AS DateTime), 580)
INSERT [dbo].[DailyShopping] ([ShoppingID], [MemberID], [ShoppingDate], [ShoppingCost]) VALUES (20, 3, CAST(N'2018-12-08 00:00:00.000' AS DateTime), 120)
SET IDENTITY_INSERT [dbo].[DailyShopping] OFF
SET IDENTITY_INSERT [dbo].[Deposits] ON 

INSERT [dbo].[Deposits] ([DepositID], [MemberID], [DepositAmount], [DepositDate]) VALUES (10, 2, 1000, CAST(N'2018-11-21 00:00:00.000' AS DateTime))
INSERT [dbo].[Deposits] ([DepositID], [MemberID], [DepositAmount], [DepositDate]) VALUES (11, 3, 1500, CAST(N'2018-11-21 00:00:00.000' AS DateTime))
INSERT [dbo].[Deposits] ([DepositID], [MemberID], [DepositAmount], [DepositDate]) VALUES (13, 2, 500, CAST(N'2018-11-22 00:00:00.000' AS DateTime))
INSERT [dbo].[Deposits] ([DepositID], [MemberID], [DepositAmount], [DepositDate]) VALUES (14, 3, 600, CAST(N'2018-11-22 00:00:00.000' AS DateTime))
INSERT [dbo].[Deposits] ([DepositID], [MemberID], [DepositAmount], [DepositDate]) VALUES (16, 4, 1000, CAST(N'2018-11-20 00:00:00.000' AS DateTime))
INSERT [dbo].[Deposits] ([DepositID], [MemberID], [DepositAmount], [DepositDate]) VALUES (17, 2, 500, CAST(N'2018-12-03 00:00:00.000' AS DateTime))
INSERT [dbo].[Deposits] ([DepositID], [MemberID], [DepositAmount], [DepositDate]) VALUES (18, 4, 500, CAST(N'2018-12-02 00:00:00.000' AS DateTime))
INSERT [dbo].[Deposits] ([DepositID], [MemberID], [DepositAmount], [DepositDate]) VALUES (19, 3, 500, CAST(N'2018-12-01 00:00:00.000' AS DateTime))
INSERT [dbo].[Deposits] ([DepositID], [MemberID], [DepositAmount], [DepositDate]) VALUES (20, 3, 100, CAST(N'2018-12-01 00:00:00.000' AS DateTime))
INSERT [dbo].[Deposits] ([DepositID], [MemberID], [DepositAmount], [DepositDate]) VALUES (21, 2, 200, CAST(N'2018-12-01 00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Deposits] OFF
SET IDENTITY_INSERT [dbo].[Members] ON 

INSERT [dbo].[Members] ([MemberID], [MemberName], [MemberEmail], [MemberPhone]) VALUES (2, N'sabuz', N's@gmail.com', N'01689')
INSERT [dbo].[Members] ([MemberID], [MemberName], [MemberEmail], [MemberPhone]) VALUES (3, N'ZAHID', N'Z@GMAIL.COM', N'01528')
INSERT [dbo].[Members] ([MemberID], [MemberName], [MemberEmail], [MemberPhone]) VALUES (4, N'Jahanur', N'j@gmail.com', N'')
SET IDENTITY_INSERT [dbo].[Members] OFF
USE [master]
GO
ALTER DATABASE [MEAL-Management-C#] SET  READ_WRITE 
GO
