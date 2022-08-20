using System.ComponentModel.DataAnnotations;

namespace Profiling.MsSql
{
    public enum PaymentSourceType
	{
		Web = 1,
		[Display(Name = "In Person")]
		InPerson = 2
	}
}
