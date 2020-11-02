using Microsoft.AspNetCore.Components;
using ServerSideBlazorApp.Data;
using ServerSideBlazorApp.Models;
using System.Threading.Tasks;
using System.Web;

namespace ServerSideBlazorApp.Pages
{
    public partial class Order
    {
        #region internals
        private OrderDetailModel Model { get; set; }
        #endregion

        #region interface
        [Parameter] public string Id { get; set; }
        [Parameter] public int PageIndex { get; set; } = 0;
        [Parameter] public int PageSize { get; set; } = 5;
        [Parameter] public string SearchPhrase { get; set; }
        #endregion

        #region methods
        protected override async Task OnInitializedAsync()
        {
            Model = await OrderService.GetOrderAsync(int.Parse(Id));
        }

        private string BuildOrderGridUrl()
        {
            return $"/orders?pageIndex={PageIndex}&pageSize={PageSize}&searchPhrase={HttpUtility.UrlEncode(SearchPhrase)}";
        }

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
