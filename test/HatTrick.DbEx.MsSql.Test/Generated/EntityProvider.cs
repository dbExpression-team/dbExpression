
namespace DbEx.dboDataService
{
    #region dbo
    public partial class dbo
    {
        #region internals
        private static dboSchemaExpression _schema = new dboSchemaExpression();
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
    }
    #endregion
}
namespace DbEx.secDataService
{
    #region sec
    public partial class sec
    {
        #region internals
        private static secSchemaExpression _schema = new secSchemaExpression();
        #endregion

        #region interface
        public static PersonEntity Person { get { return _schema.Person; } }
        #endregion

        #region constructors
        private sec()
        {

        }
        #endregion
    }
    #endregion
}