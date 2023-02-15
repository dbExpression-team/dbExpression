using DbEx.DataService;
using DbEx.dboData;
using DbEx.dboDataService;
using DbEx.secDataService;
using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder.Alias;
using Microsoft.Extensions.Logging;

namespace MsSql.DocumentationExamples.Reference.Mssql.Functions.Aggregate
{
    ///<summary>Code examples from https://dbexpression.com/docs/reference/mssql/functions/aggregate/varp</summary>
    public class VarP : IDocumentationExamples
    {
        private readonly ILogger<VarP> logger;

        public VarP(ILogger<VarP> logger)
        {
            this.logger = logger;
        }

        public void ExecuteExamples()
        {
            VarP_line_no_46();
            VarP_line_no_64();
            VarP_line_no_86();
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/aggregate/varp at line 46</summary>
        private void VarP_line_no_46()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/aggregate/varp at line 46");

            float result = db.SelectOne(
                    db.fx.VarP(dbo.Product.ShippingWeight)
                )
                .From(dbo.Product)
                .Execute();

            /*
            SELECT TOP(1)
            	VARP([dbo].[Product].[ShippingWeight])
            FROM
            	[dbo].[Product];
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/aggregate/varp at line 64</summary>
        private void VarP_line_no_64()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/aggregate/varp at line 64");

            float result = db.SelectOne(
                    db.fx.VarP(dbo.Product.ShippingWeight)
                )
                .From(dbo.Product)
                .OrderBy(db.fx.VarP(dbo.Product.ShippingWeight).Desc())
                .Execute();

            /*
            SELECT TOP(1)
            	VARP([dbo].[Product].[ShippingWeight])
            FROM
            	[dbo].[Product]
            ORDER BY
            	VARP([dbo].[Product].[ShippingWeight]) DESC;
            */
        }

        ///<summary>https://dbexpression.com/docs/reference/mssql/functions/aggregate/varp at line 86</summary>
        private void VarP_line_no_86()
        {
            logger.LogDebug("https://dbexpression.com/docs/reference/mssql/functions/aggregate/varp at line 86");

            IEnumerable<float> results = db.SelectMany(
                    db.fx.VarP(dbo.Product.ShippingWeight)
                )
                .From(dbo.Product)
                .GroupBy(dbo.Product.ProductCategoryType)
                .Having(db.fx.VarP(dbo.Product.ShippingWeight) > 1)
                .Execute();

            /*
            exec sp_executesql N'SELECT
            	VARP([dbo].[Product].[ShippingWeight])
            FROM
            	[dbo].[Product]
            GROUP BY
            	[dbo].[Product].[ProductCategoryType]
            HAVING
            	VARP([dbo].[Product].[ShippingWeight]) > @P1;',N'@P1 real',@P1=1
            */
        }

    }
}
