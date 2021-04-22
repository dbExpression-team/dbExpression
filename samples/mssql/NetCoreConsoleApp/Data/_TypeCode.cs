using System;
using System.ComponentModel.DataAnnotations;

namespace SimpleConsole.Data
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

	#region GenderType
	public enum GenderType : int
	{
		[Display(Name = "Mail", Description = "Male")]
		Male = 1,
		[Display(Name = "Female", Description = "Female")]
		Female = 2,
	}
	#endregion

	#region payment method type
	public enum PaymentMethodType : int
	{
		[Display(Name = "Credit Card", Description = "Credit Card")]
		CreditCard = 1,
		[Display(Name = "ACH", Description = "ACH")]
		ACH = 2,
		[Display(Name = "Pay Pal", Description = "Pay Pal")]
		PayPal = 3
	}
    #endregion

    #region payment source type
    public enum PaymentSourceType
	{
		Web = 1,
		[Display(Name = "In Person")]
		InPerson = 2
	}
    #endregion

    #region product category type
    public enum ProductCategoryType : int
	{
		[Display(Name = "Toys and games", Description = "Toys and games")]
		ToysAndGames = 1,
		[Display(Name = "Electronics", Description = "Electronics")]
		Electronics = 2,
		[Display(Name = "Books", Description = "Books")]
		Books = 3,
	}
	#endregion

	#region access audit result
	public enum AccessAuditResult : int
	{
		Authorized = 0,
		InvalidUsername = 1,
		InvalidPassword = 2,
		AccessDenied = 3,
		OauthTimeout = 4
	}
	#endregion
}