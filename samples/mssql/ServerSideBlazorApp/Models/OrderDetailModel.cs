using ServerSideBlazorApp.Data;
using System;
using System.Collections;
using System.Collections.Generic;

namespace ServerSideBlazorApp.Models
{
    public class OrderDetailModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public bool IsVIP { get; set; }
        public string OrderNumber { get; set; } = string.Empty;
        public PaymentMethodType PaymentMethod { get; set; }
        public AddressModel ShippingAddress { get; set; } = new();
        public AddressModel BillingAddress { get; set; } = new();
        public double TotalPurchaseAmount { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime? ShipDate { get; set; }
        public DateTime? ExpectedDeliveryDate { get; set; }
        public Guid? TrackingIdentifier { get; set; }
        public IList<OrderLineModel> Lines { get; set; } = new List<OrderLineModel>();
    }
}
