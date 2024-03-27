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
            	[t0].[Id],
            	[t0].[FirstName],
            	[t0].[LastName],
            	[t0].[BirthDate],
            	[t0].[GenderType],
            	[t0].[CreditLimit],
            	[t0].[YearOfLastCreditLimitReview],
            	[t0].[RegistrationDate],
            	[t0].[LastLoginDate],
            	[t0].[DateCreated],
            	[t0].[DateUpdated]
            FROM
            	[dbo].[Person] AS [t0]
            WHERE
            	LEN([t0].[LastName]) > LEN([t0].[FirstName]);
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
            	[t0].[Id],
            	[t0].[FirstName],
            	[t0].[LastName],
            	[t0].[BirthDate],
            	[t0].[GenderType],
            	[t0].[CreditLimit],
            	[t0].[YearOfLastCreditLimitReview],
            	[t0].[RegistrationDate],
            	[t0].[LastLoginDate],
            	[t0].[DateCreated],
            	[t0].[DateUpdated]
            FROM
            	[dbo].[Person] AS [t0]
            ORDER BY
            	LEN([t0].[LastName]) DESC;
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
            	[t0].[AddressType],
            	LEN([t0].[City]) AS [city]
            FROM
            	[dbo].[Address] AS [t0]
            GROUP BY
            	[t0].[AddressType],
            	LEN([t0].[City]);
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
            	COUNT(*) AS [count],
            	[t0].[AddressType],
            	[t0].[City]
            FROM
            	[dbo].[Address] AS [t0]
            GROUP BY
            	[t0].[AddressType],
            	[t0].[City]
            HAVING
            	LEN([t0].[City]) = @P1;',N'@P1 int',@P1=1
            */
        }

    }
}
