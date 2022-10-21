using HatTrick.DbEx.MsSql.Configuration;
using HatTrick.DbEx.Sql;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SimpleConsole.Data;
using SimpleConsole.DataService;
using System;
using System.Diagnostics;

namespace NetCoreConsoleApp
{
    class Program
	{
		#region main
		static void Main(string[] args)
        {
            Stopwatch sw = new();
            sw.Start();
            ConfigureDbEx();
            sw.Stop();
            Console.WriteLine($"Configured in {sw.ElapsedMilliseconds} milliseconds.{Environment.NewLine}");

			sw.Reset();
			sw.Start();
			RunBasicExpressions();
			sw.Stop();
			Console.WriteLine($"Basic expressions completed in {sw.ElapsedMilliseconds} milliseconds.{Environment.NewLine}");

			sw.Reset();
			sw.Start();
			RunAdvancedExpressions();
			sw.Stop();
			Console.WriteLine($"Advanced expressions completed in {sw.ElapsedMilliseconds} milliseconds.{Environment.NewLine}");

			sw.Reset();
            sw.Start();
            RunStoredProcedures();
            sw.Stop();
            Console.WriteLine($"Stored procedure expressions completed in {sw.ElapsedMilliseconds} milliseconds.{Environment.NewLine}");
#if DEBUG
            Console.WriteLine("Press [Enter] to exit");
            Console.ReadLine();
#endif
        }
		#endregion

		#region configure dbex
		static void ConfigureDbEx()
        {
            var config = new ConfigurationBuilder()
                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                        .Build();

            var services = new ServiceCollection();
            services.AddLogging(builder =>
            {
                builder.ClearProviders();
                builder.AddConsole();
                builder.SetMinimumLevel(LogLevel.Debug);
                builder.AddFilter("HatTrick.DbEx.*", level => level >= LogLevel.Debug);
            });
            services.AddDbExpression(dbex =>
            {

                dbex.AddDatabase<SimpleConsoleDb>(
                    database =>
                    {
                        database.ConnectionString.Use(config.GetConnectionString("dbex_mssql_test"));
                        database.SqlStatements.Assembly.ConfigureAssemblyOptions(x => x.PrependCommaOnSelectClause = false);
                        database.Conversions.ForTypes(x =>
                            x.ForEnumType<PaymentMethodType>().PersistAsString()
                             .ForEnumType<PaymentSourceType>().PersistAsString()
                        );
                        database.Logging.ConfigureLoggingOptions(l => l.LogParameterValues = true);
                    }
                );

            });
            var provider = services.BuildServiceProvider();
            provider.UseStaticRuntimeFor<SimpleConsoleDb>();
        }
        #endregion

        #region run basic expressions
        static void RunBasicExpressions()
        {
            var inserts = new Inserts();
            inserts.Execute();

            var selectProjection = new SelectDynamicProjections();
            selectProjection.Execute();

            var selectEntity = new SelectEntities();
            selectEntity.Execute();

            var selectScalar = new SelectScalarValues();
            selectScalar.Execute();

            var updates = new Updates();
            updates.Execute();

            var deletes = new Deletes();
            deletes.Execute();
        }
        #endregion

        #region run advanced expressions
        static void RunAdvancedExpressions()
        {
            var aliasing = new Aliasing();
            aliasing.Execute();

            var arithmetic = new Arithmetic();
            arithmetic.Execute();

            var connectionsAndTransactions = new ConnectionsAndTransactions();
            connectionsAndTransactions.Execute();

            var functions = new Functions();
            functions.Execute();

            var groupBy = new GroupByClause();
            groupBy.Execute();

            var having = new HavingClause();
            having.Execute();

            var join = new JoinClauses();
            join.Execute();

            var orderBy = new OrderByClause();
            orderBy.Execute();

            var pagination = new Pagination();
            pagination.Execute();

            var randomExamples = new RandomExamples();
            randomExamples.Execute();

            var stringConcat = new StringConcatenation();
            stringConcat.Execute();

            var subQueries = new SubQueries();
            subQueries.Execute();

            var top = new TopClause();
            top.Execute();

            var where = new WhereClause();
            where.Execute();
        }
        #endregion

        #region run stored procedures
        static void RunStoredProcedures()
        {
            StoredProcedures sprocs = new();
            sprocs.Execute();
        }
        #endregion
    }
}
