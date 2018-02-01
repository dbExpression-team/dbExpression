USE [MsSqlTest];
GO

declare @SQL as varchar(4000)
declare @msg as varchar(500)
declare @schemaname as varchar(500)
set @schemaname = 'dbo'

IF OBJECT_ID('tempdb..#dropcode') IS NOT NULL DROP TABLE #dropcode
CREATE TABLE #dropcode
(
   ID int identity(1,1)
  ,SQLstatement varchar(1000)
 )
 
-- removes all the foreign keys that reference a PK in the target schema
 SELECT @SQL =
  'select
       '' ALTER TABLE ''+SCHEMA_NAME(fk.schema_id)+''.''+OBJECT_NAME(fk.parent_object_id)+'' DROP CONSTRAINT ''+ fk.name
  FROM sys.foreign_keys fk
  join sys.tables t on t.object_id = fk.referenced_object_id
  where t.schema_id = schema_id(''' + @SchemaName+''')
    and fk.schema_id <> t.schema_id
  order by fk.name desc'
 
 INSERT INTO #dropcode
 EXEC (@SQL)
  
 -- drop all default constraints, check constraints and Foreign Keys
 SELECT @SQL =
 'SELECT
       '' ALTER TABLE ''+schema_name(t.schema_id)+''.''+OBJECT_NAME(fk.parent_object_id)+'' DROP CONSTRAINT ''+ fk.[Name]
  FROM sys.objects fk
  join sys.tables t on t.object_id = fk.parent_object_id
  where t.schema_id = schema_id(''' + @SchemaName+''')
   and fk.type IN (''D'', ''C'', ''F'')'
  
 INSERT INTO #dropcode
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
 
INSERT INTO #dropcode
EXEC (@SQL)
 
DECLARE @ID int, @statement varchar(1000)
DECLARE statement_cursor CURSOR
FOR SELECT SQLStatement
      FROM #dropcode
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


---------------------------------START THE BUILD ---------------------------------------------------------
USE [MsSqlTest]
GO
/****** Object:  Schema [sec]    Script Date: 12/14/2016 11:40:47 AM ******/
CREATE SCHEMA [sec]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 12/14/2016 11:40:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Person]    Script Date: 12/14/2016 11:40:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Person](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](20) NOT NULL,
	[LastName] [varchar](20) NOT NULL,
	[BirthDate] [datetime] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateUpdated] [datetime] NOT NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Person_Address]    Script Date: 12/14/2016 11:40:47 AM ******/
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
/****** Object:  Table [dbo].[Product]    Script Date: 12/14/2016 11:40:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](80) NOT NULL,
	[Description] [varchar](300) NULL,
	[Price] [decimal](12, 2) NOT NULL,
	[Quantity] [int] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateUpdated] [datetime] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Purchase]    Script Date: 12/14/2016 11:40:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Purchase](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PersonId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[PurchasePrice] [decimal](12, 2) NOT NULL,
	[PurchaseDate] [datetime] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
 CONSTRAINT [PK_Purchase] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TypeCode]    Script Date: 12/14/2016 11:40:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TypeCode](
	[Name] [varchar](50) NOT NULL,
	[Key] [varchar](100) NOT NULL,
	[Value] [int] NOT NULL,
	[FriendlyName] [varchar](120) NULL,
	[Description] [varchar](120) NULL,
 CONSTRAINT [PK_TypeCode] PRIMARY KEY CLUSTERED 
(
	[Name] ASC,
	[Value] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [sec].[Person]    Script Date: 12/14/2016 11:40:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [sec].[Person](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PersonId] [bigint] NOT NULL,
	[SSN] [char](9) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateUpdated] [datetime] NOT NULL,
 CONSTRAINT [PK_secPerson] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[PersonTotalPurchasesView]    Script Date: 12/14/2016 11:40:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[PersonTotalPurchasesView]
AS
SELECT        
	dbo.Person.Id, 
	SUM(dbo.Purchase.PurchasePrice) AS TotalPurchases
FROM            
dbo.Person INNER JOIN dbo.Purchase ON dbo.Purchase.PersonId = dbo.Person.Id
GROUP BY dbo.Person.Id

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
ALTER TABLE [dbo].[Purchase]  WITH CHECK ADD  CONSTRAINT [FK_Purchase_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[Purchase] CHECK CONSTRAINT [FK_Purchase_Product]
GO
EXEC sys.sp_addextendedproperty @name=N'htl', @value=N'type=AddressType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Address', @level2type=N'COLUMN',@level2name=N'AddressType'
GO
EXEC sys.sp_addextendedproperty @name=N'htl', @value=N'ignore' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TypeCode'
GO
