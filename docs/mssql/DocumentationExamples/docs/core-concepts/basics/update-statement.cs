using DocumentationExamples.DataService;
using DocumentationExamples.dboData;
using DocumentationExamples.dboDataService;
using DocumentationExamples.secDataService;
using DbExpression.MsSql.Expression;
using DbExpression.Sql;
using DbExpression.Sql.Builder.Alias;
using Microsoft.Extensions.Logging;

namespace DocumentationExamples.Core_concepts.Basics
{
    ///<summary>Code examples from https://dbexpression.com/docs/core-concepts/basics/update-statement</summary>
    public class Update_Statements : IDocumentationExamples
    {
        private readonly ILogger<Update_Statements> logger;

        public Update_Statements(ILogger<Update_Statements> logger)
        {
            this.logger = logger;
        }

        public void ExecuteExamples()
        {
            Update_Statements_line_no_18();
            Update_Statements_line_no_44();
            Update_Statements_line_no_68();
            Update_Statements_line_no_89();
            Update_Statements_line_no_115();
        }

        ///<summary>https://dbexpression.com/docs/core-concepts/basics/update-statement at line 18</summary>
        private void Update_Statements_line_no_18()
        {
            logger.LogDebug("https://dbexpression.com/docs/core-concepts/basics/update-statement at line 18");

            int affected = db.Update(dbo.Person.CreditLimit.Set(25_000))
                .From(dbo.Person)
                .Where(dbo.Person.Id == 1)
                .Execute();

            /*
            exec sp_executesql N'UPDATE
                [t0]
            SET
                [t0].[CreditLimit] = @P1
            FROM
                [dbo].[Person] AS [t0]
            WHERE
                [t0].[Id] = @P2;
            SELECT @@ROWCOUNT;',N'@P1 int,@P2 int',@P1=25000,@P2=1
            */
        }

        ///<summary>https://dbexpression.com/docs/core-concepts/basics/update-statement at line 44</summary>
        private void Update_Statements_line_no_44()
        {
            logger.LogDebug("https://dbexpression.com/docs/core-concepts/basics/update-statement at line 44");

            int affected = db.Update(
                    dbo.Product.ListPrice.Set(dbo.Product.ListPrice * 1.1)
                )
                .From(dbo.Product)
                .Where(dbo.Product.ProductCategoryType == ProductCategoryType.Books)
                .Execute();

            /*
            exec sp_executesql N'UPDATE
                [t0]
            SET
                [t0].[ListPrice] = ([t0].[ListPrice] * @P1)
            FROM
                [dbo].[Product] AS [t0]
            WHERE
                [t0].[ProductCategoryType] = @P2;
            SELECT @@ROWCOUNT;',N'@P1 float,@P2 int',@P1=1.1000000000000001,@P2=3
            */
        }

        ///<summary>https://dbexpression.com/docs/core-concepts/basics/update-statement at line 68</summary>
        private void Update_Statements_line_no_68()
        {
            logger.LogDebug("https://dbexpression.com/docs/core-concepts/basics/update-statement at line 68");

            int affected = db.Update(dbo.Address.Line2.Set(dbex.Null))
                .From(dbo.Address)
                .Where(dbo.Address.Id == 7)
                .Execute();

            /*
            exec sp_executesql N'UPDATE
                [t0]
            SET
                [t0].[Line2] = NULL
            FROM
                [dbo].[Address] AS [t0]
            WHERE
                [t0].[Id] = @P1;
            SELECT @@ROWCOUNT;',N'@P1 int',@P1=7
            */
        }

        ///<summary>https://dbexpression.com/docs/core-concepts/basics/update-statement at line 89</summary>
        private void Update_Statements_line_no_89()
        {
            logger.LogDebug("https://dbexpression.com/docs/core-concepts/basics/update-statement at line 89");

            int affected = db.Update(
                    dbo.Person.FirstName.Set("Jane"),
                    dbo.Person.LastName.Set("Smith")
                )
                .From(dbo.Person)
                .Where(dbo.Person.Id == 12)
                .Execute();

            /*
            exec sp_executesql N'UPDATE
                [t0]
            SET
                [t0].[FirstName] = @P1,
                [t0].[LastName] = @P2
            FROM
                [dbo].[Person] AS [t0]
            WHERE
                [t0].[Id] = @P3;
            SELECT @@ROWCOUNT;',N'@P1 varchar(20),@P2 varchar(20),@P3 int',@P1='Jane',@P2='Smith',@P3=1
            */
        }

        ///<summary>https://dbexpression.com/docs/core-concepts/basics/update-statement at line 115</summary>
        private void Update_Statements_line_no_115()
        {
            logger.LogDebug("https://dbexpression.com/docs/core-concepts/basics/update-statement at line 115");

            int affectedCount = db.Update(dbo.Person.CreditLimit.Set(("newCreditLimit", "creditLimit")))
                .From(dbo.Person)
                .InnerJoin(
                    db.SelectMany(
                            dbo.Purchase.PersonId,
                            db.fx.Max(dbo.Purchase.TotalPurchaseAmount).As("creditLimit")
                        )
                        .From(dbo.Purchase)
                        .GroupBy(dbo.Purchase.PersonId)
                ).As("newCreditLimit").On(dbo.Person.Id == ("newCreditLimit", "PersonId"))
                .Execute();

            /*
            UPDATE
            	[dbo].[Person]
            SET
            	[CreditLimit] = [newCreditLimit].[creditLimit]
            FROM
            	[dbo].[Person]
            	INNER JOIN (
            		SELECT
            			[dbo].[Purchase].[PersonId],
            			MAX([dbo].[Purchase].[TotalPurchaseAmount]) AS [creditLimit]
            		FROM
            			[dbo].[Purchase]
            		GROUP BY
            			[dbo].[Purchase].[PersonId]
            	) AS [newCreditLimit] ON [dbo].[Person].[Id] = [newCreditLimit].[PersonId];
            SELECT @@ROWCOUNT;
            */
        }

    }
}
