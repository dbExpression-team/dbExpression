using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Benchmark.EFCore
{
    public partial class Person
    {
        public Person()
        {
            PersonAddresses = new HashSet<PersonAddress>();
            Purchases = new HashSet<Purchase>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public GenderType GenderType { get; set; }
        public int? CreditLimit { get; set; }
        public int? YearOfLastCreditLimitReview { get; set; }
        public DateTimeOffset RegistrationDate { get; set; }
        public DateTimeOffset? LastLoginDate { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public virtual ICollection<PersonAddress> PersonAddresses { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}
