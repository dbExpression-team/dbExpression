using HatTrick.DbEx.Sql;
using ServerSideBlazorApp.Data;
using ServerSideBlazorApp.DataService;
using ServerSideBlazorApp.dboDataService;
using ServerSideBlazorApp.Models;
using System;
using System.Threading.Tasks;

namespace ServerSideBlazorApp.Service
{
    public class ProductService : ServiceBase
    {
        public async Task<PageResponseModel<ProductSummaryModel>> GetSummaryPageAsync(PageModel model)
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
                    dbo.Product.Name
                )
                .Skip(model.Offset).Limit(model.Limit)
                .ExecuteAsync(row =>
                    new ProductSummaryModel
                    {
                        Id = row.ReadField().GetValue<int>(),
                        Category = row.ReadField().GetValue<ProductCategoryType?>(),
                        Name = row.ReadField().GetValue<string>(),
                        ListPrice = row.ReadField().GetValue<double>(),
                        Price = row.ReadField().GetValue<double>(),
                        QuantityOnHand = row.ReadField().GetValue<int>()
                    }
                );

            var countOfProducts = await
                db.SelectOne(
                    db.fx.Count()
                )
                .From(dbo.Product)
                .ExecuteAsync();

            return new PageResponseModel<ProductSummaryModel>(
                model.Offset,
                model.Limit,
                model.SearchPhrase,
                products,
                countOfProducts
            );
        }

        public async Task<ProductDetailModel> GetProductAsync(int productId)
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
                .ExecuteAsync(row =>
                    new ProductDetailModel
                    {
                        Id = row.ReadField().GetValue<int>(),
                        Category = row.ReadField().GetValue<ProductCategoryType?>(),
                        Name = row.ReadField().GetValue<string>(),
                        Description = row.ReadField().GetValue<string>(),
                        ListPrice = row.ReadField().GetValue<double>(),
                        Price = row.ReadField().GetValue<double>(),
                        QuantityOnHand = row.ReadField().GetValue<int>(),
                        Height = row.ReadField().GetValue<decimal?>(),
                        Width = row.ReadField().GetValue<decimal?>(),
                        Depth = row.ReadField().GetValue<decimal?>(),
                        Weight = row.ReadField().GetValue<decimal?>(),
                        ShippingWeight = row.ReadField().GetValue<decimal>(),
                        Image = Convert.ToBase64String(row.ReadField().GetValue<byte[]>() ?? new byte[0])
                    }
                );
        }

        public async Task UpdatePrice(int productId, double percentage)
        {
            await db.Update(
                dbo.Product.Price.Set(dbo.Product.Price * (1 + (percentage > 1 ? percentage / 100 : percentage)))
            )
            .From(dbo.Product)
            .Where(dbo.Product.Id == productId)
            .ExecuteAsync();
        }
    }
}
