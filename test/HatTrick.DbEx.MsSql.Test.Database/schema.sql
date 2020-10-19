SET NOCOUNT ON;

USE [MsSqlDbExTest];
GO

DECLARE @SQL as varchar(4000)
DECLARE @SchemaName as varchar(500)
DECLARE @SchemaIndex as int
SET @SchemaIndex = 1

IF OBJECT_ID('tempdb..#Schemas') IS NOT NULL DROP TABLE #Schemas
CREATE TABLE #Schemas([Id] INT, [Name] VARCHAR(20));
INSERT INTO #Schemas([Id], [Name]) values (1, 'dbo');
INSERT INTO #Schemas([Id], [Name]) values (2, 'sec');

IF OBJECT_ID('tempdb..#DropObjects') IS NOT NULL DROP TABLE #DropObjects
CREATE TABLE #DropObjects
(
	[Id] INT IDENTITY(1,1),
	[SQLstatement] VARCHAR(1000)
 )
 
 WHILE (SELECT [Id] FROM #Schemas WHERE [Id] = @SchemaIndex) IS NOT NULL
 BEGIN
	SELECT @SchemaName = [Name] FROM #Schemas WHERE [Id] = @SchemaIndex;

	-- removes all the foreign keys that reference a PK in the target schema
	 SELECT @SQL =
	  'select
		   '' ALTER TABLE ''+SCHEMA_NAME(fk.schema_id)+''.''+OBJECT_NAME(fk.parent_object_id)+'' DROP CONSTRAINT ''+ fk.name
	  FROM sys.foreign_keys fk
	  join sys.tables t on t.object_id = fk.referenced_object_id
	  where t.schema_id = schema_id(''' + @SchemaName+''')
		and fk.schema_id <> t.schema_id
	  order by fk.name desc'
 
	 INSERT INTO #DropObjects
	 EXEC (@SQL)
  
	 -- drop all default constraints, check constraints and Foreign Keys
	 SELECT @SQL =
	 'SELECT
		   '' ALTER TABLE ''+schema_name(t.schema_id)+''.''+OBJECT_NAME(fk.parent_object_id)+'' DROP CONSTRAINT ''+ fk.[Name]
	  FROM sys.objects fk
	  join sys.tables t on t.object_id = fk.parent_object_id
	  where t.schema_id = schema_id(''' + @SchemaName+''')
	   and fk.type IN (''D'', ''C'', ''F'')'
  
	 INSERT INTO #DropObjects
	 EXEC (@SQL)
 
	 -- drop all other objects in order   
	 SELECT @SQL =  
	 'SELECT
		  CASE WHEN SO.type=''PK'' THEN '' ALTER TABLE ''+SCHEMA_NAME(SO.schema_id)+''.''+OBJECT_NAME(SO.parent_object_id)+'' DROP CONSTRAINT ''+ SO.name
			   WHEN SO.type=''U'' THEN '' DROP TABLE ''+SCHEMA_NAME(SO.schema_id)+''.''+ SO.[Name]
			   WHEN SO.type=''V'' THEN '' DROP VIEW  ''+SCHEMA_NAME(SO.schema_id)+''.''+ SO.[Name]
			   WHEN SO.type=''P'' THEN '' DROP PROCEDURE  ''+SCHEMA_NAME(SO.schema_id)+''.''+ SO.[Name]         
			   WHEN SO.type=''TR'' THEN ''  DROP TRIGGER  ''+SCHEMA_NAME(SO.schema_id)+''.''+ SO.[Name]
			   WHEN SO.type  IN (''FN'', ''TF'',''IF'',''FS'',''FT'') THEN '' DROP FUNCTION  ''+SCHEMA_NAME(SO.schema_id)+''.''+ SO.[Name]
		   END
	FROM SYS.OBJECTS SO
	WHERE SO.schema_id = schema_id('''+ @SchemaName +''')
	  AND SO.type IN (''PK'', ''FN'', ''TF'', ''TR'', ''V'', ''U'', ''P'')
	ORDER BY CASE WHEN type = ''PK'' THEN 1
				  WHEN type in (''FN'', ''TF'', ''P'',''IF'',''FS'',''FT'') THEN 2
				  WHEN type = ''TR'' THEN 3
				  WHEN type = ''V'' THEN 4
				  WHEN type = ''U'' THEN 5
				ELSE 6
			  END'
 
	INSERT INTO #DropObjects
	EXEC (@SQL)

	IF @SchemaName != 'dbo'
		INSERT INTO #DropObjects SELECT 'DROP SCHEMA [' + @SchemaName + ']';

	SET @SchemaIndex = @SchemaIndex + 1
END

DECLARE @ID int, @statement varchar(1000)
DECLARE statement_cursor CURSOR
FOR SELECT SQLStatement
      FROM #DropObjects
  ORDER BY ID ASC
    
 OPEN statement_cursor
 FETCH statement_cursor INTO @statement
 WHILE (@@FETCH_STATUS = 0)
 BEGIN
 
	PRINT (@statement)
    EXEC(@statement)
 
  
 FETCH statement_cursor INTO @statement    
END
 
CLOSE statement_cursor
DEALLOCATE statement_cursor

DROP TABLE #Schemas
DROP TABLE #DropObjects
---------------------------------START THE BUILD ---------------------------------------------------------
USE [MsSqlDbExTest]
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
	[BirthDate] DATE NULL,
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
	[ValidStartTimeOfDayForPurchase] TIME NULL,
	[ValidEndTimeOfDayForPurchase] TIME NULL,
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
	[PaymentSourceType] VARCHAR(20) NULL,
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