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
    ///<summary>Code examples from https://dbexpression.com/docs/reference/mssql/functions/string/length</summary>
    public class Len : IDocumentationExamples
    {
        private readonly ILogger<Len> logger;

        public Len(ILogger<Len> logger)
        {
            this.logger = logger;
        }

        public void ExecuteExamples()
        {
            Len_line_no_47();
            Len_line_no_65();
            Len_line_no_94();
            Len_line_no_123();
            Len_line_no_150();
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/string/length at line 47</summary>
        private void Len_line_no_47()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/string/length at line 47");

            IEnumerable<long> result = db.SelectMany(
            		db.fx.Len(dbo.Person.LastName)
            	)
            	.From(dbo.Person)
            	.Execute();

            /*
            SELECT
            	LEN([dbo].[Person].[LastName])
            FROM
            	[dbo].[Person];
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/string/length at line 65</summary>
        private void Len_line_no_65()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/string/length at line 65");

            IEnumerable<Person> persons = db.SelectMany<Person>()
            	.From(dbo.Person)
            	.Where(db.fx.Len(dbo.Person.LastName) > db.fx.Len(dbo.Person.FirstName))
            	.Execute();

            /*
            SELECT
            	[_t0].[Id],
            	[_t0].[FirstName],
            	[_t0].[LastName],
            	[_t0].[BirthDate],
            	[_t0].[GenderType],
            	[_t0].[CreditLimit],
            	[_t0].[YearOfLastCreditLimitReview],
            	[_t0].[RegistrationDate],
            	[_t0].[LastLoginDate],
            	[_t0].[DateCreated],
            	[_t0].[DateUpdated]
            FROM
            	[dbo].[Person] AS [_t0]
            WHERE
            	LEN([_t0].[LastName]) > LEN([_t0].[FirstName]);
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/string/length at line 94</summary>
        private void Len_line_no_94()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/string/length at line 94");

            IEnumerable<Person> result = db.SelectMany<Person>()
            	.From(dbo.Person)
            	.OrderBy(db.fx.Len(dbo.Person.LastName).Desc())
            	.Execute();

            /*
            SELECT
            	[_t0].[Id],
            	[_t0].[FirstName],
            	[_t0].[LastName],
            	[_t0].[BirthDate],
            	[_t0].[GenderType],
            	[_t0].[CreditLimit],
            	[_t0].[YearOfLastCreditLimitReview],
            	[_t0].[RegistrationDate],
            	[_t0].[LastLoginDate],
            	[_t0].[DateCreated],
            	[_t0].[DateUpdated]
            FROM
            	[dbo].[Person] AS [_t0]
            ORDER BY
            	LEN([_t0].[LastName]) DESC;
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/string/length at line 123</summary>
        private void Len_line_no_123()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/string/length at line 123");

            IEnumerable<dynamic> values = db.SelectMany(
            		dbo.Address.AddressType,
            		db.fx.Len(dbo.Address.City).As("city")
            	)
            	.From(dbo.Address)
            	.GroupBy(
            		dbo.Address.AddressType,
            		db.fx.Len(dbo.Address.City)
            	)
            	.Execute();

            /*
            SELECT
            	[_t0].[AddressType],
            	LEN([_t0].[City]) AS [city]
            FROM
            	[dbo].[Address] AS [_t0]
            GROUP BY
            	[_t0].[AddressType],
            	LEN([_t0].[City]);
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/string/length at line 150</summary>
        private void Len_line_no_150()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/string/length at line 150");

            IEnumerable<dynamic> addresses = db.SelectMany(
            		db.fx.Count().As("count"),
            		dbo.Address.AddressType,
            		dbo.Address.City
            	)
            	.From(dbo.Address)
            	.GroupBy(
            		dbo.Address.AddressType,
            		dbo.Address.City
            	)
            	.Having(
            		db.fx.Len(dbo.Address.City) == 1
            	)
            	.Execute();

            /*
            exec sp_executesql N'SELECT
            	COUNT(@P1) AS [count],
            	[_t0].[AddressType],
            	[_t0].[City]
            FROM
            	[dbo].[Address] AS [_t0]
            GROUP BY
            	[_t0].[AddressType],
            	[_t0].[City]
            HAVING
            	LEN([_t0].[City]) = @P2;',N'@P1 nchar(1),@P2 bigint',@P1=N'*',@P2=1
            */
        }

    }
}
