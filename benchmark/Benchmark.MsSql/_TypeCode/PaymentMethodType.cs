using System.ComponentModel.DataAnnotations;

namespace DbExpression.MsSql.Benchmark
{
    public enum PaymentMethodType : int
	{
		[Display(Name = "Credit Card", Description = "Credit Card")]
		CreditCard = 1,
		[Display(Name = "ACH", Description = "ACH")]
		ACH = 2,
		[Display(Name = "Pay Pal", Description = "Pay Pal")]
		PayPal = 3
	}
}
