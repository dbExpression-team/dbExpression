using System.ComponentModel.DataAnnotations;

namespace DbEx.Data
{
    public enum PaymentSourceType
	{
		Web = 1,
		[Display(Name = "In Person")]
		InPerson = 2
	}
}
