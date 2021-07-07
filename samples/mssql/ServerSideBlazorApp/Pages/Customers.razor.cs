using Blazorise;
using Blazorise.DataGrid;
using Microsoft.AspNetCore.Components;
using ServerSideBlazorApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using System.Threading.Tasks;
using System;

namespace ServerSideBlazorApp.Pages
{
    public partial class Customers
    {
        #region internals
        private static readonly Sort DefaultSort = PagingParameters.CreateDefaultSort(nameof(CustomerSummaryModel.Name), SortDirection.Ascending);
        private static readonly IList<int> AllowedPageSizes = new int[] { 5, 10, 25, 50, 100 };
        private readonly Timer searchTimer = new(800);

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
                CurrentPage = await CustomerService.GetSummaryPageAsync(PagingParameters, SearchPhrase);
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

        private void OnSearch(string searchPhrase)
        {
            SearchPhrase = searchPhrase;
            searchTimer.Stop();
            searchTimer.Start();
        }

        private void OnSearch(object source, ElapsedEventArgs e)
        {
            InvokeAsync(async () => await FetchCurrentPageAsync());
        }

        private string BuildDetailUrl(int id)
            => $"/customers/{id}?{NavigationManager.ToReturnUrl("customers", PagingParameters)}";

        protected override void OnInitialized()
        {
            searchTimer.Elapsed += OnSearch;
            searchTimer.AutoReset = false;
            base.OnInitialized();
        }

        public async override Task SetParametersAsync(ParameterView parameters)
        {
            if (NavigationManager.TryGetPagingParametersFromReturnUrl(out PagingParameters page))
                PagingParameters = page;
            await base.SetParametersAsync(parameters);
        }

        void IDisposable.Dispose()
        {
            searchTimer?.Dispose();
        }
        #endregion
    }
}
