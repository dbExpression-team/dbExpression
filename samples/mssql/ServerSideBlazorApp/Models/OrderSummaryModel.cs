using ServerSideBlazorApp.Data;
using System;

namespace ServerSideBlazorApp.Models
{
    public class OrderSummaryModel
    { 
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public bool IsVIP { get; set; }
        public string OrderNumber { get; set; } = string.Empty;
        public PaymentMethodType PaymentMethod { get; set; }
        public double TotalPurchaseAmount { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime? ShipDate { get; set; }
        public DateTime? ExpectedDeliveryDate { get; set; }
    }
}
