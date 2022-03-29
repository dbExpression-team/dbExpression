using ServerSideBlazorApp.Data;
using ServerSideBlazorApp.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using HatTrick.DbEx.Sql.Expression;

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
                try
                {
                    Top5VIPCustomers = await CustomerService.GetVIPCustomersPageAsync();
                    RecentOrders = (await OrderService.GetOrdersPageAsync(new PagingParameters(0, 5, new Sort(nameof(OrderSummaryModel.PurchaseDate), OrderExpressionDirection.DESC)))).Data;
                    if (Top5VIPCustomers.Any() || RecentOrders.Any())
                        StateHasChanged();
                }
                catch (Exception)
                {
                    NavigationManager.NavigateTo("/startup", true);
                }
            }
        }

        private async Task<IEnumerable<SingleMetricDatasetModel>> GetDailySales()
        {
            try
            {
                var orders = await OrderService.GetRecentSalesByDay();

                return orders.Select(x =>
                    new SingleMetricDatasetModel<double>
                    {
                        Label = new DateTime(x.Year, x.Month, x.Day).ToString("d", CultureInfo.InvariantCulture),
                        Value = (double)x.TotalSales
                    }
                );           
            }
            catch (Exception)
            {
                NavigationManager.NavigateTo("/startup", true);
            }
            return Enumerable.Empty<SingleMetricDatasetModel>();
        }

        private async Task<IEnumerable<SingleMetricDatasetModel>> GetSalesByProductCategory()
        {
            try
            {
                var sales = await OrderService.GetSalesByProductCategory();

                if (!sales.Any())
                    NavigationManager.NavigateTo("/startup", true);

                return sales.Select(x =>
                    new SingleMetricDatasetModel<double>
                    {
                        Label = (ProductCategoryType?)x.ProductCategoryType is null ? "Other" : x.ProductCategoryType.ToString(),
                        Value = (double)x.TotalSales
                    }
                );
            }
            catch (Exception)
            {
                NavigationManager.NavigateTo("/startup", true);
            }
            return Enumerable.Empty<SingleMetricDatasetModel>();
        }
    }
}
