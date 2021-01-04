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
        private static readonly Sort DefaultSort = PagingParameters.CreateDefaultSort(nameof(OrderSummaryModel.PurchaseDate), SortDirection.Descending);
        private static readonly IList<int> AllowedPageSizes = new int[] { 5, 10, 25, 50, 100 };

        private PagingParameters PagingParameters { get; set; } = PagingParameters.CreateDefault(DefaultSort);
        private Page<OrderSummaryModel> CurrentPage { get; set; } = Page<OrderSummaryModel>.CreateDefault();
        private PagingParameters PreviousPagingParameters { get; set; }

        #endregion

        #region methods
        private async Task FetchCurrentPageAsync()
        {
            try
            {
                CurrentPage = await OrderService.GetOrdersPageAsync(PagingParameters);
            }
            finally
            {
                PreviousPagingParameters = PagingParameters;
                await ProgressBar.Hide();
            }

            StateHasChanged();
        }

        private async Task OnPage(DataGridReadDataEventArgs<OrderSummaryModel> args)
        {
            if (!args.Columns.Any())
                return;

            PagingParameters = args.CreatePageRequestModel(PreviousPagingParameters ?? PagingParameters, DefaultSort);

            await FetchCurrentPageAsync();
        }

        private string BuildDetailUrl(int id)
            => $"/orders/{id}?{NavigationManager.ToReturnUrl("orders", PagingParameters)}";

        public async override Task SetParametersAsync(ParameterView parameters)
        {
            if (NavigationManager.TryGetPagingParametersFromReturnUrl(out PagingParameters page))
                PagingParameters = page;
            await base.SetParametersAsync(parameters);
        }
        #endregion
    }
}
