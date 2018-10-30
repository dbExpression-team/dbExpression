using System;
using System.ComponentModel.DataAnnotations;

namespace Generated.dbo.Data
{
	#region AddressType
	public enum AddressType : int
	{
		[Display(Name = "Shipping", Description = "Shipping Address")]
		Shipping = 0,
		[Display(Name = "Mailing", Description = "Mailing Address")]
		Mailing = 1,
		[Display(Name = "Billing", Description = "Billing Address")]
		Billing = 2,
	}
	#endregion
}
