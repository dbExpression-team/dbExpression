using System;

namespace ServerSideBlazorApp.dboDataService
{
    using HatTrick.DbEx.Sql;
    using HatTrick.DbEx.Sql.Configuration;

    #region dbo
    public static partial class dbo
    {
        #region internals
        private static volatile dboSchemaExpression _schema;
        #endregion

        #region interface
        public static AddressEntity Address { get { return _schema.Address; } }
        public static PersonEntity Person { get { return _schema.Person; } }
        public static PersonAddressEntity PersonAddress { get { return _schema.PersonAddress; } }
        public static ProductEntity Product { get { return _schema.Product; } }
        public static PurchaseEntity Purchase { get { return _schema.Purchase; } }
        public static PurchaseLineEntity PurchaseLine { get { return _schema.PurchaseLine; } }
        public static PersonTotalPurchasesViewEntity PersonTotalPurchasesView { get { return _schema.PersonTotalPurchasesView; } }
        #endregion

		#region constructors
        static dbo()
        {
            _schema = new dboSchemaExpression(new Lazy<ISqlSchemaMetadata>(() =>
                {
                    if (!DbExpression.Configuration.Databases.TryGetValue("ServerSideBlazorApp", out var config))
                        throw new DbExpressionConfigurationException($"Metadata for source reference key 'ServerSideBlazorApp' has not been provided.");

                    var schema = config?.Metadata?.Schemas;
                    if (schema == null)
                        throw new DbExpressionConfigurationException($"Configured metadata does not contain schema for 'dbo'");

                    schema.TryGetValue("dbo", out ISqlSchemaMetadata schemaMetadata);
                    if (schemaMetadata == null)
                        throw new DbExpressionConfigurationException($"Configured metadata does not contain schema for 'dbo'");

                    return schemaMetadata;
                }));
        }
        #endregion
    }
    #endregion
}
namespace ServerSideBlazorApp.secDataService
{
    using HatTrick.DbEx.Sql;
    using HatTrick.DbEx.Sql.Configuration;

    #region sec
    public static partial class sec
    {
        #region internals
        private static volatile secSchemaExpression _schema;
        #endregion

        #region interface
        public static PersonEntity Person { get { return _schema.Person; } }
        #endregion

		#region constructors
        static sec()
        {
            _schema = new secSchemaExpression(new Lazy<ISqlSchemaMetadata>(() =>
                {
                    if (!DbExpression.Configuration.Databases.TryGetValue("ServerSideBlazorApp", out var config))
                        throw new DbExpressionConfigurationException($"Metadata for source reference key 'ServerSideBlazorApp' has not been provided.");

                    var schema = config?.Metadata?.Schemas;
                    if (schema == null)
                        throw new DbExpressionConfigurationException($"Configured metadata does not contain schema for 'sec'");

                    schema.TryGetValue("sec", out ISqlSchemaMetadata schemaMetadata);
                    if (schemaMetadata == null)
                        throw new DbExpressionConfigurationException($"Configured metadata does not contain schema for 'sec'");

                    return schemaMetadata;
                }));
        }
        #endregion
    }
    #endregion
}