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
            	LEFT([dbo].[Address].[City], @P1)
            FROM
            	[dbo].[Address];',N'@P1 int',@P1=1
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
            	[dbo].[Address].[Id]
            FROM
            	[dbo].[Address]
            WHERE
            	LEFT([dbo].[Address].[City], @P1) = @P2;',N'@P1 int,@P2 char(1)',@P1=1,@P2='D'
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
            	[dbo].[Person].[Id],
            	[dbo].[Person].[FirstName],
            	[dbo].[Person].[LastName],
            	[dbo].[Person].[BirthDate],
            	[dbo].[Person].[GenderType],
            	[dbo].[Person].[CreditLimit],
            	[dbo].[Person].[YearOfLastCreditLimitReview],
            	[dbo].[Person].[RegistrationDate],
            	[dbo].[Person].[LastLoginDate],
            	[dbo].[Person].[DateCreated],
            	[dbo].[Person].[DateUpdated]
            FROM
            	[dbo].[Person]
            ORDER BY
            	LEFT([dbo].[Person].[FirstName], @P1) ASC,
            	LEFT([dbo].[Person].[LastName], @P2) ASC;',N'@P1 int,@P2 int',@P1=1,@P2=1
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
            	COUNT(@P1) AS [count],
            	[dbo].[Person].[YearOfLastCreditLimitReview],
            	LEFT([dbo].[Person].[LastName], @P2) AS [last_initial]
            FROM
            	[dbo].[Person]
            GROUP BY
            	[dbo].[Person].[YearOfLastCreditLimitReview],
            	LEFT([dbo].[Person].[LastName], @P2);',N'@P1 nchar(1),@P2 int',@P1=N'*',@P2=1
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
            	COUNT(@P1) AS [count],
            	[dbo].[Person].[YearOfLastCreditLimitReview],
            	LEFT([dbo].[Person].[LastName], @P2) AS [last_initial]
            FROM
            	[dbo].[Person]
            GROUP BY
            	[dbo].[Person].[YearOfLastCreditLimitReview],
            	LEFT([dbo].[Person].[LastName], @P2)
            HAVING
            	LEFT([dbo].[Person].[LastName], @P2) > @P3;',N'@P1 nchar(1),@P2 int,@P3 char(1)',@P1=N'*',@P2=1,@P3='M'
            */
        }

    }
}
