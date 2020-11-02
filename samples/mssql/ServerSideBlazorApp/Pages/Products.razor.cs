using Blazorise.DataGrid;
using MatBlazor;
using Microsoft.AspNetCore.Components;
using ServerSideBlazorApp.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ServerSideBlazorApp.Pages
{
    public partial class Products
    {
        #region internals
        private bool ShowLoading { get; set; } = true;
        private PageResponseModel<ProductSummaryModel> CurrentPage { get; set; }
        #endregion

        #region interface
        [Parameter] public int PageIndex { get; set; } = 0;
        [Parameter] public int PageSize { get; set; } = 10;
        #endregion

        #region methods
        private async Task SetCurrentPageAsync(int pageIndex, int pageSize)
        {
            if (PageSize == pageSize && PageIndex == pageIndex && CurrentPage is object)
                return;

            PageSize = pageSize;
            PageIndex = pageIndex;

            await ProgressBar.Show();

            var model = new PageRequestModel { Limit = pageSize, Offset = pageIndex * pageSize };

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
            await SetCurrentPageAsync(paging.PageIndex, paging.PageSize);
            StateHasChanged();
        }

        private async Task OnPage(DataGridReadDataEventArgs<ProductSummaryModel> e)
            => await OnPage(e.Page - 1, e.PageSize);

        private async Task OnPage(int pageIndex, int pageSize)
            => await SetCurrentPageAsync(pageIndex, pageSize);

        private async Task OnPageSizeChanged(int pageSize)
            => await SetCurrentPageAsync(0, pageSize);

        private string BuildDetailUrl(int id)
            => $"/products/{id}?pageIndex={PageIndex}&pageSize={PageSize}";

        protected override async Task OnInitializedAsync()
            => await SetCurrentPageAsync(PageIndex, PageSize);

        public async override Task SetParametersAsync(ParameterView parameters)
        {
            if (NavigationManager.TryGetQueryStringParameter<int>(nameof(PageIndex), out var pageIndex))
                PageIndex = pageIndex;
            if (NavigationManager.TryGetQueryStringParameter<int>(nameof(PageSize), out var pageSize))
                PageSize = pageSize;
            await base.SetParametersAsync(parameters);
        }
        #endregion
    }
}
