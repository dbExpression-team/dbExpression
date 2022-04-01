using System;

namespace HatTrick.DbEx.MsSql.Benchmark.Dapper
{
    public partial class Address
    {
        public virtual int Id { get; set; }
        public virtual AddressType? AddressType { get; set; }
        public virtual string Line1 { get; set; }
        public virtual string Line2 { get; set; }
        public virtual string City { get; set; }
        public virtual string State { get; set; }
        public virtual string Zip { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual DateTime DateUpdated { get; set; }
    }
}
