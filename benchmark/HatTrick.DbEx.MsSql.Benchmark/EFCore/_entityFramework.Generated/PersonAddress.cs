using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Benchmark.EFCore
{
    public partial class PersonAddress
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int AddressId { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual Address Address { get; set; }
        public virtual Person Person { get; set; }
    }
}
