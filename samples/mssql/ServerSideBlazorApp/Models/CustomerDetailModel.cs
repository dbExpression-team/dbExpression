using ServerSideBlazorApp.Data;
using System;

namespace ServerSideBlazorApp.Models
{
    public class CustomerDetailModel
    {
        public int Id { get; set; }
        public AddressModel ShippingAddress { get; set; }
        public AddressModel MailingAddress { get; set; }
        public DateTimeOffset? BirthDate { get; set; }
        public GenderType Gender { get; set; }
    }
}
