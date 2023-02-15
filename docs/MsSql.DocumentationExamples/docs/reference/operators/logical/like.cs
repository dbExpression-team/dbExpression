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
    ///<summary>Code examples from https://dbexpression.com/docs/reference/operators/logical/like</summary>
    public class Like : IDocumentationExamples
    {
        private readonly ILogger<Like> logger;

        public Like(ILogger<Like> logger)
        {
            this.logger = logger;
        }

        public void ExecuteExamples()
        {
            Like_line_no_69();
            Like_line_no_97();
            Like_line_no_127();
            Like_line_no_152();
            Like_line_no_187();
        }

        ///<summary>https://dbexpression.com/docs/reference/operators/logical/like at line 69</summary>
        private void Like_line_no_69()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/operators/logical/like at line 69");

            IEnumerable<Person> persons = db.SelectMany<Person>()
                .From(dbo.Person)
                .Where(dbo.Person.FirstName.Like("J%"))
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
            	[_t0].[FirstName] LIKE @P1;',N'@P1 char(2)',@P1='J%'
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/operators/logical/like at line 97</summary>
        private void Like_line_no_97()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/operators/logical/like at line 97");

            IEnumerable<Person> persons = db.SelectMany<Person>()
                .From(dbo.Person)
                .Where(!dbo.Person.FirstName.Like("J%"))
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
            	NOT ([_t0].[FirstName] LIKE @P1);',N'@P1 char(2)',@P1='J%'
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/operators/logical/like at line 127</summary>
        private void Like_line_no_127()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/operators/logical/like at line 127");

            IEnumerable<string> product_counts = db.SelectMany(
                    dbo.Product.Name
                )
                .From(dbo.Product)
                .GroupBy(dbo.Product.Name)
                .Having(dbo.Product.Name.Like("%Book%"))
                .Execute();

            /*
            exec sp_executesql N'SELECT
            	[_t0].[Name]
            FROM
            	[dbo].[Product] AS [_t0]
            GROUP BY
            	[_t0].[Name]
            HAVING
            	[_t0].[Name] LIKE @P1;',N'@P1 char(6)',@P1='%Book%'
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/operators/logical/like at line 152</summary>
        private void Like_line_no_152()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/operators/logical/like at line 152");

            IEnumerable<Person> persons = db.SelectMany<Person>()
                .From(dbo.Person)
                .InnerJoin(dbo.PersonAddress).On(dbo.Person.Id == dbo.PersonAddress.PersonId)
                .InnerJoin(dbo.Address).On(
                    dbo.Address.Zip.Like("80%")
                    &
                    dbo.PersonAddress.AddressId == dbo.Address.Id
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
            	INNER JOIN [dbo].[Person_Address] AS [_t1] ON [_t0].[Id] = [_t1].[PersonId]
            	INNER JOIN [dbo].[Address] AS [_t2] ON [_t2].[Zip] LIKE @P1
            	AND
            	[_t1].[AddressId] = [_t2].[Id];',N'@P1 char(3)',@P1='80%'
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/operators/logical/like at line 187</summary>
        private void Like_line_no_187()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/operators/logical/like at line 187");

            IEnumerable<Person> persons = db.SelectMany<Person>()
                .From(dbo.Person)
                .InnerJoin(dbo.PersonAddress).On(dbo.Person.Id == dbo.PersonAddress.PersonId)
                .InnerJoin(dbo.Address).On(
                    !dbo.Address.Zip.Like("80%")
                    &
                    dbo.PersonAddress.AddressId == dbo.Address.Id
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
            	INNER JOIN [dbo].[Person_Address] AS [_t1] ON [_t0].[Id] = [_t1].[PersonId]
            	INNER JOIN [dbo].[Address] AS [_t2] ON NOT ([_t2].[Zip] LIKE @P1)
            	AND
            	[_t1].[AddressId] = [_t2].[Id];',N'@P1 char(3)',@P1='80%'
            */
        }

    }
}
