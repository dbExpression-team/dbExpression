using HatTrick.DbEx.Sql;
using ServerSideBlazorApp.DataService;
using ServerSideBlazorApp.dboDataService;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ServerSideBlazorApp.Pages
{
    public partial class Startup
    {
        private int successStep;

        protected override async Task OnInitializedAsync()
            => await Refresh();

        private async Task Refresh()
        {
            successStep = 0;

            if (!EvaluateCanConnect())
                return;

            successStep = 1;

            if (!await EvaluateHasSchema())
                return;

            successStep = 2;

            if (!await EvaluateHasACustomer())
                return;

            successStep = 3;

            if (await EvaluateHasAnImage())
                successStep = 4;

            if (successStep >= 3)
                NavigationManager.NavigateTo("/");
        }

        private string GetFontAwesome(int step)
            => $"fa-lg far fa-{(successStep >= step ? "check" : "times")}-circle mr-4";

        private string GetColor(int step)
            => $"color:{(successStep >= step ? "green" : "red")}";

        private bool EvaluateCanConnect()
        {
            using (var conn = db.GetConnection())
            {
                try
                {
                    conn.Open();
                }
                catch (SqlException)
                {
                    return false;
                }
            }
            return true;
        }

        private async Task<bool> EvaluateHasSchema()
        {
            try
            {
                await db.SelectOne(dbo.Customer.Id).From(dbo.Customer).ExecuteAsync();
            }
            catch (SqlException)
            {
                return false;
            }
            return true;
        }

        private async Task<bool> EvaluateHasACustomer()
            => await db.SelectOne(db.fx.Count()).From(dbo.Customer).ExecuteAsync() > 0;

        private async Task<bool> EvaluateHasAnImage()
            => await db.SelectOne(db.fx.Count()).From(dbo.Product).Where(dbo.Product.Image != DBNull.Value).ExecuteAsync() > 0;
    }
}
