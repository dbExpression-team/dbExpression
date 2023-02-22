using DocumentationExamples.DataService;
using DocumentationExamples.dboData;
using DocumentationExamples.dboDataService;
using DocumentationExamples.secDataService;
using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder.Alias;
using Microsoft.Extensions.Logging;

namespace DocumentationExamples.Reference.Mssql.Functions.String
{
    ///<summary>Code examples from https://dbexpression.com/docs/reference/mssql/functions/string/left</summary>
    public class Left : IDocumentationExamples
    {
        private readonly ILogger<Left> logger;

        public Left(ILogger<Left> logger)
        {
            this.logger = logger;
        }

        public void ExecuteExamples()
        {
            Left_line_no_61();
            Left_line_no_79();
            Left_line_no_100();
            Left_line_no_133();
            Left_line_no_162();
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/string/left at line 61</summary>
        private void Left_line_no_61()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/string/left at line 61");

            IEnumerable<string> result = db.SelectMany(
            		db.fx.Left(dbo.Address.City, 1)
            	)
            	.From(dbo.Address)
            	.Execute();

            /*
            exec sp_executesql N'SELECT
                LEFT([t0].[City], @P1)
            FROM
                [dbo].[Address] AS [t0];',N'@P1 int',@P1=1
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/string/left at line 79</summary>
        private void Left_line_no_79()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/string/left at line 79");

            IEnumerable<int> result = db.SelectMany(
            		dbo.Address.Id
            	)
            	.From(dbo.Address)
                .Where(db.fx.Left(dbo.Address.City, 1) == "D")
            	.Execute();

            /*
            exec sp_executesql N'SELECT
                [t0].[Id]
            FROM
                [dbo].[Address] AS [t0]
            WHERE
                LEFT([t0].[City], @P1) = @P2;',N'@P1 int,@P2 char(1)',@P1=1,@P2='D'
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/string/left at line 100</summary>
        private void Left_line_no_100()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/string/left at line 100");

            IEnumerable<Person> persons = db.SelectMany<Person>()
                .From(dbo.Person)
                .OrderBy(
                    db.fx.Left(dbo.Person.FirstName, 1),
                    db.fx.Left(dbo.Person.LastName, 1)
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
                LEFT([t0].[FirstName], @P1) ASC,
                LEFT([t0].[LastName], @P2) ASC;',N'@P1 int,@P2 int',@P1=1,@P2=1
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/string/left at line 133</summary>
        private void Left_line_no_133()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/string/left at line 133");

            IEnumerable<dynamic> values = db.SelectMany(
                    db.fx.Count().As("count"),
                    dbo.Person.YearOfLastCreditLimitReview,
                    db.fx.Left(dbo.Person.LastName, 1).As("last_initial")
                )
                .From(dbo.Person)
                .GroupBy(
                    dbo.Person.YearOfLastCreditLimitReview,
                    db.fx.Left(dbo.Person.LastName, 1)
                )
                .Execute();

            /*
            exec sp_executesql N'SELECT
            	COUNT(*) AS [count],
            	[t0].[YearOfLastCreditLimitReview],
            	LEFT([t0].[LastName], @P1) AS [last_initial]
            FROM
            	[dbo].[Person] AS [t0]
            GROUP BY
            	[t0].[YearOfLastCreditLimitReview],
            	LEFT([t0].[LastName], @P1);',N'@P1 int',@P1=1
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/string/left at line 162</summary>
        private void Left_line_no_162()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/string/left at line 162");

            IEnumerable<dynamic> addresses = db.SelectMany(
                    db.fx.Count().As("count"),
                    dbo.Person.YearOfLastCreditLimitReview,
                    db.fx.Left(dbo.Person.LastName, 1).As("last_initial")
                )
                .From(dbo.Person)
                .GroupBy(
                    dbo.Person.YearOfLastCreditLimitReview,
                    db.fx.Left(dbo.Person.LastName, 1)
                )
                .Having(
                    db.fx.Left(dbo.Person.LastName, 1) > "M"
                )
                .Execute();

            /*
            exec sp_executesql N'SELECT
            	COUNT(*) AS [count],
            	[t0].[YearOfLastCreditLimitReview],
            	LEFT([t0].[LastName], @P1) AS [last_initial]
            FROM
            	[dbo].[Person] AS [t0]
            GROUP BY
            	[t0].[YearOfLastCreditLimitReview],
            	LEFT([t0].[LastName], @P1)
            HAVING
            	LEFT([t0].[LastName], @P1) > @P2;',N'@P1 int,@P2 varchar(1)',@P1=1,@P2='M'
            */
        }

    }
}
