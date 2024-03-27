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
    ///<summary>Code examples from https://dbexpression.com/docs/reference/mssql/functions/string/right</summary>
    public class Right : IDocumentationExamples
    {
        private readonly ILogger<Right> logger;

        public Right(ILogger<Right> logger)
        {
            this.logger = logger;
        }

        public void ExecuteExamples()
        {
            Right_line_no_61();
            Right_line_no_79();
            Right_line_no_100();
            Right_line_no_131();
            Right_line_no_160();
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/string/right at line 61</summary>
        private void Right_line_no_61()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/string/right at line 61");

            IEnumerable<string> result = db.SelectMany(
            		db.fx.Right(dbo.Address.City, 1)
            	)
            	.From(dbo.Address)
            	.Execute();

            /*
            exec sp_executesql N'SELECT
                RIGHT([t0].[City], @P1)
            FROM
                [dbo].[Address] AS [t0];',N'@P1 int',@P1=1
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/string/right at line 79</summary>
        private void Right_line_no_79()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/string/right at line 79");

            IEnumerable<int> result = db.SelectMany(
            		dbo.Address.Id
            	)
            	.From(dbo.Address)
                .Where(db.fx.Right(dbo.Address.City, 2) == "ly")
            	.Execute();

            /*
            exec sp_executesql N'SELECT
                [t0].[Id]
            FROM
                [dbo].[Address] AS [t0]
            WHERE
                RIGHT([t0].[City], @P1) = @P2;',N'@P1 int,@P2 varchar(2)',@P1=2,@P2='ly'
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/string/right at line 100</summary>
        private void Right_line_no_100()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/string/right at line 100");

            IEnumerable<Person> persons = db.SelectMany<Person>()
                .From(dbo.Person)
                .OrderBy(
                    db.fx.Right(dbo.Person.FirstName, 1)
                )
                .Execute();

            /*
            exec sp_executesql N'SELECT
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
                RIGHT([t0].[FirstName], @P1) ASC;',N'@P1 int',@P1=1
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/string/right at line 131</summary>
        private void Right_line_no_131()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/string/right at line 131");

            IEnumerable<dynamic> values = db.SelectMany(
                    db.fx.Count().As("count"),
                    dbo.Person.YearOfLastCreditLimitReview,
                    db.fx.Right(dbo.Person.LastName, 1).As("last_character")
                )
                .From(dbo.Person)
                .GroupBy(
                    dbo.Person.YearOfLastCreditLimitReview,
                    db.fx.Right(dbo.Person.LastName, 1)
                )
                .Execute();

            /*
            exec sp_executesql N'SELECT
            	COUNT(*) AS [count],
            	[t0].[YearOfLastCreditLimitReview],
            	RIGHT([t0].[LastName], @P1) AS [last_character]
            FROM
            	[dbo].[Person] AS [t0]
            GROUP BY
            	[t0].[YearOfLastCreditLimitReview],
            	RIGHT([t0].[LastName], @P1);',N'@P1 int',@P1=1
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/string/right at line 160</summary>
        private void Right_line_no_160()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/string/right at line 160");

            IEnumerable<dynamic> addresses = db.SelectMany(
                    db.fx.Count().As("count"),
                    dbo.Person.YearOfLastCreditLimitReview,
                    db.fx.Right(dbo.Person.LastName, 1).As("last_character")
                )
                .From(dbo.Person)
                .GroupBy(
                    dbo.Person.YearOfLastCreditLimitReview,
                    db.fx.Right(dbo.Person.LastName, 1)
                )
                .Having(
                    db.fx.Right(dbo.Person.LastName, 1) > "."
                )
                .Execute();

            /*
            exec sp_executesql N'SELECT
            	COUNT(*) AS [count],
            	[t0].[YearOfLastCreditLimitReview],
            	RIGHT([t0].[LastName], @P1) AS [last_character]
            FROM
            	[dbo].[Person] AS [t0]
            GROUP BY
            	[t0].[YearOfLastCreditLimitReview],
            	RIGHT([t0].[LastName], @P1)
            HAVING
            	RIGHT([t0].[LastName], @P1) > @P2;',N'@P1 int,@P2 varchar(1)',@P1=1,@P2='.'
            */
        }

    }
}
