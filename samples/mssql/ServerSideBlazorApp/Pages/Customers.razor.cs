using Blazorise;
using Blazorise.DataGrid;
using Microsoft.AspNetCore.Components;
using ServerSideBlazorApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ServerSideBlazorApp.Pages
{
    public partial class Customers
    {
        #region internals
        private static readonly SemaphoreSlim isSearching = new SemaphoreSlim(1, 1);
        private static readonly Sort DefaultSort = PagingParameters.CreateDefaultSort(nameof(CustomerSummaryModel.Name), SortDirection.Ascending);
        private static readonly IList<int> AllowedPageSizes = new int[] { 5, 10, 25, 50, 100 };

        private string SearchPhrase { get; set; }
        private PagingParameters PagingParameters { get; set; } = PagingParameters.CreateDefault(DefaultSort);
        private Page<CustomerSummaryModel> CurrentPage { get; set; } = Page<CustomerSummaryModel>.CreateDefault();
        private PagingParameters PreviousPagingParameters { get; set; }
        #endregion

        #region methods
        private async Task FetchCurrentPageAsync()
        {
            await ProgressBar.Show();

            try
            {
                CurrentPage = await service.GetSummaryPageAsync(PagingParameters, SearchPhrase);
                PreviousPagingParameters = PagingParameters;
            }
            finally
            {
                await ProgressBar.Hide();
            }

            StateHasChanged();
        }

        private async Task OnPage(DataGridReadDataEventArgs<CustomerSummaryModel> args)
        {
            if (!args.Columns.Any())
                return;

            PagingParameters = args.CreatePageRequestModel(PreviousPagingParameters ?? PagingParameters, DefaultSort);

            await FetchCurrentPageAsync();
        }

        private async Task OnSearch(string searchPhrase)
        {
            if (SearchPhrase == searchPhrase)
                return;            

            await isSearching.WaitAsync();
            try
            {
                SearchPhrase = searchPhrase;
                PagingParameters.Offset = 0;
                await FetchCurrentPageAsync();
            }
            finally
            {
                isSearching.Release();
            }
        }

        private string BuildDetailUrl(int id)
            => $"/customers/{id}?{NavigationManager.ToReturnUrl("customers", PagingParameters)}";

        public async override Task SetParametersAsync(ParameterView parameters)
        {
            if (NavigationManager.TryGetPagingParametersFromReturnUrl(out PagingParameters page))
                PagingParameters = page;
            await base.SetParametersAsync(parameters);
        }
        #endregion
    }
}
