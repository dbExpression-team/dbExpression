using DocumentationExamples.DataService;
using DocumentationExamples.dboData;
using DocumentationExamples.dboDataService;
using DocumentationExamples.secDataService;
using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder.Alias;
using Microsoft.Extensions.Logging;

namespace DocumentationExamples.Reference.Mssql.Functions.String
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
                SUBSTRING([_t0].[Name], @P1, @P2)
            FROM
                [dbo].[Product] AS [_t0];',N'@P1 int,@P2 int',@P1=1,@P2=2
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
                [_t0].[Id]
            FROM
                [dbo].[Product] AS [_t0]
            WHERE
                SUBSTRING([_t0].[Name], @P1, @P2) = @P3;',N'@P1 int,@P2 int,@P3 char(1)',@P1=2,@P2=1,@P3=' '
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
                [_t0].[Id],
                [_t0].[ProductCategoryType],
                [_t0].[Name],
                [_t0].[Description],
                [_t0].[ListPrice],
                [_t0].[Price],
                [_t0].[Quantity],
                [_t0].[Image],
                [_t0].[Height],
                [_t0].[Width],
                [_t0].[Depth],
                [_t0].[Weight],
                [_t0].[ShippingWeight],
                [_t0].[ValidStartTimeOfDayForPurchase],
                [_t0].[ValidEndTimeOfDayForPurchase],
                [_t0].[DateCreated],
                [_t0].[DateUpdated]
            FROM
                [dbo].[Product] AS [_t0]
            ORDER BY
                SUBSTRING([_t0].[Name], @P1, (LEN([_t0].[Name]) - @P2)) ASC;',N'@P1 bigint,@P2 int',@P1=2,@P2=1
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
            	COUNT(*) AS [count],
            	[_t0].[AddressType],
            	SUBSTRING([_t0].[City], @P1, @P2) AS [ignore_first_character]
            FROM
            	[dbo].[Address] AS [_t0]
            GROUP BY
            	[_t0].[AddressType],
            	SUBSTRING([_t0].[City], @P1, @P2);',N'@P1 int,@P2 int',@P1=2,@P2=1
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
            	COUNT(*) AS [count],
            	[_t0].[AddressType]
            FROM
            	[dbo].[Address] AS [_t0]
            GROUP BY
            	[_t0].[AddressType],
            	SUBSTRING([_t0].[City], @P1, @P1)
            HAVING
            	SUBSTRING([_t0].[City], @P1, @P1) > @P2;',N'@P1 int,@P2 varchar(1)',@P1=1,@P2='M'
            */
        }

    }
}
