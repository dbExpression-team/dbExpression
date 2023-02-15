using DbEx.DataService;
using DbEx.dboData;
using DbEx.dboDataService;
using DbEx.secDataService;
using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder.Alias;
using Microsoft.Extensions.Logging;

namespace MsSql.DocumentationExamples.Core_concepts.Advanced
{
    ///<summary>Code examples from https://dbexpression.com/docs/core-concepts/advanced/arithmetic</summary>
    public class Arithmetic : IDocumentationExamples
    {
        private readonly ILogger<Arithmetic> logger;

        public Arithmetic(ILogger<Arithmetic> logger)
        {
            this.logger = logger;
        }

        public void ExecuteExamples()
        {
            Arithmetic_line_no_45();
        }

        ///<summary>https://dbexpression.com/docs/core-concepts/advanced/arithmetic at line 45</summary>
        private void Arithmetic_line_no_45()
        {
            logger.LogDebug("https://dbexpression.com/docs/core-concepts/advanced/arithmetic at line 45");

            //select the product info (inventory on hand, price of inventory and projected margin on sales)
            IEnumerable<dynamic> inventoryStats = db.SelectMany(
                    dbo.Product.Id,
                    dbo.Product.Name,
                    dbo.Product.Quantity.As("QuantityOnHand"),
                    (dbo.Product.Quantity * dbo.Product.Price).As("InventoryCost"),
                    ((dbo.Product.Quantity * dbo.Product.ListPrice) - (dbo.Product.Quantity * dbo.Product.Price)).As("ProjectedMargin")
                )
                .From(dbo.Product)
                .Execute();

            /*
            SELECT
                [dbo].[Product].[Id],
                [dbo].[Product].[Name],
                [dbo].[Product].[Quantity] AS [QuantityOnHand],
                ([dbo].[Product].[Quantity] * [dbo].[Product].[Price]) AS [InventoryCost],
                (([dbo].[Product].[Quantity] * [dbo].[Product].[ListPrice]) - ([dbo].[Product].[Quantity] * [dbo].[Product].[Price])) AS [ProjectedMargin]
            FROM
                [dbo].[Product];
            */
        }

    }
}
