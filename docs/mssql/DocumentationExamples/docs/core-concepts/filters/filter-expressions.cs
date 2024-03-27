using DocumentationExamples.DataService;
using DocumentationExamples.dboData;
using DocumentationExamples.dboDataService;
using DocumentationExamples.secDataService;
using DbExpression.MsSql.Expression;
using DbExpression.Sql;
using DbExpression.Sql.Builder.Alias;
using Microsoft.Extensions.Logging;

namespace DocumentationExamples.Core_concepts.Filters
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
            Filter_Expressions_line_no_195();
            Filter_Expressions_line_no_219();
            Filter_Expressions_line_no_251();
            Filter_Expressions_line_no_283();
            Filter_Expressions_line_no_319();
            Filter_Expressions_line_no_344();
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
            	[t0].[RegistrationDate]
            FROM
            	[dbo].[Person] AS [t0]
            WHERE
            	[t0].[Id] = @P1;',N'@P1 int',@P1=1
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
            WHERE
            	[t0].[LastLoginDate] > @P1;',N'@P1 datetimeoffset(7)',@P1='2021-04-14 00:00:00 -05:00'
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
            WHERE
            	[t0].[LastName] = @P1;',N'@P1 varchar(20)',@P1='Cartman'
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
            WHERE
            	[t0].[FirstName] = [t0].[LastName];
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
            WHERE
            	[t0].[YearOfLastCreditLimitReview] > @P1
            	AND
            	[t0].[CreditLimit] >= @P2;',N'@P1 int,@P2 int',@P1=2020,@P2=25000
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
            exec sp_executesql N'SSELECT
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
            WHERE
            	[t0].[LastName] = @P1
            	OR
            	[t0].[LastName] = @P2
            	OR
            	[t0].[LastName] = @P3;',N'@P1 varchar(20),@P2 varchar(20),@P3 varchar(20)',@P1='Broflovski',@P2='Cartman',@P3='McCormick'
            */
        }

        ///<summary>https://dbexpression.com/docs/core-concepts/filters/filter-expressions at line 195</summary>
        private void Filter_Expressions_line_no_195()
        {
            logger.LogDebug("https://dbexpression.com/docs/core-concepts/filters/filter-expressions at line 195");

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
            	[t0].[Id],
            	SUM([t1].[TotalPurchaseAmount]) AS [LifetimeValue]
            FROM
            	[dbo].[Person] AS [t0]
            	INNER JOIN [dbo].[Purchase] AS [t1] ON [t0].[Id] = [t1].[PersonId]
            GROUP BY
            	[t0].[Id];
            */
        }

        ///<summary>https://dbexpression.com/docs/core-concepts/filters/filter-expressions at line 219</summary>
        private void Filter_Expressions_line_no_219()
        {
            logger.LogDebug("https://dbexpression.com/docs/core-concepts/filters/filter-expressions at line 219");

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
            	[t0].[Id],
            	[t1].[Zip]
            FROM
            	[dbo].[Person] AS [t0]
            	INNER JOIN [dbo].[Person_Address] AS [t2] ON [t0].[Id] = [t2].[PersonId]
            	INNER JOIN [dbo].[Address] AS [t1] ON [t2].[AddressId] = [t1].[Id]
            	AND
            	[t1].[AddressType] = @P1;',N'@P1 int',@P1=1
            */
        }

        ///<summary>https://dbexpression.com/docs/core-concepts/filters/filter-expressions at line 251</summary>
        private void Filter_Expressions_line_no_251()
        {
            logger.LogDebug("https://dbexpression.com/docs/core-concepts/filters/filter-expressions at line 251");

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
            	[t0].[LastName],
            	COUNT([t0].[Id]) AS [LastNameCount]
            FROM
            	[dbo].[Person] AS [t0]
            GROUP BY
            	[t0].[LastName]
            HAVING
            	COUNT([t0].[Id]) > @P1;',N'@P1 int',@P1=1
            */
        }

        ///<summary>https://dbexpression.com/docs/core-concepts/filters/filter-expressions at line 283</summary>
        private void Filter_Expressions_line_no_283()
        {
            logger.LogDebug("https://dbexpression.com/docs/core-concepts/filters/filter-expressions at line 283");

            IEnumerable<Product> products = db.SelectMany<Product>()
                .From(dbo.Product)
                .Where(
                    ((dbo.Product.Quantity * dbo.Product.ListPrice) - (dbo.Product.Quantity * dbo.Product.Price)) > 1000
                )
                .Execute();

            /*
            exec sp_executesql N'SELECT
            	[t0].[Id],
            	[t0].[ProductCategoryType],
            	[t0].[Name],
            	[t0].[Description],
            	[t0].[ListPrice],
            	[t0].[Price],
            	[t0].[Quantity],
            	[t0].[Image],
            	[t0].[Height],
            	[t0].[Width],
            	[t0].[Depth],
            	[t0].[Weight],
            	[t0].[ShippingWeight],
            	[t0].[ValidStartTimeOfDayForPurchase],
            	[t0].[ValidEndTimeOfDayForPurchase],
            	[t0].[DateCreated],
            	[t0].[DateUpdated]
            FROM
            	[dbo].[Product] AS [t0]
            WHERE
            	(([t0].[Quantity] * [t0].[ListPrice]) - ([t0].[Quantity] * [t0].[Price])) > @P1;',N'@P1 float',@P1=1000
            */
        }

        ///<summary>https://dbexpression.com/docs/core-concepts/filters/filter-expressions at line 319</summary>
        private void Filter_Expressions_line_no_319()
        {
            logger.LogDebug("https://dbexpression.com/docs/core-concepts/filters/filter-expressions at line 319");

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
                    [t0].[OrderNumber],
                    [t1].[PurchasePrice],
                    [t1].[Quantity]
                  FROM
                    [dbo].[PurchaseLine] AS [t1]
                    INNER JOIN [dbo].[Purchase] AS [t0] ON [t1].[PurchaseId] = [t0].[Id]
                    AND
                    [t0].[TotalPurchaseAmount] > @P1;',N'@P1 money',@P1=$100.0000
            */
        }

        ///<summary>https://dbexpression.com/docs/core-concepts/filters/filter-expressions at line 344</summary>
        private void Filter_Expressions_line_no_344()
        {
            logger.LogDebug("https://dbexpression.com/docs/core-concepts/filters/filter-expressions at line 344");

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
            	[t0].[OrderNumber],
            	SUM([t1].[PurchasePrice])
            FROM
            	[dbo].[PurchaseLine] AS [t1]
            	INNER JOIN [dbo].[Purchase] AS [t0] ON [t1].[PurchaseId] = [t0].[Id]
            GROUP BY
            	[t0].[OrderNumber]
            HAVING
            	SUM([t1].[PurchasePrice]) > @P1;',N'@P1 decimal(3,0)',@P1=100
            */
        }

    }
}
