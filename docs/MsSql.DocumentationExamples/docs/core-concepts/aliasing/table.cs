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
    ///<summary>Code examples from https://dbexpression.com/docs/core-concepts/aliasing/table</summary>
    public class Table_Aliasing : IDocumentationExamples
    {
        private readonly ILogger<Table_Aliasing> logger;

        public Table_Aliasing(ILogger<Table_Aliasing> logger)
        {
            this.logger = logger;
        }

        public void ExecuteExamples()
        {
            Table_Aliasing_line_no_26();
        }

        ///<summary>https://dbexpression.com/docs/core-concepts/aliasing/table at line 26</summary>
        private void Table_Aliasing_line_no_26()
        {
            logger.LogDebug("https://dbexpression.com/docs/core-concepts/aliasing/table at line 26");

            IEnumerable<dynamic> persons = db.SelectMany(
                    dbo.Person.Id,
                    dbo.Person.FirstName,
                    dbo.Person.LastName,
                    sec.Person.As("secure").SocialSecurityNumber
            		// ^ use table alias for sec.Person to retrieve column
                )
                .From(dbo.Person)
                .InnerJoin(sec.Person.As("secure"))
            	// ^ establish table alias for sec.Person
                    .On(dbo.Person.Id == sec.Person.As("secure").Id)
            		// ^ use table alias for sec.Person in join condition
                .Execute();

            /*
            SELECT
            	[dbo].[Person].[Id],
            	[dbo].[Person].[FirstName],
            	[dbo].[Person].[LastName],
            	[secure].[SSN] AS [SocialSecurityNumber]
            FROM
            	[dbo].[Person]
            	INNER JOIN [sec].[Person] AS [secure] ON [dbo].[Person].[Id] = [secure].[Id];
            */
        }

    }
}
