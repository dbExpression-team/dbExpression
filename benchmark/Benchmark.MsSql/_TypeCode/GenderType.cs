using System;
using System.ComponentModel.DataAnnotations;

namespace DbExpression.MsSql.Benchmark
{
	public enum GenderType : long
	{
		[Display(Name = "Mail", Description = "Male")]
		Male = 1,
		[Display(Name = "Female", Description = "Female")]
		Female = 2,
	}
}
