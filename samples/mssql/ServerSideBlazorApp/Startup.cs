using Blazorise;
using Blazorise.Icons.Material;
using Blazorise.Material;
using HatTrick.DbEx.Sql.Expression;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ServerSideBlazorApp.Data;
using ServerSideBlazorApp.DataService;
using ServerSideBlazorApp.Service;
using System.Text.Json;

namespace ServerSideBlazorApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddHttpContextAccessor();

            //add dbExpression dependencies to the service collection.  Note in the configuration of a specific database,
            //the delegate contains the ServiceProvider, which can be used to resolve services
            services.AddDbExpression(
                dbex => {

                    dbex.AddMsSql2019Database<CRMDatabase>(
                        (serviceProvider, database) =>
                            {
                                database.ConnectionString.Use(Configuration.GetConnectionString("Default"));

                                database.Conversions.UseDefaultFactory(x =>
                                    x.OverrideForEnumType<PaymentMethodType>().PersistAsString()
                                        .OverrideForEnumType<PaymentSourceType>().PersistAsString()
                                );

                                //description for a product is stored as serialized json.  Note the clrType override in dbex.config.json that generates a property type of 'ServerSideBlazorApp.Data.ProductDescription'
                                database.Conversions.UseDefaultFactory(x =>
                                    x.OverrideForReferenceType<ProductDescription>().Use(
                                        productDescription => productDescription is null ? null : JsonSerializer.Serialize(productDescription), //serialize to json as it goes in to the database
                                        dbValue => string.IsNullOrWhiteSpace(dbValue as string) ? default : JsonSerializer.Deserialize<ProductDescription>((dbValue as string)!)) //deserialize to ProductDescription as it comes from the database
                                    );
                            },
                            lifetime: ServiceLifetime.Scoped //could easily be ommitted and the default of "Singleton" would be applied; including as an example of creating a lifetime for the database as "Scoped"
                        );
                    }
                );

            services.AddBlazorise(options =>
                {
                    options.Debounce = true;
                    options.DebounceInterval = 300;
                })
              .AddMaterialProviders()
              .AddMaterialIcons();

            services.AddScoped<CustomerService>();
            services.AddScoped<OrderService>();
            services.AddScoped<ProductService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
