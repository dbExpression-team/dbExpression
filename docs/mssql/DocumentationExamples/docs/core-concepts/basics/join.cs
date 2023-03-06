using DocumentationExamples.DataService;
using DocumentationExamples.dboData;
using DocumentationExamples.dboDataService;
using DocumentationExamples.secDataService;
using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder.Alias;
using Microsoft.Extensions.Logging;

namespace DocumentationExamples.Core_concepts.Basics
{
    ///<summary>Code examples from https://dbexpression.com/docs/core-concepts/basics/join</summary>
    public class Joins : IDocumentationExamples
    {
        private readonly ILogger<Joins> logger;

        public Joins(ILogger<Joins> logger)
        {
            this.logger = logger;
        }

        public void ExecuteExamples()
        {
            Joins_line_no_20();
            Joins_line_no_52();
            Joins_line_no_88();
            Joins_line_no_118();
            Joins_line_no_145();
        }

        ///<summary>https://dbexpression.com/docs/core-concepts/basics/join at line 20</summary>
        private void Joins_line_no_20()
        {
            logger.LogDebug("https://dbexpression.com/docs/core-concepts/basics/join at line 20");

            //select all people who do not have an address
            IEnumerable<Person> people = db.SelectMany<Person>()
                .From(dbo.Person)
                .LeftJoin(dbo.PersonAddress).On(dbo.PersonAddress.PersonId == dbo.Person.Id)
                .Where(dbo.PersonAddress.Id == dbex.Null)
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
                LEFT JOIN [dbo].[Person_Address] AS [t1] ON [t1].[PersonId] = [t0].[Id]
            WHERE
                [t1].[Id] IS NULL;
            */
        }

        ///<summary>https://dbexpression.com/docs/core-concepts/basics/join at line 52</summary>
        private void Joins_line_no_52()
        {
            logger.LogDebug("https://dbexpression.com/docs/core-concepts/basics/join at line 52");

            //get person credit limit info for people in zip 94043
            IEnumerable<dynamic> info = db.SelectMany(
                    dbo.Person.Id,
                    dbo.Person.FirstName,
                    dbo.Person.LastName,
                    dbo.Person.CreditLimit,
                    dbo.Person.YearOfLastCreditLimitReview
                )
                .From(dbo.Address)
                .RightJoin(dbo.PersonAddress).On(dbo.PersonAddress.AddressId == dbo.Address.Id)
                .RightJoin(dbo.Person).On(dbo.Person.Id == dbo.PersonAddress.PersonId)
                .Where(dbo.Address.Zip == "94043" & dbo.Address.AddressType == AddressType.Billing)
                .Execute();

            /*
            exec sp_executesql N'SELECT
                [t0].[Id],
                [t0].[FirstName],
                [t0].[LastName],
                [t0].[CreditLimit],
                [t0].[YearOfLastCreditLimitReview]
            FROM
                [dbo].[Address] AS [t1]
                RIGHT JOIN [dbo].[Person_Address] AS [t2] ON [t2].[AddressId] = [t1].[Id]
                RIGHT JOIN [dbo].[Person] AS [t0] ON [t0].[Id] = [t2].[PersonId]
            WHERE
                [t1].[Zip] = @P1
                AND
                [t1].[AddressType] = @P2;',N'@P1 varchar(10),@P2 int',@P1='94043',@P2=2
            */
        }

        ///<summary>https://dbexpression.com/docs/core-concepts/basics/join at line 88</summary>
        private void Joins_line_no_88()
        {
            logger.LogDebug("https://dbexpression.com/docs/core-concepts/basics/join at line 88");

            //select all address records for person with id equal 1
            IEnumerable<Address> addresses = db.SelectMany<Address>()
                .From(dbo.Address)
                .InnerJoin(dbo.PersonAddress).On(dbo.PersonAddress.AddressId == dbo.Address.Id)
                .Where(dbo.PersonAddress.PersonId == 1)
                .Execute();

            /*
            exec sp_executesql N'SELECT
                [t0].[Id],
                [t0].[AddressType],
                [t0].[Line1],
                [t0].[Line2],
                [t0].[City],
                [t0].[State],
                [t0].[Zip],
                [t0].[DateCreated],
                [t0].[DateUpdated]
            FROM
                [dbo].[Address] AS [t0]
                INNER JOIN [dbo].[Person_Address] AS [t1] ON [t1].[AddressId] = [t0].[Id]
            WHERE
                [t1].[PersonId] = @P1;',N'@P1 int',@P1=1
            */
        }

        ///<summary>https://dbexpression.com/docs/core-concepts/basics/join at line 118</summary>
        private void Joins_line_no_118()
        {
            logger.LogDebug("https://dbexpression.com/docs/core-concepts/basics/join at line 118");

            //select data set for people's purchases
            IEnumerable<dynamic> purchases = db.SelectMany(
                    dbo.Person.Id,
                    dbo.Person.FirstName,
                    dbo.Person.LastName,
                    dbo.Purchase.OrderNumber
                )
                .From(dbo.Person)
                .FullJoin(dbo.Purchase).On(dbo.Purchase.PersonId == dbo.Person.Id)
                .Execute();

            /*
            exec sp_executesql N'SELECT
                [t0].[Id],
                [t0].[FirstName],
                [t0].[LastName],
                [t1].[OrderNumber]
            FROM
                [dbo].[Person] AS [t0]
                FULL JOIN [dbo].[Purchase] AS [t1] ON [t1].[PersonId] = [t0].[Id];',N'@P1 float',@P1=0
            */
        }

        ///<summary>https://dbexpression.com/docs/core-concepts/basics/join at line 145</summary>
        private void Joins_line_no_145()
        {
            logger.LogDebug("https://dbexpression.com/docs/core-concepts/basics/join at line 145");

            //select all product combinations price totals
            IEnumerable<double> prices = db.SelectMany(
                    (dbo.Product.As("p1").Price + dbo.Product.As("p2").Price)
                )
                .From(dbo.Product.As("p1"))
                .CrossJoin(dbo.Product.As("p2"))
                .Execute();

            /*
            SELECT
                ([p1].[Price] + [p2].[Price])
            FROM
                [dbo].[Product] AS [p1]
                CROSS JOIN [dbo].[Product] AS [p2];
            */
        }

    }
}
