using Microsoft.AspNetCore.Components;
using ServerSideBlazorApp.Models;
using System.Threading.Tasks;
using System.Web;

namespace ServerSideBlazorApp.Pages
{
    public partial class Order
    {
        #region internals
        private string ReturnUrl { get; set; }
        private OrderDetailModel Model { get; set; }
        #endregion

        #region interface
        [Parameter] public string Id { get; set; }
        #endregion

        #region methods
        protected override async Task OnInitializedAsync()
        {
            Model = await OrderService.GetOrderAsync(int.Parse(Id));
        }

        public async override Task SetParametersAsync(ParameterView parameters)
        {
            ReturnUrl = NavigationManager.GetReturnUrl();
            await base.SetParametersAsync(parameters);
        }
        #endregion
    }
}
