using Blazorise;
using Microsoft.AspNetCore.Components;
using ServerSideBlazorApp.Models;
using System;
using System.Threading.Tasks;

namespace ServerSideBlazorApp.Shared
{
    public partial class AddressEdit : ComponentBase
    {
        private AddressModel originalAddress;
        private Validations validations;

        private bool IsValid { get; set; } = true;

        [Parameter] public AddressModel Address { get; set; }
        [Parameter] public UIControlMode Mode { get; set; } = UIControlMode.View;
        [Parameter] public Func<AddressModel, Task<AddressModel>> OnSave { get; set; }

        public void SetMode(UIControlMode mode)
        {
            Mode = mode;
            if (mode == UIControlMode.Edit)
            {
                originalAddress = Address.Copy();
            }
            StateHasChanged();
        }

        public void ToggleMode()
        {
            if (Mode == UIControlMode.View)
            {
                originalAddress = Address.Copy();
                Mode = UIControlMode.Edit;
            }
            else
            {
                Mode = UIControlMode.View;
            }
            StateHasChanged();
        }

        public async Task Save()
        {
            if (!await validations.ValidateAll())
                return;

            Address = await OnSave(Address);
            originalAddress = null;
            Mode = UIControlMode.View;
            StateHasChanged();
        }

        public void Cancel()
        {
            validations.ClearAll();

            Address = originalAddress ?? Address;
            originalAddress = null;
            Mode = UIControlMode.View;
            StateHasChanged();
        }

        public void SetSubmitButtonState(ValidationsStatusChangedEventArgs args)
        {
            IsValid = args.Status != ValidationStatus.Error;
            StateHasChanged();
        }
    }
}
