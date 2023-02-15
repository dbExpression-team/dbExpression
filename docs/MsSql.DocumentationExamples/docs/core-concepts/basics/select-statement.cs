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
    ///<summary>Code examples from https://dbexpression.com/docs/core-concepts/basics/select-statement</summary>
    public class Select_Statements : IDocumentationExamples
    {
        private readonly ILogger<Select_Statements> logger;

        public Select_Statements(ILogger<Select_Statements> logger)
        {
            this.logger = logger;
        }

        public void ExecuteExamples()
        {
            Select_Statements_line_no_29();
            Select_Statements_line_no_60();
            Select_Statements_line_no_93();
            Select_Statements_line_no_112();
            Select_Statements_line_no_139();
            Select_Statements_line_no_166();
        }

        ///<summary>https://dbexpression.com/docs/core-concepts/basics/select-statement at line 29</summary>
        private void Select_Statements_line_no_29()
        {
            logger.LogDebug("https://dbexpression.com/docs/core-concepts/basics/select-statement at line 29");

            Person? person = db.SelectOne<Person>()
                .From(dbo.Person)
                .Where(dbo.Person.Id == 1)
                .Execute();

            /*
            exec sp_executesql N'SELECT TOP(1)
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
                [dbo].[Person].[Id] = @P1;',N'@P1 int',@P1=1
            */
        }

        ///<summary>https://dbexpression.com/docs/core-concepts/basics/select-statement at line 60</summary>
        private void Select_Statements_line_no_60()
        {
            logger.LogDebug("https://dbexpression.com/docs/core-concepts/basics/select-statement at line 60");

            IEnumerable<Person> people = db.SelectMany<Person>()
                .From(dbo.Person)
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

        ///<summary>https://dbexpression.com/docs/core-concepts/basics/select-statement at line 93</summary>
        private void Select_Statements_line_no_93()
        {
            logger.LogDebug("https://dbexpression.com/docs/core-concepts/basics/select-statement at line 93");

            string? firstName = db.SelectOne(dbo.Person.FirstName)
                .From(dbo.Person)
                .Where(dbo.Person.Id == 1)
                .Execute();

            /*
            exec sp_executesql N'SELECT TOP(1)
                [dbo].[Person].[FirstName]
            FROM
                [dbo].[Person]
            WHERE
                [dbo].[Person].[Id] = @P1;',N'@P1 int',@P1=1
            */
        }

        ///<summary>https://dbexpression.com/docs/core-concepts/basics/select-statement at line 112</summary>
        private void Select_Statements_line_no_112()
        {
            logger.LogDebug("https://dbexpression.com/docs/core-concepts/basics/select-statement at line 112");

            IEnumerable<string> firstNames = db.SelectMany(dbo.Person.FirstName)
                .From(dbo.Person)
                .Where(dbo.Person.LastName == "Cartman")
                .Execute();

            /*
            exec sp_executesql N'SELECT
                [dbo].[Person].[FirstName]
            FROM
                [dbo].[Person]
            WHERE
                [dbo].[Person].[LastName] = @P1;',N'@P1 varchar(20)',@P1='Cartman'
            */
        }

        ///<summary>https://dbexpression.com/docs/core-concepts/basics/select-statement at line 139</summary>
        private void Select_Statements_line_no_139()
        {
            logger.LogDebug("https://dbexpression.com/docs/core-concepts/basics/select-statement at line 139");

            dynamic? record = db.SelectOne(
                	dbo.Person.Id,
                	dbo.Person.FirstName,
                	dbo.Person.LastName
                )
                .From(dbo.Person)
                .Where(dbo.Person.Id == 1)
                .Execute();

            /*
            exec sp_executesql N'SELECT TOP(1)
                [dbo].[Person].[Id],
                [dbo].[Person].[FirstName],
                [dbo].[Person].[LastName]
            FROM
                [dbo].[Person]
            WHERE
                [dbo].[Person].[Id] = @P1;',N'@P1 int',@P1=1
            */
        }

        ///<summary>https://dbexpression.com/docs/core-concepts/basics/select-statement at line 166</summary>
        private void Select_Statements_line_no_166()
        {
            logger.LogDebug("https://dbexpression.com/docs/core-concepts/basics/select-statement at line 166");

            IEnumerable<dynamic> records = db.SelectMany(
                    dbo.Person.Id,
                    dbo.Person.FirstName,
                    dbo.Person.LastName
                )
                .From(dbo.Person)
                .Where(dbo.Person.LastName == "Cartman")
                .Execute();

            /*
            exec sp_executesql N'SELECT
                [dbo].[Person].[Id],
                [dbo].[Person].[FirstName],
                [dbo].[Person].[LastName]
            FROM
                [dbo].[Person]
            WHERE
                [dbo].[Person].[LastName] = @P1;',N'@P1 varchar(20)',@P1='Cartman'
            */
        }

    }
}
