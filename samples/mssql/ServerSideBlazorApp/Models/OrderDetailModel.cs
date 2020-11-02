using ServerSideBlazorApp.Data;
using System;
using System.Collections.Generic;

namespace ServerSideBlazorApp.Models
{
    public class OrderDetailModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public bool IsVIP { get; set; }
        public string OrderNumber { get; set; }
        public PaymentMethodType PaymentMethod { get; set; }
        public AddressModel ShippingAddress { get; set; }
        public AddressModel BillingAddress { get; set; }
        public double TotalPurchaseAmount { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime? ShipDate { get; set; }
        public DateTime? ExpectedDeliveryDate { get; set; }
        public Guid? TrackingIdentifier { get; set; }
        public IList<OrderLineModel> Lines { get; set; } = new List<OrderLineModel>();
    }
}
