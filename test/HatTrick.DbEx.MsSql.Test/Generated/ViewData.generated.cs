using HatTrick.DbEx.Sql;
using System;

namespace Data.dbo
{
    #region person total purchases view
    [Serializable]
    public partial class PersonTotalPurchasesView : IDbEntity
    {
        public int Id { get; set; }
        public decimal? TotalPurchases { get; set; }
    }
    #endregion
}
