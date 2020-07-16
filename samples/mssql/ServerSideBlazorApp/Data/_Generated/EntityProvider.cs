using System;

namespace ServerSideBlazorApp.dboDataService
{
    using HatTrick.DbEx.Sql;

    #region dbo
    public partial class dbo
    {
        #region internals
        private static dboSchemaExpression _schema;
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
        private dbo()
        {

        }
        #endregion

		#region methods
        public static void Initialize(ISqlSchemaMetadata metadata)
        {
            _schema = new dboSchemaExpression(new Lazy<ISqlSchemaMetadata>(() => metadata));
        }
        #endregion
    }
    #endregion
}
namespace ServerSideBlazorApp.secDataService
{
    using HatTrick.DbEx.Sql;

    #region sec
    public partial class sec
    {
        #region internals
        private static secSchemaExpression _schema;
        #endregion

        #region interface
        public static PersonEntity Person { get { return _schema.Person; } }
        #endregion

        #region constructors
        private sec()
        {

        }
        #endregion

		#region methods
        public static void Initialize(ISqlSchemaMetadata metadata)
        {
            _schema = new secSchemaExpression(new Lazy<ISqlSchemaMetadata>(() => metadata));
        }
        #endregion
    }
    #endregion
}