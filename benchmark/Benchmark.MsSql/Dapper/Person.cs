using System;

namespace HatTrick.DbEx.MsSql.Benchmark.Dapper
{
    public partial class Person
    {
        public virtual int Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual DateTime? BirthDate { get; set; }
        public virtual GenderType GenderType { get; set; }
        public virtual int? CreditLimit { get; set; }
        public virtual int? YearOfLastCreditLimitReview { get; set; }
        public virtual DateTimeOffset RegistrationDate { get; set; }
        public virtual DateTimeOffset? LastLoginDate { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual DateTime DateUpdated { get; set; }
    }
}
