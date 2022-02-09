using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Benchmark.EFCore
{
    public partial class PurchaseLine
    {
        public int Id { get; set; }
        public int PurchaseId { get; set; }
        public int ProductId { get; set; }
        public decimal PurchasePrice { get; set; }
        public int Quantity { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public virtual Product Product { get; set; }
        public virtual Purchase Purchase { get; set; }
    }
}
