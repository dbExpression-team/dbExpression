using DbEx.DataService;
using DbEx.dboData;
using DbEx.dboDataService;
using DbEx.secDataService;
using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder.Alias;
using Microsoft.Extensions.Logging;

namespace MsSql.DocumentationExamples.Core_concepts.Filters
{
    ///<summary>Code examples from https://dbexpression.com/docs/core-concepts/filters/filter-expressions</summary>
    public class Filter_Expressions : IDocumentationExamples
    {
        private readonly ILogger<Filter_Expressions> logger;

        public Filter_Expressions(ILogger<Filter_Expressions> logger)
        {
            this.logger = logger;
        }

        public void ExecuteExamples()
        {
            Filter_Expressions_line_no_13();
            Filter_Expressions_line_no_32();
            Filter_Expressions_line_no_62();
            Filter_Expressions_line_no_91();
            Filter_Expressions_line_no_120();
            Filter_Expressions_line_no_155();
            Filter_Expressions_line_no_197();
            Filter_Expressions_line_no_221();
            Filter_Expressions_line_no_253();
            Filter_Expressions_line_no_285();
            Filter_Expressions_line_no_321();
            Filter_Expressions_line_no_346();
        }

        ///<summary>https://dbexpression.com/docs/core-concepts/filters/filter-expressions at line 13</summary>
        private void Filter_Expressions_line_no_13()
        {
            logger.LogDebug("https://dbexpression.com/docs/core-concepts/filters/filter-expressions at line 13");

            DateTimeOffset registration = db.SelectOne(dbo.Person.RegistrationDate)
                .From(dbo.Person)
                //int field expression comparison to int literal value
                .Where(dbo.Person.Id == 1)
                .Execute();

            /*
            exec sp_executesql N'SELECT TOP(1)
            	[dbo].[Person].[RegistrationDate]
            FROM
            	[dbo].[Person]
            WHERE
            	[dbo].[Person].[Id] = @P1;',N'@P1 int',@P1=1
            */
        }

        ///<summary>https://dbexpression.com/docs/core-concepts/filters/filter-expressions at line 32</summary>
        private void Filter_Expressions_line_no_32()
        {
            logger.LogDebug("https://dbexpression.com/docs/core-concepts/filters/filter-expressions at line 32");

            var yesterday = DateTime.Now.Date.AddDays(-1);
            IEnumerable<Person> people = db.SelectMany<Person>()
                .From(dbo.Person)
                //DateTime field expression comparison to DateTime literal value
                .Where(dbo.Person.LastLoginDate > yesterday)
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
            WHERE
            	[dbo].[Person].[LastLoginDate] > @P1;',N'@P1 datetimeoffset(7)',@P1='2021-04-14 00:00:00 -05:00'
            */
        }

        ///<summary>https://dbexpression.com/docs/core-concepts/filters/filter-expressions at line 62</summary>
        private void Filter_Expressions_line_no_62()
        {
            logger.LogDebug("https://dbexpression.com/docs/core-concepts/filters/filter-expressions at line 62");

            IEnumerable<Person> people = db.SelectMany<Person>()
                .From(dbo.Person)
                //string field expression comparison to string literal value
                .Where(dbo.Person.LastName == "Cartman")
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
            WHERE
            	[dbo].[Person].[LastName] = @P1;',N'@P1 varchar(20)',@P1='Cartman'
            */
        }

        ///<summary>https://dbexpression.com/docs/core-concepts/filters/filter-expressions at line 91</summary>
        private void Filter_Expressions_line_no_91()
        {
            logger.LogDebug("https://dbexpression.com/docs/core-concepts/filters/filter-expressions at line 91");

            IEnumerable<Person> people = db.SelectMany<Person>()
                .From(dbo.Person)
                //string field expression comparison to string field expression
                .Where(dbo.Person.FirstName == dbo.Person.LastName)
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
            WHERE
            	[dbo].[Person].[FirstName] = [dbo].[Person].[LastName];
            */
        }

        ///<summary>https://dbexpression.com/docs/core-concepts/filters/filter-expressions at line 120</summary>
        private void Filter_Expressions_line_no_120()
        {
            logger.LogDebug("https://dbexpression.com/docs/core-concepts/filters/filter-expressions at line 120");

            IEnumerable<Person> people = db.SelectMany<Person>()
               .From(dbo.Person)
               //logical And
               .Where(
                   dbo.Person.YearOfLastCreditLimitReview > DateTime.Now.AddYears(-1).Year
                   &
                   dbo.Person.CreditLimit >= 25000
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
            WHERE
            	[dbo].[Person].[YearOfLastCreditLimitReview] > @P1
            	AND
            	[dbo].[Person].[CreditLimit] >= @P2;',N'@P1 int,@P2 int',@P1=2020,@P2=25000
            */
        }

        ///<summary>https://dbexpression.com/docs/core-concepts/filters/filter-expressions at line 155</summary>
        private void Filter_Expressions_line_no_155()
        {
            logger.LogDebug("https://dbexpression.com/docs/core-concepts/filters/filter-expressions at line 155");

            IEnumerable<Person> people = db.SelectMany<Person>()
                .From(dbo.Person)
                //logical Or
                .Where(
                    dbo.Person.LastName == "Broflovski"
                    |
                    dbo.Person.LastName == "Cartman"
                    |
                    dbo.Person.LastName == "McCormick"
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
            WHERE
            	(
            		[dbo].[Person].[LastName] = @P1
            		OR
            		[dbo].[Person].[LastName] = @P2
            	)
            	OR
            	[dbo].[Person].[LastName] = @P3;',N'@P1 varchar(20),@P2 varchar(20),@P3 varchar(20)',@P1='Broflovski',@P2='Cartman',@P3='McCormick'
            */
        }

        ///<summary>https://dbexpression.com/docs/core-concepts/filters/filter-expressions at line 197</summary>
        private void Filter_Expressions_line_no_197()
        {
            logger.LogDebug("https://dbexpression.com/docs/core-concepts/filters/filter-expressions at line 197");

            IEnumerable<dynamic> person_totals = db.SelectMany(
                    dbo.Person.Id,
                    db.fx.Sum(dbo.Purchase.TotalPurchaseAmount).As("LifetimeValue")
                )
                .From(dbo.Person)
                //int field expression comparison to int field expression
                .InnerJoin(dbo.Purchase).On(dbo.Person.Id == dbo.Purchase.PersonId)
                .GroupBy(dbo.Person.Id)
                .Execute();

            /*
            SELECT
            	[dbo].[Person].[Id],
            	SUM([dbo].[Purchase].[TotalPurchaseAmount]) AS [LifetimeValue]
            FROM
            	[dbo].[Person]
            	INNER JOIN [dbo].[Purchase] ON [dbo].[Person].[Id] = [dbo].[Purchase].[PersonId]
            GROUP BY
            	[dbo].[Person].[Id];
            */
        }

        ///<summary>https://dbexpression.com/docs/core-concepts/filters/filter-expressions at line 221</summary>
        private void Filter_Expressions_line_no_221()
        {
            logger.LogDebug("https://dbexpression.com/docs/core-concepts/filters/filter-expressions at line 221");

            IEnumerable<dynamic> person_zips = db.SelectMany(
                    dbo.Person.Id,
                    dbo.Address.Zip
                )
                .From(dbo.Person)
                //int field expression comparison to int field expression
                .InnerJoin(dbo.PersonAddress).On(dbo.Person.Id == dbo.PersonAddress.PersonId)
                //int field expression comparison to int field expression AND enum field expression comparison to literal enum value
                .InnerJoin(dbo.Address).On(
                    dbo.PersonAddress.AddressId == dbo.Address.Id
                    &
                    dbo.Address.AddressType == AddressType.Mailing
                )
                .Execute();

            /*
            exec sp_executesql N'SELECT
            	[dbo].[Person].[Id],
            	[dbo].[Address].[Zip]
            FROM
            	[dbo].[Person]
            	INNER JOIN [dbo].[Person_Address] ON [dbo].[Person].[Id] = [dbo].[Person_Address].[PersonId]
            	INNER JOIN [dbo].[Address] ON [dbo].[Person_Address].[AddressId] = [dbo].[Address].[Id]
            	AND
            	[dbo].[Address].[AddressType] = @P1;',N'@P1 int',@P1=1
            */
        }

        ///<summary>https://dbexpression.com/docs/core-concepts/filters/filter-expressions at line 253</summary>
        private void Filter_Expressions_line_no_253()
        {
            logger.LogDebug("https://dbexpression.com/docs/core-concepts/filters/filter-expressions at line 253");

            IEnumerable<dynamic> people = db.SelectMany(
                    dbo.Person.LastName,
                    db.fx.Count(dbo.Person.Id).As("LastNameCount")
                )
                .From(dbo.Person)
                .GroupBy(dbo.Person.LastName)
                //aggregate function comparison to int literal value
                .Having(
                    db.fx.Count(dbo.Person.Id) > 1
                )
                .Execute();

            /*
            exec sp_executesql N'SELECT
            	[dbo].[Person].[LastName],
            	COUNT([dbo].[Person].[Id]) AS [LastNameCount]
            FROM
            	[dbo].[Person]
            GROUP BY
            	[dbo].[Person].[LastName]
            HAVING
            	COUNT([dbo].[Person].[Id]) > @P1;',N'@P1 int',@P1=1
            */
        }

        ///<summary>https://dbexpression.com/docs/core-concepts/filters/filter-expressions at line 285</summary>
        private void Filter_Expressions_line_no_285()
        {
            logger.LogDebug("https://dbexpression.com/docs/core-concepts/filters/filter-expressions at line 285");

            IEnumerable<Product> products = db.SelectMany<Product>()
                .From(dbo.Product)
                .Where(
                    ((dbo.Product.Quantity * dbo.Product.ListPrice) - (dbo.Product.Quantity * dbo.Product.Price)) > 1000
                )
                .Execute();

            /*
            exec sp_executesql N'SELECT
            	[dbo].[Product].[Id],
            	[dbo].[Product].[ProductCategoryType],
            	[dbo].[Product].[Name],
            	[dbo].[Product].[Description],
            	[dbo].[Product].[ListPrice],
            	[dbo].[Product].[Price],
            	[dbo].[Product].[Quantity],
            	[dbo].[Product].[Image],
            	[dbo].[Product].[Height],
            	[dbo].[Product].[Width],
            	[dbo].[Product].[Depth],
            	[dbo].[Product].[Weight],
            	[dbo].[Product].[ShippingWeight],
            	[dbo].[Product].[ValidStartTimeOfDayForPurchase],
            	[dbo].[Product].[ValidEndTimeOfDayForPurchase],
            	[dbo].[Product].[DateCreated],
            	[dbo].[Product].[DateUpdated]
            FROM
            	[dbo].[Product]
            WHERE
            	(([dbo].[Product].[Quantity] * [dbo].[Product].[ListPrice]) - ([dbo].[Product].[Quantity] * [dbo].[Product].[Price])) > @P1;',N'@P1 float',@P1=1000
            */
        }

        ///<summary>https://dbexpression.com/docs/core-concepts/filters/filter-expressions at line 321</summary>
        private void Filter_Expressions_line_no_321()
        {
            logger.LogDebug("https://dbexpression.com/docs/core-concepts/filters/filter-expressions at line 321");

            IEnumerable<dynamic> purchases = db.SelectMany(
                    dbo.Purchase.OrderNumber,
                    dbo.PurchaseLine.PurchasePrice,
                    dbo.PurchaseLine.Quantity
                )
                .From(dbo.PurchaseLine)
                .InnerJoin(dbo.Purchase).On(dbo.PurchaseLine.PurchaseId == dbo.Purchase.Id & dbo.Purchase.TotalPurchaseAmount > 100)
                .Execute();

            /*
            exec sp_executesql N'SELECT
            	[dbo].[Purchase].[OrderNumber],
            	[dbo].[PurchaseLine].[PurchasePrice],
            	[dbo].[PurchaseLine].[Quantity]
            FROM
            	[dbo].[PurchaseLine]
            	INNER JOIN [dbo].[Purchase] ON [dbo].[PurchaseLine].[PurchaseId] = [dbo].[Purchase].[Id]
            	AND
            	[dbo].[Purchase].[TotalPurchaseAmount] > @P1;',N'@P1 money',@P1=$100.0000
            */
        }

        ///<summary>https://dbexpression.com/docs/core-concepts/filters/filter-expressions at line 346</summary>
        private void Filter_Expressions_line_no_346()
        {
            logger.LogDebug("https://dbexpression.com/docs/core-concepts/filters/filter-expressions at line 346");

            IEnumerable<dynamic> purchases = db.SelectMany(
                    dbo.Purchase.OrderNumber,
                    db.fx.Sum(dbo.PurchaseLine.PurchasePrice)
                )
                .From(dbo.PurchaseLine)
                .InnerJoin(dbo.Purchase).On(dbo.PurchaseLine.PurchaseId == dbo.Purchase.Id)
                .GroupBy(dbo.Purchase.OrderNumber)
                .Having(db.fx.Sum(dbo.PurchaseLine.PurchasePrice) > 100)
                .Execute();

            /*
            exec sp_executesql N'SELECT
            	[dbo].[Purchase].[OrderNumber],
            	SUM([dbo].[PurchaseLine].[PurchasePrice])
            FROM
            	[dbo].[PurchaseLine]
            	INNER JOIN [dbo].[Purchase] ON [dbo].[PurchaseLine].[PurchaseId] = [dbo].[Purchase].[Id]
            GROUP BY
            	[dbo].[Purchase].[OrderNumber]
            HAVING
            	SUM([dbo].[PurchaseLine].[PurchasePrice]) > @P1;',N'@P1 decimal(3,0)',@P1=100
            */
        }

    }
}
