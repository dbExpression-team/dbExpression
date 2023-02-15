using DbEx.DataService;
using DbEx.dboData;
using DbEx.dboDataService;
using DbEx.secDataService;
using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder.Alias;
using Microsoft.Extensions.Logging;

namespace MsSql.DocumentationExamples.Reference.Operators.Logical
{
    ///<summary>Code examples from https://dbexpression.com/docs/reference/operators/logical/in</summary>
    public class In : IDocumentationExamples
    {
        private readonly ILogger<In> logger;

        public In(ILogger<In> logger)
        {
            this.logger = logger;
        }

        public void ExecuteExamples()
        {
            In_line_no_78();
            In_line_no_106();
            In_line_no_135();
            In_line_no_166();
        }

        ///<summary>https://dbexpression.com/docs/reference/operators/logical/in at line 78</summary>
        private void In_line_no_78()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/operators/logical/in at line 78");

            IEnumerable<Person> persons = db.SelectMany<Person>()
                .From(dbo.Person)
                .Where(dbo.Person.FirstName.In("Jane", "John", "Mary", "Joe"))
                .Execute();

            /*
            exec sp_executesql N'SELECT
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
                [_t0].[FirstName] IN (@P1,@P2,@P3,@P4);',N'@P1 varchar(20),@P2 varchar(20),@P3 varchar(20),@P4 varchar(20)',@P1='Jane',@P2='John',@P3='Mary',@P4='Joe'
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/operators/logical/in at line 106</summary>
        private void In_line_no_106()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/operators/logical/in at line 106");

            IEnumerable<Person> persons = db.SelectMany<Person>()
                .From(dbo.Person)
                .Where(!dbo.Person.FirstName.In("Jane", "John", "Mary", "Joe"))
                .Execute();

            /*
            exec sp_executesql N'SELECT
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
                NOT ([_t0].[FirstName] IN (@P1,@P2,@P3,@P4));',N'@P1 varchar(20),@P2 varchar(20),@P3 varchar(20),@P4 varchar(20)',@P1='Jane',@P2='John',@P3='Mary',@P4='Joe'
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/operators/logical/in at line 135</summary>
        private void In_line_no_135()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/operators/logical/in at line 135");

            IEnumerable<dynamic> product_counts = db.SelectMany(
                    dbo.Product.ProductCategoryType,
                    db.fx.Count().As("CategoryCount")
                )
                .From(dbo.Product)
                .GroupBy(dbo.Product.ProductCategoryType)
                .Having(
                    dbo.Product.ProductCategoryType.In(
                        ProductCategoryType.Books,
                        ProductCategoryType.ToysAndGames,
                        ProductCategoryType.Electronics
                    )
                )
                .Execute();

            /*
            exec sp_executesql N'      SELECT
                [_t0].[ProductCategoryType],
                COUNT(@P1) AS [CategoryCount]
            FROM
                [dbo].[Product] AS [_t0]
            GROUP BY
                [_t0].[ProductCategoryType]
            HAVING
                [_t0].[ProductCategoryType] IN (@P2,@P3,@P4);',N'@P1 nchar(1),@P2 int,@P3 int,@P4 int',@P1=N'*',@P2=3,@P3=1,@P4=2
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/operators/logical/in at line 166</summary>
        private void In_line_no_166()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/operators/logical/in at line 166");

            IEnumerable<Person> persons = db.SelectMany<Person>()
                .From(dbo.Person)
                .InnerJoin(dbo.PersonAddress).On(
                    dbo.PersonAddress.PersonId.In(1, 12, 14)
                    &
                    dbo.PersonAddress.PersonId == dbo.Person.Id
                )
                .Execute();

            /*
            exec sp_executesql N'SELECT
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
                INNER JOIN [dbo].[Person_Address] AS [_t1] ON [_t1].[PersonId] IN (@P1,@P2,@P3)
                AND
                [_t1].[PersonId] = [_t0].[Id];',N'@P1 int,@P2 int,@P3 int',@P1=1,@P2=12,@P3=14
            */
        }

    }
}
