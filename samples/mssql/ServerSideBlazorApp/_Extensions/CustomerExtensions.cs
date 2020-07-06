using ServerSideBlazorApp.dboData;
using ServerSideBlazorApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace ServerSideBlazorApp
{
    public static class CustomerExtensions
    {
        public static IEnumerable<CustomerSummaryModel> MapToModels(this IEnumerable<Person> people)
        {
            return people?.Select(x => new CustomerSummaryModel { Id = x.Id, Name = $"{x.FirstName} {x.LastName}" });
        }
    }
}
