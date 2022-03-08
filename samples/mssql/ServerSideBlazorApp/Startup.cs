using Blazorise;
using Blazorise.Icons.Material;
using Blazorise.Material;
using HatTrick.DbEx.MsSql.Configuration;
using HatTrick.DbEx.Sql.Mapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ServerSideBlazorApp.Data;
using ServerSideBlazorApp.DataService;
using ServerSideBlazorApp.Service;
using System;
using System.Linq;
using System.Net.Http;
using HatTrick.DbEx.Sql.Connection;

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
                                    pd => pd is null ? null : System.Text.Json.JsonSerializer.Serialize(pd), //serialize to json as it goes in to the database
                                    o => string.IsNullOrWhiteSpace(o as string) ? default : System.Text.Json.JsonSerializer.Deserialize<ProductDescription>((o as string)!)) //deserialize to ProductDescription as it comes from the database
                                );
                        });
                    }
                );

            services.AddBlazorise(options => options.ChangeTextOnKeyPress = true)
              .AddMaterialProviders()
              .AddMaterialIcons();

            services.AddSingleton<CustomerService>();
            services.AddSingleton<OrderService>();
            services.AddSingleton<ProductService>();
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

            //UseDbExpression is required when AddDbExpression is used in ConfigureServices.  No specific order for UseDbExpression is mandated,
            //but it must occur before any code that uses dbExpression to build and execute queries.  If you have middleware that uses dbExpression,
            //ensure they are listed with their "Use<Middelware>()" equivalent AFTER UseDbExpression.
            app.UseDbExpression();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            //app.ApplicationServices
            //  .UseMaterialProviders()
            //  .UseMaterialIcons();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
