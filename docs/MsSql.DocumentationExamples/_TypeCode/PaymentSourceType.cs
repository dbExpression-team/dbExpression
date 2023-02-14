using System.ComponentModel.DataAnnotations;

namespace MsSql.DocumentationExamples
{
    public enum PaymentSourceType
	{
		Web = 1,
		[Display(Name = "In Person")]
		InPerson = 2
	}
}
