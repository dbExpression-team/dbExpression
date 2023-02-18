using DocumentationExamples.DataService;
using DocumentationExamples.dboData;
using DocumentationExamples.dboDataService;
using DocumentationExamples.secDataService;
using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder.Alias;
using Microsoft.Extensions.Logging;

namespace DocumentationExamples.Reference.Mssql.Functions.Aggregate
{
    ///<summary>Code examples from https://dbexpression.com/docs/reference/mssql/functions/aggregate/var</summary>
    public class Var : IDocumentationExamples
    {
        private readonly ILogger<Var> logger;

        public Var(ILogger<Var> logger)
        {
            this.logger = logger;
        }

        public void ExecuteExamples()
        {
            Var_line_no_46();
            Var_line_no_64();
            Var_line_no_86();
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/aggregate/var at line 46</summary>
        private void Var_line_no_46()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/aggregate/var at line 46");

            float result = db.SelectOne(
                    db.fx.Var(dbo.Product.ShippingWeight)
                )
                .From(dbo.Product)
                .Execute();

            /*
            SELECT TOP(1)
                VAR([_t0].[ShippingWeight])
            FROM
                [dbo].[Product] AS [_t0];
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/aggregate/var at line 64</summary>
        private void Var_line_no_64()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/aggregate/var at line 64");

            float result = db.SelectOne(
                    db.fx.Var(dbo.Product.ShippingWeight)
                )
                .From(dbo.Product)
                .OrderBy(db.fx.Var(dbo.Product.ShippingWeight).Desc())
                .Execute();

            /*
            SELECT TOP(1)
                VAR([_t0].[ShippingWeight])
            FROM
                [dbo].[Product] AS [_t0]
            ORDER BY
                VAR([_t0].[ShippingWeight]) DESC;
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/aggregate/var at line 86</summary>
        private void Var_line_no_86()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/aggregate/var at line 86");

            IEnumerable<ProductCategoryType?> results = db.SelectMany(
                    dbo.Product.ProductCategoryType
                )
                .From(dbo.Product)
                .GroupBy(dbo.Product.ProductCategoryType)
                .Having(db.fx.Var(dbo.Product.ShippingWeight) > 1)
                .Execute();

            /*
            exec sp_executesql N'SELECT
                [_t0].[ProductCategoryType]
            FROM
                [dbo].[Product] AS [_t0]
            GROUP BY
                [_t0].[ProductCategoryType]
            HAVING
                VAR([_t0].[ShippingWeight]) > @P1;',N'@P1 real',@P1=1
            */
        }

    }
}
