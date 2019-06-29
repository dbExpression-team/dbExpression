using System;
using System.ComponentModel.DataAnnotations;

namespace DbEx.Data
{
    #region GenderType
    public enum GenderType : int
	{
		[Display(Name = "Mail", Description = "Male")]
		Male = 1,
		[Display(Name = "Female", Description = "Female")]
		Female = 2,
	}
	#endregion
}
