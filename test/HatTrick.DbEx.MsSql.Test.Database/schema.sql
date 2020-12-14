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
/****** Object:  Schema [sec]    Script Date: 12/13/2020 9:56:58 PM ******/
CREATE SCHEMA [sec]
GO
/****** Object:  Table [dbo].[Person]    Script Date: 12/13/2020 9:56:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](20) NOT NULL,
	[LastName] [varchar](20) NOT NULL,
	[BirthDate] [date] NULL,
	[GenderType] [int] NOT NULL,
	[CreditLimit] [int] NULL,
	[YearOfLastCreditLimitReview] [int] NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateUpdated] [datetime] NOT NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Purchase]    Script Date: 12/13/2020 9:56:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Purchase](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PersonId] [int] NOT NULL,
	[OrderNumber] [varchar](20) NOT NULL,
	[TotalPurchaseQuantity] [int] NOT NULL,
	[TotalPurchaseAmount] [money] NOT NULL,
	[PurchaseDate] [datetime] NOT NULL,
	[ShipDate] [datetime] NULL,
	[ExpectedDeliveryDate] [datetime] NULL,
	[TrackingIdentifier] [uniqueidentifier] NULL,
	[PaymentMethodType] [varchar](20) NOT NULL,
	[PaymentSourceType] [varchar](20) NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateUpdated] [datetime] NOT NULL,
 CONSTRAINT [PK_Purchase] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[PersonTotalPurchasesView]    Script Date: 12/13/2020 9:56:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  Table [dbo].[Address]    Script Date: 12/13/2020 9:56:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Person_Address]    Script Date: 12/13/2020 9:56:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person_Address](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PersonId] [int] NOT NULL,
	[AddressId] [int] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
 CONSTRAINT [PK_Person_Address] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 12/13/2020 9:56:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductCategoryType] [int] NULL,
	[Name] [varchar](80) NOT NULL,
	[Description] [nvarchar](2000) NULL,
	[ListPrice] [money] NOT NULL,
	[Price] [money] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Image] [varbinary](max) NULL,
	[Height] [decimal](4, 1) NULL,
	[Width] [decimal](4, 1) NULL,
	[Depth] [decimal](4, 1) NULL,
	[Weight] [decimal](4, 1) NULL,
	[ShippingWeight] [decimal](4, 1) NOT NULL,
	[ValidStartTimeOfDayForPurchase] [time](7) NULL,
	[ValidEndTimeOfDayForPurchase] [time](7) NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateUpdated] [datetime] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PurchaseLine]    Script Date: 12/13/2020 9:56:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseLine](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PurchaseId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[PurchasePrice] [decimal](12, 2) NOT NULL,
	[Quantity] [int] NOT NULL,
	[PurchaseTotal]  AS ([PurchasePrice]*[Quantity]),
	[DateCreated] [datetime] NOT NULL,
	[DateUpdated] [datetime] NOT NULL,
 CONSTRAINT [PK_PurchaseLine] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [sec].[Person]    Script Date: 12/13/2020 9:56:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sec].[Person](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SSN] [char](9) NOT NULL,
	[DateCreated] [datetimeoffset](7) NOT NULL,
	[DateUpdated] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_secPerson] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Address] ADD  CONSTRAINT [DF_Address_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[Address] ADD  CONSTRAINT [DF_Address_DateUpdated]  DEFAULT (getdate()) FOR [DateUpdated]
GO
ALTER TABLE [dbo].[Person] ADD  CONSTRAINT [DF_Person_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[Person] ADD  CONSTRAINT [DF_Person_DateUpdated]  DEFAULT (getdate()) FOR [DateUpdated]
GO
ALTER TABLE [dbo].[Person_Address] ADD  CONSTRAINT [DF_Person_Address_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_DateUpdated]  DEFAULT (getdate()) FOR [DateUpdated]
GO
ALTER TABLE [dbo].[Purchase] ADD  CONSTRAINT [DF_Purchase_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[Purchase] ADD  CONSTRAINT [DF_Purchase_DateUpdated]  DEFAULT (getdate()) FOR [DateUpdated]
GO
ALTER TABLE [dbo].[PurchaseLine] ADD  CONSTRAINT [DF_PurchaseLine_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[PurchaseLine] ADD  CONSTRAINT [DF_PurchaseLine_DateUpdated]  DEFAULT (getdate()) FOR [DateUpdated]
GO
ALTER TABLE [dbo].[Person_Address]  WITH CHECK ADD  CONSTRAINT [FK_Person_Address_Address] FOREIGN KEY([AddressId])
REFERENCES [dbo].[Address] ([Id])
GO
ALTER TABLE [dbo].[Person_Address] CHECK CONSTRAINT [FK_Person_Address_Address]
GO
ALTER TABLE [dbo].[Person_Address]  WITH CHECK ADD  CONSTRAINT [FK_Person_Address_Person] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([Id])
GO
ALTER TABLE [dbo].[Person_Address] CHECK CONSTRAINT [FK_Person_Address_Person]
GO
ALTER TABLE [dbo].[Purchase]  WITH CHECK ADD  CONSTRAINT [FK_Purchase_Person] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([Id])
GO
ALTER TABLE [dbo].[Purchase] CHECK CONSTRAINT [FK_Purchase_Person]
GO
ALTER TABLE [dbo].[PurchaseLine]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseLine_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[PurchaseLine] CHECK CONSTRAINT [FK_PurchaseLine_Product]
GO
ALTER TABLE [dbo].[PurchaseLine]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseLine_Purchase] FOREIGN KEY([PurchaseId])
REFERENCES [dbo].[Purchase] ([Id])
GO
ALTER TABLE [dbo].[PurchaseLine] CHECK CONSTRAINT [FK_PurchaseLine_Purchase]
GO
/****** Object:  Trigger [dbo].[TR_Address_DateUpdated]    Script Date: 12/13/2020 9:56:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[TR_Address_DateUpdated]
ON [dbo].[Address]
AFTER UPDATE 
AS 
UPDATE dbo.[Address] 
SET DateUpdated = GETDATE()
FROM inserted i
INNER JOIN dbo.[Address] a ON a.Id = i.Id
GO
ALTER TABLE [dbo].[Address] ENABLE TRIGGER [TR_Address_DateUpdated]
GO
/****** Object:  Trigger [dbo].[TR_Person_DateUpdated]    Script Date: 12/13/2020 9:56:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[TR_Person_DateUpdated]
ON [dbo].[Person]
AFTER UPDATE 
AS 
UPDATE dbo.[Person] 
SET DateUpdated = GETDATE()
FROM inserted i
INNER JOIN dbo.[Person] a ON a.Id = i.Id
GO
ALTER TABLE [dbo].[Person] ENABLE TRIGGER [TR_Person_DateUpdated]
GO
/****** Object:  Trigger [dbo].[TR_Product_DateUpdated]    Script Date: 12/13/2020 9:56:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[TR_Product_DateUpdated]
ON [dbo].[Product]
AFTER UPDATE 
AS 
UPDATE dbo.[Product] 
SET DateUpdated = GETDATE()
FROM inserted i
INNER JOIN dbo.[Product] a ON a.Id = i.Id
GO
ALTER TABLE [dbo].[Product] ENABLE TRIGGER [TR_Product_DateUpdated]
GO
/****** Object:  Trigger [dbo].[TR_Purchase_DateUpdated]    Script Date: 12/13/2020 9:56:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[TR_Purchase_DateUpdated]
ON [dbo].[Purchase]
AFTER UPDATE 
AS 
UPDATE dbo.[Purchase] 
SET DateUpdated = GETDATE()
FROM inserted i
INNER JOIN dbo.[Purchase] a ON a.Id = i.Id
GO
ALTER TABLE [dbo].[Purchase] ENABLE TRIGGER [TR_Purchase_DateUpdated]
GO
/****** Object:  Trigger [dbo].[TR_PurchaseLine_DateUpdated]    Script Date: 12/13/2020 9:56:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[TR_PurchaseLine_DateUpdated]
ON [dbo].[PurchaseLine]
AFTER UPDATE 
AS 
UPDATE dbo.[PurchaseLine] 
SET DateUpdated = GETDATE()
FROM inserted i
INNER JOIN dbo.[PurchaseLine] a ON a.Id = i.Id
GO
ALTER TABLE [dbo].[PurchaseLine] ENABLE TRIGGER [TR_PurchaseLine_DateUpdated]
GO
/****** Object:  Trigger [sec].[TR_Person_DateUpdated]    Script Date: 12/13/2020 9:56:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [sec].[TR_Person_DateUpdated]
ON [sec].[Person]
AFTER UPDATE 
AS 
UPDATE sec.[Person] 
SET DateUpdated = GETDATE()
FROM inserted i
INNER JOIN sec.[Person] a ON a.Id = i.Id
GO
ALTER TABLE [sec].[Person] ENABLE TRIGGER [TR_Person_DateUpdated]
GO
