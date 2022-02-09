using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Benchmark.EFCore
{
    public partial class Address
    {
        public Address()
        {
            PersonAddresses = new HashSet<PersonAddress>();
        }

        public int Id { get; set; }
        public AddressType? AddressType { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public virtual ICollection<PersonAddress> PersonAddresses { get; set; }
    }
}
