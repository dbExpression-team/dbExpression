using DbEx.DataService;
using DbEx.dboData;
using DbEx.dboDataService;
using DbEx.secDataService;
using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder.Alias;
using Microsoft.Extensions.Logging;

namespace MsSql.DocumentationExamples.Core_concepts.Basics
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
                [dbo].[Person].[DateCreated] DESC
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
                [dbo].[Person].[RegistrationDate] DESC
                OFFSET @P1	 ROWS
            ;',N'@P1 int',@P1=1
            */
        }

    }
}
