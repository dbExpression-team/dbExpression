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
        private bool isFromReturnUrl;
        private bool ShowProgressBar { get; set; } = false;
        private Page<CustomerSummaryModel, PagingParametersWithSearch> CurrentPage { get; set; } = new Page<CustomerSummaryModel, PagingParametersWithSearch>(PagingParametersWithSearch.CreateDefault(DefaultSort), null!, 0);
        #endregion 

        #region methods
        private async Task FetchCurrentPageAsync()
        {
            ShowProgressBar = true;

            try
            {
                var page = await CustomerService.GetSummaryPageAsync(CurrentPage.PagingParameters);
                CurrentPage.Data = page.Data;
                CurrentPage.TotalCount = page.TotalCount;
            }
            finally
            {
                ShowProgressBar = false;
            }
        }

        private async Task OnPage(DataGridReadDataEventArgs<CustomerSummaryModel> args)
        {
            if (!args.Columns.Any())
                return;

            var requested = args.CreatePagingParameters(CurrentPage.PagingParameters, DefaultSort, p =>
            {
                p.SearchPhrase = CurrentPage.PagingParameters.SearchPhrase;
                if (isFromReturnUrl)
                {
                    if (p.Offset == CurrentPage.PagingParameters.Offset)
                        isFromReturnUrl = false; //offset same as from  returnUrl or is now in-sync
                    else
                        p.Offset = CurrentPage.PagingParameters.Offset;  //from returnUrl, the parameter from returnUrl should override
                }
            });
            CurrentPage.PagingParameters = requested;
            await FetchCurrentPageAsync();
        }

        private void OnSearch(string? searchPhrase)
        {
            CurrentPage.PagingParameters.SearchPhrase = searchPhrase;
            CurrentPage.Data = null!;
            searchTimer.Stop();
            searchTimer.Start();
        }

        private void OnSearch(object? source, ElapsedEventArgs e)
        {
            InvokeAsync(async () =>
            {
                CurrentPage.PagingParameters.Offset = 0;
                if (CurrentPage.PagingParameters.Offset == 0)
                {
                    CurrentPage.Data = null!;
                    await FetchCurrentPageAsync();
                    StateHasChanged();
                }
            });
        }

        private string BuildDetailUrl(int id)
        {
            var url = $"/customers/{id}?{NavigationManager.ToReturnUrl("customers", CurrentPage.PagingParameters)}";
            return url;
        }

        protected override void OnInitialized()
        {
            searchTimer.Elapsed += OnSearch;
            searchTimer.AutoReset = false;
            base.OnInitialized();
        }

        public async override Task SetParametersAsync(ParameterView parameters)
        {
            if (NavigationManager.TryGetPagingParametersFromReturnUrl(out PagingParametersWithSearch? page))
            {
                CurrentPage.PagingParameters = page!;
                isFromReturnUrl = true;
            }

            await base.SetParametersAsync(parameters);
        }

        void IDisposable.Dispose()
        {
            searchTimer?.Dispose();
        }
        #endregion
    }
}
