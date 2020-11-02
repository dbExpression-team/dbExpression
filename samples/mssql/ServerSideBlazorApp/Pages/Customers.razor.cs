using Blazorise;
using Blazorise.DataGrid;
using Microsoft.AspNetCore.Components;
using ServerSideBlazorApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace ServerSideBlazorApp.Pages
{
    public partial class Customers
    {
        #region internals
        private PageResponseModel<CustomerSummaryModel> CurrentPage { get; set; }
        private SemaphoreSlim IsSearching { get; set; } = new SemaphoreSlim(1, 1);
        #endregion

        #region interface
        [Parameter] public int PageIndex { get; set; } = 0;
        [Parameter] public int PageSize { get; set; } = 10;
        [Parameter] public string SearchPhrase { get; set; }
        [Parameter] public string SortField { get; set; }
        [Parameter] public SortDirection SortDirection { get; set; }
        #endregion

        #region methods
        private async Task SetCurrentPageAsync(int pageIndex, int pageSize, Sort sort, string searchPhrase)
        {
            if (PageSize == pageSize && PageIndex == pageIndex && SearchPhrase == searchPhrase && (sort is object && sort.Field == SortField && sort.Ascending && SortDirection == SortDirection.Ascending) &&  CurrentPage is object)
                return;

            PageSize = pageSize;
            PageIndex = pageIndex;
            SearchPhrase = searchPhrase;
            SortField = sort?.Field;
            SortDirection = sort is object ? (sort.Ascending ? SortDirection.Ascending : SortDirection.Descending) : SortDirection.None;

            await ProgressBar.Show();

            var model = new PageRequestModel(PageIndex * PageSize, PageSize, SearchPhrase = SearchPhrase, SortField is null ? null : new Sort(SortField, SortDirection == SortDirection.Ascending));

            try
            {
                CurrentPage = await service.GetSummaryPageAsync(model);
            }
            finally
            {
                await ProgressBar.Hide();
            }


            StateHasChanged();
        }

        private async Task OnPage((int PageIndex, int PageSize) paging)
        {
            await SetCurrentPageAsync(paging.PageIndex, paging.PageSize, new Sort(SortField, SortDirection == SortDirection.Ascending), SearchPhrase);
            StateHasChanged();
        }

        private async Task OnPage(DataGridReadDataEventArgs<CustomerSummaryModel> e)
        {
            var sort = e.Columns.FirstOrDefault(c => c.Direction != SortDirection.None);
            if (sort is object)
            {
                await OnPage(e.Page - 1, e.PageSize, new Sort(sort.Field, sort.Direction == SortDirection.Ascending));
            }
            else
            {
                await OnPage(e.Page - 1, e.PageSize, default);
            }
        }

        private async Task OnPage(int pageIndex, int pageSize, Sort sort)
            => await SetCurrentPageAsync(pageIndex, pageSize, sort, SearchPhrase);

        private async Task OnPageSizeChanged(int pageSize)
            => await SetCurrentPageAsync(0, pageSize, new Sort(SortField, SortDirection == SortDirection.Ascending), SearchPhrase);

        private async Task OnSearch(string searchPhrase)
        {
            await IsSearching.WaitAsync();
            try
            {
                if (IsSearching.CurrentCount > 1)
                    return;

                await SetCurrentPageAsync(0, PageSize, new Sort(SortField, SortDirection == SortDirection.Ascending), searchPhrase);
            }
            finally
            {
                IsSearching.Release();
            }
        }

        private bool AllowSort(string field)
            => SortField is null || SortField == field;

        private string BuildDetailUrl(int id)
            => $"/customers/{id}?pageIndex={PageIndex}&pageSize={PageSize}&searchPhrase={HttpUtility.UrlEncode(SearchPhrase)}";

        protected override async Task OnInitializedAsync()
            => await SetCurrentPageAsync(PageIndex, PageSize, null, null);

        public async override Task SetParametersAsync(ParameterView parameters)
        {
            if (NavigationManager.TryGetQueryStringParameter<int>(nameof(PageIndex), out var pageIndex))
                PageIndex = pageIndex;
            if (NavigationManager.TryGetQueryStringParameter<int>(nameof(PageSize), out var pageSize))
                PageSize = pageSize;
            if (NavigationManager.TryGetQueryStringParameter<string>(nameof(SearchPhrase), out var searchPhrase))
                SearchPhrase = searchPhrase;
            await base.SetParametersAsync(parameters);
        }
        #endregion
    }
}
