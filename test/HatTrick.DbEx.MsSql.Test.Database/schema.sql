SET NOCOUNT ON;

USE [MsSqlDbExTest];
GO

DECLARE @SQL as varchar(4000)
DECLARE @SchemaName as varchar(500)
DECLARE @SchemaIndex as int
SET @SchemaIndex = 1

IF OBJECT_ID('tempdb..#Schemas') IS NOT NULL DROP TABLE #Schemas
CREATE TABLE #Schemas([Id] [int], [Name] [varchar](20));
INSERT INTO #Schemas([Id], [Name]) values (1, 'dbo');
INSERT INTO #Schemas([Id], [Name]) values (2, 'sec');

IF OBJECT_ID('tempdb..#DropObjects') IS NOT NULL DROP TABLE #DropObjects
CREATE TABLE #DropObjects
(
	[Id] [int] IDENTITY(1,1),
	[SQLstatement] [varchar](1000)
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
	[PaymentMethod] VARCHAR(20) NOT NULL,
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

EXEC sys.sp_addextendedproperty @name=N'htl', @value=N'type=AddressType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Address', @level2type=N'COLUMN',@level2name=N'AddressType'
GO
EXEC sys.sp_addextendedproperty @name=N'htl', @value=N'type=ProductCategoryType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Product', @level2type=N'COLUMN',@level2name=N'ProductCategoryType'
GO
EXEC sys.sp_addextendedproperty @name=N'htl', @value=N'type=GenderType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Person', @level2type=N'COLUMN',@level2name=N'GenderType'
GO