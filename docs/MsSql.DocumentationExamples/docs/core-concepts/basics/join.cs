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
            Joins_line_no_146();
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
                LEFT JOIN [dbo].[Person_Address] ON [dbo].[Person_Address].[PersonId] = [dbo].[Person].[Id]
            WHERE
                [dbo].[Person_Address].[Id] IS NULL;
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
                [dbo].[Person].[Id],
                [dbo].[Person].[FirstName],
                [dbo].[Person].[LastName],
                [dbo].[Person].[CreditLimit],
                [dbo].[Person].[YearOfLastCreditLimitReview]
            FROM
                [dbo].[Address]
                RIGHT JOIN [dbo].[Person_Address] ON [dbo].[Person_Address].[AddressId] = [dbo].[Address].[Id]
                RIGHT JOIN [dbo].[Person] ON [dbo].[Person].[Id] = [dbo].[Person_Address].[PersonId]
            WHERE
                [dbo].[Address].[Zip] = @P1
                AND
                [dbo].[Address].[AddressType] = @P2;',N'@P1 varchar(10),@P2 int',@P1='94043',@P2=2
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
            	[dbo].[Address].[Id],
            	[dbo].[Address].[AddressType],
            	[dbo].[Address].[Line1],
            	[dbo].[Address].[Line2],
            	[dbo].[Address].[City],
            	[dbo].[Address].[State],
            	[dbo].[Address].[Zip],
            	[dbo].[Address].[DateCreated],
            	[dbo].[Address].[DateUpdated]
            FROM
            	[dbo].[Address]
            	INNER JOIN [dbo].[Person_Address] ON [dbo].[Person_Address].[AddressId] = [dbo].[Address].[Id]
            WHERE
            	[dbo].[Person_Address].[PersonId] = @P1;',N'@P1 int',@P1=1
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
                [dbo].[Person].[Id],
                [dbo].[Person].[FirstName],
                [dbo].[Person].[LastName],
                [dbo].[Purchase].[OrderNumber],
                ISNULL([dbo].[Purchase].[TotalPurchaseAmount], @P1) AS [PurchaseAmount]
            FROM
                [dbo].[Person]
                FULL JOIN [dbo].[Purchase] ON [dbo].[Purchase].[PersonId] = [dbo].[Person].[Id];',N'@P1 float',@P1=0
            */
        }

        ///<summary>https://dbexpression.com/docs/core-concepts/basics/join at line 146</summary>
        private void Joins_line_no_146()
        {
            logger.LogDebug("https://dbexpression.com/docs/core-concepts/basics/join at line 146");

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
