using ServerSideBlazorApp.Data;

namespace ServerSideBlazorApp.Models
{
    public class OrderLineModel
    {
        public ProductCategoryType? Category { get; set; }
        public string Name { get; set; }
        public double PurchasePrice { get; set; }
        public int Quantity { get; set; }
        public double Subtotal { get; set; }
    }
}
