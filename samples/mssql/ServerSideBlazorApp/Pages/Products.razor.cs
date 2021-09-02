using Blazorise;
using Blazorise.DataGrid;
using Microsoft.AspNetCore.Components;
using ServerSideBlazorApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerSideBlazorApp.Pages
{
    public partial class Products
    {
        #region internals
        private static readonly Sort DefaultSort = PagingParameters.CreateDefaultSort(nameof(ProductSummaryModel.Name), SortDirection.Ascending);
        private static readonly IList<int> AllowedPageSizes = new int[] { 5, 10, 25, 50, 100 };

        private bool ShowProgressBar { get; set; } = false;
        private PagingParameters PagingParameters { get; set; } = PagingParameters.CreateDefault(DefaultSort);
        private Page<ProductSummaryModel> CurrentPage { get; set; } = Page<ProductSummaryModel>.CreateDefault();
        private PagingParameters PreviousPagingParameters { get; set; }
        #endregion

        #region methods
        private async Task FetchCurrentPageAsync()
        {
            ShowProgressBar = true;

            try
            {
                CurrentPage = await service.GetSummaryPageAsync(PagingParameters);
            }
            finally
            {
                PreviousPagingParameters = PagingParameters;
                ShowProgressBar = false;
            }

            StateHasChanged();
        }

        private async Task OnPage(DataGridReadDataEventArgs<ProductSummaryModel> args)
        {
            if (!args.Columns.Any())
                return;

            PagingParameters = args.CreatePagingParameters(PreviousPagingParameters ?? PagingParameters, DefaultSort);

            await FetchCurrentPageAsync();
        }

        private string BuildDetailUrl(int id)
            => $"/products/{id}?{NavigationManager.ToReturnUrl("products", PagingParameters)}";

        public async override Task SetParametersAsync(ParameterView parameters)
        {
            if (NavigationManager.TryGetPagingParametersFromReturnUrl(out PagingParameters page))
                PagingParameters = page;
            await base.SetParametersAsync(parameters);
        }
        #endregion
    }
}
