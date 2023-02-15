using DbEx.DataService;
using DbEx.dboData;
using DbEx.dboDataService;
using DbEx.secDataService;
using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder.Alias;
using Microsoft.Extensions.Logging;

namespace MsSql.DocumentationExamples.Core_concepts.Aliasing
{
    ///<summary>Code examples from https://dbexpression.com/docs/core-concepts/aliasing/composition</summary>
    public class Aliasing_the_Composition_of_Elements : IDocumentationExamples
    {
        private readonly ILogger<Aliasing_the_Composition_of_Elements> logger;

        public Aliasing_the_Composition_of_Elements(ILogger<Aliasing_the_Composition_of_Elements> logger)
        {
            this.logger = logger;
        }

        public void ExecuteExamples()
        {
            Aliasing_the_Composition_of_Elements_line_no_20();
        }

        ///<summary>https://dbexpression.com/docs/core-concepts/aliasing/composition at line 20</summary>
        private void Aliasing_the_Composition_of_Elements_line_no_20()
        {
            logger.LogDebug("https://dbexpression.com/docs/core-concepts/aliasing/composition at line 20");

            IEnumerable<dynamic> address_stats = db.SelectMany(
                    dbo.Person.FirstName,
                    dbo.Person.LastName,
                    db.fx.IsNull(("Address", "Type"), AddressType.Shipping).As("AddressType"),
                    dbex.Alias<int>("Address", "Count")
                )
                .From(dbo.Person)
                .InnerJoin(
                    db.SelectMany(
                        dbo.PersonAddress.PersonId,
                        dbo.Address.AddressType.As("Type"),
                        db.fx.Count().As("Count")
                    ).From(dbo.Address)
                    .InnerJoin(dbo.PersonAddress).On(dbo.Address.Id == dbo.PersonAddress.AddressId)
                    .GroupBy(
                        dbo.PersonAddress.PersonId,
                        dbo.Address.AddressType
                    )
                ).As("Address").On(dbo.Person.Id == ("Address", "PersonId"))
                .Execute();

            /*
            exec sp_executesql N'SELECT
            	[dbo].[Person].[FirstName],
            	[dbo].[Person].[LastName],
            	ISNULL([Address].[Type], @P1) AS [AddressType],
            	[Address].[Count]
            FROM
            	[dbo].[Person]
            	INNER JOIN (
            		SELECT
            			[dbo].[Person_Address].[PersonId],
            			[dbo].[Address].[AddressType] AS [Type],
            			COUNT(@P2) AS [Count]
            		FROM
            			[dbo].[Address]
            			INNER JOIN [dbo].[Person_Address] ON [dbo].[Address].[Id] = [dbo].[Person_Address].[AddressId]
            		GROUP BY
            			[dbo].[Person_Address].[PersonId],
            			[dbo].[Address].[AddressType]
            	) AS [Address] ON [dbo].[Person].[Id] = [Address].[PersonId];',N'@P1 bigint,@P2 char(1)',@P1=0,@P2='*'
            
            */
        }

    }
}
