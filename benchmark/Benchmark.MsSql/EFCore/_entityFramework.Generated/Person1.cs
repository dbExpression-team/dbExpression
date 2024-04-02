using System;
using System.Collections.Generic;

namespace DbExpression.MsSql.Benchmark.EFCore
{
    public partial class Person1
    {
        public int Id { get; set; }
        public string Ssn { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
