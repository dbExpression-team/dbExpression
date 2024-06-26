using System;
using System.ComponentModel.DataAnnotations;

namespace DbExpression.MsSql.Benchmark
{
    public enum AddressType : long
	{
		[Display(Name = "Shipping", Description = "Shipping Address")]
		Shipping = 0,
		[Display(Name = "Mailing", Description = "Mailing Address")]
		Mailing = 1,
		[Display(Name = "Billing", Description = "Billing Address")]
		Billing = 2,
	}
}
