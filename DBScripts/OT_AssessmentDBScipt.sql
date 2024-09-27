USE [master]
GO
/****** Object:  Database [OT_Assessment_DB]    Script Date: 27/09/2024 15:32:49 ******/
CREATE DATABASE [OT_Assessment_DB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'OT_Assessment_DB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\OT_Assessment_DB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'OT_Assessment_DB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\OT_Assessment_DB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [OT_Assessment_DB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [OT_Assessment_DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [OT_Assessment_DB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [OT_Assessment_DB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [OT_Assessment_DB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [OT_Assessment_DB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [OT_Assessment_DB] SET ARITHABORT OFF 
GO
ALTER DATABASE [OT_Assessment_DB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [OT_Assessment_DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [OT_Assessment_DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [OT_Assessment_DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [OT_Assessment_DB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [OT_Assessment_DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [OT_Assessment_DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [OT_Assessment_DB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [OT_Assessment_DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [OT_Assessment_DB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [OT_Assessment_DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [OT_Assessment_DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [OT_Assessment_DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [OT_Assessment_DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [OT_Assessment_DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [OT_Assessment_DB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [OT_Assessment_DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [OT_Assessment_DB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [OT_Assessment_DB] SET  MULTI_USER 
GO
ALTER DATABASE [OT_Assessment_DB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [OT_Assessment_DB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [OT_Assessment_DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [OT_Assessment_DB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [OT_Assessment_DB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [OT_Assessment_DB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [OT_Assessment_DB] SET QUERY_STORE = OFF
GO
USE [OT_Assessment_DB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 27/09/2024 15:32:49 ******/
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
/****** Object:  Table [dbo].[PlayerAccounts]    Script Date: 27/09/2024 15:32:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlayerAccounts](
	[AccountId] [uniqueidentifier] NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_PlayerAccounts] PRIMARY KEY CLUSTERED 
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PlayerCasinoWagers]    Script Date: 27/09/2024 15:32:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlayerCasinoWagers](
	[WagerId] [uniqueidentifier] NOT NULL,
	[AccountId] [uniqueidentifier] NOT NULL,
	[Theme] [nvarchar](100) NOT NULL,
	[GameName] [nvarchar](max) NOT NULL,
	[Provider] [nvarchar](100) NOT NULL,
	[Amount] [decimal](18, 4) NOT NULL,
	[Status] [int] NOT NULL,
	[CreatedDateTime] [datetime2](7) NOT NULL,
	[TransactionId] [uniqueidentifier] NOT NULL,
	[BrandId] [uniqueidentifier] NOT NULL,
	[ExternalReferenceId] [uniqueidentifier] NOT NULL,
	[TransactionTypeId] [uniqueidentifier] NOT NULL,
	[NumberOfBets] [int] NOT NULL,
	[SessionData] [nvarchar](max) NULL,
	[CountryCode] [nvarchar](max) NOT NULL,
	[Duration] [bigint] NOT NULL,
 CONSTRAINT [PK_PlayerCasinoWagers] PRIMARY KEY CLUSTERED 
(
	[WagerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240927131459_InitialCreate', N'8.0.8')
GO
INSERT [dbo].[PlayerAccounts] ([AccountId], [Username]) VALUES (N'daf35aad-7654-4085-868f-27347ef2e522', N'Max.Booth67')
INSERT [dbo].[PlayerAccounts] ([AccountId], [Username]) VALUES (N'72e2cae1-4ec0-4f00-8c7a-29caba70f4b4', N'Bova.Senoinoi11')
INSERT [dbo].[PlayerAccounts] ([AccountId], [Username]) VALUES (N'70f8f4dd-f621-40b8-9692-eac3f7e4a667', N'Sentle.Morake88')
GO
INSERT [dbo].[PlayerCasinoWagers] ([WagerId], [AccountId], [Theme], [GameName], [Provider], [Amount], [Status], [CreatedDateTime], [TransactionId], [BrandId], [ExternalReferenceId], [TransactionTypeId], [NumberOfBets], [SessionData], [CountryCode], [Duration]) VALUES (N'a16f1fb9-98bd-47fe-bd63-2f16fb088acc', N'72e2cae1-4ec0-4f00-8c7a-29caba70f4b4', N'Space', N'Starscape Galaxy Quest', N'Next Gen Gaming', CAST(19834.7500 AS Decimal(18, 4)), 0, CAST(N'2024-09-27T13:14:56.6927077' AS DateTime2), N'533efc4c-bffc-464e-a412-34b1948b6b58', N'5cc2e173-1de5-4a86-aacc-9b5403c8c079', N'00000000-0000-0000-0000-000000000000', N'00000000-0000-0000-0000-000000000000', 2, N'Sample session data for space game', N'ZAR', 1458721)
INSERT [dbo].[PlayerCasinoWagers] ([WagerId], [AccountId], [Theme], [GameName], [Provider], [Amount], [Status], [CreatedDateTime], [TransactionId], [BrandId], [ExternalReferenceId], [TransactionTypeId], [NumberOfBets], [SessionData], [CountryCode], [Duration]) VALUES (N'e4993f13-3bde-4f82-a85c-4618e5cdc037', N'daf35aad-7654-4085-868f-27347ef2e522', N'Adventure', N'Ergonomic Granite Cheese', N'Ergonomic Soft Fish', CAST(38273.9700 AS Decimal(18, 4)), 0, CAST(N'2024-09-27T13:14:56.6927044' AS DateTime2), N'd09b25ba-2f8a-478d-b2a6-86ff7c651ebc', N'b93d8830-70be-48e8-82d9-3e66bba13f96', N'00000000-0000-0000-0000-000000000000', N'00000000-0000-0000-0000-000000000000', 3, N'Sample session data', N'ZAR', 1827254)
INSERT [dbo].[PlayerCasinoWagers] ([WagerId], [AccountId], [Theme], [GameName], [Provider], [Amount], [Status], [CreatedDateTime], [TransactionId], [BrandId], [ExternalReferenceId], [TransactionTypeId], [NumberOfBets], [SessionData], [CountryCode], [Duration]) VALUES (N'57751b73-0a4f-4738-9c56-99acb8ed2373', N'70f8f4dd-f621-40b8-9692-eac3f7e4a667', N'Mystery', N'Mystery of the Lost Tomb', N'Ultimate Games Ltd', CAST(52450.1200 AS Decimal(18, 4)), 0, CAST(N'2024-09-27T13:14:56.6927072' AS DateTime2), N'624afb15-90ab-433a-a5b0-f05d1a653102', N'd243d980-44ec-4715-a793-30c0c9eb39a0', N'00000000-0000-0000-0000-000000000000', N'00000000-0000-0000-0000-000000000000', 5, N'Sample session data for mystery game', N'ZAR', 2657842)
GO
/****** Object:  Index [IX_PlayerCasinoWagers_AccountId]    Script Date: 27/09/2024 15:32:50 ******/
CREATE NONCLUSTERED INDEX [IX_PlayerCasinoWagers_AccountId] ON [dbo].[PlayerCasinoWagers]
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[PlayerCasinoWagers]  WITH CHECK ADD  CONSTRAINT [FK_PlayerCasinoWagers_PlayerAccounts_AccountId] FOREIGN KEY([AccountId])
REFERENCES [dbo].[PlayerAccounts] ([AccountId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PlayerCasinoWagers] CHECK CONSTRAINT [FK_PlayerCasinoWagers_PlayerAccounts_AccountId]
GO
USE [master]
GO
ALTER DATABASE [OT_Assessment_DB] SET  READ_WRITE 
GO
