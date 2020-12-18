using Blazorise;
using Blazorise.DataGrid;
using Microsoft.AspNetCore.Components;
using ServerSideBlazorApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerSideBlazorApp.Pages
{
    public partial class Orders
    {
        #region internals
        private bool IsFirstLoad { get; set; } = true;
        private PageRequestModel PageRequest { get; set; } = PageRequestModel.CreateDefault();
        private PageResponseModel<OrderSummaryModel> CurrentPage { get; set; } = PageResponseModel<OrderSummaryModel>.CreateDefault();
        private IEnumerable<DataGridColumnInfo> PreviousSorting { get; set; } = Enumerable.Empty<DataGridColumnInfo>();
        private IList<int> AllowedPageSizes { get; } = new int[] { 5, 10, 25, 50, 100 };
        #endregion

        #region methods
        private async Task FetchCurrentPageAsync()
        {
            try
            {
                CurrentPage = await OrderService.GetOrdersPageAsync(PageRequest);
            }
            finally
            {
                await ProgressBar.Hide();
            }

            StateHasChanged();
        }

        private async Task OnPage(DataGridReadDataEventArgs<OrderSummaryModel> args)
        {
            if (IsFirstLoad)
            {
                IsFirstLoad = false;
                await FetchCurrentPageAsync(); //use the defaults or parameters set via query string
                return;
            }

            PageRequest = args.BuildPageRequestModel(PreviousSorting, (args.Columns.Single(c => c.Field == nameof(OrderSummaryModel.PurchaseDate)), SortDirection.Descending));

            //store this round trip of sorting
            PreviousSorting = args.Columns.Where(c => c.Direction != SortDirection.None);

            await FetchCurrentPageAsync();
        }

        private string BuildDetailUrl(int id)
            => $"/orders/{id}?{PageRequest.ToQueryStringParameters()}";

        public async override Task SetParametersAsync(ParameterView parameters)
        {
            if (NavigationManager.GetPagingFromQueryStringParameters(out PageRequestModel model))
            {
                PageRequest = model;
            }
            await base.SetParametersAsync(parameters);
        }
        #endregion
    }
}
