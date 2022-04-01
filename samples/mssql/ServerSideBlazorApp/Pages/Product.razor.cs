using Microsoft.AspNetCore.Components;
using ServerSideBlazorApp.Models;
using System.Threading.Tasks;

namespace ServerSideBlazorApp.Pages
{
    public partial class Product : ComponentBase
    {
        #region internals
        private string? ReturnUrl { get; set; }
        private ProductDetailModel? Model { get; set; }
        #endregion

        #region interface
        [Parameter] public string Id { get; set; } = string.Empty;
        #endregion

        #region methods
        protected override async Task OnInitializedAsync()
        {
            Model = await ProductService.GetProductDetailAsync(int.Parse(Id));
        }

        public async override Task SetParametersAsync(ParameterView parameters)
        {
            ReturnUrl = NavigationManager.GetReturnUrl();
            await base.SetParametersAsync(parameters);
        }
        #endregion
    }
}
