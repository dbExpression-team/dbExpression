using Blazorise;
using Blazorise.DataGrid;
using Microsoft.AspNetCore.Components;
using ServerSideBlazorApp.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ServerSideBlazorApp.Shared
{
    public partial class CustomerOrdersView
    {
        private static readonly Sort DefaultSort = PagingParameters.CreateDefaultSort(nameof(OrderSummaryModel.PurchaseDate), SortDirection.Descending);

        private PagingParameters PagingParameters { get; set; } = PagingParameters.CreateDefault(25, DefaultSort);
        private Page<OrderSummaryModel> CurrentPage { get; set; } = Page<OrderSummaryModel>.CreateDefault();
        private PagingParameters? PreviousPagingParameters { get; set; }
        private OrderDetailModel? SelectedOrder { get; set; }

        [Parameter] public Func<PagingParameters, Task<Page<OrderSummaryModel>>> OnGetOrderPageAsync { get; set; } = new Func<PagingParameters, Task<Page<OrderSummaryModel>>>(_ => Task.FromResult(new Page<OrderSummaryModel>()));
        [Parameter] public Func<int, Task<OrderDetailModel>> OnGetOrderDetailAsync { get; set; } = new Func<int, Task<OrderDetailModel>>(_ => Task.FromResult(new OrderDetailModel()));

        private async Task FetchCurrentPageAsync()
        {
            CurrentPage = await OnGetOrderPageAsync(PagingParameters);
            PreviousPagingParameters = PagingParameters;
            StateHasChanged();
        }

        private async Task OnPage(DataGridReadDataEventArgs<OrderSummaryModel> args)
        {
            if (!args.Columns.Any())
                return;

            PagingParameters = args.CreatePagingParameters(PreviousPagingParameters ?? PagingParameters, DefaultSort);

            await FetchCurrentPageAsync();
        }

        private async Task SetSelectedOrder(OrderSummaryModel order)
        {
            await OnGetOrderDetailAsync(order.Id);
            SelectedOrder = await OnGetOrderDetailAsync(order.Id);
            StateHasChanged();
        }

        private void SelectedRowStyling(OrderSummaryModel order, DataGridRowStyling styling)
        {
            styling.Background = Background.Dark;
            styling.Style = "color:white";
        }
    }
}
