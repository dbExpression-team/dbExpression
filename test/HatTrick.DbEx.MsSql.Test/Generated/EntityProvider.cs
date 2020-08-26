
namespace DbEx.dboDataService
{
    #region dbo
#pragma warning disable CA1052 // Static holder types should be Static or NotInheritable
#pragma warning disable IDE1006 // Naming Styles
    public partial class dbo
#pragma warning restore IDE1006 // Naming Styles
#pragma warning restore CA1052 // Static holder types should be Static or NotInheritable
    {
        #region internals
        private static readonly dboSchemaExpression _schema = new dboSchemaExpression("dbo");
        #endregion

        #region interface
        public static AddressEntity Address => _schema.Address;
        public static PersonEntity Person => _schema.Person;
        public static PersonAddressEntity PersonAddress => _schema.PersonAddress;
        public static ProductEntity Product => _schema.Product;
        public static PurchaseEntity Purchase => _schema.Purchase;
        public static PurchaseLineEntity PurchaseLine => _schema.PurchaseLine;
        public static PersonTotalPurchasesViewEntity PersonTotalPurchasesView => _schema.PersonTotalPurchasesView;
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
#pragma warning disable IDE1006 // Naming Styles
    public partial class sec
#pragma warning restore IDE1006 // Naming Styles
#pragma warning restore CA1052 // Static holder types should be Static or NotInheritable
    {
        #region internals
        private static readonly secSchemaExpression _schema = new secSchemaExpression("sec");
        #endregion

        #region interface
        public static PersonEntity Person => _schema.Person;
        #endregion

        #region constructors
        private sec()
        {

        }
        #endregion
    }
    #endregion
}