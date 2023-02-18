using DocumentationExamples.DataService;
using DocumentationExamples.dboData;
using DocumentationExamples.dboDataService;
using DocumentationExamples.secDataService;
using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder.Alias;
using Microsoft.Extensions.Logging;

namespace DocumentationExamples.Core_concepts.Utilities
{
    ///<summary>Code examples from https://dbexpression.com/docs/core-concepts/utilities/dbex</summary>
    public class dbex_utilities : IDocumentationExamples
    {
        private readonly ILogger<dbex_utilities> logger;

        public dbex_utilities(ILogger<dbex_utilities> logger)
        {
            this.logger = logger;
        }

        public void ExecuteExamples()
        {
            dbex_utilities_line_no_15();
            dbex_utilities_line_no_80();
            dbex_utilities_line_no_143();
            dbex_utilities_line_no_247();
            dbex_utilities_line_no_281();
            dbex_utilities_line_no_314();
            dbex_utilities_line_no_350();
            dbex_utilities_line_no_410();
        }

        ///<summary>https://dbexpression.com/docs/core-concepts/utilities/dbex at line 15</summary>
        private void dbex_utilities_line_no_15()
        {
            logger.LogDebug("https://dbexpression.com/docs/core-concepts/utilities/dbex at line 15");

            DateTime? value = db.SelectOne(
                db.fx.DateAdd(DateParts.Year, 1, db.fx.Cast(dbo.Person.CreditLimit).AsDateTime())
            ).From(dbo.Person)
            .Where(dbo.Person.CreditLimit == dbex.Null)
            .Execute();
            

            /*
            exec sp_executesql N'SELECT TOP(1)
                DATEADD(year, @P1, CAST([_t0].[CreditLimit] AS DateTime))
            FROM
                [dbo].[Person] AS [_t0]
            WHERE
                [_t0].[CreditLimit] IS NULL;',N'@P1 int',@P1=1
            */
        }

        ///<summary>https://dbexpression.com/docs/core-concepts/utilities/dbex at line 80</summary>
        private void dbex_utilities_line_no_80()
        {
            logger.LogDebug("https://dbexpression.com/docs/core-concepts/utilities/dbex at line 80");

            IEnumerable<Person> persons = db.SelectMany<Person>()
                .From(dbo.Person)
                .Execute(row =>
                    {
                        var person = new Person();
                        dbex.GetDefaultMappingFor(dbo.Person).Invoke(row, person);
                        if (DateTime.UtcNow.Year - person.YearOfLastCreditLimitReview > 5)
                        {
                            person.CreditLimit = 0;
                        }
                        return person;
                    }
                );

            /*
            SELECT
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
                [dbo].[Person] AS [_t0];
            */
        }

        ///<summary>https://dbexpression.com/docs/core-concepts/utilities/dbex at line 143</summary>
        private void dbex_utilities_line_no_143()
        {
            logger.LogDebug("https://dbexpression.com/docs/core-concepts/utilities/dbex at line 143");

            IEnumerable<(Person, StateType?)> persons = db.SelectMany(
                    dbex.SelectAllFor(dbo.Person),
                    dbo.Address.State
                )
                .From(dbo.Person)
                .LeftJoin(dbo.PersonAddress).On(dbo.Person.Id == dbo.PersonAddress.PersonId)
                .LeftJoin(dbo.Address).On(dbo.PersonAddress.AddressId == dbo.Address.Id & dbo.Address.AddressType == AddressType.Mailing)
                .Execute(row =>
                    {
                        var person = new Person();
                        dbex.GetDefaultMappingFor(dbo.Person).Invoke(row, person);
                        var state = row.ReadField()!.GetValue<StateType?>();
                        return (person, state);
                    }
                );

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
                [_t0].[DateUpdated],
                [_t1].[State]
            FROM
                [dbo].[Person] AS [_t0]
                LEFT JOIN [dbo].[Person_Address] AS [_t2] ON [_t0].[Id] = [_t2].[PersonId]
                LEFT JOIN [dbo].[Address] AS [_t1] ON [_t2].[AddressId] = [_t1].[Id]
                AND
                [_t1].[AddressType] = @P1;',N'@P1 int',@P1=1
            */
        }

        ///<summary>https://dbexpression.com/docs/core-concepts/utilities/dbex at line 247</summary>
        private void dbex_utilities_line_no_247()
        {
            logger.LogDebug("https://dbexpression.com/docs/core-concepts/utilities/dbex at line 247");

            IEnumerable<dynamic> person_purchases = db.SelectMany(
                    dbex.SelectAllFor(dbo.Person),
                    dbo.Purchase.Id.As("PurchaseId"),
                    dbo.Purchase.PurchaseDate
                )
                .From(dbo.Person)
                .InnerJoin(dbo.Purchase).On(dbo.Person.Id == dbo.Purchase.PersonId)
                .Execute();

            /*
            SELECT
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
                [_t0].[DateUpdated],
                [_t1].[Id] AS [PurchaseId],
                [_t1].[PurchaseDate]
            FROM
                [dbo].[Person] AS [_t0]
                INNER JOIN [dbo].[Purchase] AS [_t1] ON [_t0].[Id] = [_t1].[PersonId];
            */
        }

        ///<summary>https://dbexpression.com/docs/core-concepts/utilities/dbex at line 281</summary>
        private void dbex_utilities_line_no_281()
        {
            logger.LogDebug("https://dbexpression.com/docs/core-concepts/utilities/dbex at line 281");

            IEnumerable<dynamic> person_purchases = db.SelectMany(
                    dbex.SelectAllFor(dbo.Person, name => name == nameof(dbo.Person.Id) ? "PersonId" : name),
                    dbo.Purchase.Id,
                    dbo.Purchase.PurchaseDate
                )
                .From(dbo.Person)
                .InnerJoin(dbo.Purchase).On(dbo.Person.Id == dbo.Purchase.PersonId)
                .Execute();

            /*
            SELECT
                [_t0].[Id] AS [PersonId],
                [_t0].[FirstName],
                [_t0].[LastName],
                [_t0].[BirthDate],
                [_t0].[GenderType],
                [_t0].[CreditLimit],
                [_t0].[YearOfLastCreditLimitReview],
                [_t0].[RegistrationDate],
                [_t0].[LastLoginDate],
                [_t0].[DateCreated],
                [_t0].[DateUpdated],
                [_t1].[Id],
                [_t1].[PurchaseDate]
            FROM
                [dbo].[Person] AS [_t0]
                INNER JOIN [dbo].[Purchase] AS [_t1] ON [_t0].[Id] = [_t1].[PersonId];
            */
        }

        ///<summary>https://dbexpression.com/docs/core-concepts/utilities/dbex at line 314</summary>
        private void dbex_utilities_line_no_314()
        {
            logger.LogDebug("https://dbexpression.com/docs/core-concepts/utilities/dbex at line 314");

            IEnumerable<dynamic> person_purchases = db.SelectMany(
                    dbex.SelectAllFor(dbo.Person, "Person_"),
                    dbo.Purchase.Id,
                    dbo.Purchase.PurchaseDate
                )
                .From(dbo.Person)
                .InnerJoin(dbo.Purchase).On(dbo.Person.Id == dbo.Purchase.PersonId)
                .Execute();

            /*
            SELECT
                [_t0].[Id] AS [Person_Id],
                [_t0].[FirstName] AS [Person_FirstName],
                [_t0].[LastName] AS [Person_LastName],
                [_t0].[BirthDate] AS [Person_BirthDate],
                [_t0].[GenderType] AS [Person_GenderType],
                [_t0].[CreditLimit] AS [Person_CreditLimit],
                [_t0].[YearOfLastCreditLimitReview] AS [Person_YearOfLastCreditLimitReview],
                [_t0].[RegistrationDate] AS [Person_RegistrationDate],
                [_t0].[LastLoginDate] AS [Person_LastLoginDate],
                [_t0].[DateCreated] AS [Person_DateCreated],
                [_t0].[DateUpdated] AS [Person_DateUpdated],
                [_t1].[Id],
                [_t1].[PurchaseDate]
            FROM
                [dbo].[Person] AS [_t0]
                INNER JOIN [dbo].[Purchase] AS [_t1] ON [_t0].[Id] = [_t1].[PersonId];
            */
        }

        ///<summary>https://dbexpression.com/docs/core-concepts/utilities/dbex at line 350</summary>
        private void dbex_utilities_line_no_350()
        {
            logger.LogDebug("https://dbexpression.com/docs/core-concepts/utilities/dbex at line 350");

            static string alias(string entity, string name)
                {
                    switch (name)
                    {
                        case nameof(dbo.Person.Id):
                        case nameof(dbo.Person.DateCreated):
                        case nameof(dbo.Person.DateUpdated):
                        case nameof(dbo.Purchase.PersonId): return $"{entity}_{name}";
                        default: return name;
                    }
                };
            
            IEnumerable<dynamic> person_purchases = db.SelectMany(
                    dbex.SelectAllFor(dbo.Person, name => alias(nameof(Person), name))
                    .Concat(dbex.SelectAllFor(dbo.Purchase, name => alias(nameof(Purchase), name)))
                    // ^ LINQ concat, not database concat function
                )
                .From(dbo.Person)
                .InnerJoin(dbo.Purchase).On(dbo.Person.Id == dbo.Purchase.PersonId)
                .Execute();

            /*
            SELECT
                [_t0].[Id] AS [Person_Id],
                [_t0].[FirstName],
                [_t0].[LastName],
                [_t0].[BirthDate],
                [_t0].[GenderType],
                [_t0].[CreditLimit],
                [_t0].[YearOfLastCreditLimitReview],
                [_t0].[RegistrationDate],
                [_t0].[LastLoginDate],
                [_t0].[DateCreated] AS [Person_DateCreated],
                [_t0].[DateUpdated] AS [Person_DateUpdated],
                [_t1].[Id] AS [Purchase_Id],
                [_t1].[PersonId] AS [Purchase_PersonId],
                [_t1].[OrderNumber],
                [_t1].[TotalPurchaseQuantity],
                [_t1].[TotalPurchaseAmount],
                [_t1].[PurchaseDate],
                [_t1].[ShipDate],
                [_t1].[ExpectedDeliveryDate],
                [_t1].[TrackingIdentifier],
                [_t1].[PaymentMethodType],
                [_t1].[PaymentSourceType],
                [_t1].[DateCreated] AS [Purchase_DateCreated],
                [_t1].[DateUpdated] AS [Purchase_DateUpdated]
            FROM
                [dbo].[Person] AS [_t0]
                INNER JOIN [dbo].[Purchase] AS [_t1] ON [_t0].[Id] = [_t1].[PersonId];
            */
        }

        ///<summary>https://dbexpression.com/docs/core-concepts/utilities/dbex at line 410</summary>
        private void dbex_utilities_line_no_410()
        {
            logger.LogDebug("https://dbexpression.com/docs/core-concepts/utilities/dbex at line 410");

            
            int personId = 1;
            
            var personWithChanges = db.SelectOne<Person>()
                 .From(dbo.Person)
                 .Where(dbo.Person.Id == personId)
                 .Execute();
            
            //change some properties on the person instance
            personWithChanges!.CreditLimit = 5000;
            personWithChanges.YearOfLastCreditLimitReview = DateTime.UtcNow.Year;
            
            
            var persistedState = db.SelectOne<Person>()
                .From(dbo.Person)
                .Where(dbo.Person.Id == personId)
                .Execute();
            
            var fieldUpdates = dbex.BuildAssignmentsFor(dbo.Person).From(persistedState!).To(personWithChanges);
            
            //update based on the comparison.  updateFields will contain a SET for CreditLimit and YearOfLastCreditLimitReview
            db.Update(
                    fieldUpdates
                )
                .From(dbo.Person)
                .Where(dbo.Person.Id == personId)
                .Execute();

            /*
            exec sp_executesql N'PDATE
                [_t0]
            SET
                [_t0].[CreditLimit] = @P1,
                [_t0].[YearOfLastCreditLimitReview] = @P2
            FROM
                [dbo].[Person] AS [_t0]
            WHERE
                [_t0].[Id] = @P3;
            SELECT @@ROWCOUNT;',N'@P1 int,@P2 int,@P3 int',@P1=5000,@P2=2021,@P3=1
            */
        }

    }
}
