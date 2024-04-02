using DocumentationExamples.DataService;
using DocumentationExamples.dboData;
using DocumentationExamples.dboDataService;
using DocumentationExamples.secDataService;
using DbExpression.MsSql.Expression;
using DbExpression.Sql;
using DbExpression.Sql.Builder.Alias;
using Microsoft.Extensions.Logging;

namespace DocumentationExamples.Core_concepts.Basics
{
    ///<summary>Code examples from https://dbexpression.com/docs/core-concepts/basics/offset-and-limit</summary>
    public class Offset_and_Limit_Pagination : IDocumentationExamples
    {
        private readonly ILogger<Offset_and_Limit_Pagination> logger;

        public Offset_and_Limit_Pagination(ILogger<Offset_and_Limit_Pagination> logger)
        {
            this.logger = logger;
        }

        public void ExecuteExamples()
        {
            Offset_and_Limit_Pagination_line_no_14();
            Offset_and_Limit_Pagination_line_no_46();
        }

        ///<summary>https://dbexpression.com/docs/core-concepts/basics/offset-and-limit at line 14</summary>
        private void Offset_and_Limit_Pagination_line_no_14()
        {
            logger.LogDebug("https://dbexpression.com/docs/core-concepts/basics/offset-and-limit at line 14");

            //skip the first 10 matched records, and only return 10 records
            IEnumerable<Person> people = db.SelectMany<Person>()
                .From(dbo.Person)
                .OrderBy(dbo.Person.DateCreated.Desc())
                .Offset(10)
                .Limit(10)
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
                [t0].[DateCreated] DESC
                OFFSET @P1 ROWS
                FETCH NEXT @P2 ROWS ONLY;',N'@P1 int,@P2 int',@P1=10,@P2=10
            */
        }

        ///<summary>https://dbexpression.com/docs/core-concepts/basics/offset-and-limit at line 46</summary>
        private void Offset_and_Limit_Pagination_line_no_46()
        {
            logger.LogDebug("https://dbexpression.com/docs/core-concepts/basics/offset-and-limit at line 46");

            //skip the first record, and return all remaining records
            IEnumerable<Person> notTheLastPersonToRegister = db.SelectMany<Person>()
                .From(dbo.Person)
                .OrderBy(dbo.Person.RegistrationDate.Desc())
                .Offset(1)
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
                [t0].[RegistrationDate] DESC
                OFFSET @P1 ROWS;',N'@P1 int',@P1=1
            */
        }

    }
}
