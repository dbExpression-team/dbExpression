using DocumentationExamples.DataService;
using DocumentationExamples.dboData;
using DocumentationExamples.dboDataService;
using DocumentationExamples.secDataService;
using DbExpression.MsSql.Expression;
using DbExpression.Sql;
using DbExpression.Sql.Builder.Alias;
using Microsoft.Extensions.Logging;

namespace DocumentationExamples.Core_concepts.Configuration
{
    ///<summary>Code examples from https://dbexpression.com/docs/core-concepts/configuration/enums</summary>
    public class Enums : IDocumentationExamples
    {
        private readonly ILogger<Enums> logger;

        public Enums(ILogger<Enums> logger)
        {
            this.logger = logger;
        }

        public void ExecuteExamples()
        {
            Enums_line_no_142();
        }

        ///<summary>https://dbexpression.com/docs/core-concepts/configuration/enums at line 142</summary>
        private void Enums_line_no_142()
        {
            logger.LogDebug("https://dbexpression.com/docs/core-concepts/configuration/enums at line 142");

            db.SelectOne(
                    dbo.Person.FirstName,
                    dbo.Person.LastName,
                    dbo.Address.AddressType
                )
                .From(dbo.Person)
                .LeftJoin(dbo.PersonAddress).On(dbo.Person.Id == dbo.PersonAddress.PersonId)
                .LeftJoin(dbo.Address).On(dbo.PersonAddress.AddressId == dbo.Address.Id)
                .Execute();

            /*
            SELECT TOP(1)
                [t0].[FirstName],
                [t0].[LastName],
                [t1].[AddressType]
            FROM
                [dbo].[Person] AS [t0]
                LEFT JOIN [dbo].[Person_Address] AS [t2] ON [t0].[Id] = [t2].[PersonId]
                LEFT JOIN [dbo].[Address] AS [t1] ON [t2].[AddressId] = [t1].[Id];
            */
        }

    }
}
