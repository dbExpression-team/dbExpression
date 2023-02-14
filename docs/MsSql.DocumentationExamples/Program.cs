﻿using HatTrick.DbEx.MsSql.Configuration;
using HatTrick.DbEx.Sql;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using MsSql.DocumentationExamples;
using System.Reflection;
using DbEx.DataService;
using System.Transactions;
using HatTrick.DbEx.Sql.Connection;
using System.Text.Json;

//run all of the documentation samples
new ServiceCollection()
    .AddLogging()
    .ConfigureDbExpression()
    .DiscoverAndRegisterDocumentationExamples()
    .BuildServiceProvider()
    .UseStaticRuntimeFor<MsSqlDb>()
    .GetServices<IDocumentationExamples>()
    .ExecuteDocumentationExamples();

static class Extensions
{
    public static IServiceCollection ConfigureDbExpression(this IServiceCollection services)
    {
        var config = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                    .Build();

        //configure dbExpression
        services.AddDbExpression(dbex =>
            dbex.AddDatabase<MsSqlDb>(
                database =>
                {
                    database.ConnectionString.Use(config.GetConnectionString("MsSqlDb_Examples")!);
                    database.Conversions.ForTypes(x =>
                        x.ForEnumType<PaymentMethodType>().PersistAsString()
                         .ForEnumType<PaymentSourceType>().PersistAsString()
                         .ForEnumType<StateType>().PersistAsString()
                         .ForReferenceType<ProductDescription>().Use(
                            productDescription => productDescription is null ? null : JsonSerializer.Serialize(productDescription), //serialize to json as it goes in to the database
                            dbValue => string.IsNullOrWhiteSpace(dbValue as string) ? default : JsonSerializer.Deserialize<ProductDescription>((dbValue as string)!)) //deserialize to ProductDescription as it comes from the database
                    );
                    database.Logging.ConfigureLoggingOptions(l => l.LogParameterValues = true);
                }
            )
        );

        return services;
    }

    public static IServiceCollection AddLogging(this IServiceCollection services)
    {
        //add some console logging
        services.AddLogging(builder =>
        {
            builder.ClearProviders();
            builder.AddConsole();
            builder.SetMinimumLevel(LogLevel.Debug);
            builder.AddFilter("HatTrick.DbEx.*", level => level >= LogLevel.Debug);
        });
        return services;
    }

    public static IServiceCollection DiscoverAndRegisterDocumentationExamples(this IServiceCollection services)
    {
        //discover and register all example classes as singletons. change the where predicate if you want to run a more specific set
        foreach (var example in Assembly.GetExecutingAssembly()
                                        .GetTypes()
                                        .Where(t => t.GetInterfaces().Contains(typeof(IDocumentationExamples)))
        )
        {
            services.AddSingleton(typeof(IDocumentationExamples), example);
        }
        return services;
    }

    public static void ExecuteDocumentationExamples(this IEnumerable<IDocumentationExamples> runners)
    {
        foreach (var runner in runners)
        {
            //don't ever do this...  but it works in this case to ensure each class works with the same original data set.
            using TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew);
            try
            {
                runner.ExecuteExamples();
                throw new RollbackDocumentationExample("Reset database state please.");
            }
            catch (RollbackDocumentationExample) { }
        }
    }
}

class RollbackDocumentationExample : Exception
{
    public RollbackDocumentationExample(string message) : base(message) { }
}