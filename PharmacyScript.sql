USE [master]
GO
/****** Object:  Database [Pharmacy]    Script Date: 10.02.2015 12:57:32 ******/
CREATE DATABASE [Pharmacy]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Pharmacy', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Pharmacy.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Pharmacy_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Pharmacy_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Pharmacy] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Pharmacy].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Pharmacy] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Pharmacy] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Pharmacy] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Pharmacy] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Pharmacy] SET ARITHABORT OFF 
GO
ALTER DATABASE [Pharmacy] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Pharmacy] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Pharmacy] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Pharmacy] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Pharmacy] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Pharmacy] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Pharmacy] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Pharmacy] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Pharmacy] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Pharmacy] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Pharmacy] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Pharmacy] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Pharmacy] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Pharmacy] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Pharmacy] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Pharmacy] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Pharmacy] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Pharmacy] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Pharmacy] SET  MULTI_USER 
GO
ALTER DATABASE [Pharmacy] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Pharmacy] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Pharmacy] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Pharmacy] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Pharmacy] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Pharmacy]
GO
/****** Object:  Table [dbo].[EyeClientData]    Script Date: 10.02.2015 12:57:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EyeClientData](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LeftEye] [int] NULL,
	[RightEye] [int] NULL,
	[ClientId] [int] NULL,
 CONSTRAINT [PK_EyeClientData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MainClientData]    Script Date: 10.02.2015 12:57:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MainClientData](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
 CONSTRAINT [PK_MainClientData] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OtherClientData]    Script Date: 10.02.2015 12:57:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OtherClientData](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BirthDate] [datetime] NULL,
	[Address] [nvarchar](100) NULL,
	[Phone] [nvarchar](20) NULL,
	[ClientId] [int] NULL,
 CONSTRAINT [PK_OtherClientData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[VisitData]    Script Date: 10.02.2015 12:57:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VisitData](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VisitDate] [datetime] NULL,
	[OrderAmount] [decimal](18, 3) NULL,
	[OrderStatus] [nvarchar](20) NULL,
	[ClientId] [int] NULL,
	[Removed] [bit] NULL,
 CONSTRAINT [PK_VisitData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[EyeClientData] ON 

INSERT [dbo].[EyeClientData] ([Id], [LeftEye], [RightEye], [ClientId]) VALUES (1, 3, 3, 1)
INSERT [dbo].[EyeClientData] ([Id], [LeftEye], [RightEye], [ClientId]) VALUES (2, 3, 3, 2)
INSERT [dbo].[EyeClientData] ([Id], [LeftEye], [RightEye], [ClientId]) VALUES (3, -1, -1, 3)
SET IDENTITY_INSERT [dbo].[EyeClientData] OFF
SET IDENTITY_INSERT [dbo].[MainClientData] ON 

INSERT [dbo].[MainClientData] ([id], [FirstName], [LastName], [Email]) VALUES (1, N'John', N'Weak', N'j.weak@gmail.com')
INSERT [dbo].[MainClientData] ([id], [FirstName], [LastName], [Email]) VALUES (2, N'Eugene', N'Kostyukevich', N'ekostukevich@gmail.com')
INSERT [dbo].[MainClientData] ([id], [FirstName], [LastName], [Email]) VALUES (3, N'Kate', N'Draenkova', N'draenkova@mail.ru')
SET IDENTITY_INSERT [dbo].[MainClientData] OFF
SET IDENTITY_INSERT [dbo].[OtherClientData] ON 

INSERT [dbo].[OtherClientData] ([Id], [BirthDate], [Address], [Phone], [ClientId]) VALUES (1, CAST(N'1976-01-25 00:00:00.000' AS DateTime), N'New York', N'+575647647', 1)
INSERT [dbo].[OtherClientData] ([Id], [BirthDate], [Address], [Phone], [ClientId]) VALUES (2, CAST(N'1994-04-20 00:00:00.000' AS DateTime), N'Minsk', N'+5636347', 2)
INSERT [dbo].[OtherClientData] ([Id], [BirthDate], [Address], [Phone], [ClientId]) VALUES (3, CAST(N'1993-09-16 00:00:00.000' AS DateTime), N'Minsk', N'+375291234567', 3)
SET IDENTITY_INSERT [dbo].[OtherClientData] OFF
SET IDENTITY_INSERT [dbo].[VisitData] ON 

INSERT [dbo].[VisitData] ([Id], [VisitDate], [OrderAmount], [OrderStatus], [ClientId], [Removed]) VALUES (1, CAST(N'2015-02-10 00:00:00.000' AS DateTime), CAST(11.000 AS Decimal(18, 3)), N'Canceled', 2, 0)
INSERT [dbo].[VisitData] ([Id], [VisitDate], [OrderAmount], [OrderStatus], [ClientId], [Removed]) VALUES (2, CAST(N'2015-02-10 00:00:00.000' AS DateTime), CAST(11.000 AS Decimal(18, 3)), N'In progress', 3, 0)
INSERT [dbo].[VisitData] ([Id], [VisitDate], [OrderAmount], [OrderStatus], [ClientId], [Removed]) VALUES (3, CAST(N'2015-02-09 00:00:00.000' AS DateTime), CAST(1.000 AS Decimal(18, 3)), N'Completed', 3, 0)
INSERT [dbo].[VisitData] ([Id], [VisitDate], [OrderAmount], [OrderStatus], [ClientId], [Removed]) VALUES (4, CAST(N'2015-02-10 00:00:00.000' AS DateTime), CAST(11.000 AS Decimal(18, 3)), N'Canceled', 2, 0)
INSERT [dbo].[VisitData] ([Id], [VisitDate], [OrderAmount], [OrderStatus], [ClientId], [Removed]) VALUES (5, CAST(N'2015-02-09 00:00:00.000' AS DateTime), CAST(1.000 AS Decimal(18, 3)), N'In progress', 2, 0)
INSERT [dbo].[VisitData] ([Id], [VisitDate], [OrderAmount], [OrderStatus], [ClientId], [Removed]) VALUES (7, CAST(N'2015-02-08 00:00:00.000' AS DateTime), CAST(121.000 AS Decimal(18, 3)), N'In progress', 2, 0)
INSERT [dbo].[VisitData] ([Id], [VisitDate], [OrderAmount], [OrderStatus], [ClientId], [Removed]) VALUES (8, CAST(N'2015-02-11 00:00:00.000' AS DateTime), CAST(2222.000 AS Decimal(18, 3)), N'In progress', 2, 0)
SET IDENTITY_INSERT [dbo].[VisitData] OFF
ALTER TABLE [dbo].[EyeClientData]  WITH CHECK ADD  CONSTRAINT [FK_EyeClientData_EyeClientData] FOREIGN KEY([ClientId])
REFERENCES [dbo].[MainClientData] ([id])
GO
ALTER TABLE [dbo].[EyeClientData] CHECK CONSTRAINT [FK_EyeClientData_EyeClientData]
GO
ALTER TABLE [dbo].[OtherClientData]  WITH CHECK ADD  CONSTRAINT [FK_OtherClientData_MainClientData] FOREIGN KEY([ClientId])
REFERENCES [dbo].[MainClientData] ([id])
GO
ALTER TABLE [dbo].[OtherClientData] CHECK CONSTRAINT [FK_OtherClientData_MainClientData]
GO
ALTER TABLE [dbo].[VisitData]  WITH CHECK ADD  CONSTRAINT [FK_VisitData_VisitData] FOREIGN KEY([ClientId])
REFERENCES [dbo].[MainClientData] ([id])
GO
ALTER TABLE [dbo].[VisitData] CHECK CONSTRAINT [FK_VisitData_VisitData]
GO
USE [master]
GO
ALTER DATABASE [Pharmacy] SET  READ_WRITE 
GO
