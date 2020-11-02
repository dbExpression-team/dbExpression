using Microsoft.AspNetCore.Components;
using ServerSideBlazorApp.Models;

namespace ServerSideBlazorApp.Shared
{
    public partial class AddressView : ComponentBase
    {
        [Parameter] public AddressModel Address { get; set; }
    }
}
