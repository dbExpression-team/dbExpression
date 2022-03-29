using ServerSideBlazorApp.Data;

namespace ServerSideBlazorApp.Models
{
    public class ProductSummaryModel
    {
        public int Id { get; set; }
        public ProductCategoryType? Category { get; set; }
        public string? Name { get; set; }
        public double ListPrice { get; set; }
        public double Price { get; set; }
        public int QuantityOnHand { get; set; }
    }
}
