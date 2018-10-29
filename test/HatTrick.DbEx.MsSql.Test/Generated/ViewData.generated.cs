using System;

namespace HatTrick.DbEx.MsSql.Test.dbo.Data
{
	#region person total purchases view
	[Serializable]
	public partial class PersonTotalPurchasesView
    {
        public int Id { get; set; }
        public decimal? TotalPurchases { get; set; }
    }
	#endregion
}
