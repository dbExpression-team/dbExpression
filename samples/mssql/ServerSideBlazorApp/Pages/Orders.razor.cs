using Blazorise.DataGrid;
using Microsoft.AspNetCore.Components;
using ServerSideBlazorApp.Models;
using System.Threading.Tasks;

namespace ServerSideBlazorApp.Pages
{
    public partial class Orders
    {
        #region internals
        private PageResponseModel<OrderSummaryModel> CurrentPage { get; set; }
        #endregion

        #region interface
        [Parameter] public int PageIndex { get; set; } = 0;
        [Parameter] public int PageSize { get; set; } = 10;
        [Parameter] public string SearchPhrase { get; set; }
        #endregion

        #region methods
        private async Task SetCurrentPageAsync(int pageIndex, int pageSize, string searchPhrase)
        {
            if (PageSize == pageSize && PageIndex == pageIndex && SearchPhrase == searchPhrase && CurrentPage is object)
                return;

            PageSize = pageSize;
            PageIndex = pageIndex;
            SearchPhrase = searchPhrase;

            await ProgressBar.Show();

            var model = new PageRequestModel { Limit = pageSize, Offset = pageIndex * pageSize, SearchPhrase = searchPhrase };

            try
            {
                CurrentPage = await OrderService.GetOrdersPageAsync(model);
            }
            finally
            {
                await ProgressBar.Hide();
            }


            StateHasChanged();
        }

        private async Task OnPage((int PageIndex, int PageSize) paging)
        {
            await SetCurrentPageAsync(paging.PageIndex, paging.PageSize, null);
            StateHasChanged();
        }

        private async Task OnPage(DataGridReadDataEventArgs<OrderSummaryModel> e)
            => await OnPage(e.Page - 1, e.PageSize);

        private async Task OnPage(int pageIndex, int pageSize)
            => await SetCurrentPageAsync(pageIndex, pageSize, null);

        private async Task OnPageSizeChanged(int pageSize)
            => await SetCurrentPageAsync(0, pageSize, null);

        private string BuildDetailUrl(int id)
            => $"/orders/{id}?pageIndex={PageIndex}&pageSize={PageSize}";

        protected override async Task OnInitializedAsync() 
            => await SetCurrentPageAsync(PageIndex, PageSize, SearchPhrase);

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
