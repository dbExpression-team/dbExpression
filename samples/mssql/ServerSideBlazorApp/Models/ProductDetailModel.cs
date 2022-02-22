using ServerSideBlazorApp.Data;

namespace ServerSideBlazorApp.Models
{
    public class ProductDetailModel
    {
        public int Id { get; set; }
        public ProductCategoryType? Category { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public double ListPrice { get; set; }
        public double Price { get; set; }
        public int QuantityOnHand { get; set; }
        public decimal? Height { get; set; }
        public decimal? Width { get; set; }
        public decimal? Depth { get; set; }
        public decimal? Weight { get; set; }
        public decimal ShippingWeight { get; set; }
        public string Image { get; set; }
    }
}
