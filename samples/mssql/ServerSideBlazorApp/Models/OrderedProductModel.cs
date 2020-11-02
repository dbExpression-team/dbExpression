using ServerSideBlazorApp.Data;

namespace ServerSideBlazorApp.Models
{
    public class OrderedProductModel
    {
        public int Id { get; set; }
        public ProductCategoryType? Category { get; set; }
        public string Name { get; set; }
        public double ListPrice { get; set; }
        public double Price { get; set; }
    }
}
