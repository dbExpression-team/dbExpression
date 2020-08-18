CREATE DATABASE [MsSqlDbExTest]
	CONTAINMENT = NONE
	ON  PRIMARY 
	( 
		NAME = N'MsSqlDbExTest', FILENAME = N'/var/opt/mssql/data/MsSqlDbExtTest.mdf' , SIZE = 8192KB , MAXSIZE = 128MB, FILEGROWTH = 8192KB )
		LOG ON 
		( 
			NAME = N'MsSqlDbExTest_log', 
			FILENAME = N'/var/opt/mssql/data/MsSqlDbExtTest.ldf', 
			SIZE = 8192KB , 
			MAXSIZE = 128MB , 
			FILEGROWTH = 8192KB 
		)
GO

ALTER DATABASE [MsSqlDbExTest] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [MsSqlDbExTest] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [MsSqlDbExTest] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [MsSqlDbExTest] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [MsSqlDbExTest] SET ARITHABORT OFF 
GO

ALTER DATABASE [MsSqlDbExTest] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [MsSqlDbExTest] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [MsSqlDbExTest] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [MsSqlDbExTest] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [MsSqlDbExTest] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [MsSqlDbExTest] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [MsSqlDbExTest] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [MsSqlDbExTest] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [MsSqlDbExTest] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [MsSqlDbExTest] SET  DISABLE_BROKER 
GO

ALTER DATABASE [MsSqlDbExTest] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [MsSqlDbExTest] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [MsSqlDbExTest] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [MsSqlDbExTest] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [MsSqlDbExTest] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [MsSqlDbExTest] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [MsSqlDbExTest] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [MsSqlDbExTest] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [MsSqlDbExTest] SET  MULTI_USER 
GO

ALTER DATABASE [MsSqlDbExTest] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [MsSqlDbExTest] SET DB_CHAINING OFF 
GO

ALTER DATABASE [MsSqlDbExTest] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [MsSqlDbExTest] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [MsSqlDbExTest] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [MsSqlDbExTest] SET QUERY_STORE = OFF
GO

USE [MsSqlDbExTest]
GO

ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO

ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO

ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO

ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO

ALTER DATABASE [MsSqlDbExTest] SET  READ_WRITE 
GO

CREATE TABLE [dbo].[Address](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AddressType] [int] NULL,
	[Line1] [varchar](50) NOT NULL,
	[Line2] [varchar](50) NULL,
	[City] [varchar](60) NOT NULL,
	[State] [char](2) NOT NULL,
	[Zip] [varchar](10) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateUpdated] [datetime] NOT NULL,
	CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED ([Id])
)
GO

CREATE TABLE [dbo].[Person](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](20) NOT NULL,
	[LastName] [varchar](20) NOT NULL,
	[BirthDate] [datetime] NULL,
	[GenderType] [int] NOT NULL,
	[CreditLimit] [int] NULL,
	[YearOfLastCreditLimitReview] [int] NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateUpdated] [datetime] NOT NULL,
	CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED ([Id]) 
)
GO

CREATE TABLE [dbo].[Person_Address](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PersonId] [int] NOT NULL,
	[AddressId] [int] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	CONSTRAINT [PK_Person_Address] PRIMARY KEY CLUSTERED ([Id]),
	CONSTRAINT [FK_Person_Address_Address] FOREIGN KEY([AddressId]) REFERENCES [dbo].[Address] ([Id]),
	CONSTRAINT [FK_Person_Address_Person] FOREIGN KEY([PersonId]) REFERENCES [dbo].[Person] ([Id])
)
GO

CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductCategoryType] [int] NULL,
	[Name] [varchar](80) NOT NULL,
	[Description] [varchar](2000) NULL,
	[ListPrice] [decimal](12, 2) NOT NULL,
	[Price] [decimal](12, 2) NOT NULL,
	[Quantity] [int] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateUpdated] [datetime] NOT NULL,
	CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED ([Id]) 
)
GO

CREATE TABLE [dbo].[Purchase](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PersonId] [int] NOT NULL,
	[TotalPurchaseAmount] [decimal](12, 2) NOT NULL,
	[PurchaseDate] [datetime] NOT NULL,
	[ShipDate] [datetime] NULL,
	[ExpectedDeliveryDate] [datetime] NULL,
	[TrackingIdentifier] [uniqueidentifier] NULL,
	[PaymentMethodType] VARCHAR(20) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateUpdated] [datetime] NOT NULL,
	CONSTRAINT [PK_Purchase] PRIMARY KEY CLUSTERED ([Id]),
	CONSTRAINT [FK_Purchase_Person] FOREIGN KEY([PersonId]) REFERENCES [dbo].[Person] ([Id])
)
GO

CREATE TABLE [dbo].[PurchaseLine](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PurchaseId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[PurchasePrice] [decimal](12, 2) NOT NULL,
	[Quantity] [int] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateUpdated] [datetime] NOT NULL,
	CONSTRAINT [PK_PurchaseLine] PRIMARY KEY CLUSTERED ([Id]),
	CONSTRAINT [FK_PurchaseLine_Purchase] FOREIGN KEY([PurchaseId]) REFERENCES [dbo].[Purchase] ([Id]),
	CONSTRAINT [FK_PurchaseLine_Product] FOREIGN KEY([ProductId]) REFERENCES [dbo].[Product] ([Id])
)
GO

CREATE SCHEMA [sec]
GO

CREATE TABLE [sec].[Person](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SSN] [char](9) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateUpdated] [datetime] NOT NULL,
	CONSTRAINT [PK_secPerson] PRIMARY KEY CLUSTERED ([Id])
)
GO

CREATE VIEW [dbo].[PersonTotalPurchasesView]
AS
SELECT        
	[dbo].[Person].[Id], 
	SUM([dbo].[Purchase].[TotalPurchaseAmount]) AS TotalPurchases
FROM            
	[dbo].[Person] 
	INNER JOIN [dbo].[Purchase] ON [dbo].[Purchase].[PersonId] = [dbo].[Person].[Id]
GROUP BY 
	[dbo].[Person].[Id]

GO


