using System;

namespace HatTrick.DbEx.MsSql.Test
{
    public class ProductDescription
    {
        public string Short { get; set; } = String.Empty;
        public string Long { get; set; } = String.Empty;
        public DateTime? LastReviewDate { get; set; }
    }
}
