using DocumentationExamples.DataService;
using DocumentationExamples.dboData;
using DocumentationExamples.dboDataService;
using DocumentationExamples.secDataService;
using DbExpression.MsSql.Expression;
using DbExpression.Sql;
using DbExpression.Sql.Builder.Alias;
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
            	[t0].[FirstName],
            	[t0].[LastName],
            	ISNULL([t1].[Type], @P1) AS [AddressType],
            	[t1].[Count]
            FROM
            	[dbo].[Person] AS [t0]
            	INNER JOIN (
            		SELECT
            			[t2].[PersonId],
            			[t1].[AddressType] AS [Type],
            			COUNT(*) AS [Count]
            		FROM
            			[dbo].[Address] AS [t1]
            			INNER JOIN [dbo].[Person_Address] AS [t2] ON [t1].[Id] = [t2].[AddressId]
            		GROUP BY
            			[t2].[PersonId],
            			[t1].[AddressType]
            	) AS [t1] ON [t0].[Id] = [t1].[PersonId];',N'@P1 bigint',@P1=0
            */
        }

    }
}
