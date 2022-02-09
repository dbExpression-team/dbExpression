using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Benchmark.EFCore
{
    public partial class Product
    {
        public Product()
        {
            PurchaseLines = new HashSet<PurchaseLine>();
        }

        public int Id { get; set; }
        public ProductCategoryType? ProductCategoryType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal ListPrice { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public byte[] Image { get; set; }
        public decimal? Height { get; set; }
        public decimal? Width { get; set; }
        public decimal? Depth { get; set; }
        public decimal? Weight { get; set; }
        public decimal ShippingWeight { get; set; }
        public TimeSpan? ValidStartTimeOfDayForPurchase { get; set; }
        public TimeSpan? ValidEndTimeOfDayForPurchase { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public virtual ICollection<PurchaseLine> PurchaseLines { get; set; }
    }
}
