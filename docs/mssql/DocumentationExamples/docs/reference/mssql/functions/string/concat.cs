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
    ///<summary>Code examples from https://dbexpression.com/docs/reference/mssql/functions/string/concat</summary>
    public class Concat : IDocumentationExamples
    {
        private readonly ILogger<Concat> logger;

        public Concat(ILogger<Concat> logger)
        {
            this.logger = logger;
        }

        public void ExecuteExamples()
        {
            Concat_line_no_64();
            Concat_line_no_82();
            Concat_line_no_103();
            Concat_line_no_130();
            Concat_line_no_158();
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/string/concat at line 64</summary>
        private void Concat_line_no_64()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/string/concat at line 64");

            IEnumerable<string> result = db.SelectMany(
            		db.fx.Concat(dbo.Address.City, ", ", db.fx.Cast(dbo.Address.State).AsVarChar(2))
            	)
            	.From(dbo.Address)
            	.Execute();

            /*
            exec sp_executesql N'SELECT
                CONCAT([t0].[City], @P1, CAST([t0].[State] AS VarChar(2)))
            FROM
                [dbo].[Address] AS [t0];',N'@P1 char(2)',@P1=', '
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/string/concat at line 82</summary>
        private void Concat_line_no_82()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/string/concat at line 82");

            IEnumerable<int> result = db.SelectMany(
            		dbo.Address.Id
            	)
            	.From(dbo.Address)
                .Where(db.fx.Concat(dbo.Address.Line1, dbo.Address.Line2) != dbo.Address.Line1)
            	.Execute();

            /*
            SSELECT
                [t0].[Id]
            FROM
                [dbo].[Address] AS [t0]
            WHERE
                CONCAT([t0].[Line1], [t0].[Line2]) <> [t0].[Line1];
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/string/concat at line 103</summary>
        private void Concat_line_no_103()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/string/concat at line 103");

            IEnumerable<Address> addresses = db.SelectMany<Address>()
                .From(dbo.Address)
                .OrderBy(db.fx.Concat(dbo.Address.City, ", ", db.fx.Cast(dbo.Address.State).AsVarChar(2)))
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
                CONCAT([t0].[City], @P1, CAST([t0].[State] AS VarChar(2))) ASC;',N'@P1 char(2)',@P1=', '
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/string/concat at line 130</summary>
        private void Concat_line_no_130()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/string/concat at line 130");

            IEnumerable<dynamic> values = db.SelectMany(
                    dbo.Address.AddressType,
                    db.fx.Concat(dbo.Address.City, ", ", db.fx.Cast(dbo.Address.State).AsVarChar(2)).As("formatted_city_state")
                )
                .From(dbo.Address)
                .GroupBy(
                    dbo.Address.AddressType,
                    db.fx.Concat(dbo.Address.City, ", ", db.fx.Cast(dbo.Address.State).AsVarChar(2))
                )
                .Execute();

            /*
            exec sp_executesql N'SELECT
                [t0].[AddressType],
                CONCAT([t0].[City], @P1, CAST([t0].[State] AS VarChar(2))) AS [formatted_city_state]
            FROM
                [dbo].[Address] AS [t0]
            GROUP BY
                [t0].[AddressType],
                CONCAT([t0].[City], @P1, CAST([t0].[State] AS VarChar(2)));',N'@P1 char(2)',@P1=', '
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/string/concat at line 158</summary>
        private void Concat_line_no_158()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/string/concat at line 158");

            IEnumerable<dynamic> values = db.SelectMany(
                    db.fx.Count().As("count"),
                    dbo.Address.AddressType
                )
                .From(dbo.Address)
                .GroupBy(
                    dbo.Address.AddressType,
                    db.fx.Concat(dbo.Address.City, ", ", db.fx.Cast(dbo.Address.State).AsVarChar(2))
                )
                .Having(
                    db.fx.Concat(dbo.Address.City, ", ", db.fx.Cast(dbo.Address.State).AsVarChar(2)).Like("%y, A%")
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
            	CONCAT([t0].[City], @P1, CAST([t0].[State] AS VarChar(2)))
            HAVING
            	CONCAT([t0].[City], @P1, CAST([t0].[State] AS VarChar(2))) LIKE @P2;',N'@P1 varchar(2),@P2 varchar(6)',@P1=', ',@P2='%y, A%'
            */
        }

    }
}
