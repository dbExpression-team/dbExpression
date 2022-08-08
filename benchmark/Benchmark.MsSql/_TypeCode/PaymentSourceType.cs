using System.ComponentModel.DataAnnotations;

namespace HatTrick.DbEx.MsSql.Benchmark
{
    public enum PaymentSourceType
	{
		Web = 1,
		[Display(Name = "In Person")]
		InPerson = 2
	}
}
