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

ALTER DATABASE [MsSqlDbExTest] SET RECOVERY SIMPLE
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
	[DateCreated] DATETIME NOT NULL CONSTRAINT [DF_Address_DateCreated] DEFAULT (getdate()),
	[DateUpdated] DATETIME NOT NULL CONSTRAINT [DF_Address_DateUpdated] DEFAULT (getdate()),
	CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED ([Id])
)
GO

CREATE TRIGGER [dbo].[TR_Address_DateUpdated]
	ON [dbo].[Address]
	AFTER UPDATE 
	AS 
	IF NOT UPDATE([DateUpdated])
		UPDATE [dbo].[Address] 
		SET [DateUpdated] = GETDATE()
		FROM inserted i
		INNER JOIN [dbo].[Address] a ON a.Id = i.Id
GO

CREATE TABLE [dbo].[Person](
	[Id] INT IDENTITY(1,1) NOT NULL,
	[FirstName] VARCHAR(20) NOT NULL,
	[LastName] VARCHAR(20) NOT NULL,
	[BirthDate] DATE NULL,
	[GenderType] INT NOT NULL,
	[CreditLimit] INT NULL,
	[YearOfLastCreditLimitReview] INT NULL,
	[RegistrationDate] DATETIMEOFFSET NOT NULL CONSTRAINT [DF_Person_RegistrationDate] DEFAULT (sysdatetimeoffset()),
	[LastLoginDate] DATETIMEOFFSET NULL,
	[DateCreated] DATETIME NOT NULL CONSTRAINT [DF_Person_DateCreated] DEFAULT (getdate()),
	[DateUpdated] DATETIME NOT NULL CONSTRAINT [DF_Person_DateUpdated] DEFAULT (getdate()),
	CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED ([Id]) 
)
GO

CREATE TRIGGER [dbo].[TR_Person_DateUpdated]
	ON [dbo].[Person]
	AFTER UPDATE 
	AS 
	IF NOT UPDATE([DateUpdated])
		UPDATE [dbo].[Person] 
		SET [DateUpdated] = GETDATE()
		FROM inserted i
		INNER JOIN [dbo].[Person] a ON a.Id = i.Id
GO

CREATE TABLE [dbo].[Person_Address](
	[Id] INT IDENTITY(1,1) NOT NULL,
	[PersonId] INT NOT NULL,
	[AddressId] INT NOT NULL,
	[DateCreated] DATETIME NOT NULL CONSTRAINT [DF_Person_Address_DateCreated] DEFAULT (getdate()),
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
	[ValidStartTimeOfDayForPurchase] TIME NULL,
	[ValidEndTimeOfDayForPurchase] TIME NULL,
	[DateCreated] DATETIME NOT NULL CONSTRAINT [DF_Product_DateCreated] DEFAULT (getdate()),
	[DateUpdated] DATETIME NOT NULL CONSTRAINT [DF_Product_DateUpdated] DEFAULT (getdate()),
	CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED ([Id]) 
)
GO

CREATE TRIGGER [dbo].[TR_Product_DateUpdated]
	ON [dbo].[Product]
	AFTER UPDATE 
	AS 
	IF NOT UPDATE([DateUpdated])
		UPDATE [dbo].[Product] 
		SET [DateUpdated] = GETDATE()
		FROM inserted i
		INNER JOIN [dbo].[Product] a ON a.Id = i.Id
GO

CREATE TABLE [dbo].[Purchase](
	[Id] INT IDENTITY(1,1) NOT NULL,
	[PersonId] INT NOT NULL,
	[OrderNumber] VARCHAR(20) NOT NULL,
	[TotalPurchaseQuantity] INT NOT NULL,
	[TotalPurchaseAmount] MONEY NOT NULL,
	[PurchaseDate] DATETIME NOT NULL,
	[ShipDate] DATETIME NULL,
	[ExpectedDeliveryDate] DATETIME NULL,
	[TrackingIdentifier] UNIQUEIDENTIFIER NULL,
	[PaymentMethodType] VARCHAR(20) NOT NULL,
	[PaymentSourceType] VARCHAR(20) NULL,
	[DateCreated] DATETIME NOT NULL CONSTRAINT [DF_Purchase_DateCreated] DEFAULT (getdate()),
	[DateUpdated] DATETIME NOT NULL CONSTRAINT [DF_Purchase_DateUpdated] DEFAULT (getdate()),
	CONSTRAINT [PK_Purchase] PRIMARY KEY CLUSTERED ([Id]),
	CONSTRAINT [FK_Purchase_Person] FOREIGN KEY([PersonId]) REFERENCES [dbo].[Person] ([Id])
)
GO

CREATE TRIGGER [dbo].[TR_Purchase_DateUpdated]
	ON [dbo].[Purchase]
	AFTER UPDATE 
	AS 
	IF NOT UPDATE([DateUpdated])
		UPDATE [dbo].[Purchase] 
		SET [DateUpdated] = GETDATE()
		FROM inserted i
		INNER JOIN [dbo].[Purchase] a ON a.Id = i.Id
GO

CREATE TABLE [dbo].[PurchaseLine](
	[Id] INT IDENTITY(1,1) NOT NULL,
	[PurchaseId] INT NOT NULL,
	[ProductId] INT NOT NULL,
	[PurchasePrice] DECIMAL(12, 2) NOT NULL,
	[Quantity] INT NOT NULL,
	[DateCreated] DATETIME NOT NULL CONSTRAINT [DF_PurchaseLine_DateCreated] DEFAULT (getdate()),
	[DateUpdated] DATETIME NOT NULL CONSTRAINT [DF_PurchaseLine_DateUpdated] DEFAULT (getdate()),
	CONSTRAINT [PK_PurchaseLine] PRIMARY KEY CLUSTERED ([Id]),
	CONSTRAINT [FK_PurchaseLine_Purchase] FOREIGN KEY([PurchaseId]) REFERENCES [dbo].[Purchase] ([Id]),
	CONSTRAINT [FK_PurchaseLine_Product] FOREIGN KEY([ProductId]) REFERENCES [dbo].[Product] ([Id])
)
GO

CREATE TRIGGER [dbo].[TR_PurchaseLine_DateUpdated]
	ON [dbo].[PurchaseLine]
	AFTER UPDATE 
	AS 
	IF NOT UPDATE([DateUpdated])
		UPDATE [dbo].[PurchaseLine] 
		SET [DateUpdated] = GETDATE()
		FROM inserted i
		INNER JOIN [dbo].[PurchaseLine] a ON a.Id = i.Id
GO

CREATE TABLE [dbo].[AccessAuditLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PersonId] INT NOT NULL,
	[AccessResult] INT NOT NULL,
	[DateCreated] DATETIME NOT NULL CONSTRAINT [DF_AccessAuditLog_DateCreated] DEFAULT (getdate()),
	CONSTRAINT [PK_AccessAuditLog] PRIMARY KEY CLUSTERED ([Id])
)
GO

CREATE SCHEMA [unit_test]
GO

CREATE TABLE [unit_test].[ExpressionElementType](
	[Id] INT NOT NULL,
	[Boolean] BIT NOT NULL,
	[NullableBoolean] BIT NULL,
	[Byte] TINYINT NOT NULL,
	[NullableByte] TINYINT NULL,
	[ByteArray] VARBINARY(MAX) NOT NULL,
	[NullableByteArray] VARBINARY(MAX) NULL,
	[DateTime] DATETIME2 NOT NULL,
	[NullableDateTime] DATETIME2 NULL,
	[DateTimeOffset] DATETIMEOFFSET NOT NULL,
	[NullableDateTimeOffset] DATETIMEOFFSET NULL,
	[Decimal] DECIMAL(5, 4) NOT NULL,
	[NullableDecimal] DECIMAL(5, 4) NULL,
	[Double] MONEY NOT NULL,
	[NullableDouble] MONEY NULL,
	[Guid] UNIQUEIDENTIFIER NOT NULL,
	[NullableGuid] UNIQUEIDENTIFIER NULL,
	[Int16] SMALLINT NOT NULL,
	[NullableInt16] SMALLINT NULL,
	[Int32] INT NOT NULL,
	[NullableInt32] INT NULL,
	[Int64] BIGINT NOT NULL,
	[NullableInt64] BIGINT NULL,
	[Single] REAL NOT NULL,
	[NullableSingle] REAL NULL,	
	[String] VARCHAR(20) NOT NULL,
	[NullableString] VARCHAR(20) NULL,	
	[TimeSpan] TIME NOT NULL,
	[NullableTimeSpan] TIME NULL
)
GO

CREATE TABLE [unit_test].[identifier] (
	[_identifier] VARCHAR(20) NULL,
	[__identifier] VARCHAR(20) NULL,
	[name] VARCHAR(20) NULL,
	[_name] VARCHAR(20) NULL,
	[__name] VARCHAR(20) NULL,
	[schema] VARCHAR(20) NULL,
	[_schema] VARCHAR(20) NULL,
	[__schema] VARCHAR(20) NULL,
	[alias] VARCHAR(20) NULL,
	[_alias] VARCHAR(20) NULL,
	[__alias] VARCHAR(20) NULL,
	[entity] VARCHAR(20) NULL,
	[_entity] VARCHAR(20) NULL,
	[__entity] VARCHAR(20) NULL
)
GO

CREATE TABLE [unit_test].[entity] (
	[identifier] VARCHAR(20) NULL,
	[_identifier] VARCHAR(20) NULL,
	[__identifier] VARCHAR(20) NULL,
	[name] VARCHAR(20) NULL,
	[_name] VARCHAR(20) NULL,
	[__name] VARCHAR(20) NULL,
	[schema] VARCHAR(20) NULL,
	[_schema] VARCHAR(20) NULL,
	[__schema] VARCHAR(20) NULL,
	[alias] VARCHAR(20) NULL,
	[_alias] VARCHAR(20) NULL,
	[__alias] VARCHAR(20) NULL,
	[_entity] VARCHAR(20) NULL,
	[__entity] VARCHAR(20) NULL
)
GO

CREATE TABLE [unit_test].[name] (
	[identifier] VARCHAR(20) NULL,
	[_identifier] VARCHAR(20) NULL,
	[__identifier] VARCHAR(20) NULL,
	[_name] VARCHAR(20) NULL,
	[__name] VARCHAR(20) NULL,
	[schema] VARCHAR(20) NULL,
	[_schema] VARCHAR(20) NULL,
	[__schema] VARCHAR(20) NULL,
	[alias] VARCHAR(20) NULL,
	[_alias] VARCHAR(20) NULL,
	[__alias] VARCHAR(20) NULL,
	[entity] VARCHAR(20) NULL,
	[_entity] VARCHAR(20) NULL,
	[__entity] VARCHAR(20) NULL
)
GO

CREATE TABLE [unit_test].[schema] (
	[identifier] VARCHAR(20) NULL,
	[_identifier] VARCHAR(20) NULL,
	[__identifier] VARCHAR(20) NULL,
	[name] VARCHAR(20) NULL,
	[_name] VARCHAR(20) NULL,
	[__name] VARCHAR(20) NULL,
	[_schema] VARCHAR(20) NULL,
	[__schema] VARCHAR(20) NULL,
	[alias] VARCHAR(20) NULL,
	[_alias] VARCHAR(20) NULL,
	[__alias] VARCHAR(20) NULL,
	[entity] VARCHAR(20) NULL,
	[_entity] VARCHAR(20) NULL,
	[__entity] VARCHAR(20) NULL
)
GO

CREATE TABLE [unit_test].[alias] (
	[identifier] VARCHAR(20) NULL,
	[_identifier] VARCHAR(20) NULL,
	[__identifier] VARCHAR(20) NULL,
	[name] VARCHAR(20) NULL,
	[_name] VARCHAR(20) NULL,
	[__name] VARCHAR(20) NULL,
	[schema] VARCHAR(20) NULL,
	[_schema] VARCHAR(20) NULL,
	[__schema] VARCHAR(20) NULL,
	[_alias] VARCHAR(20) NULL,
	[__alias] VARCHAR(20) NULL,
	[entity] VARCHAR(20) NULL,
	[_entity] VARCHAR(20) NULL,
	[__entity] VARCHAR(20) NULL
)
GO

CREATE SCHEMA [sec]
GO

CREATE TABLE [sec].[Person](
	[Id] INT NOT NULL,
	[SSN] CHAR(11) NOT NULL,
	[DateCreated] DATETIME NOT NULL CONSTRAINT [DF_Person_DateCreated] DEFAULT (getdate()),
	[DateUpdated] DATETIME NOT NULL CONSTRAINT [DF_Person_DateUpdated] DEFAULT (getdate()),
	CONSTRAINT [PK_secPerson] PRIMARY KEY CLUSTERED ([Id])
)
GO

CREATE TRIGGER [sec].[TR_Person_DateUpdated]
	ON [sec].[Person]
	AFTER UPDATE 
	AS 
	IF NOT UPDATE([DateUpdated])
		UPDATE [sec].[Person] 
		SET [DateUpdated] = GETDATE()
		FROM inserted i
		INNER JOIN [sec].[Person] a ON a.Id = i.Id
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

CREATE PROCEDURE [dbo].[SelectPersonId_As_ScalarValue_With_Input_And_Default_Value]
	@P1 INT NULL = 3
AS
	SELECT 
		[dbo].[Person].[Id]
	FROM 
		[dbo].[Person]
	WHERE 
		[dbo].[Person].[Id] = @P1;
GO

CREATE PROCEDURE [dbo].[SelectPerson_As_Dynamic_With_Input]
	@P1 INT NULL
AS
	SELECT 
		[dbo].[Person].[Id]
		,[dbo].[Person].[FirstName]
		,[dbo].[Person].[LastName]
		,[dbo].[Person].[BirthDate]
		,[dbo].[Person].[GenderType]
		,[dbo].[Person].[CreditLimit]
		,[dbo].[Person].[YearOfLastCreditLimitReview]
		,[dbo].[Person].[RegistrationDate]
		,[dbo].[Person].[LastLoginDate]
		,[dbo].[Person].[DateCreated]
		,[dbo].[Person].[DateUpdated]
	FROM 
		[dbo].[Person]
	WHERE 
		[dbo].[Person].[Id] = @P1;
GO

CREATE PROCEDURE [dbo].[SelectPerson_As_DynamicList_With_Input]
	@P1 INT NULL 
AS
	SELECT 
		[dbo].[Person].[Id]
		,[dbo].[Person].[FirstName]
		,[dbo].[Person].[LastName]
		,[dbo].[Person].[BirthDate]
		,[dbo].[Person].[GenderType]
		,[dbo].[Person].[CreditLimit]
		,[dbo].[Person].[YearOfLastCreditLimitReview]
		,[dbo].[Person].[RegistrationDate]
		,[dbo].[Person].[LastLoginDate]
		,[dbo].[Person].[DateCreated]
		,[dbo].[Person].[DateUpdated]
	FROM 
		[dbo].[Person]
	WHERE 
		[dbo].[Person].[Id] > @P1;
GO

CREATE PROCEDURE [dbo].[SelectPersonId_As_ScalarValue_With_Input]
	@P1 INT NULL
AS
	SELECT 
		[dbo].[Person].[Id]
	FROM 
		[dbo].[Person]
	WHERE 
		[dbo].[Person].[Id] = @P1;
GO

CREATE PROCEDURE [dbo].[SelectPersonId_As_ScalarValueList_With_Input]
	@P1 INT NULL
AS
	SELECT 
		[dbo].[Person].[Id]
	FROM 
		[dbo].[Person]
	WHERE 
		[dbo].[Person].[Id] > @P1;
GO

CREATE PROCEDURE [dbo].[SelectPerson_As_Dynamic_With_Input_And_Output]
	@P1 INT,
	@Count INT OUTPUT
AS
	SELECT 
		[dbo].[Person].[Id]
		,[dbo].[Person].[FirstName]
		,[dbo].[Person].[LastName]
		,[dbo].[Person].[BirthDate]
		,[dbo].[Person].[GenderType]
		,[dbo].[Person].[CreditLimit]
		,[dbo].[Person].[YearOfLastCreditLimitReview]
		,[dbo].[Person].[RegistrationDate]
		,[dbo].[Person].[LastLoginDate]
		,[dbo].[Person].[DateCreated]
		,[dbo].[Person].[DateUpdated]
	FROM 
		[dbo].[Person]
	WHERE 
		[dbo].[Person].[Id] = @P1;

	SELECT @Count = 1;
GO

CREATE PROCEDURE [dbo].[SelectPerson_As_DynamicList_With_Input_And_Output]
	@P1 INT,
	@Count INT OUTPUT
AS
	SELECT 
		[dbo].[Person].[Id]
		,[dbo].[Person].[FirstName]
		,[dbo].[Person].[LastName]
		,[dbo].[Person].[BirthDate]
		,[dbo].[Person].[GenderType]
		,[dbo].[Person].[CreditLimit]
		,[dbo].[Person].[YearOfLastCreditLimitReview]
		,[dbo].[Person].[RegistrationDate]
		,[dbo].[Person].[LastLoginDate]
		,[dbo].[Person].[DateCreated]
		,[dbo].[Person].[DateUpdated]
	FROM 
		[dbo].[Person]
	WHERE 
		[dbo].[Person].[Id] > @P1;

	SELECT 
		@Count = COUNT(*) 
	FROM 
		[dbo].[Person]
	WHERE 
		[dbo].[Person].[Id] > @P1;
GO

CREATE PROCEDURE [dbo].[SelectPersonId_As_ScalarValue_With_Input_And_Output]
	@P1 INT NULL,
	@Count INT OUTPUT
AS
	SELECT 
		[Id]
	FROM 
		[dbo].[Person]
	WHERE 
		[dbo].[Person].[Id] = @P1;

	SELECT 
		@Count = COUNT(*) 
	FROM 
		[dbo].[Person]
	WHERE 
		[dbo].[Person].[Id] = @P1;
GO

CREATE PROCEDURE [dbo].[SelectPersonId_As_ScalarValueList_With_Input_And_Output]
	@P1 INT NULL,
	@Count INT OUTPUT
AS
	SELECT 
		[Id]
	FROM 
		[dbo].[Person]
	WHERE 
		[dbo].[Person].[Id] > @P1;

	SELECT 
		@Count = COUNT(*) 
	FROM 
		[dbo].[Person]
	WHERE 
		[dbo].[Person].[Id] > @P1;
GO

CREATE PROCEDURE [dbo].[SelectPerson_As_Dynamic_With_Input_And_InputOutput]
	@P1 INT,
	@CreditLimit INT OUTPUT
AS
	SELECT 
		[dbo].[Person].[Id]
		,[dbo].[Person].[FirstName]
		,[dbo].[Person].[LastName]
		,[dbo].[Person].[BirthDate]
		,[dbo].[Person].[GenderType]
		,[dbo].[Person].[CreditLimit]
		,[dbo].[Person].[YearOfLastCreditLimitReview]
		,[dbo].[Person].[RegistrationDate]
		,[dbo].[Person].[LastLoginDate]
		,[dbo].[Person].[DateCreated]
		,[dbo].[Person].[DateUpdated]
	FROM 
		[dbo].[Person]
	WHERE 
		[dbo].[Person].[Id] = @P1
		AND
		[dbo].[Person].[CreditLimit] = @CreditLimit;

	SELECT 
		@CreditLimit = [dbo].[Person].[CreditLimit] * 2
	FROM 
		[dbo].[Person]
	WHERE 
		[dbo].[Person].[Id] = @P1
		AND
		[dbo].[Person].[CreditLimit] = @CreditLimit;
GO

CREATE PROCEDURE [dbo].[SelectPerson_As_DynamicList_With_Input_And_InputOutput]
	@P1 INT,
	@CreditLimit INT OUTPUT
AS
	SELECT 
		[dbo].[Person].[Id]
		,[dbo].[Person].[FirstName]
		,[dbo].[Person].[LastName]
		,[dbo].[Person].[BirthDate]
		,[dbo].[Person].[GenderType]
		,[dbo].[Person].[CreditLimit]
		,[dbo].[Person].[YearOfLastCreditLimitReview]
		,[dbo].[Person].[RegistrationDate]
		,[dbo].[Person].[LastLoginDate]
		,[dbo].[Person].[DateCreated]
		,[dbo].[Person].[DateUpdated]
	FROM 
		[dbo].[Person]
	WHERE 
		[dbo].[Person].[Id] >= @P1
		AND
		[dbo].[Person].[CreditLimit] = @CreditLimit;

	SELECT 
		@CreditLimit = [dbo].[Person].[CreditLimit] * 2
	FROM 
		[dbo].[Person]
	WHERE 
		[dbo].[Person].[Id] = @P1
		AND
		[dbo].[Person].[CreditLimit] = @CreditLimit;
GO

CREATE PROCEDURE [dbo].[SelectPersonId_As_ScalarValue_With_Input_And_InputOutput]
	@P1 INT,
	@CreditLimit INT OUTPUT
AS
	SELECT 
		[Id]
	FROM 
		[dbo].[Person]
	WHERE 
		[dbo].[Person].[Id] = @P1
		AND
		[dbo].[Person].[CreditLimit] = @CreditLimit;

	SELECT 
		@CreditLimit = [dbo].[Person].[CreditLimit] * 2
	FROM 
		[dbo].[Person]
	WHERE 
		[dbo].[Person].[Id] = @P1
		AND
		[dbo].[Person].[CreditLimit] = @CreditLimit;
GO


CREATE PROCEDURE [dbo].[SelectPersonId_As_ScalarValueList_With_Input_And_InputOutput]
	@P1 INT,
	@CreditLimit INT OUTPUT
AS
	SELECT 
		[Id]
	FROM 
		[dbo].[Person]
	WHERE 
		[dbo].[Person].[Id] >= @P1
		AND
		[dbo].[Person].[CreditLimit] = @CreditLimit;

	SELECT 
		@CreditLimit = [dbo].[Person].[CreditLimit] * 2
	FROM 
		[dbo].[Person]
	WHERE 
		[dbo].[Person].[Id] = @P1;
GO

CREATE PROCEDURE [dbo].[UpdatePersonCreditLimit_With_Inputs]
	@P1 INT,
	@CreditLimit INT
AS
	UPDATE 
		[dbo].[Person]
	SET
		[dbo].[Person].[CreditLimit] = @CreditLimit
	WHERE 
		[dbo].[Person].[Id] = @P1;
GO

