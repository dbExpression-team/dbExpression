using MatBlazor;
using ServerSideBlazorApp.Models;
using System;
using System.Threading.Tasks;

namespace ServerSideBlazorApp.Pages
{
    public partial class Customers
    {
        private int PageIndex { get; set; } = 0;
        private int PageSize { get; set; } = 5;
        private string SearchPhrase { get; set; }
        private PageResponseModel<CustomerSummaryModel> CurrentPage { get; set; } = new PageResponseModel<CustomerSummaryModel>();

        protected override async Task OnInitializedAsync() => await FetchCurrentPage();

        private async Task FetchCurrentPage()
        {
            await ProgressBar.Show();

            var model = new PageRequestModel { Limit = PageSize, Offset = PageIndex * PageSize, SearchPhrase = SearchPhrase };

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

        private async Task OnPage(MatPaginatorPageEvent e)
        {
            PageSize = e.PageSize;
            PageIndex = e.PageIndex;
            await FetchCurrentPage();
            StateHasChanged();
        }

        private async Task OnPage(int index)
        {
            PageIndex = index;
            await FetchCurrentPage();
            StateHasChanged();
        }
    }
}
