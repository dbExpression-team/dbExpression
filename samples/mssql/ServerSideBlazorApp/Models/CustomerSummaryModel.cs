using System.Collections;

namespace ServerSideBlazorApp.Models
{
    public class CustomerSummaryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal LifetimeValue { get; set; }
        public short? CurrentAge { get; set; }
    }
}
