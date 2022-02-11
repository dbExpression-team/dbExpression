using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.MsSql.Benchmark.EFCore
{
    public partial class Purchase
    {
        public Purchase()
        {
            PurchaseLines = new HashSet<PurchaseLine>();
        }

        public int Id { get; set; }
        public int PersonId { get; set; }
        public string OrderNumber { get; set; }
        public int TotalPurchaseQuantity { get; set; }
        public decimal TotalPurchaseAmount { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime? ShipDate { get; set; }
        public DateTime? ExpectedDeliveryDate { get; set; }
        public Guid? TrackingIdentifier { get; set; }
        public PaymentMethodType PaymentMethodType { get; set; }
        public PaymentSourceType PaymentSourceType { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public virtual Person Person { get; set; }
        public virtual ICollection<PurchaseLine> PurchaseLines { get; set; }
    }
}
