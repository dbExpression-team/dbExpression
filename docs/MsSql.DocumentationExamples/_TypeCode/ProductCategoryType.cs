using System;
using System.ComponentModel.DataAnnotations;

namespace MsSql.DocumentationExamples
{
	#region ProductCategoryType
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
}
