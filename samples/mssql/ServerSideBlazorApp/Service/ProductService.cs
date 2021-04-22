using HatTrick.DbEx.Sql;
using ServerSideBlazorApp.Data;
using ServerSideBlazorApp.DataService;
using ServerSideBlazorApp.dboDataService;
using ServerSideBlazorApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HatTrick.DbEx.Sql.Expression;

namespace ServerSideBlazorApp.Service
{
    /// <summary>
    /// A service that provides methods to retrieve Product information from the database.
    /// </summary>
    public class ProductService
    {
        //variable to hold dbExpression order by elements.  Stored as a variable as it's used more than once and to demonstrate that order by elements can be treated like most any other .NET object
        private static readonly IDictionary<string, AnyElement> ProductSummarySortingFields = new Dictionary<string, AnyElement>
        {
            { nameof(ProductSummaryModel.Category), dbo.Product.ProductCategoryType },
            { nameof(ProductSummaryModel.Name), dbo.Product.Name },
            { nameof(ProductSummaryModel.ListPrice), dbo.Product.ListPrice },
            { nameof(ProductSummaryModel.Price), dbo.Product.Price },
            { nameof(ProductSummaryModel.QuantityOnHand), dbo.Product.Quantity }
        };

        /// <summary>
        /// Search for orders, and retrieve a paged list using the supplied paging parameters.
        /// </summary>
        /// <param name="pagingParameters">A set of parameters specifying the offset, limit, and sorting criteria used in the SQL statement.</param>
        public async Task<Page<ProductSummaryModel>> GetSummaryPageAsync(PagingParameters pagingParameters)
        { 
            var products = await 
                db.SelectMany(
                    dbo.Product.Id,
                    dbo.Product.ProductCategoryType,
                    dbo.Product.Name,
                    dbo.Product.ListPrice,
                    dbo.Product.Price,
                    dbo.Product.Quantity
                )
                .From(dbo.Product)
                .OrderBy(
                    pagingParameters.Sorting?.Select(s => s.Direction == OrderExpressionDirection.ASC ? ProductSummarySortingFields[s.Field].Asc : ProductSummarySortingFields[s.Field].Desc)
                )
                .Offset(pagingParameters.Offset).Limit(pagingParameters.Limit)
                .ExecuteAsync(reader =>
                    new ProductSummaryModel
                    {
                        Id = reader.ReadField().GetValue<int>(),
                        Category = reader.ReadField().GetValue<ProductCategoryType?>(),
                        Name = reader.ReadField().GetValue<string>(),
                        ListPrice = reader.ReadField().GetValue<double>(),
                        Price = reader.ReadField().GetValue<double>(),
                        QuantityOnHand = reader.ReadField().GetValue<int>()
                    }
                );

            var countOfProducts = await
                db.SelectOne(
                    db.fx.Count()
                )
                .From(dbo.Product)
                .ExecuteAsync();

            return new Page<ProductSummaryModel>(
                pagingParameters,
                products,
                countOfProducts
            );
        }

        /// <summary>
        /// Fetch a specific product by id.
        /// </summary>
        public async Task<ProductDetailModel> GetProductDetailAsync(int productId)
        {
            return await
                db.SelectOne(
                    dbo.Product.Id,
                    dbo.Product.ProductCategoryType,
                    dbo.Product.Name,
                    dbo.Product.Description,
                    dbo.Product.ListPrice,
                    dbo.Product.Price,
                    dbo.Product.Quantity,
                    dbo.Product.Height,
                    dbo.Product.Width,
                    dbo.Product.Depth,
                    dbo.Product.Weight,
                    dbo.Product.ShippingWeight,
                    dbo.Product.Image
                )
                .From(dbo.Product)
                .Where(dbo.Product.Id == productId)
                .ExecuteAsync(reader =>
                    new ProductDetailModel
                    {
                        Id = reader.ReadField().GetValue<int>(),
                        Category = reader.ReadField().GetValue<ProductCategoryType?>(),
                        Name = reader.ReadField().GetValue<string>(),
                        Description = reader.ReadField().GetValue<string>(),
                        ListPrice = reader.ReadField().GetValue<double>(),
                        Price = reader.ReadField().GetValue<double>(),
                        QuantityOnHand = reader.ReadField().GetValue<int>(),
                        Height = reader.ReadField().GetValue<decimal?>(),
                        Width = reader.ReadField().GetValue<decimal?>(),
                        Depth = reader.ReadField().GetValue<decimal?>(),
                        Weight = reader.ReadField().GetValue<decimal?>(),
                        ShippingWeight = reader.ReadField().GetValue<decimal>(),
                        Image = Convert.ToBase64String(reader.ReadField().GetValue<byte[]>() ?? new byte[0])
                    }
                );
        }

        /// <summary>
        /// Update the price of a specific product by a specified percentage.
        /// </summary>
        public async Task UpdatePrice(int productId, double percentage)
        {
            await db.Update(
                //this is not good sound business logic, but for demonstration to show how dbExpression elements can be intermixed with things like ternarys.
                dbo.Product.Price.Set(dbo.Product.Price * (1 + (percentage > 1 ? percentage / 100 : percentage)))
            )
            .From(dbo.Product)
            .Where(dbo.Product.Id == productId)
            .ExecuteAsync();
        }
    }
}
