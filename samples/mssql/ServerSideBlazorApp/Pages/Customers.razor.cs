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
        private bool IsFirstLoad { get; set; } = true;
        private PageRequestModel PageRequest { get; set; } = PageRequestModel.CreateDefault();
        private PageResponseModel<CustomerSummaryModel> CurrentPage { get; set; } = PageResponseModel<CustomerSummaryModel>.CreateDefault();
        private IEnumerable<DataGridColumnInfo> PreviousSorting { get; set; } = Enumerable.Empty<DataGridColumnInfo>();
        private IList<int> AllowedPageSizes { get; } = new int[] { 5, 10, 25, 50, 100 };
        private SemaphoreSlim IsSearching { get; set; } = new SemaphoreSlim(1, 1);
        #endregion

        #region methods
        private async Task FetchCurrentPageAsync()
        {
            await ProgressBar.Show();

            try
            {
                CurrentPage = await service.GetSummaryPageAsync(PageRequest);
            }
            finally
            {
                await ProgressBar.Hide();
            }

            StateHasChanged();
        }

        private async Task OnPage(DataGridReadDataEventArgs<CustomerSummaryModel> args)
        {
            if (IsFirstLoad)
            {
                IsFirstLoad = false;
                await FetchCurrentPageAsync(); //use the defaults or parameters set via query string
                return;
            }

            PageRequest = args.BuildPageRequestModel(PreviousSorting, (args.Columns.Single(c => c.Field == nameof(CustomerSummaryModel.Name)), SortDirection.Ascending));

            //store this round trip of sorting
            PreviousSorting = args.Columns.Where(c => c.Direction != SortDirection.None);

            await FetchCurrentPageAsync();
        }

        private async Task OnSearch(string searchPhrase)
        {
            await IsSearching.WaitAsync();
            try
            {
                if (IsSearching.CurrentCount > 1)
                    return;

                PageRequest.Offset = 0;
                await FetchCurrentPageAsync();
            }
            finally
            {
                IsSearching.Release();
            }
        }

        private string BuildDetailUrl(int id)
            => $"/customers/{id}?{PageRequest.ToQueryStringParameters()}";

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
