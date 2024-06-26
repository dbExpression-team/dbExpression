using DocumentationExamples.DataService;
using DocumentationExamples.dboData;
using DocumentationExamples.dboDataService;
using DocumentationExamples.secDataService;
using DbExpression.MsSql.Expression;
using DbExpression.Sql;
using DbExpression.Sql.Builder.Alias;
using Microsoft.Extensions.Logging;

namespace DocumentationExamples.Core_concepts.Basics
{
    ///<summary>Code examples from https://dbexpression.com/docs/core-concepts/basics/union-and-union-all</summary>
    public class Union_and_Union_All : IDocumentationExamples
    {
        private readonly ILogger<Union_and_Union_All> logger;

        public Union_and_Union_All(ILogger<Union_and_Union_All> logger)
        {
            this.logger = logger;
        }

        public void ExecuteExamples()
        {
            Union_and_Union_All_line_no_11();
            Union_and_Union_All_line_no_45();
            Union_and_Union_All_line_no_83();
        }

        ///<summary>https://dbexpression.com/docs/core-concepts/basics/union-and-union-all at line 11</summary>
        private void Union_and_Union_All_line_no_11()
        {
            logger.LogDebug("https://dbexpression.com/docs/core-concepts/basics/union-and-union-all at line 11");

            IEnumerable<dynamic> results = db.SelectMany(
                    dbo.Person.Id,
                    dbo.Person.FirstName,
                    dbo.Person.LastName
                )
                .From(dbo.Person)
                .Union()
                .SelectMany(
                    dbo.Address.Id,
                    dbo.Address.Line1,
                    dbo.Address.Line2
                )
                .From(dbo.Address)
                .Execute();

            /*
            SELECT
                [t0].[Id],
                [t0].[FirstName],
                [t0].[LastName]
            FROM
                [dbo].[Person] AS [t0]
            UNION
            SELECT
                [t1].[Id],
                [t1].[Line1],
                [t1].[Line2]
            FROM
                [dbo].[Address] AS [t1];
            */
        }

        ///<summary>https://dbexpression.com/docs/core-concepts/basics/union-and-union-all at line 45</summary>
        private void Union_and_Union_All_line_no_45()
        {
            logger.LogDebug("https://dbexpression.com/docs/core-concepts/basics/union-and-union-all at line 45");

            IEnumerable<dynamic> results = db.SelectMany(
                    dbo.Person.Id,
                    dbo.Person.FirstName,
                    dbo.Person.LastName
                )
                .From(dbo.Person)
                .UnionAll()
                .SelectMany(
                    dbo.Address.Id,
                    dbo.Address.Line1,
                    dbo.Address.Line2
                )
                .From(dbo.Address)
                .Execute();

            /*
            SELECT
                [t0].[Id],
                [t0].[FirstName],
                [t0].[LastName]
            FROM
                [dbo].[Person] AS [t0]
            UNION ALL
            SELECT
                [t1].[Id],
                [t1].[Line1],
                [t1].[Line2]
            FROM
                [dbo].[Address] AS [t1];
            */
        }

        ///<summary>https://dbexpression.com/docs/core-concepts/basics/union-and-union-all at line 83</summary>
        private void Union_and_Union_All_line_no_83()
        {
            logger.LogDebug("https://dbexpression.com/docs/core-concepts/basics/union-and-union-all at line 83");

            IEnumerable<dynamic> results = db.SelectMany(
                    dbex.Alias<string>("Pivot", "State"),
                    db.fx.Sum(("Pivot", "ShippingCount")).As("Shipping"),
                    db.fx.Sum(("Pivot", "MailingCount")).As("Mailing"),
                    db.fx.Sum(("Pivot", "BillingCount")).As("Billing")
                ).From(
                    db.SelectMany(
                        dbo.Address.State,
                        db.fx.Count().As("ShippingCount"),
                        dbex.Null.As("MailingCount"),
                        dbex.Null.As("BillingCount")
                    ).From(dbo.Address)
                    .Where(dbo.Address.AddressType == AddressType.Shipping)
                    .GroupBy(dbo.Address.State)
                    .UnionAll()
                    .SelectMany(
                        dbo.Address.State,
                        dbex.Null,
                        db.fx.Count(),
                        dbex.Null
                    ).From(dbo.Address)
                    .Where(dbo.Address.AddressType == AddressType.Mailing)
                    .GroupBy(dbo.Address.State)
                    .UnionAll()
                    .SelectMany(
                        dbo.Address.State,
                        dbex.Null,
                        dbex.Null,
                        db.fx.Count()
                    ).From(dbo.Address)
                    .Where(dbo.Address.AddressType == AddressType.Billing)
                    .GroupBy(dbo.Address.State)
                ).As("Pivot")
                .GroupBy(("Pivot", "State"))
                .OrderBy(("Pivot", "State"))
                .Execute();

            /*
            exec sp_executesql N'SELECT
            	[t0].[State],
            	SUM([t0].[ShippingCount]) AS [Shipping],
            	SUM([t0].[MailingCount]) AS [Mailing],
            	SUM([t0].[BillingCount]) AS [Billing]
            FROM
            (
            	SELECT
            		[t1].[State],
            		COUNT(*) AS [ShippingCount],
            		NULL AS [MailingCount],
            		NULL AS [BillingCount]
            	FROM
            		[dbo].[Address] AS [t1]
            	WHERE
            		[t1].[AddressType] = @P1
            	GROUP BY
            		[t1].[State]
            	UNION ALL
            	SELECT
            		[t1].[State],
            		NULL,
            		COUNT(*),
            		NULL
            	FROM
            		[dbo].[Address] AS [t1]
            	WHERE
            		[t1].[AddressType] = @P2
            	GROUP BY
            		[t1].[State]
            	UNION ALL
            	SELECT
            		[t1].[State],
            		NULL,
            		NULL,
            		COUNT(*)
            	FROM
            		[dbo].[Address] AS [t1]
            	WHERE
            		[t1].[AddressType] = @P3
            	GROUP BY
            		[t1].[State]
            ) AS [t0]
            GROUP BY
            	[t0].[State]
            ORDER BY
            	[t0].[State] ASC;',N'@P1 int,@P2 int,@P3 int',@P1=0,@P2=1,@P3=2
            */
        }

    }
}
