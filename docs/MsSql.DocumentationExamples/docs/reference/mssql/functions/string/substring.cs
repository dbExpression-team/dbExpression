using DbEx.DataService;
using DbEx.dboData;
using DbEx.dboDataService;
using DbEx.secDataService;
using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder.Alias;
using Microsoft.Extensions.Logging;

namespace MsSql.DocumentationExamples.Reference.Mssql.Functions.String
{
    ///<summary>Code examples from https://dbexpression.com/docs/reference/mssql/functions/string/substring</summary>
    public class Substring : IDocumentationExamples
    {
        private readonly ILogger<Substring> logger;

        public Substring(ILogger<Substring> logger)
        {
            this.logger = logger;
        }

        public void ExecuteExamples()
        {
            Substring_line_no_92();
            Substring_line_no_110();
            Substring_line_no_131();
            Substring_line_no_166();
            Substring_line_no_195();
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/string/substring at line 92</summary>
        private void Substring_line_no_92()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/string/substring at line 92");

            IEnumerable<string> result = db.SelectMany(
                    db.fx.Substring(dbo.Product.Name, 1, 2)
                )
                .From(dbo.Product)
                .Execute();

            /*
            exec sp_executesql N'SELECT
            	SUBSTRING([dbo].[Product].[Name], @P1, @P2)
            FROM
            	[dbo].[Product];',N'@P1 int,@P2 int',@P1=1,@P2=2
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/string/substring at line 110</summary>
        private void Substring_line_no_110()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/string/substring at line 110");

            IEnumerable<int> result = db.SelectMany(
            		dbo.Product.Id
            	)
            	.From(dbo.Product)
            	.Where(db.fx.Substring(dbo.Product.Name, 2, 1) == " ")
            	.Execute();

            /*
            exec sp_executesql N'SELECT
            	[dbo].[Product].[Id]
            FROM
            	[dbo].[Product]
            WHERE
            	SUBSTRING([dbo].[Product].[Name], @P1, @P2) = @P3;',N'@P1 int,@P2 int,@P3 char(1)',@P1=2,@P2=1,@P3=' '
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/string/substring at line 131</summary>
        private void Substring_line_no_131()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/string/substring at line 131");

            IEnumerable<Product> products = db.SelectMany<Product>()
            	.From(dbo.Product)
            	.OrderBy(db.fx.Substring(dbo.Product.Name, 2, db.fx.Len(dbo.Product.Name) - 1))
            	.Execute();

            /*
            exec sp_executesql N'SELECT
            	[dbo].[Product].[Id],
            	[dbo].[Product].[ProductCategoryType],
            	[dbo].[Product].[Name],
            	[dbo].[Product].[Description],
            	[dbo].[Product].[ListPrice],
            	[dbo].[Product].[Price],
            	[dbo].[Product].[Quantity],
            	[dbo].[Product].[Image],
            	[dbo].[Product].[Height],
            	[dbo].[Product].[Width],
            	[dbo].[Product].[Depth],
            	[dbo].[Product].[Weight],
            	[dbo].[Product].[ShippingWeight],
            	[dbo].[Product].[ValidStartTimeOfDayForPurchase],
            	[dbo].[Product].[ValidEndTimeOfDayForPurchase],
            	[dbo].[Product].[DateCreated],
            	[dbo].[Product].[DateUpdated]
            FROM
            	[dbo].[Product]
            ORDER BY
            	SUBSTRING([dbo].[Product].[Name], @P1, (LEN([dbo].[Product].[Name]) - @P2)) ASC;',N'@P1 bigint,@P2 int',@P1=2,@P2=1
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/string/substring at line 166</summary>
        private void Substring_line_no_166()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/string/substring at line 166");

            IEnumerable<dynamic> values = db.SelectMany(
                    db.fx.Count().As("count"),
                    dbo.Address.AddressType,
                    db.fx.Substring(dbo.Address.City, 2, 1).As("ignore_first_character")
                )
                .From(dbo.Address)
                .GroupBy(
                    dbo.Address.AddressType,
                    db.fx.Substring(dbo.Address.City, 2, 1)
                )
                .Execute();

            /*
            exec sp_executesql N'SELECT
            	COUNT(@P1) AS [count],
            	[dbo].[Address].[AddressType],
            	SUBSTRING([dbo].[Address].[City], @P2, @P3) AS [ignore_first_character]
            FROM
            	[dbo].[Address]
            GROUP BY
            	[dbo].[Address].[AddressType],
            	SUBSTRING([dbo].[Address].[City], @P2, @P3);',N'@P1 nchar(1),@P2 int,@P3 int',@P1=N'*',@P2=1,@P3=1
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/string/substring at line 195</summary>
        private void Substring_line_no_195()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/string/substring at line 195");

            IEnumerable<dynamic> values = db.SelectMany(
                    db.fx.Count().As("count"),
                    dbo.Address.AddressType
                )
                .From(dbo.Address)
                .GroupBy(
                    dbo.Address.AddressType,
                    db.fx.Substring(dbo.Address.City, 1, 1)
                )
                .Having(
                    db.fx.Substring(dbo.Address.City, 1, 1) > "M"
                )
                .Execute();

            /*
            exec sp_executesql N'SELECT
            	COUNT(@P1) AS [count],
            	[dbo].[Address].[AddressType]
            FROM
            	[dbo].[Address]
            GROUP BY
            	[dbo].[Address].[AddressType],
            	SUBSTRING([dbo].[Address].[City], @P2, @P2)
            HAVING
            	SUBSTRING([dbo].[Address].[City], @P2, @P2) > @P4;',N'@P1 nchar(1),@P2 int,@P3 int,@P4 char(1)',@P1=N'*',@P2=1,@P3=1,@P4='M'
            */
        }

    }
}
