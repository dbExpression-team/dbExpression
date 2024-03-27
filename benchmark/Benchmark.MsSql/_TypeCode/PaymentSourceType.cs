using System.ComponentModel.DataAnnotations;

namespace DbExpression.MsSql.Benchmark
{
    public enum PaymentSourceType
	{
		Web = 1,
		[Display(Name = "In Person")]
		InPerson = 2
	}
}
