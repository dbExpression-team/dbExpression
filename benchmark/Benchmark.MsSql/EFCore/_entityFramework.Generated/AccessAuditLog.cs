using System;
using System.Collections.Generic;

namespace DbExpression.MsSql.Benchmark.EFCore
{
    public partial class AccessAuditLog
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int AccessResult { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
