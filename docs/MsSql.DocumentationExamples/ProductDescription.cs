using System;

namespace MsSql.DocumentationExamples
{
    public class ProductDescription
    {
        public string Short { get; set; } = String.Empty;
        public string Long { get; set; } = String.Empty;
        public DateTime? LastReviewDate { get; set; }
    }
}
