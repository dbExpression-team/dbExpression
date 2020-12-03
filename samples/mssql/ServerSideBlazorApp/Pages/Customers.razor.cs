using Blazorise;
using Blazorise.DataGrid;
using Microsoft.AspNetCore.Components;
using ServerSideBlazorApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
        private IEnumerable<DataGridColumnInfo> Sorting { get; set; }
        #endregion

        #region interface
        [Parameter] public int PageIndex { get; set; } = 0;
        [Parameter] public int PageSize { get; set; } = 10;
        [Parameter] public string SearchPhrase { get; set; }
        [Parameter] public string SortField { get; set; } = nameof(CustomerSummaryModel.Name);
        [Parameter] public SortDirection SortDirection { get; set; } = SortDirection.Ascending;
        #endregion

        #region methods
        private async Task SetCurrentPageAsync(int pageIndex, int pageSize, IEnumerable<DataGridColumnInfo> sorting, string searchPhrase = null)
        {
            //if (PageSize == pageSize && PageIndex == pageIndex && SearchPhrase == searchPhrase && /*(sort is object && sort.Field == SortField && sort.Ascending && SortDirection == SortDirection.Ascending) &&*/ CurrentPage is object)
            //    return;

            PageSize = pageSize;
            PageIndex = pageIndex;
            SearchPhrase = searchPhrase;
            if (sorting is object)
                Sorting = sorting;

            await ProgressBar.Show();

            var model = new PageRequestModel(PageIndex * PageSize, PageSize, SearchPhrase = SearchPhrase, sorting?.Select(s => new Sort(s.Field, s.Direction == SortDirection.Ascending)));

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
            await SetCurrentPageAsync(paging.PageIndex, paging.PageSize, Sorting);
            StateHasChanged();
        }

        private async Task OnPage(DataGridReadDataEventArgs<CustomerSummaryModel> e)
        {
            var sorting = Sorting?.ToList() ?? new List<DataGridColumnInfo>();
            List<DataGridColumnInfo> updated = e.Columns.ToList();
            var @new = new DataGridColumnInfo[updated.Count + 1];
            var pageReset = false;

            foreach (var column in updated.Where(c => c.Direction != SortDirection.None))
            {
                var match = sorting?.SingleOrDefault(s => s.Field == column.Field);
                if (match is object)
                {
                    @new[column.Direction != match.Direction ? 0 : sorting.IndexOf(match) + 1] = column;
                }
                else
                {
                    @new[0] = column;
                }
                pageReset = true;
            }

            await SetCurrentPageAsync(pageReset ? 0 : e.Page - 1, e.PageSize, @new.Where(c => c is object));
        }

        private async Task OnPageSizeChanged(int pageSize)
            => await SetCurrentPageAsync(0, pageSize, Sorting);

        private async Task OnSearch(string searchPhrase)
        {
            await IsSearching.WaitAsync();
            try
            {
                if (IsSearching.CurrentCount > 1)
                    return;

                await SetCurrentPageAsync(0, PageSize, Sorting, searchPhrase);
            }
            finally
            {
                IsSearching.Release();
            }
        }

        private string BuildDetailUrl(int id)
            => $"/customers/{id}?pageIndex={PageIndex}&pageSize={PageSize}&searchPhrase={HttpUtility.UrlEncode(SearchPhrase)}";

        protected override async Task OnInitializedAsync()
            => await SetCurrentPageAsync(PageIndex, PageSize, null);

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
