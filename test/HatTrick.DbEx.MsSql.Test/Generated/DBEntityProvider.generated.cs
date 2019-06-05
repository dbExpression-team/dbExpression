
namespace DataService
{
    using DataService.EntityExpression.dbo;
    using HatTrick.DbEx.Sql;
    using HatTrick.DbEx.Sql.Configuration;

    #region dbo
    public static partial class dbo
    {
        #region internals
        private static volatile dboSchema _schema;
        #endregion

        #region interface
        public static AddressEntity Address { get { return _schema.Address; } }
        public static PersonEntity Person { get { return _schema.Person; } }
        public static Person_AddressEntity Person_Address { get { return _schema.Person_Address; } }
        public static ProductEntity Product { get { return _schema.Product; } }
        public static PurchaseEntity Purchase { get { return _schema.Purchase; } }
        public static PurchaseLineEntity PurchaseLine { get { return _schema.PurchaseLine; } }
        public static PersonTotalPurchasesViewEntity PersonTotalPurchasesView { get { return _schema.PersonTotalPurchasesView; } }
        #endregion

        #region constructors
        static dbo()
        {
            if (!DbExpression.Configuration.Databases.TryGetValue("MsSqlDbExTest-design", out var config))
                throw new DbExpressionConfigurationException($"Metadata for database named 'MsSqlDbExTest' has not been provided.");
            var schema = config?.DatabaseConfiguration?.Metadata?.Schemas;
            if (schema == null)
                throw new DbExpressionConfigurationException($"Configured metadata does not contain schema for '{nameof(dbo)}'");
            schema.TryGetValue(nameof(dbo), out ISqlSchemaMetadata schemaMetadata);
            if (schemaMetadata == null)
                throw new DbExpressionConfigurationException($"Configured metadata does not contain schema for '{nameof(dbo)}'");
            _schema = new dboSchema(schemaMetadata);
        }
        #endregion

        internal static void Initialize(ISqlSchemaMetadata schemaMetadata)
        {
            if (schemaMetadata == null)
                throw new DbExpressionConfigurationException($"Configured metadata does not contain schema for '{nameof(sec)}'");
            _schema = new dboSchema(schemaMetadata);
        }
    }
    #endregion
}

namespace DataService
{
    using DataService.EntityExpression.sec;
    using HatTrick.DbEx.Sql;
    using HatTrick.DbEx.Sql.Configuration;

    #region sec
    public static partial class sec
    {
        #region internals
        private static volatile secSchema _schema;
        #endregion

        #region interface
        public static PersonEntity Person { get { return _schema.Person; } }
        #endregion

        #region constructors
        static sec()
        {
            if (!DbExpression.Configuration.Databases.TryGetValue("MsSqlDbExTest-design", out var config))
                throw new DbExpressionConfigurationException($"Metadata for database named 'MsSqlDbExTest' has not been provided.");
            var schema = config?.DatabaseConfiguration?.Metadata?.Schemas;
            if (schema == null)
                throw new DbExpressionConfigurationException($"Configured metadata does not contain schema for '{nameof(sec)}'");
            schema.TryGetValue(nameof(sec), out ISqlSchemaMetadata schemaMetadata);
            if (schemaMetadata == null)
                throw new DbExpressionConfigurationException($"Configured metadata does not contain schema for '{nameof(sec)}'");
            _schema = new secSchema(schemaMetadata);
        }
        #endregion

        #region methods
        public static void Initialize(ISqlSchemaMetadata schemaMetadata)
        {
            if (schemaMetadata == null)
                throw new DbExpressionConfigurationException($"Configured metadata does not contain schema for '{nameof(sec)}'");
            _schema = new secSchema(schemaMetadata);
        }
        #endregion
    }
    #endregion
}
