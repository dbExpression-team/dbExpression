using System;
using System.Collections.Generic;

namespace DbExpression.MsSql.Benchmark.EFCore
{
    public partial class PersonTotalPurchasesView
    {
        public int Id { get; set; }
        public decimal? TotalAmount { get; set; }
        public int? TotalCount { get; set; }
    }
}
