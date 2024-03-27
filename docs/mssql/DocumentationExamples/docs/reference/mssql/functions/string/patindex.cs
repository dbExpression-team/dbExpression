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
    ///<summary>Code examples from https://dbexpression.com/docs/reference/mssql/functions/string/patindex</summary>
    public class PatIndex : IDocumentationExamples
    {
        private readonly ILogger<PatIndex> logger;

        public PatIndex(ILogger<PatIndex> logger)
        {
            this.logger = logger;
        }

        public void ExecuteExamples()
        {
            PatIndex_line_no_67();
            PatIndex_line_no_87();
            PatIndex_line_no_108();
            PatIndex_line_no_135();
            PatIndex_line_no_162();
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/string/patindex at line 67</summary>
        private void PatIndex_line_no_67()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/string/patindex at line 67");

            IEnumerable<long> result = db.SelectMany(
            		db.fx.PatIndex("%" + dbo.Address.State + "%", dbo.Address.City)
            	)
            	.From(dbo.Address)
            	.Execute();

            /*
            exec sp_executesql N'SELECT
            	PATINDEX(@P1, [t0].[City])
            FROM
            	[dbo].[Address] AS [t0];',N'@P1 char(1),@P2 char(1)',@P1='%',@P2='%'
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/string/patindex at line 87</summary>
        private void PatIndex_line_no_87()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/string/patindex at line 87");

            IEnumerable<int> result = db.SelectMany(
            		dbo.Address.Id
            	)
            	.From(dbo.Address)
            	.Where(db.fx.PatIndex(dbo.Address.Line1, dbo.Address.City) == 1)
            	.Execute();

            /*
            exec sp_executesql N'SELECT
            	[t0].[Id]
            FROM
            	[dbo].[Address] AS [t0]
            WHERE
            	PATINDEX([t0].[Line1], [t0].[City]) = @P1;',N'@P1 bigint',@P1=1
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/string/patindex at line 108</summary>
        private void PatIndex_line_no_108()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/string/patindex at line 108");

            IEnumerable<Address> addresses = db.SelectMany<Address>()
                .From(dbo.Address)
                .OrderBy(db.fx.PatIndex("%" + dbo.Address.State + "%", dbo.Address.City))
                .Execute();

            /*
            exec sp_executesql N'SELECT
            	[t0].[Id],
            	[t0].[AddressType],
            	[t0].[Line1],
            	[t0].[Line2],
            	[t0].[City],
            	[t0].[State],
            	[t0].[Zip],
            	[t0].[DateCreated],
            	[t0].[DateUpdated]
            FROM
            	[dbo].[Address] AS [t0]
            ORDER BY
            	PATINDEX(@P1, [t0].[City]) ASC;',N'@P1 char(1),@P2 char(1)',@P1='%',@P2='%'
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/string/patindex at line 135</summary>
        private void PatIndex_line_no_135()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/string/patindex at line 135");

            IEnumerable<dynamic> values = db.SelectMany(
            		db.fx.Count().As("count"),
            		dbo.Address.AddressType
            	)
            	.From(dbo.Address)
            	.GroupBy(
            		dbo.Address.AddressType,
            		db.fx.PatIndex("%" + dbo.Address.State + "%", dbo.Address.City)
            	)
            	.Execute();

            /*
            exec sp_executesql N'SELECT
            	COUNT(@P1) AS [count],
            	[t0].[AddressType]
            FROM
            	[dbo].[Address] AS [t0]
            GROUP BY
            	[t0].[AddressType],
            	PATINDEX(@P2, [t0].[City]);',N'@P1 nchar(1),@P2 char(1)',@P1=N'*',@P2='%'
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/string/patindex at line 162</summary>
        private void PatIndex_line_no_162()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/string/patindex at line 162");

            IEnumerable<dynamic> values = db.SelectMany(
            		db.fx.Count().As("count"),
            		dbo.Address.AddressType
            	)
            	.From(dbo.Address)
            	.GroupBy(
            		dbo.Address.AddressType,
            		db.fx.PatIndex("%" + dbo.Address.State + "%", dbo.Address.Line1)
            	)
            	.Having(
            		db.fx.PatIndex("%" + dbo.Address.State + "%", dbo.Address.Line1) > 0
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
            	PATINDEX(@P1, [t0].[Line1])
            HAVING
            	PATINDEX(@P1, [t0].[Line1]) > @P2;',N'@P1 varchar(7),@P2 int',@P1='%State%',@P2=0
            */
        }

    }
}
