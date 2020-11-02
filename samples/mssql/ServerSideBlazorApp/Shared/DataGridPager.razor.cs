using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerSideBlazorApp.Shared
{
    public partial class DataGridPager : ComponentBase
    {
        private (int, int) _current;

        private bool IsFirstPage => CurrentPage == 0;
        private bool IsCurrentPage(int pageNumber) => pageNumber == CurrentPage + 1;
        private bool IsLastPage => CurrentPage == LastPageIndex;
        private int LastPageIndex => (TotalItems / PageSize) == 0 ? 0 : (TotalItems / PageSize) - ((TotalItems % PageSize) > 0 ? 0 : 1);

        private (int First, int Last) Pages
        {
            get
            {
                if (_current != default && _current.Item1 == CurrentPage && _current.Item2 == PageSize)
                    return (_current.Item1, _current.Item2);

                int start;
                int end = LastPageIndex;
                int totalPageCount = (TotalItems / PageSize) + ((TotalItems % PageSize) > 0 ? 1 : 0);

                if (CurrentPage <= (PagingDisplayLength / 2))
                {
                    //still working our way to the "middle" of page numbers....
                    start = 1;
                }
                else if (CurrentPage > (end - PagingDisplayLength / 2))
                {
                    //nearing the last page....
                    start = end - PagingDisplayLength + 2;
                }
                else
                {
                    start = CurrentPage - (PagingDisplayLength / 2) + 1;
                }
                _current = (start, Math.Min(start + PagingDisplayLength - 1, totalPageCount));

                return _current;
            }
        }

        [Parameter] public Func<(int PageIndex, int PageSize), Task> OnPageChange { get; set; }
        [Parameter] public Func<int, Task> OnPageSizeChange { get; set; }
        [Parameter] public int PagingDisplayLength { get; set; } = 5;
        [Parameter] public int CurrentPage { get; set; }
        [Parameter] public int PageSize { get; set; }
        [Parameter] public int TotalItems { get; set; }
        [Parameter] public IEnumerable<int> AllowedPageSizes { get; set; } = new int[] { 5, 10, 25, 50, 100 };


        private async Task NavigateToPage(string pageIndex) => await OnPageChange((int.Parse(pageIndex), PageSize));
        private async Task NavigateToFirstPage() => await OnPageChange((0, PageSize));
        private async Task NavigateToPreviousPage() => await OnPageChange((CurrentPage -1, PageSize));
        private async Task NavigateToNextPage() => await OnPageChange((CurrentPage + 1, PageSize));
        private async Task NavigateToLastPage() => await OnPageChange((LastPageIndex, PageSize));
        private async Task ChangePageSize(int pageSize) => await OnPageSizeChange(pageSize);
    }
}
