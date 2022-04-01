using Microsoft.AspNetCore.Components;
using ServerSideBlazorApp.Models;

namespace ServerSideBlazorApp.Shared
{
    public partial class OrderView : ComponentBase
    {
        [Parameter] public OrderDetailModel Order { get; set; } = new();
    }
}
