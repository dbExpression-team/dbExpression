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
    ///<summary>Code examples from https://dbexpression.com/docs/reference/mssql/functions/string/charindex</summary>
    public class CharIndex : IDocumentationExamples
    {
        private readonly ILogger<CharIndex> logger;

        public CharIndex(ILogger<CharIndex> logger)
        {
            this.logger = logger;
        }

        public void ExecuteExamples()
        {
            CharIndex_line_no_88();
            CharIndex_line_no_106();
            CharIndex_line_no_127();
            CharIndex_line_no_154();
            CharIndex_line_no_182();
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/string/charindex at line 88</summary>
        private void CharIndex_line_no_88()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/string/charindex at line 88");

            IEnumerable<long?> result = db.SelectMany(
            		db.fx.CharIndex(dbo.Address.Line2, dbo.Address.Line1)
            	)
            	.From(dbo.Address)
            	.Execute();

            /*
            SELECT
                CHARINDEX([t0].[Line2], [t0].[Line1])
            FROM
                [dbo].[Address] AS [t0];
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/string/charindex at line 106</summary>
        private void CharIndex_line_no_106()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/string/charindex at line 106");

            IEnumerable<int> result = db.SelectMany(
            		dbo.Address.Id
            	)
            	.From(dbo.Address)
            	.Where(db.fx.CharIndex(dbo.Address.Line2, dbo.Address.Line1) == 1)
            	.Execute();

            /*
            exec sp_executesql N'SELECT
                [t0].[Id]
            FROM
                [dbo].[Address] AS [t0]
            WHERE
                CHARINDEX([t0].[Line2], [t0].[Line1]) = @P1;',N'@P1 bigint',@P1=1
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/string/charindex at line 127</summary>
        private void CharIndex_line_no_127()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/string/charindex at line 127");

            IEnumerable<Address> addresses = db.SelectMany<Address>()
                .From(dbo.Address)
                .OrderBy(db.fx.CharIndex(dbo.Address.Line2, dbo.Address.Line1))
                .Execute();

            /*
            SELECT
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
                CHARINDEX([t0].[Line2], [t0].[Line1]) ASC;
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/string/charindex at line 154</summary>
        private void CharIndex_line_no_154()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/string/charindex at line 154");

            IEnumerable<dynamic> values = db.SelectMany(
                    dbo.Address.AddressType,
                    db.fx.CharIndex(dbo.Address.Line2, dbo.Address.Line1).As("first_index_of")
                )
                .From(dbo.Address)
                .GroupBy(
                    dbo.Address.AddressType,
                    db.fx.CharIndex(dbo.Address.Line2, dbo.Address.Line1)
                )
                .Execute();

            /*
            SELECT
                [t0].[AddressType],
                CHARINDEX([t0].[Line2], [t0].[Line1]) AS [first_index_of]
            FROM
                [dbo].[Address] AS [t0]
            GROUP BY
                [t0].[AddressType],
                CHARINDEX([t0].[Line2], [t0].[Line1]);
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/string/charindex at line 182</summary>
        private void CharIndex_line_no_182()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/string/charindex at line 182");

            IEnumerable<dynamic> values = db.SelectMany(
            		dbo.Address.AddressType,
            		dbo.Address.Line1,
            		dbo.Address.Line2
            	)
            	.From(dbo.Address)
            	.GroupBy(
            		dbo.Address.AddressType,
            		dbo.Address.Line1,
            		dbo.Address.Line2
            	)
            	.Having(
            		db.fx.CharIndex(dbo.Address.Line2, dbo.Address.Line1) >= 0
            	)
            	.Execute();

            /*
            exec sp_executesql N'SELECT
                [t0].[AddressType],
                [t0].[Line1],
                [t0].[Line2]
            FROM
                [dbo].[Address] AS [t0]
            GROUP BY
                [t0].[AddressType],
                [t0].[Line1],
                [t0].[Line2]
            HAVING
                CHARINDEX([t0].[Line2], [t0].[Line1]) >= @P1;',N'@P1 bigint',@P1=0
            */
        }

    }
}
