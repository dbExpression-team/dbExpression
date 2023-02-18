using DocumentationExamples.DataService;
using DocumentationExamples.dboData;
using DocumentationExamples.dboDataService;
using DocumentationExamples.secDataService;
using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder.Alias;
using Microsoft.Extensions.Logging;

namespace DocumentationExamples.Core_concepts.Aliasing
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
            	[_t0].[FirstName],
            	[_t0].[LastName],
            	ISNULL([_t1].[Type], @P1) AS [AddressType],
            	[_t1].[Count]
            FROM
            	[dbo].[Person] AS [_t0]
            	INNER JOIN (
            		SELECT
            			[_t2].[PersonId],
            			[_t1].[AddressType] AS [Type],
            			COUNT(*) AS [Count]
            		FROM
            			[dbo].[Address] AS [_t1]
            			INNER JOIN [dbo].[Person_Address] AS [_t2] ON [_t1].[Id] = [_t2].[AddressId]
            		GROUP BY
            			[_t2].[PersonId],
            			[_t1].[AddressType]
            	) AS [_t1] ON [_t0].[Id] = [_t1].[PersonId];',N'@P1 bigint',@P1=0
            */
        }

    }
}
