using System;

namespace HatTrick.DbEx.MsSql.Benchmark.Dapper
{
    public partial class PersonAddress
    {
        public virtual int Id { get; set; }
        public virtual int PersonId { get; set; }
        public virtual int AddressId { get; set; }
        public virtual DateTime DateCreated { get; set; }
    }
}
