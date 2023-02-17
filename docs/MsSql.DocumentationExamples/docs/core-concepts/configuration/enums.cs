using DbEx.DataService;
using DbEx.dboData;
using DbEx.dboDataService;
using DbEx.secDataService;
using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder.Alias;
using Microsoft.Extensions.Logging;

namespace MsSql.DocumentationExamples.Core_concepts.Configuration
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
                [_t0].[FirstName],
                [_t0].[LastName],
                [_t1].[AddressType]
            FROM
                [dbo].[Person] AS [_t0]
                LEFT JOIN [dbo].[Person_Address] AS [_t2] ON [_t0].[Id] = [_t2].[PersonId]
                LEFT JOIN [dbo].[Address] AS [_t1] ON [_t2].[AddressId] = [_t1].[Id];
            */
        }

    }
}
