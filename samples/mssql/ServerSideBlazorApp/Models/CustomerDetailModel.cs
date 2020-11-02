using ServerSideBlazorApp.Data;
using System;

namespace ServerSideBlazorApp.Models
{
    public class CustomerDetailModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public GenderType Gender { get; set; }
        public short? CurrentAge { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? CreditLimit { get; set; }
        public int? YearOfLastCreditLimitReview { get; set; }
        public AddressModel ShippingAddress { get; set; } = new AddressModel();
        public AddressModel MailingAddress { get; set; } = new AddressModel();
        public AddressModel BillingAddress { get; set; } = new AddressModel();
        public bool IsVIP { get; set; }
        public double LifetimeValue { get; set; }
    }
}
