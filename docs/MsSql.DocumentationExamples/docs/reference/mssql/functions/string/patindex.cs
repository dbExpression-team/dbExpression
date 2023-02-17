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
            	PATINDEX(@P1, [_t0].[City])
            FROM
            	[dbo].[Address] AS [_t0];',N'@P1 char(1),@P2 char(1)',@P1='%',@P2='%'
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
            	[_t0].[Id]
            FROM
            	[dbo].[Address] AS [_t0]
            WHERE
            	PATINDEX([_t0].[Line1], [_t0].[City]) = @P1;',N'@P1 bigint',@P1=1
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
            	[_t0].[Id],
            	[_t0].[AddressType],
            	[_t0].[Line1],
            	[_t0].[Line2],
            	[_t0].[City],
            	[_t0].[State],
            	[_t0].[Zip],
            	[_t0].[DateCreated],
            	[_t0].[DateUpdated]
            FROM
            	[dbo].[Address] AS [_t0]
            ORDER BY
            	PATINDEX(@P1, [_t0].[City]) ASC;',N'@P1 char(1),@P2 char(1)',@P1='%',@P2='%'
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
            	[_t0].[AddressType]
            FROM
            	[dbo].[Address] AS [_t0]
            GROUP BY
            	[_t0].[AddressType],
            	PATINDEX(@P2, [_t0].[City]);',N'@P1 nchar(1),@P2 char(1)',@P1=N'*',@P2='%'
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
            	COUNT(@P1) AS [count],
            	[_t0].[AddressType]
            FROM
            	[dbo].[Address] AS [_t0]
            GROUP BY
            	[_t0].[AddressType],
            	PATINDEX(@P2, [_t0].[Line1])
            HAVING
            	PATINDEX(@P2, [_t0].[Line1]) > @P3;',N'@P1 nchar(1),@P2 char(1),@P3 bigint',@P1=N'*',@P2='%',@P3=0
            */
        }

    }
}
