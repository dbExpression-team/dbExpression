using Blazorise.Charts;
using Microsoft.Extensions.Hosting;
using ServerSideBlazorApp.Data;
using ServerSideBlazorApp.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ServerSideBlazorApp.Pages
{
    public partial class Index
    {
        private IEnumerable<CustomerSummaryModel> Top5VIPCustomers { get; set; } = Enumerable.Empty<CustomerSummaryModel>();
        private IEnumerable<OrderSummaryModel> RecentOrders { get; set; } = Enumerable.Empty<OrderSummaryModel>();

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                Top5VIPCustomers = await CustomerService.GetVIPCustomers();
                RecentOrders = (await OrderService.GetOrdersPageAsync(new PageRequestModel(0, 5))).Page;
                if (Top5VIPCustomers.Any() || RecentOrders.Any())
                    StateHasChanged();
            }
        }

        private async Task<IEnumerable<SingleMetricDatasetModel>> GetDailySales()
            => (await OrderService.GetRecentSalesByDay()).Select(x => 
                new SingleMetricDatasetModel<double> 
                { 
                    Label = new DateTime(x.Year, x.Month, x.Day).ToString("d", CultureInfo.InvariantCulture), 
                    Value = (double)x.TotalSales
                }
            );

        private async Task<IEnumerable<SingleMetricDatasetModel>> GetSalesByProductCategory()
            => (await OrderService.GetSalesByProductCategory()).Select(x =>
                new SingleMetricDatasetModel<double>
                {
                    Label = (ProductCategoryType?)x.ProductCategoryType is null ? "Other" : x.ProductCategoryType.ToString(),
                    Value = (double)x.TotalSales
                }
            );
    }
}
