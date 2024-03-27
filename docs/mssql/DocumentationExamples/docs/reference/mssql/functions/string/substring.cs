using DocumentationExamples.DataService;
using DocumentationExamples.dboData;
using DocumentationExamples.dboDataService;
using DocumentationExamples.secDataService;
using DbExpression.MsSql.Expression;
using DbExpression.Sql;
using DbExpression.Sql.Builder.Alias;
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
                SUBSTRING([t0].[Name], @P1, @P2)
            FROM
                [dbo].[Product] AS [t0];',N'@P1 int,@P2 int',@P1=1,@P2=2
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
                [t0].[Id]
            FROM
                [dbo].[Product] AS [t0]
            WHERE
                SUBSTRING([t0].[Name], @P1, @P2) = @P3;',N'@P1 int,@P2 int,@P3 char(1)',@P1=2,@P2=1,@P3=' '
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
                [t0].[Id],
                [t0].[ProductCategoryType],
                [t0].[Name],
                [t0].[Description],
                [t0].[ListPrice],
                [t0].[Price],
                [t0].[Quantity],
                [t0].[Image],
                [t0].[Height],
                [t0].[Width],
                [t0].[Depth],
                [t0].[Weight],
                [t0].[ShippingWeight],
                [t0].[ValidStartTimeOfDayForPurchase],
                [t0].[ValidEndTimeOfDayForPurchase],
                [t0].[DateCreated],
                [t0].[DateUpdated]
            FROM
                [dbo].[Product] AS [t0]
            ORDER BY
                SUBSTRING([t0].[Name], @P1, (LEN([t0].[Name]) - @P2)) ASC;',N'@P1 bigint,@P2 int',@P1=2,@P2=1
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
            	[t0].[AddressType],
            	SUBSTRING([t0].[City], @P1, @P2) AS [ignore_first_character]
            FROM
            	[dbo].[Address] AS [t0]
            GROUP BY
            	[t0].[AddressType],
            	SUBSTRING([t0].[City], @P1, @P2);',N'@P1 int,@P2 int',@P1=2,@P2=1
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
            	[t0].[AddressType]
            FROM
            	[dbo].[Address] AS [t0]
            GROUP BY
            	[t0].[AddressType],
            	SUBSTRING([t0].[City], @P1, @P1)
            HAVING
            	SUBSTRING([t0].[City], @P1, @P1) > @P2;',N'@P1 int,@P2 varchar(1)',@P1=1,@P2='M'
            */
        }

    }
}
