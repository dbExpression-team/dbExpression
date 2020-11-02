using Microsoft.AspNetCore.Components;
using ServerSideBlazorApp.Models;
using System.Threading.Tasks;

namespace ServerSideBlazorApp.Pages
{
    public partial class Product : ComponentBase
    {
        #region internals
        private ProductDetailModel Model { get; set; }
        #endregion

        #region interface
        [Parameter] public string Id { get; set; }
        [Parameter] public int PageIndex { get; set; } = 0;
        [Parameter] public int PageSize { get; set; } = 5;
        #endregion

        #region methods
        protected override async Task OnInitializedAsync()
        {
            Model = await ProductService.GetProductAsync(int.Parse(Id));
        }

        private string BuildProductGridUrl()
        {
            return $"/products?pageIndex={PageIndex}&pageSize={PageSize}";
        }

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
