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
	[Id] INT IDENTITY(1,1) NOT NULL,
	[AddressType] INT NULL,
	[Line1] VARCHAR(50) NOT NULL,
	[Line2] VARCHAR(50) NULL,
	[City] VARCHAR(60) NOT NULL,
	[State] CHAR(2) NOT NULL,
	[Zip] VARCHAR(10) NOT NULL,
	[DateCreated] DATETIME NOT NULL,
	[DateUpdated] DATETIME NOT NULL,
	CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED ([Id])
)
GO

CREATE TABLE [dbo].[Person](
	[Id] INT IDENTITY(1,1) NOT NULL,
	[FirstName] VARCHAR(20) NOT NULL,
	[LastName] VARCHAR(20) NOT NULL,
	[BirthDate] DATETIME NULL,
	[GenderType] INT NOT NULL,
	[CreditLimit] INT NULL,
	[YearOfLastCreditLimitReview] INT NULL,
	[DateCreated] DATETIME NOT NULL,
	[DateUpdated] DATETIME NOT NULL,
	CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED ([Id]) 
)
GO

CREATE TABLE [dbo].[Person_Address](
	[Id] INT IDENTITY(1,1) NOT NULL,
	[PersonId] INT NOT NULL,
	[AddressId] INT NOT NULL,
	[DateCreated] DATETIME NOT NULL,
	CONSTRAINT [PK_Person_Address] PRIMARY KEY CLUSTERED ([Id]),
	CONSTRAINT [FK_Person_Address_Address] FOREIGN KEY([AddressId]) REFERENCES [dbo].[Address] ([Id]),
	CONSTRAINT [FK_Person_Address_Person] FOREIGN KEY([PersonId]) REFERENCES [dbo].[Person] ([Id])
)
GO

CREATE TABLE [dbo].[Product](
	[Id] INT IDENTITY(1,1) NOT NULL,
	[ProductCategoryType] INT NULL,
	[Name] VARCHAR(80) NOT NULL,
	[Description] NVARCHAR(2000) NULL,
	[ListPrice] MONEY NOT NULL,
	[Price] MONEY NOT NULL,
	[Quantity] INT NOT NULL,
	[Image] VARBINARY(MAX) NULL,
	[Height] DECIMAL(4, 1) NULL,
	[Width] DECIMAL(4, 1) NULL,
	[Depth] DECIMAL(4, 1) NULL,
	[Weight] DECIMAL(4, 1) NULL,
	[ShippingWeight] DECIMAL(4, 1) NOT NULL,
	[DateCreated] DATETIME NOT NULL,
	[DateUpdated] DATETIME NOT NULL,
	CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED ([Id]) 
)
GO

CREATE TABLE [dbo].[Purchase](
	[Id] INT IDENTITY(1,1) NOT NULL,
	[PersonId] INT NOT NULL,
	[TotalPurchaseAmount] MONEY NOT NULL,
	[PurchaseDate] DATETIME NOT NULL,
	[ShipDate] DATETIME NULL,
	[ExpectedDeliveryDate] DATETIME NULL,
	[TrackingIdentifier] UNIQUEIDENTIFIER NULL,
	[PaymentMethodType] VARCHAR(20) NOT NULL,
	[DateCreated] DATETIME NOT NULL,
	[DateUpdated] DATETIME NOT NULL,
	CONSTRAINT [PK_Purchase] PRIMARY KEY CLUSTERED ([Id]),
	CONSTRAINT [FK_Purchase_Person] FOREIGN KEY([PersonId]) REFERENCES [dbo].[Person] ([Id])
)
GO

CREATE TABLE [dbo].[PurchaseLine](
	[Id] INT IDENTITY(1,1) NOT NULL,
	[PurchaseId] INT NOT NULL,
	[ProductId] INT NOT NULL,
	[PurchasePrice] DECIMAL(12, 2) NOT NULL,
	[Quantity] INT NOT NULL,
	[DateCreated] DATETIME NOT NULL,
	[DateUpdated] DATETIME NOT NULL,
	CONSTRAINT [PK_PurchaseLine] PRIMARY KEY CLUSTERED ([Id]),
	CONSTRAINT [FK_PurchaseLine_Purchase] FOREIGN KEY([PurchaseId]) REFERENCES [dbo].[Purchase] ([Id]),
	CONSTRAINT [FK_PurchaseLine_Product] FOREIGN KEY([ProductId]) REFERENCES [dbo].[Product] ([Id])
)
GO

CREATE SCHEMA [sec]
GO

CREATE TABLE [sec].[Person](
	[Id] INT IDENTITY(1,1) NOT NULL,
	[SSN] CHAR(9) NOT NULL,
	[DateCreated] DATETIMEOFFSET NOT NULL,
	[DateUpdated] DATETIMEOFFSET NOT NULL,
	CONSTRAINT [PK_secPerson] PRIMARY KEY CLUSTERED ([Id])
)
GO

CREATE VIEW [dbo].[PersonTotalPurchasesView]
AS
SELECT        
	[dbo].[Person].[Id], 
	SUM([dbo].[Purchase].[TotalPurchaseAmount]) AS [TotalAmount],
	COUNT([dbo].[Purchase].[Id]) AS [TotalCount]
FROM            
	[dbo].[Person] 
	INNER JOIN [dbo].[Purchase] ON [dbo].[Purchase].[PersonId] = [dbo].[Person].[Id]
GROUP BY 
	[dbo].[Person].[Id]

GO


