using DbEx.DataService;
using DbEx.dboData;
using DbEx.dboDataService;
using DbEx.secDataService;
using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder.Alias;
using Microsoft.Extensions.Logging;

namespace MsSql.DocumentationExamples.Core_concepts.Basics
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
            	[dbo].[Person].[Id],
            	[dbo].[Person].[FirstName],
            	[dbo].[Person].[LastName]
            FROM
            	[dbo].[Person]
            UNION
            SELECT
            	[dbo].[Address].[Id],
            	[dbo].[Address].[Line1],
            	[dbo].[Address].[Line2]
            FROM
            	[dbo].[Address];
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
            	[dbo].[Person].[Id],
            	[dbo].[Person].[FirstName],
            	[dbo].[Person].[LastName]
            FROM
            	[dbo].[Person]
            UNION ALL
            SELECT
            	[dbo].[Address].[Id],
            	[dbo].[Address].[Line1],
            	[dbo].[Address].[Line2]
            FROM
            	[dbo].[Address];
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
            	[Pivot].[State],
            	SUM([Pivot].[ShippingCount]) AS [Shipping],
            	SUM([Pivot].[MailingCount]) AS [Mailing],
            	SUM([Pivot].[BillingCount]) AS [Billing]
            FROM
            (
            	SELECT
            		[dbo].[Address].[State],
            		COUNT(@P1) AS [ShippingCount],
            		NULL AS [MailingCount],
            		NULL AS [BillingCount]
            	FROM
            		[dbo].[Address]
            	WHERE
            		[dbo].[Address].[AddressType] = @P2
            	GROUP BY
            		[dbo].[Address].[State]
            	UNION ALL
            	SELECT
            		[dbo].[Address].[State],
            		NULL,
            		COUNT(@P3),
            		NULL
            	FROM
            		[dbo].[Address]
            	WHERE
            		[dbo].[Address].[AddressType] = @P4
            	GROUP BY
            		[dbo].[Address].[State]
            	UNION ALL
            	SELECT
            		[dbo].[Address].[State],
            		NULL,
            		NULL,
            		COUNT(@P5)
            	FROM
            		[dbo].[Address]
            	WHERE
            		[dbo].[Address].[AddressType] = @P6
            	GROUP BY
            		[dbo].[Address].[State]
            ) AS [Pivot]
            GROUP BY
            	[Pivot].[State]
            ORDER BY
            	[Pivot].[State] ASC;',N'@P1 nchar(1),@P2 int,@P3 nchar(1),@P4 int,@P5 nchar(1),@P6 int',@P1=N'*',@P2=0,@P3=N'*',@P4=1,@P5=N'*',@P6=2
            */
        }

    }
}
