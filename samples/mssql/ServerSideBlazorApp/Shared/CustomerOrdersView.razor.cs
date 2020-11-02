using Blazorise;
using Blazorise.DataGrid;
using MatBlazor;
using Microsoft.AspNetCore.Components;
using ServerSideBlazorApp.Models;
using System;
using System.Threading.Tasks;

namespace ServerSideBlazorApp.Shared
{
    public partial class CustomerOrdersView
    {
        private int PageIndex { get; set; } = 0;
        private int PageSize { get; set; } = 5;
        private PageResponseModel<OrderSummaryModel> CurrentPage { get; set; } = new PageResponseModel<OrderSummaryModel>();
        private OrderDetailModel SelectedOrder { get; set; }

        [Parameter] public Func<PageRequestModel, Task<PageResponseModel<OrderSummaryModel>>> OnGetOrderPageAsync { get; set; }
        [Parameter] public Func<int, Task<OrderDetailModel>> OnGetOrderDetailAsync { get; set; }

        protected override async Task OnInitializedAsync()
            => await SetCurrentPageAsync();

        private async Task SetCurrentPageAsync()
        {
            CurrentPage = await OnGetOrderPageAsync(new PageRequestModel { Limit = PageSize, Offset = PageIndex * PageSize });
        }

        private async Task OnPage(MatPaginatorPageEvent e)
        {
            PageSize = e.PageSize;
            PageIndex = e.PageIndex;
            await SetCurrentPageAsync();
            StateHasChanged();
        }

        private async Task OnPage(int index)
        {
            PageIndex = index;
            await SetCurrentPageAsync();
            StateHasChanged();
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
