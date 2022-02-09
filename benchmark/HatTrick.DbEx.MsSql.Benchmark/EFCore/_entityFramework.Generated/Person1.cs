using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Benchmark.EFCore
{
    public partial class Person1
    {
        public int Id { get; set; }
        public string Ssn { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
