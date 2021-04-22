using System.ComponentModel.DataAnnotations;

namespace ServerSideBlazorApp.Data
{
    public enum PaymentSourceType
	{
		Web = 1,
		[Display(Name = "In Person")]
		InPerson = 2
	}
}
