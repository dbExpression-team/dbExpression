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
    ///<summary>Code examples from https://dbexpression.com/docs/reference/mssql/functions/string/rtrim</summary>
    public class RTrim : IDocumentationExamples
    {
        private readonly ILogger<RTrim> logger;

        public RTrim(ILogger<RTrim> logger)
        {
            this.logger = logger;
        }

        public void ExecuteExamples()
        {
            RTrim_line_no_42();
            RTrim_line_no_60();
            RTrim_line_no_89();
            RTrim_line_no_118();
            RTrim_line_no_146();
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/string/rtrim at line 42</summary>
        private void RTrim_line_no_42()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/string/rtrim at line 42");

            IEnumerable<string> result = db.SelectMany(
            		db.fx.RTrim(dbo.Person.LastName)
            	)
            	.From(dbo.Person)
            	.Execute();

            /*
            SELECT
            	RTRIM([t0].[LastName])
            FROM
            	[dbo].[Person] AS [t0];
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/string/rtrim at line 60</summary>
        private void RTrim_line_no_60()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/string/rtrim at line 60");

            IEnumerable<Person> result = db.SelectMany<Person>()
                .From(dbo.Person)
            	.Where(db.fx.RTrim(dbo.Person.LastName) != dbo.Person.LastName)
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
            	RTRIM([t0].[LastName]) <> [t0].[LastName];
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/string/rtrim at line 89</summary>
        private void RTrim_line_no_89()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/string/rtrim at line 89");

            IEnumerable<Person> result = db.SelectMany<Person>()
            	.From(dbo.Person)
            	.OrderBy(db.fx.RTrim(dbo.Person.LastName))
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
            	RTRIM([t0].[LastName]) ASC;
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/string/rtrim at line 118</summary>
        private void RTrim_line_no_118()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/string/rtrim at line 118");

            IEnumerable<dynamic> values = db.SelectMany(
            		dbo.Address.AddressType,
            		db.fx.RTrim(dbo.Address.City).As("city")
            	)
            	.From(dbo.Address)
            	.GroupBy(
            		dbo.Address.AddressType,
            		db.fx.RTrim(dbo.Address.City)
            	)
            	.Execute();

            /*
            SELECT
            	[t0].[AddressType],
            	RTRIM([t0].[City]) AS [city]
            FROM
            	[dbo].[Address] AS [t0]
            GROUP BY
            	[t0].[AddressType],
            	RTRIM([t0].[City]);
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/string/rtrim at line 146</summary>
        private void RTrim_line_no_146()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/string/rtrim at line 146");

            IEnumerable<dynamic> addresses = db.SelectMany(
            		db.fx.Count().As("count"),
            		dbo.Address.AddressType
            	)
            	.From(dbo.Address)
            	.GroupBy(
            		dbo.Address.AddressType,
            		dbo.Address.City
            	)
            	.Having(
            		db.fx.RTrim(dbo.Address.City) == "Los Angeles"
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
            	[t0].[City]
            HAVING
            	RTRIM([t0].[City]) = @P1;',N'@P1 varchar(11)',@P1='Los Angeles'
            */
        }

    }
}
