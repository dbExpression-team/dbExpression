
namespace DbEx.dboDataService
{
    #region dbo
#pragma warning disable CA1052 // Static holder types should be Static or NotInheritable
    public partial class dbo
#pragma warning restore CA1052 // Static holder types should be Static or NotInheritable
    {
        #region internals
        private static dboSchemaExpression _schema = new dboSchemaExpression("MsSqlDbExTest.dbo");
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
#pragma warning disable CA1052 // Static holder types should be Static or NotInheritable
    public partial class sec
#pragma warning restore CA1052 // Static holder types should be Static or NotInheritable
    {
        #region internals
        private static secSchemaExpression _schema = new secSchemaExpression("MsSqlDbExTest.sec");
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